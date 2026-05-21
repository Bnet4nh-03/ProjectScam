import { Client } from '@stomp/stompjs';
import { eventBus } from '@/plugin/eventBus';

const CHANNEL_NAME = 'atv-admin-messaging-channel';
const LEADER_ELECTION_TIMEOUT = 150; // ms

class MessagingService {
    constructor() {
        this.stompClient = null;
        this.subscriptions = new Map();
        this.userTopic = null;

        // Multi-tab state
        this.channel = new BroadcastChannel(CHANNEL_NAME);
        this.isLeader = false;
        this.leaderCheckTimeout = null;
        this.userId = null;
        this.password = null; // Be cautious with storing passwords

        this.channel.onmessage = this.handleChannelMessage.bind(this);
        window.addEventListener('beforeunload', this.handleBeforeUnload.bind(this));
    }

    handleBeforeUnload() {
        if (this.isLeader) {
            this.channel.postMessage({ type: 'LEADER_CLOSING' });
        }
    }

    handleChannelMessage(event) {
        const { type, payload } = event.data;

        switch (type) {
            case 'REQUEST_LEADER_STATUS':
                if (this.isLeader) {
                    this.channel.postMessage({ type: 'LEADER_STATUS_RESPONSE', payload: { leaderId: this.userId } });
                }
                break;

            case 'LEADER_STATUS_RESPONSE':
                // Another tab is the leader, we are a follower.
                console.log(`Follower: Leader found (ID: ${payload.leaderId}). Halting connection.`);
                clearTimeout(this.leaderCheckTimeout);
                break;

            case 'NEW_MESSAGE_FROM_LEADER':
                // A message broadcasted by the leader.
                // **CRUCIAL CHECK:** Only followers should process this.
                if (!this.isLeader) {
                    console.log('%cFollower: Received broadcasted message from leader', 'color: orange;', payload);
                    eventBus.emit('new-message', payload);
                }
                break;

            case 'LEADER_CLOSING':
                // The leader is closing, let's elect a new one
                console.log('Follower: Leader is closing. Initiating re-election.');
                if (!this.isLeader) {
                    this.electLeader();
                }
                break;
        }
    }

    electLeader() {
        clearTimeout(this.leaderCheckTimeout);
        this.leaderCheckTimeout = setTimeout(() => {
            console.log('Leader Election: No leader responded. Becoming the new leader.');
            this.isLeader = true;
            this.startStompConnection();
        }, LEADER_ELECTION_TIMEOUT);

        console.log('Leader Election: Requesting leader status...');
        this.channel.postMessage({ type: 'REQUEST_LEADER_STATUS' });
    }

    connect(userId, password) {
        if (this.stompClient && this.stompClient.active) {
            console.log('Already connected or in the process of connecting.');
            return;
        }
        this.userId = "admin";
        this.password = "admin"; // Be cautious
        this.userTopic = `/topic/user.${userId}`;

        this.electLeader();
    }

    startStompConnection() {
        if (!this.isLeader) {
            console.error("Followers cannot start STOMP connection.");
            return;
        }
        console.log("Leader: Starting STOMP connection...");

        const WEBSOCKET_URL = 'ws://localhost:61614/ws'; // Replace with your ActiveMQ WebSocket URL

        this.stompClient = new Client({
            brokerURL: WEBSOCKET_URL,
            connectHeaders: {
                login: this.userId,
                passcode: this.password,
                'client-id': `atv-admin-user-${this.userId}` // Crucial for durable subscription // định danh để khi kích hoạt Durable Subscription thì biết gửi tin nhắn cho ai
            },
            reconnectDelay: 5000,
            heartbeatIncoming: 4000,
            heartbeatOutgoing: 4000,
            onConnect: (frame) => {
                console.log('Leader: Connected to ActiveMQ:', frame);
                this.subscribeToUserTopic();
            },
            onStompError: (frame) => {
                console.error('Leader: Broker reported error: ' + frame.headers['message']);
                console.error('Leader: Additional details: ' + frame.body);
            },
        });

        this.stompClient.activate();
    }

    subscribeToUserTopic() {
        if (!this.isLeader || !this.stompClient || !this.stompClient.connected) {
            console.error('Only the leader can subscribe, and must be connected.');
            return;
        }

        const subscriptionHeaders = {
            'id': `user-subscription-${this.userTopic}`,
            'durable': 'true',
            'auto-delete': 'false'
        };

        const subscription = this.stompClient.subscribe(this.userTopic, (message) => {
            console.log(`%cLeader: Message received from STOMP topic ${this.userTopic}`, 'color: green; font-weight: bold;');

            let payload;
            try {
                // Attempt to parse the message body as JSON
                const parsedBody = JSON.parse(message.body);
                payload = { topic: this.userTopic, body: parsedBody };
            } catch (e) {
                // If parsing fails, treat the body as a simple string
                console.warn("Leader: Message body is not valid JSON. Treating as plain text.");
                payload = { topic: this.userTopic, body: { content: message.body } };
            }

            // --- NEW, MORE EXPLICIT LOGIC ---

            // 1. The Leader processes the message for its own UI immediately.
            console.log('Leader: Processing message for self via eventBus.');
            eventBus.emit('new-message', payload);

            // 2. The Leader broadcasts the message to all other tabs (followers).
            console.log('%cLeader: Broadcasting message to other tabs via BroadcastChannel...', 'color: blue;');
            this.channel.postMessage({ type: 'NEW_MESSAGE_FROM_LEADER', payload: payload });

        }, subscriptionHeaders);

        this.subscriptions.set(this.userTopic, subscription);
        console.log(`Leader: Created durable subscription for ${this.userTopic}`);
    }


    disconnect() {
        // This will be called on logout
        if (this.isLeader && this.stompClient) {
            this.stompClient.deactivate();
            console.log('Leader: Disconnected from ActiveMQ. Durable subscription remains.');
        }
        // Reset state regardless of being leader or not
        this.stompClient = null;
        this.isLeader = false;
        this.subscriptions.clear();
        this.userId = null;
        this.password = null;
        console.log('Messaging service state has been reset.');
    }
}

export default new MessagingService();

