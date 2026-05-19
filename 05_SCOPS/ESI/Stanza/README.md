# SCOPS ESI Stanza

## Tổng quan

Thư mục `05_SCOPS/ESI/Stanza` chứa các tập tin Tcl của SCOPS được thiết kế cho môi trường Linux/VA. Các tệp chính:
- `scops3_1M_Linux.tcl`
- `scops3_2_S_VA_Linux.tcl`
- `scops3_3_S_APL.tcl`

Những tệp này là script giao diện và xử lý nghiệp vụ cho SCOPS, bao gồm tìm lot, đọc dữ liệu host, xử lý lỗi test, và gọi backend để lấy dữ liệu từ database hoặc dịch vụ SCOPS.

## Mục tiêu chính của folder

- triển khai giao diện người dùng và logic cho SCOPS trên nền Tcl/Tk,
- hỗ trợ tìm lot, chọn lot, hiển thị thông tin lot, và quản lý trạng thái test,
- gửi các truy vấn theo định dạng SCOPS tới server/host để lấy dữ liệu từ DB,
- tích hợp với hệ thống kiểm tra wafer, RFIDs và các trạng thái tester.

## Kiến trúc chung của script

Các file Stanza đều được cấu trúc theo hai phần chính:

1. thư viện và các macro cơ bản (VTCL library procedures + custom helper functions),
2. các procedure do người dùng định nghĩa (user-defined procedures) xử lý nghiệp vụ cụ thể.

### Cấu trúc chương trình

- `main`: procedure chính khởi tạo môi trường, đọc cấu hình, load thư viện, set-up giao diện và bắt đầu vòng lặp.
- `FUNC_SEND_QRY`: procedure trung tâm gửi truy vấn tới server SCOPS và nhận kết quả trả về.
- `BTN_SEARCH_LOT`, `FUNC_SELECT_LOT_LISTBOX`, `FUNC_GET_LOTINFORMATION`, `FUNC_GET_HOSTSTATUS`, `FUNC_SET_STATUS`, `BTN_START_LOT`, `BTN_END_LOT`: các bước hành động chính khi người dùng tương tác.
- Nhiều procedure phụ trợ khác xử lý dữ liệu, chọn mô tả, kiểm tra socket/RFID, quản lý flags, vẽ chart và cập nhật trạng thái hệ thống.

## Luồng hoạt động tổng thể

### 1. Khởi tạo

Khi gọi `main`:
- xác định `g_rootdir`, hostname và hệ điều hành,
- gọi `FUNC_SET_DELIMITER`, `FUNC_INITIALIZE_VARIABLE`, `FUNC_INITIALIZE_FLAG`,
- thiết lập `g_scopsserver` và các server IP cần thiết,
- đọc cấu hình qua `FUNC_GET_CONFIG "FILE"` và `FUNC_GET_CONFIG "DB"`,
- load thư viện Tcl/Tk và các hàm mở rộng,
- gọi `FUNC_GET_DESCRIPTION`, `FUNC_UPDATE_OS`, `FUNC_UPDATE_ID`, `FUNC_UPDATE_SCOPSVERSION`,
- vào loop xử lý chính qua `FUNC_EXECUTE_LOOP`, và lấy trạng thái host ban đầu qua `FUNC_GET_HOSTSTATUS`.

### 2. Tìm lot và lựa chọn lot

- Người dùng nhập tên lot vào giao diện.
- `BTN_SEARCH_LOT` xây dựng truy vấn:
  - `SCOPS,SearchLot,$g_hostname,$g_lotname*`
- Gọi `FUNC_SEND_QRY $qry` để gửi dữ liệu tới server SCOPS.
- Nếu trả về kết quả, parse theo delimiters (`g_cd`, `g_rd`) để lấy `lotname`, `dcc`, `operation`.
- Lưu thông tin vào mảng `g_lotarray` và hiển thị vào listbox.
- Khi người dùng chọn một dòng trong listbox, `FUNC_SELECT_LOT_LISTBOX` sẽ:
  - lấy `g_lotname`, `g_dcc`, `g_operation`,
  - gọi `FUNC_GET_LOTINFORMATION` để nạp thông tin chi tiết của lot.

### 3. Lấy thông tin mô tả

- `FUNC_GET_DESCRIPTION` gửi query `SCOPS,GETDESCRIPTION,MAIN,*`
- Kết quả trả về chứa danh sách mô tả chính và được lưu vào `g_maindescriptionarray`.
- Các combo box hiển thị danh sách này để người dùng chọn lý do lỗi, thêm retest, hành động...

### 4. Lấy trạng thái máy/host

- `FUNC_GET_HOSTSTATUS` gửi query:
  - `SCOPS,GetHostStatus,$g_hostname*`
- Trả về một chuỗi mã hóa, parse theo delimiter và gán vào các biến:
  - `g_hoststatus`, `g_lotname`, `g_dcc`, `g_operation`, `g_job`,
  - `g_devicename`, `g_customer`, `g_testprogram`, `g_condition`, `g_yieldlimit`,...
- Nếu host đang ở trạng thái test (mã 101/102/103/104), script cập nhật dữ liệu hiển thị và thông tin lot.

## Các thao tác gọi backend / stored procedure

Trong Stanza, gọi backend không phải là gọi SQL trực tiếp, mà là gửi một chuỗi lệnh tới SCOPS host và nhận dữ liệu trả về.

Các dạng truy vấn tiêu biểu:
- `SCOPS,SearchLot,<hostname>,<lotname>*`
- `SCOPS,GETDESCRIPTION,MAIN,*`
- `SCOPS,GETDESCRIPTION,SUB,<main_desc_id>,*`
- `SCOPS,GETDESCRIPTION,ACTION,<main_desc_id>,<sub_desc_id>*`
- `SCOPS,GetHostStatus,<hostname>*`
- `SCOPS,CALLSP2,CheckVACustomer,<hostname>*`

Trong đó phần `CALLSP2` thường tương ứng với việc gọi một stored procedure backend để kiểm tra dữ liệu khách hàng hoặc trạng thái QA.

### `FUNC_SEND_QRY` là điểm quan trọng nhất

- Hàm này gửi query đến server/máy chủ SCOPS,
- nhận kết quả chuỗi trả về,
- trả về kết quả raw để các procedure khác parse thành dữ liệu.

Nó hoạt động như một layer trung gian giữa giao diện Tcl và server backend.

## Các phần chính trong `scops3_2_S_VA_Linux.tcl`

### `BTN_SEARCH_LOT`
- Kiểm tra điều kiện đầu vào của tên lot,
- chuyển thành uppercase,
- gọi server để tìm lot,
- parse kết quả và lưu vào listbox.

### `FUNC_SELECT_LOT_LISTBOX`
- Lấy thông tin lot được chọn từ listbox,
- gọi `FUNC_GET_LOTINFORMATION` để lấy toàn bộ dữ liệu phụ thuộc lot.

### `FUNC_GET_DESCRIPTION`
- Lấy danh sách mô tả chính (`MAIN`) từ server,
- xây dựng danh sách combo box cho người dùng chọn.

### `FUNC_SELECT_MAINDSC_COMBOBOX` và `FUNC_SELECT_SUBDSC_COMBOBOX`
- Khi chọn mô tả chính, hệ thống tải tiếp danh sách nguyên nhân phụ và hành động tương ứng.
- Phần này điều khiển logic VA và xử lý riêng cho khách hàng kỹ thuật.

### `FUNC_GET_HOSTSTATUS`
- Kiểm tra trạng thái tester hiện tại,
- nếu máy đang chạy test, cập nhật dữ liệu lot và test hiện tại,
- hỗ trợ refresh UI hiện tại khi hệ thống đang chạy.

## Những biến global quan trọng

Script sử dụng nhiều biến global để duy trì trạng thái:
- `g_hostname`: tên máy hiện tại,
- `g_scopsserver`: địa chỉ server SCOPS,
- `g_lotname`, `g_dcc`, `g_operation`, `g_job`: thông tin lot và job,
- `g_operatorid`, `g_operatorid_sub`: mã operator,
- `g_hoststatus`: trạng thái hiện tại của tester,
- `g_maindescriptionarray`, `g_subdescriptionarray`: dữ liệu list mô tả,
- `g_rfid_flag`, `g_traylot_flag`, `g_reellot_flag`: các flag điều khiển luồng.

## Flow hoạt động chi tiết

1. Người dùng mở script và `main` chạy.
2. `main` chuẩn bị môi trường: config, hostname, delimiter, tiếng, thư viện và status.
3. Người dùng gõ tên lot và nhấn tìm.
4. `BTN_SEARCH_LOT` gửi query tới backend, lấy danh sách lot hợp lệ.
5. Người dùng chọn 1 lot từ listbox.
6. `FUNC_SELECT_LOT_LISTBOX` lấy thông tin lot và gọi `FUNC_GET_LOTINFORMATION` để nạp chi tiết.
7. Người dùng có thể chọn lý do, mô tả, hành động, hoặc bắt đầu / kết thúc lot.
8. Các trạng thái máy và dữ liệu test được refresh bằng `FUNC_GET_HOSTSTATUS` và các hàm cập nhật khác.

## Lưu ý khi sử dụng

- Các tệp Tcl này phụ thuộc vào server SCOPS nội bộ và định dạng trả về đặc thù.
- Mặc định `g_scopsserver` được set thành `10.201.16.50`.
- Truy vấn tới backend sử dụng delimiter tách `g_cd` và `g_rd`.
- Nếu không có kết quả, script hiện message box báo lỗi và xóa danh sách lot.
- Một số server test được gán cứng thành `test` trong `main` để chạy môi trường thử nghiệm.

## Các phần cần mở rộng / kiểm tra tiếp

- `FUNC_GET_LOTINFORMATION`: lấy chi tiết lot sau khi chọn lot,
- `FUNC_SET_STATUS`: cập nhật trạng thái xử lý,
- `BTN_START_LOT`, `BTN_END_LOT`: bắt đầu/kết thúc lot,
- `FUNC_EXECUTE_LOOP`: vòng sự kiện chính của ứng dụng,
- `FUNC_CREATE_SOCKET`, `FUNC_RFID_*`: tích hợp RFID và socket.

## Kết luận

Thư mục `Stanza` chứa các script Tcl giao tiếp với SCOPS server theo cú pháp query chuyên dụng. Các stored procedure backend được gọi gián tiếp qua `FUNC_SEND_QRY` với chuỗi command như `SCOPS,CALLSP2,CheckVACustomer,...`. Luồng chính là: khởi tạo -> tìm lot -> chọn lot -> tải chi tiết -> cập nhật trạng thái.
