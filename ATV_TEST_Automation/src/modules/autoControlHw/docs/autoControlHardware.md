# Auto Control Hardware - Tester Summary Dashboard

## 1. Tổng quan
Module **Tester Summary** cung cấp cái nhìn toàn diện và thời gian thực (Real-time) về cấu hình phần cứng của các máy Tester trong nhà máy. Hệ thống tự động đối soát dữ liệu quét được từ RFID với Ma trận tương thích (Compatibility Matrix) đã đăng ký để đưa ra các cảnh báo trực quan cho người vận hành và PM.

## 2. Tính năng chính
- **Giám sát Real-time**: Hiển thị phần cứng (TB, CK, MP) hiện tại đang cắm trên máy thông qua dữ liệu RFID.
- **Đối soát tự động**: Tự động nhận diện Package đang chạy và kiểm tra tính hợp lệ so với đăng ký.
- **Ma trận tham chiếu**: Hiển thị đầy đủ danh sách linh kiện được phép sử dụng cho từng Device/Package.
- **Bộ lọc Cascading**: Lọc dữ liệu theo phân cấp: Customer -> Device -> Package -> Tester.
- **Giao diện trực quan**: Sử dụng màu sắc và nhãn trạng thái để tối ưu hóa việc ra quyết định.

## 3. Ý nghĩa các trạng thái (Legend)
Hệ thống sử dụng 5 trạng thái cốt lõi để báo cáo năng lực sản xuất:

| Trạng thái | Màu sắc | Hiển thị | Ý nghĩa |
| :--- | :--- | :--- | :--- |
| **Matching** | Xanh dương | Mã phần cứng | Phần cứng đang cắm khớp hoàn toàn với Ma trận và đúng với Package mục tiêu. |
| **Ready** | Xanh lá | **READY** | Máy hiện đang trống (không có linh kiện) nhưng **Sẵn sàng** để chạy Package đang chọn. |
| **Busy** | Vàng | Mã phần cứng | Phần cứng đang cắm hợp lệ nhưng thuộc về một Package khác (không nằm trong filter). |
| **Illegal** | Đỏ | Mã phần cứng | **Cảnh báo!** Phần cứng đang cắm không khớp với Ma trận hoặc lắp sai vị trí. |
| **Unsupported** | Trắng | `---` | Máy không hỗ trợ (không được đăng ký) để chạy Package/Device này trong Ma trận. |

## 4. Quy trình xử lý dữ liệu (Technical Logic)

### 4.1. Tầng Database (SQL Store)
- **Nguồn RFID**: Truy vấn trực tiếp từ `CIMitar_Data.dbo.RFIDInfo` để lấy bản ghi mới nhất cho từng Hostname.
- **Parsing**: Tự động bóc tách chuỗi RFID hỗn hợp thành các mã riêng biệt cho Test Board (TB), Change Kit (CK), và Manual Picker (MP).
- **Mapping**: Sử dụng logic `COALESCE` để xác định Package Name:
    - Ưu tiên 1: Khớp bộ linh kiện thực tế với Ma trận.
    - Ưu tiên 2: Lấy Package đã đăng ký cho máy (Reference) nếu lắp sai.

### 4.2. Tầng Frontend (Vue.js)
- **Transform Logic**:
    - Nếu máy trống (`N/A`): Kiểm tra `isCompatibleWithPackage` để gán nhãn **READY** hoặc **UNSUPPORTED**.
    - Nếu có phần cứng: So sánh mã linh kiện thực tế (`activeHw`) với mã đăng ký (`matrixHw`) để xác định tính hợp lệ.
- **UI Components**:
    - **PrimeVue FloatLabel & MultiSelect**: Đồng bộ style hệ thống, bo góc `rounded-md`.
    - **Sticky Header**: Cố định tiêu đề cột (Tester Name) và cột thông số (Parameter) khi cuộn bảng lớn.
    - **Vertical Text**: Tối ưu hóa không gian hiển thị tên Package ở cột bên trái.

## 5. Cấu trúc Ma trận tham chiếu (Reference Matrix)
Phần phía dưới bảng (Registered Compatibility Matrix) hiển thị dữ liệu đăng ký tĩnh:
- **Dấu `---` trên nền kẻ sọc**: Biểu thị ô không được hỗ trợ.
- **Mã phần cứng trên nền trắng**: Biểu thị linh kiện bắt buộc phải sử dụng theo đăng ký.

## 6. Lưu ý cho người vận hành
1. Luôn nhấn **Search** sau khi thay đổi bộ lọc để cập nhật dữ liệu mới nhất.
2. Khi thấy trạng thái **Illegal (Đỏ)**, cần kiểm tra lại phần cứng thực tế trên máy ngay lập tức trước khi bắt đầu Lot.
3. Trạng thái **Ready (Xanh lá)** là cơ sở để PM điều phối hàng về máy trống một cách tối ưu nhất.
