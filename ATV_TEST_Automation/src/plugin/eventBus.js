import mitt from 'mitt';

const emitter = mitt();

// You can still attach other global properties to it if needed
emitter.toast = null;

export const eventBus = emitter;
