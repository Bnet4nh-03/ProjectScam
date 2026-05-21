import axios from 'axios';

// Tạo instance của axios với các cấu hình mặc định
const apiClient = axios.create({
    baseURL: import.meta.env.VITE_API_BASE_URL, // Đặt base URL cho API của bạn
    headers: {
        'Content-Type': 'application/json',
    },
    timeout: 120000, // Thời gian timeout cho request (30 giây)
});

// Xử lý các request chung (ví dụ như thêm token vào header nếu cần)
apiClient.interceptors.request.use(
    (config) => {
        // Nếu bạn có token, thêm vào header
        const token = localStorage.getItem('token');
        if (token) {
            config.headers['Authorization'] = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

// Xử lý các phản hồi từ server
apiClient.interceptors.response.use(
    (response) => {
        return response.data; // Trả về data trong response

    },
    (error) => {
        var response = {
            header: {
                userId: "",
                accessToken: "",
                role: "",
                message: error.code + ": " + error.message,
                code: 1
            },
            body: ""
        }
        return response;
        // if (error.response && error.response.status === 401) {
        //     // Ví dụ: xử lý khi bị lỗi 401 (unauthorized)
        //     console.log('Unauthorized');
        // }
        // return Promise.reject(error);
    }
);

// Tạo các method API đơn giản (GET, POST, PUT, DELETE)
export const apiService = {
    get(endpoint, params = {}) {
        return apiClient.get(endpoint, { params });
    },
    post(endpoint, data) {
        return apiClient.post(endpoint, data);
    },
    put(endpoint, data) {
        return apiClient.put(endpoint, data);
    },
    delete(endpoint, params = {}) {
        return apiClient.delete(endpoint, { params });
    },
};
