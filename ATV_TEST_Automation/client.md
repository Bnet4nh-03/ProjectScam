# Kiến trúc Front-end - Dự án Checksheet Client

Tài liệu này tổng hợp kiến trúc và các quy tắc đã thống nhất cho dự án front-end Vue.js. Mục tiêu là xây dựng một client mạnh mẽ, có tổ chức cho hệ thống Checksheet API (.NET).

## 1. Nguyên tắc cốt lõi

1.  **Kiến trúc Module:** Toàn bộ logic nghiệp vụ của ứng dụng được chia thành các module độc lập nằm trong `src/modules`. Mỗi module đại diện cho một miền nghiệp vụ lớn (ví dụ: `core`, `safety`, `admin`).
2.  **Tách biệt mối quan tâm (Separation of Concerns):**
    *   **Logic nghiệp vụ** được đóng gói trong `modules`.
    *   **Các thành phần hỗ trợ toàn cục** (bố cục, tiện ích, plugin) được đặt ở thư mục `src` gốc để thể hiện vai trò chung của chúng.
3.  **Tính nhất quán:** Cấu trúc bên trong mỗi module (pages, components, services) và các quy ước đặt tên được áp dụng nhất quán trong toàn bộ dự án.

## 2. Cấu trúc thư mục chi tiết

```
C:/Users/701387/.../CheckSheetClient/
├── .env.development       // Biến môi trường cho development (VD: API URL)
├── .env.production        // Biến môi trường cho production
├── package.json           // Quản lý các gói phụ thuộc
├── vite.config.mjs        // Cấu hình Vite
│
└── src/
    ├── assets/              // Chứa tài sản tĩnh: global CSS, fonts, images
    │
    ├── components/
    │   └── base/            // Chứa các component UI chung, tái sử dụng, không có logic nghiệp vụ (BaseButton, BaseModal)
    │
    ├── layout/              // Chứa bố cục chính của ứng dụng (AppLayout, AppTopbar, AppMenu)
    │
    ├── plugin/              // Cấu hình các plugin của bên thứ ba (Highcharts, i18n, FontAwesome)
    │
    ├── router/
    │   └── index.js         // Router gốc, chịu trách nhiệm tổng hợp router từ các module
    │
    ├── utils/               // Chứa các tiện ích toàn cục
    │   ├── func.js          // <-- Nơi đặt các HÀM dùng chung
    │   └── variable.js      // <-- Nơi đặt các BIẾN HẰNG SỐ chung
    │
    ├── modules/             // <-- Nơi chứa TOÀN BỘ logic nghiệp vụ của ứng dụng
    │   │
    │   ├── core/            // Module chứa các chức năng lõi, dùng chung cho các module khác
    │   │   ├── pages/         // Các trang core (Login, NotFound, AccessDenied)
    │   │   ├── services/      // Các service lõi (AuthService, BaseService)
    │   │   ├── stores/        // Các store lõi (useAuthStore)
    │   │   └── router.js      // Định nghĩa route cho module core
    │   │
    │   ├── admin/           // Module quản lý các tính năng quản trị cho Checksheet
    │   │   ├── pages/         // (UserManagement, RoleManagement)
    │   │   ├── components/
    │   │   ├── services/
    │   │   └── router.js
    │   │
    │   ├── safety/          // Module quản lý các tính năng chính của Checksheet
    │   │   ├── pages/         // (DeviceList, Checksheet)
    │   │   ├── components/'''
    │   │   ├── services/'''
    │   │   ├── constants.js   // Hằng số nghiệp vụ riêng của module safety (VD: CHECK_STATUS)
    │   │   └── router.js
    │   │
    │   └── oldSource/       // Module chứa code cũ để tham khảo
    │       ├── pages/
    │       ├── components/
    │       ├── services/
    │       └── router.js
    │
    ├── App.vue              // Component gốc của ứng dụng
    └── main.js              // Điểm bắt đầu của ứng dụng, nơi khởi tạo Vue và các plugin
```

## 3. Quy tắc đặt để mã nguồn

*   **Hàm dùng chung:** Đặt tại `src/utils/func.js`. Đây là các hàm tiện ích có thể được sử dụng ở bất kỳ đâu.
*   **Hằng số (Constants):**
    *   **Toàn cục:** Đặt tại `src/utils/variable.js`.
    *   **Theo nghiệp vụ:** Đặt trong tệp `constants.js` bên trong module tương ứng (ví dụ: `src/modules/safety/constants.js`).
    *   **Cấu hình môi trường:** Đặt trong các tệp `.env` ở thư mục gốc.
*   **Components:**
    *   **UI thuần túy, tái sử dụng cao:** Đặt tại `src/components/base/`.
    *   **Gắn với một trang cụ thể:** Đặt trong thư mục `components/` của module chứa trang đó.
*   **Pages (Views):** Là các component chính, được gắn với route, đặt trong thư mục `pages/` của từng module.
*   **Stores (Pinia):** Store nào phục vụ cho nghiệp vụ của module nào thì đặt trong thư mục `stores/` của module đó. Store lõi (`useAuthStore`) sẽ nằm trong `modules/core/stores`.

## 4. Quy tắc phát triển

*   **Ghi lại thay đổi:** Mỗi khi thay đổi hoặc thêm code, hãy ghi lại chi tiết các thay đổi đó vào tài liệu này hoặc các tài liệu liên quan.
*   **Kiểm tra lỗi cú pháp:** Mỗi khi thay đổi hoặc thêm code, chỉ cần ưu tiên sửa các lỗi cú pháp (syntax errors). Các cảnh báo ở mức 'info' từ linter có thể tạm thời bỏ qua và không cần sửa ngay.

## 5. Lịch sử thay đổi trong phiên làm việc

### 2025-08-19 - Cập nhật logic đăng nhập và phân quyền

**Mục tiêu:** Đảm bảo người dùng được chuyển hướng đến màn hình có quyền truy cập sau khi đăng nhập và cải thiện cơ chế phân quyền dựa trên `userConfig` từ API.

**Các thay đổi chính:**

*   **`src/modules/core/stores/useAuthStore.js`**:
    *   **Cập nhật action `login`**: Thay đổi logic chuyển hướng sau đăng nhập. Thay vì luôn chuyển hướng đến `/`, giờ đây sẽ tìm kiếm route đầu tiên mà người dùng có quyền truy cập.
    *   **Thêm hàm `findFirstAccessibleRoute(routes)`**: Hàm đệ quy này duyệt qua danh sách các route và các route con để tìm route đầu tiên mà người dùng có quyền truy cập (dựa trên `requiresAuth` và `requiredPermissions`).
    *   **Thêm hàm `checkRouteAccess(route)`**: Hàm trợ giúp kiểm tra quyền truy cập của một route cụ thể dựa trên trạng thái xác thực và quyền hạn của người dùng.
    *   **Sửa đổi hàm `HasPermission(requiredPermissions)`**: Đổi tên tham số từ `permission` thành `requiredPermissions` để rõ ràng hơn. Thêm kiểm tra nếu `requiredPermissions` rỗng hoặc không có, hàm sẽ trả về `true`. Logic kiểm tra quyền vẫn giữ nguyên (người dùng có bất kỳ quyền nào trong `requiredPermissions` thì được phép).

*   **`src/modules/admin/router.js`**:
    *   **Đổi tên `meta.permissions` thành `meta.requiredPermissions`**: Để làm rõ mục đích của thuộc tính này trong định nghĩa route.
    *   **Cập nhật `requiredPermissions`**:
        *   `User Management`: `['F_D_ASSY1_V']` (ví dụ).
        *   `Role Management`: `['F_D_ASSY2_V']` (ví dụ).

*   **`src/router/index.js`**:
    *   **Cập nhật `router.beforeEach`**: Thay đổi điều kiện kiểm tra quyền từ `to.meta.permissions` sang `to.meta.requiredPermissions` để phù hợp với tên mới.

*   **`src/modules/core/router.js`**:
    *   **Thêm route gốc (`/`)**: Định nghĩa một route cho path `/` trỏ đến `AppLayout` và có một route con là `Dashboard.vue` (`@/modules/oldSource/pages/Dashboard.vue`) với `meta: { requiresAuth: true }`. Điều này đảm bảo có một trang mặc định để chuyển hướng sau khi đăng nhập.

*   **Các thay đổi tạm thời để gỡ lỗi (đã hoàn nguyên)**:
    *   `src/layout/AppLayout.vue`: Đã thêm và sau đó xóa dòng `<h1>Test Render</h1>`.
    *   `src/modules/oldSource/pages/Dashboard.vue`: Đã comment và sau đó bỏ comment các widget con.