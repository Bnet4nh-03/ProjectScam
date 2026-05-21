# Đặc tả Backend API - Hệ thống Checksheet (Kiến trúc Layered)

## 1. Tổng quan

Tài liệu này mô tả kiến trúc và các API cho project backend, được xây dựng bằng C# trên nền tảng .NET 8. API này sẽ đóng vai trò là server trung tâm, cung cấp dữ liệu và xử lý logic nghiệp vụ cho ứng dụng di động Flutter Checksheet.

API sẽ chịu trách nhiệm:
- Xác thực người dùng.
- Cung cấp dữ liệu master (Danh sách bộ phận, nhà máy, loại thiết bị...).
- Quản lý và truy vấn thông tin thiết bị.
- Cung cấp các checklist động dựa trên loại thiết bị.
- Tiếp nhận và lưu trữ kết quả kiểm tra từ ứng dụng di động.
- Tổng hợp dữ liệu để hiển thị trên các màn hình dashboard và báo cáo.

## 2. Kiến trúc dự án (Modular Architecture)

Dự án được tổ chức theo **Kiến trúc Module (Modular Architecture)**. Cách tiếp cận này chia nhỏ ứng dụng thành các khối chức năng độc lập gọi là **module**. Mỗi module quản lý một nghiệp vụ cụ thể (ví dụ: `Core`, `HRGA`, `Safety`), giúp tăng tính tái sử dụng, dễ bảo trì và cho phép các nhóm phát triển song song.

- **`Modules/`**: Thư mục gốc chứa tất cả các module nghiệp vụ.
    - **`Core/`**: Module chứa các chức năng cốt lõi, dùng chung như xác thực (`Auth`), quản lý nhân viên (`Employee`).
    - **`HRGA/`**: Module quản lý các nghiệp vụ Nhân sự - Hành chính.
    - **`Safety/`**: Module quản lý các nghiệp vụ liên quan đến An toàn.
- **Cấu trúc bên trong mỗi Module (ví dụ `Modules/Safety/`)**:
    - **`Controllers/`**: Chứa các API Controller chỉ thuộc về module `Safety`.
    - **`Services/`**: Chứa các lớp service xử lý logic nghiệp vụ cho `Safety`.
    - **`Repositories/`**: Chứa các lớp repository truy cập dữ liệu cho `Safety`.
    - **`DTOs/`**: Chứa các đối tượng truyền dữ liệu (Data Transfer Objects) của riêng `Safety`.
- **`Infrastructure/`**: Chứa các thành phần hỗ trợ dùng chung cho toàn bộ dự án (ví dụ: `DbConnectionFactory`, `Log`,...).
- **`Interfaces/`**: Chứa các "hợp đồng" (contracts) cho các service và repository. Cấu trúc thư mục con bên trong `Interfaces` cũng được chia theo module (`Interfaces/Safety`, `Interfaces/HRGA`) để giữ sự nhất quán.

**Luồng xử lý của một yêu cầu:**
`Client Request` -> `Controller (trong Module)` -> `Service (trong Module)` -> `Repository (trong Module)` -> `Database`

## 3. Luồng công việc để thêm một tính năng mới

Để xây dựng một nhóm API mới (ví dụ: `DevicesController` trong module `Safety`), hãy thực hiện theo các bước sau:

1.  **Xác định hoặc tạo Module**: Chọn module phù hợp (ví dụ: `Modules/Safety/`). Nếu là một nghiệp vụ hoàn toàn mới, hãy tạo một thư mục module mới.
2.  **Tạo DTOs**: Trong thư mục `DTOs` của module (ví dụ: `Modules/Safety/DTOs/`), tạo các lớp C# cần thiết (`DeviceDetailDto.cs`).
3.  **Định nghĩa Interfaces**:
    - Trong `Interfaces/`, tạo thư mục con cho module nếu chưa có (ví dụ: `Interfaces/Safety/`).
    - Tạo interface cho service (`IDevicesService.cs`) và repository (`IDevicesRepository.cs`) trong đó.
4.  **Triển khai Repository**: Trong thư mục `Repositories` của module (ví dụ: `Modules/Safety/Repositories/`), tạo lớp triển khai interface repository.
5.  **Triển khai Service**: Trong thư mục `Services` của module (ví dụ: `Modules/Safety/Services/`), tạo lớp triển khai interface service.
6.  **Tạo Controller**: Trong thư mục `Controllers` của module (ví dụ: `Modules/Safety/Controllers/`), tạo API controller.
7.  **Đăng ký Dependencies**: Trong `Program.cs` hoặc `Infrastructure/ServiceRegistration.cs`, đăng ký các interface và lớp triển khai mới để Dependency Injection hoạt động.

## 4. Định nghĩa API Endpoints (Sử dụng POST và BaseRequest/BaseResponse)

Tất cả các API endpoint sẽ sử dụng phương thức `POST` và tuân thủ cấu trúc `BaseRequest` cho request body và `BaseResponse` cho response body. Dữ liệu cụ thể của từng request/response sẽ nằm trong thuộc tính `body` của `BaseRequest`/`BaseResponse`.

---

### 4.1. AuthController (`/api/auth`)

| Method | Endpoint      | Mô tả                                       | Request Body                                   | Response Body                                  |
|--------|---------------|---------------------------------------------|------------------------------------------------|------------------------------------------------|
| `POST` | `/login`      | Xác thực người dùng, trả về JWT.            | `BaseRequest { body: LoginRequest { Username, Password, SiteName } }` | `BaseResponse { body: LoginResponse { Token, UserDto } }` |
| `POST` | `/logout`     | (Tùy chọn) Hủy token phía server.           | `BaseRequest { body: {} }`                     | `BaseResponse { body: 204 No Content }`        |

### 4.2. MasterDataController (`/api/master-data`)

| Method | Endpoint         | Mô tả                               | Request Body                                   | Response Body                                  |
|--------|------------------|-------------------------------------|------------------------------------------------|------------------------------------------------|
| `POST` | `/get-sites`     | Lấy danh sách các site hoạt động.   | `BaseRequest { body: {} }`                     | `BaseResponse { body: List<SiteDto> }`         |
| `POST` | `/get-departments`| Lấy danh sách bộ phận theo site.    | `BaseRequest { body: GetDepartmentsPayload { SiteId } }` | `BaseResponse { body: List<DepartmentDto> }`   |
| `POST` | `/get-buildings` | Lấy danh sách tòa nhà theo site.    | `BaseRequest { body: GetBuildingsPayload { SiteId } }` | `BaseResponse { body: List<BuildingDto> }`     |
| `POST` | `/get-floors`    | Lấy danh sách tầng theo tòa nhà.    | `BaseRequest { body: GetFloorsPayload { BuildingId } }` | `BaseResponse { body: List<FloorDto> }`        |
| `POST` | `/get-device-types`| Lấy danh sách các loại thiết bị.    | `BaseRequest { body: {} }`                     | `BaseResponse { body: List<DeviceTypeDto> }`   |

### 4.3. DevicesController (`/api/devices`)

| Method | Endpoint             | Mô tả                                           | Request Body                                   | Response Body                                  |
|--------|----------------------|-------------------------------------------------|------------------------------------------------|------------------------------------------------|
| `POST` | `/get-devices`       | Lấy danh sách thiết bị có phân trang và lọc.    | `BaseRequest { body: GetDevicesPayload { Page, PageSize, DepartmentId, DeviceTypeId, BuildingId, FloorId, SearchQuery } }` | `BaseResponse { body: PagedList<DeviceSummaryDto> }` |
| `POST` | `/get-device-detail` | Lấy thông tin chi tiết của một thiết bị.        | `BaseRequest { body: GetDeviceDetailPayload { DeviceId } }` | `BaseResponse { body: DeviceDetailDto }`       |
| `POST` | `/get-device-history`| Lấy lịch sử kiểm tra của một thiết bị.          | `BaseRequest { body: GetDeviceHistoryPayload { DeviceId, Page, PageSize } }` | `BaseResponse { body: PagedList<CheckResultSummaryDto> }` |

### 4.4. ChecklistsController (`/api/checklists`)

| Method | Endpoint                      | Mô tả                                                | Request Body                               | Response Body                                  |
|--------|-------------------------------|------------------------------------------------------|--------------------------------------------|------------------------------------------------|
| `POST` | `/GetTemplate`                | Lấy mẫu checklist cho một loại thiết bị.              | `BaseRequest { body: GetChecklistTemplatePayload { DeviceTypeId } }` | `BaseResponse { body: ChecklistTemplateDto }`  |
| `POST` | `/SubmitResults`              | Nộp kết quả của một lần kiểm tra.                    | `BaseRequest { body: CreateCheckResultPayload { ... } }` | `BaseResponse { body: CheckResultDto }`        |
| `POST` | `/GetResultDetail`            | Lấy chi tiết một kết quả kiểm tra đã nộp.            | `BaseRequest { body: GetCheckResultDetailPayload { CheckResultId } }` | `BaseResponse { body: CheckResultDetailDto }`  |
| `POST` | `/UpdateResult`               | Cập nhật một kết quả kiểm tra (nếu được phép).       | `BaseRequest { body: UpdateCheckResultPayload { ... } }` | `BaseResponse { body: CheckResultDto }`        |
| `POST` | `/UploadImage`                | Tải lên hình ảnh cho một mục NG.                     | `BaseRequest { body: UploadImagePayload { Base64Image, FileName, MimeType } }` | `BaseResponse { body: ImagePathResponse { Path } }` |

### 4.5. SummaryController (`/api/summary`)

| Method | Endpoint                   | Mô tả                                                              | Request Body                                   | Response Body                                  |
|--------|----------------------------|--------------------------------------------------------------------|------------------------------------------------|------------------------------------------------|
| `POST` | `/get-device-type-status`  | Lấy thống kê (Tổng, OK, NG, Cần KT) theo từng loại thiết bị.       | `BaseRequest { body: GetDeviceTypeStatusPayload { DepartmentId } }` | `BaseResponse { body: List<DeviceTypeSummaryDto> }` |
| `POST` | `/get-completion-trend`    | Lấy dữ liệu xu hướng hoàn thành checklist (ví dụ: 6 tháng gần nhất). | `BaseRequest { body: GetCompletionTrendPayload { DepartmentId } }` | `BaseResponse { body: List<MonthlyTrendPointDto> }` |
| `POST` | `/get-status-trend`        | Lấy dữ liệu xu hướng trạng thái (OK/NG/NeedCheck) theo tháng.      | `BaseRequest { body: GetStatusTrendPayload { DepartmentId } }` | `BaseResponse { body: List<MonthlyStatusTrendDto> }` |
| `POST` | `/get-ng-hotspots`         | Lấy danh sách các "điểm nóng" có nhiều thiết bị NG.                | `BaseRequest { body: GetNGHotspotsPayload { DepartmentId } }` | `BaseResponse { body: List<NGHotspotDto> }`   |

## 5. Các Gói NuGet cần thiết

- `Swashbuckle.AspNetCore`: Tự động tạo tài liệu Swagger/OpenAPI.
- `Microsoft.AspNetCore.Authentication.JwtBearer`: Hỗ trợ xác thực JWT.
- `Dapper`: Micro-ORM để thực thi các câu lệnh SQL.
- `Microsoft.Data.SqlClient`: Driver để kết nối với SQL Server.
- `MySql.Data`: (Tùy chọn) Driver để kết nối với MySQL nếu cần.

## 6. Cấu hình (`appsettings.json`)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=ATV_CHECK_SHEET;User Id=your_user;Password=your_password;Trusted_Connection=False;Encrypt=True;"
  },
  "Jwt": {
    "Key": "your_super_secret_key_that_is_long_enough",
    "Issuer": "ChecksheetApi",
    "Audience": "ChecksheetApp"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

---

## 7. Quy tắc làm việc và Lịch sử thay đổi

### Quy tắc làm việc

1.  **Kiểm tra code (Linting/Syntax Check)**: Sau khi thêm hoặc chỉnh sửa code, cần thực hiện kiểm tra để đảm bảo không có lỗi cú pháp (syntax error). Các cảnh báo (warning) hoặc thông tin (info) từ linter có thể tạm thời bỏ qua để tập trung vào các lỗi nghiêm trọng.
2.  **Ghi Lịch sử thay đổi (Changelog)**: Tất cả các thay đổi về cấu trúc, thêm tính năng, hoặc sửa lỗi quan trọng sẽ được ghi lại ở mục "Lịch sử thay đổi" bên dưới. Mỗi mục ghi cần có ngày và mô tả ngắn gọn về thay đổi.

### Lịch sử thay đổi (Changelog)

-   **2025-08-15**: Cập nhật tài liệu `backend.md` để phản ánh **Kiến trúc Module (Modular Architecture)** thay cho kiến trúc Layered ban đầu. Định nghĩa lại luồng công việc phát triển tính năng mới theo module.
-   **2025-08-15**: Hoàn thành triển khai API `GetTemplate` trong `ChecklistsController` của module `Safety`. API này sử dụng phương thức `POST` và tuân thủ cấu trúc `BaseRequest`/`BaseResponse` của dự án. Đã sửa lỗi cú pháp và build thành công.
-   **2025-08-15**: Hoàn thành triển khai các API CRUD (`AddSite`, `UpdateSite`, `DeleteSite`, `GetAllSites`, `GetSiteById`) cho bảng `Sites` trong `MasterDataManagementController` của module `Core`. Các API này sử dụng phương thức `POST` và tuân thủ cấu trúc `BaseRequest`/`BaseResponse`.
-   **2025-08-15**: Hoàn thành triển khai các API CRUD (`AddDepartment`, `UpdateDepartment`, `DeleteDepartment`, `GetAllDepartments`, `GetDepartmentById`, `GetDepartmentsBySiteId`) cho bảng `Departments` trong `MasterDataManagementController` của module `Core`. Các API này sử dụng phương thức `POST` và tuân thủ cấu trúc `BaseRequest`/`BaseResponse`.
-   **2025-08-15**: Hoàn thành triển khai các API CRUD (`AddBuilding`, `UpdateBuilding`, `DeleteBuilding`, `GetAllBuildings`, `GetBuildingById`, `GetBuildingsBySiteId`) cho bảng `Buildings` trong `MasterDataManagementController` của module `Core`. Các API này sử dụng phương thức `POST` và tuân thủ cấu trúc `BaseRequest`/`BaseResponse`.
-	**2025-08-15**: Hoàn thành triển khai các API CRUD (`AddFloor`, `UpdateFloor`, `DeleteFloor`, `GetAllFloors`, `GetFloorById`, `GetFloorsByBuildingId`) cho bảng `Floors` trong `MasterDataManagementController` của module `Core`. Các API này sử dụng phương thức `POST` và tuân thủ cấu trúc `BaseRequest`/`BaseResponse`.
-	**2025-08-15**: Hoàn thành triển khai các API CRUD (`AddUser`, `UpdateUser`, `DeleteUser`, `GetAllUsers`, `GetUserById`) cho bảng `Users` trong `MasterDataManagementController` của module `Core`. Các API này sử dụng phương thức `POST` và tuân thủ cấu trúc `BaseRequest`/`BaseResponse`.
-	**2025-08-15**: Hoàn thành triển khai các API CRUD (`AddDeviceType`, `UpdateDeviceType`, `DeleteDeviceType`, `GetAllDeviceTypes`, `GetDeviceTypeById`) cho bảng `DeviceTypes` trong `MasterDataManagementController` của module `Core`. Các API này sử dụng phương thức `POST` và tuân thủ cấu trúc `BaseRequest`/`BaseResponse`.
-	**2025-08-15**: Hoàn thành triển khai các API CRUD (`AddDevice`, `UpdateDevice`, `DeleteDevice`, `GetAllDevices`, `GetDeviceById`) cho bảng `Devices` trong `MasterDataManagementController` của module `Core`. Các API này sử dụng phương thức `POST` và tuân thủ cấu trúc `BaseRequest`/`BaseResponse`.