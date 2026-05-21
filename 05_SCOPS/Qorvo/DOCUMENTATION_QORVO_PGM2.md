# SCOPS 3 QORVO PGM2 - Tài Liệu Chi Tiết

## Phần 1: TỔNG QUAN

### Thông Tin Cơ Bản
- **Tên File:** scops3_8_3_QORVO_PGM2.tcl
- **Loại Ứng Dụng:** GUI Tcl/Tk
- **Phiên Bản SCOPS:** 8_3_QORVO_PGM2
- **Server:** 10.201.16.50
- **Platform Hỗ Trợ:** Windows, Linux
- **Công Nghệ:** Tcl/Tk, BWidget, Tix

### Mục Đích Chính
Ứng dụng SCOPS (System for Chip Operation and Production Settings) dùng để:
- Quản lý và kiểm soát các lot sản phẩm
- Thực hiện các hoạt động test chương trình (Program Test)
- Quản lý RFID và theo dõi thiết bị
- Xử lý dữ liệu kiểm tra (TPA, SWR, Temperature)
- Ghi nhận kết quả test và retest
- Liên hệ với SCOPS server để lấy/gửi thông tin

---

## Phần 2: CẤU TRÚC NÚT (NODES/WIDGETS)

### 2.1 GIAO DIỆN CHÍNH (Main Window: .top83)

#### **Tab 1: LOT SEARCH & SELECTION**
| Nút/Widget | Tên Biến | Nhiệm Vụ | Trạng Thái |
|-----------|----------|---------|-----------|
| Search Lot Button | `BTN_SEARCH_LOT` | Tìm kiếm lot theo tên nhập vào | Normal |
| Lot Name Input | `g_ent_lotname` | Nhập tên lot cần tìm | Entry |
| Lot Listbox | `g_lst_lotname` | Hiển thị danh sách lot tìm được | Scrolled Listbox |
| Lot Info Display | Multiple Label | Hiển thị: DCC, Operation, Job | Display |
| Clear Button | `FUNC_CLEAR_LOT` | Xóa toàn bộ thông tin lot | Normal |

**Luồng Hoạt Động:**
1. Người dùng nhập tên lot → Click "Search Lot"
2. System gửi query: `SCOPS,SearchLot,{hostname},{lotname}*`
3. Server trả về danh sách lot matching
4. Hiển thị trong Listbox
5. Người dùng chọn lot từ Listbox
6. Load thông tin lot: DCC, Operation, Job

---

#### **Tab 2: JOB & DESCRIPTION SELECTION**
| Nút/Widget | Tên Biến | Nhiệm Vụ | Trạng Thái |
|-----------|----------|---------|-----------|
| Main Description | `g_cbo_maindsc` | Combobox chọn mô tả chính | Combobox |
| Sub Description | `g_cbo_subdsc` | Combobox chọn mô tả phụ | Combobox |
| Job Selection | `g_lst_job` | Listbox chọn job | Scrolled Listbox |
| Job Info | `g_lbl_job_xxx` | Hiển thị thông tin job | Label |

**Nhiệm Vụ:**
- Lấy danh sách description từ server
- Cho phép người dùng chọn main description → update sub description
- Hiển thị danh sách job cho description đã chọn
- Lưu job được chọn vào `g_job`

---

#### **Tab 3: TEST EXECUTION**
| Nút/Widget | Tên Biến | Nhiệm Vụ | Trạng Thái |
|-----------|----------|---------|-----------|
| Operator ID | `g_ent_operatorid` | Nhập ID người vận hành | Entry |
| Start Lot Button | `BTN_START_LOT` | Bắt đầu lot test | Button |
| Set Down Button | `BTN_SET_DOWN` | Đặt thiết bị xuống | Button |
| Status Display | `g_lbl_status` | Hiển thị trạng thái hiện tại | Label |
| Host Status | `g_lbl_hoststatus` | Hiển thị trạng thái host | Label |

**Nhiệm Vụ:**
- Nhập Operator ID → Enable nút Start
- Click Start → Xác thực thông tin, gửi query bắt đầu
- Theo dõi status của lot
- Hiển thị message lỗi nếu có

---

#### **Tab 4: RFID & DEVICE MANAGEMENT**
| Nút/Widget | Tên Biến | Nhiệm Vụ | Trạng Thái |
|-----------|----------|---------|-----------|
| Search RFID | `BTN_SEARCH_RFID` | Tìm kiếm RFID tag | Button |
| RFID Result | `g_txt_rfid` | Hiển thị kết quả RFID | Text Widget |
| Device Name | `g_ent_devicename` | Nhập tên thiết bị | Entry |
| Probe Check | `FUNC_RFID_CHECK_PROBETOUCHDOWN` | Kiểm tra probe touchdown | Function |
| Socket Check | `FUNC_RFID_CHECK_SOCKETTOUCHDOWN` | Kiểm tra socket touchdown | Function |

**Nhiệm Vụ:**
- Đọc RFID tag từ thiết bị
- So sánh RFID với lot info
- Kiểm tra probe touchdown status
- Kiểm tra socket touchdown status
- Cập nhật socket/probe touch count

---

#### **Tab 5: TEST RESULT INPUT**
| Nút/Widget | Tên Biến | Nhiệm Vụ | Trạng Thái |
|-----------|----------|---------|-----------|
| Comment Entry | `g_ent_comment` | Nhập ghi chú | Entry |
| TPA Result | `g_ent_tpa` | Nhập giá trị TPA | Entry |
| Temperature | `g_ent_temperature` | Nhập nhiệt độ | Entry |
| SWR Number | `g_ent_swrnumber` | Nhập SWR number | Entry |
| Input Result Btn | `BTN_INPUT_TESTRESULT` | Gửi kết quả test | Button |

**Nhiệm Vụ:**
- Kiểm tra giá trị nhập vào
- Validate SWR number format
- Validate TPA range
- Gửi dữ liệu kết quả lên server
- Cập nhật status

---

#### **Tab 6: LOT COMPLETION**
| Nút/Widget | Tên Biến | Nhiệm Vụ | Trạng Thái |
|-----------|----------|---------|-----------|
| Add Retest Btn | `BTN_ADD_RETEST` | Thêm lot vào danh sách retest | Button |
| End Lot Button | `BTN_END_LOT` | Kết thúc lot | Button |
| Downtime Entry | `g_ent_downtime` | Nhập thời gian downtime | Entry |
| Log Display | `g_txt_log` | Hiển thị log hoạt động | Text Widget |

**Nhiệm Vụ:**
- Confirm thông tin lot trước kết thúc
- Gửi query kết thúc lot
- Ghi nhận downtime
- Xóa dữ liệu lot khỏi memory
- Hiển thị log chi tiết

---

#### **Tab 7-8: APL & DEBUG**
| Nút/Widget | Tên Biến | Nhiệm Vụ | Trạng Thái |
|-----------|----------|---------|-----------|
| APL Windows | `FUNC_APL_WINDOWS` | Gọi APL trên Windows | Function |
| APL T2000 | `FUNC_APL_T2000` | Gọi APL T2000 tester | Function |
| APL Xilinx | `FUNC_APL_XILINX` | Gọi APL Xilinx | Function |
| APL Microchip | `FUNC_APL_MICROCHIP` | Gọi APL Microchip | Function |
| APL T5585 | `FUNC_APL_T5585` | Gọi APL T5585 tester | Function |
| APL EVE_SLT | `FUNC_APL_EVE_SLT` | Gọi APL EVE SLT | Function |
| APL EVE_UFLEX | `FUNC_APL_EVE_UFLEX` | Gọi APL EVE UFLEX | Function |
| Debug Clear | `FUNC_DEBUG_CLEAR` | Xóa debug log | Function |
| Debug Save | `FUNC_DEBUG_SAVE` | Lưu debug log | Function |
| Debug Send | `FUNC_DEBUG_SENDFILE` | Gửi debug file | Function |

---

### 2.2 CỬ SỴ SECONDARY WINDOWS

#### **Window Confirmation (.top86)**
| Nút/Widget | Tên Biến | Nhiệm Vụ |
|-----------|----------|---------|
| OK Button | Button | Xác nhận hành động |
| Cancel Button | Button | Hủy bỏ hành động |
| Message Label | Label | Hiển thị thông báo |

**Cách Tắt:** Click X hoặc Cancel → Call `FUNC_CLOSE_CONFIRMATION`

#### **Window RFID Reader (.top85)**
| Nút/Widget | Tên Biến | Nhiệm Vụ |
|-----------|----------|---------|
| RFID Result | `g_txt_rfid_result` | Hiển thị tag RFID đọc được |
| Refresh Button | Button | Làm mới dữ liệu |
| Close Button | Button | Đóng window |

**Cách Tắt:** Click Close → Call `FUNC_CLOSE_RFID`

#### **Main Window (.top83)**
**Cách Tắt:** Click X → Call `FUNC_CLOSE_SCOPS` → Exit

---

## Phần 3: LUỒNG GỌI FUNCTION (Function Call Flow)

### 3.1 INITIALIZATION FLOW (Khởi Tạo Ứng Dụng)

```
main (argc, argv)
    ↓
FUNC_INITIALIZE_VARIABLE()
    ├─ Khởi tạo global variables
    ├─ Load config file
    ├─ Set default values
    └─ FUNC_SET_DELIMITER() [Set g_rd = "^"]
    ↓
FUNC_INITIALIZE_FLAG()
    ├─ Set flag_readydiff = 0
    ├─ Set flag_traylot = 0
    ├─ Set flag_reellot = 0
    └─ Set flag_operatorid = 0
    ↓
FUNC_SET_LANGUAGE()
    └─ Thiết lập ngôn ngữ UI
    ↓
FUNC_SET_SKIN()
    └─ Thiết lập theme/skin cho UI
    ↓
Window create .top83 (Main GUI)
    ├─ Create all widgets/buttons
    ├─ Create tabs
    └─ Initialize UI elements
    ↓
FUNC_LOAD_FUNCTIONS()
    └─ Load external functions từ files
    ↓
FUNC_BIND_WIDGET()
    ├─ Bind click event on g_ent_operatorid
    │   └─ Enable BTN_START_LOT
    ├─ Set close protocol cho .top86 → FUNC_CLOSE_CONFIRMATION
    ├─ Set close protocol cho .top85 → FUNC_CLOSE_RFID
    ├─ Set close protocol cho .top83 → FUNC_CLOSE_SCOPS
    └─ COMPLETED
    ↓
FUNC_GET_CONFIG(0)
    ├─ Lấy config từ server
    ├─ Parse và setup configuration
    └─ Update UI elements
    ↓
TCL_LIB_FTP()      [Load FTP library]
TCL_LIB_MIME()     [Load MIME library]
TCL_LIB_SMTP()     [Load SMTP library]
TCL_LIB_BASE64()   [Load Base64 library]
TCL_LIB_MD5()      [Load MD5 library]
    ↓
Application Ready
```

---

### 3.2 LOT SEARCH FLOW (Tìm Kiếm Lot)

```
User: Input lotname + Click "BTN_SEARCH_LOT"
    ↓
BTN_SEARCH_LOT(flag=1)
    ├─ Validate lotname not empty
    ├─ Set g_lotname = toupper(g_ent_lotname)
    ├─ Build query: "SCOPS,SearchLot,{hostname},{lotname}*"
    └─ Call FUNC_SEND_QRY(query)
        ├─ FUNC_SET_DELIMITER()
        ├─ FUNC_CREATE_SOCKET(host, port, timeout)
        └─ Send query to server
            ↓
            Server Process Query
            ↓
            Return: lot1^dcc1^operation1|lot2^dcc2^operation2|...
    ↓
Parse Response:
    ├─ Split by "|" → array
    ├─ For each lot:
    │   ├─ Split by "^" → lotname, dcc, operation
    │   ├─ Store in g_lotarray(idx.*)
    │   └─ Add to listbox
    ↓
Display in Listbox:
    └─ User see lot list
        ↓
User: Click on lot in Listbox
    ↓
FUNC_SELECT_LOT_LISTBOX()
    ├─ Get selected index from listbox
    ├─ Extract: g_lotname, g_dcc, g_operation from array
    ├─ Initialize: g_job = ""
    ├─ Enable/Disable buttons as needed
    ├─ Update display labels
    └─ Ready for Job selection
```

---

### 3.3 JOB & DESCRIPTION SELECTION FLOW

```
After Lot Selected:
    ↓
FUNC_GET_DESCRIPTION()
    ├─ Build query: "SCOPS,GETDESCRIPTION,MAIN,*"
    ├─ Call FUNC_SEND_QRY(qry)
    └─ Get response with descriptions
    ↓
Parse Descriptions:
    ├─ Split response by delimiter
    └─ Populate g_cbo_maindsc combobox
        ↓
User: Select MainDescription from Combobox
    ↓
FUNC_SELECT_MAINDSC_COMBOBOX()
    ├─ Get selected main description
    ├─ Build query: "SCOPS,GETDESCRIPTION,SUB,{main_desc}"
    ├─ Call FUNC_SEND_QRY(qry)
    └─ Get sub descriptions
        ↓
        Parse & Populate g_cbo_subdsc
        ↓
User: Select SubDescription from Combobox
    ↓
FUNC_SELECT_SUBDSC_COMBOBOX()
    ├─ Get selected sub description
    ├─ Build query: "SCOPS,GETJOB,{main},{sub}"
    ├─ Call FUNC_SEND_QRY(qry)
    └─ Get job list
        ↓
        Parse Jobs & Populate g_lst_job listbox
        ↓
User: Click on Job in Listbox
    ↓
FUNC_SELECT_JOB_LISTBOX()
    ├─ Get selected index
    ├─ Extract g_job from array
    ├─ Enable Start button
    └─ Update display
```

---

### 3.4 LOT STARTUP FLOW (Bắt Đầu Lot)

```
User: Input OperatorID + Click "BTN_START_LOT"
    ↓
BTN_START_LOT()
    ├─ Validate operatorid:
    │   ├─ Call FUNC_CHECK_OPERATORID(operatorid)
    │   └─ If invalid → Show error & return
    ├─ Validate lot information complete:
    │   ├─ g_lotname, g_job not empty
    │   ├─ Call FUNC_CHECK_VARIABLE() for each critical var
    │   └─ If fail → Show error & return
    ├─ Check prerequisites:
    │   ├─ FUNC_CHECK_SCOPSVERSION() - Check SCOPS version
    │   ├─ FUNC_CHECK_TPMS() - Check TPMS status
    │   ├─ FUNC_CHECK_HP93KDRIVER() - Check driver
    │   ├─ FUNC_CHECK_BINAGENT() - Check BinAgent
    │   └─ If any fail → Show warning
    ├─ Get lot information from server:
    │   ├─ Query: "SCOPS,GETJOBINFO,{job}"
    │   ├─ Call FUNC_SEND_QRY(qry)
    │   └─ Parse response → Fill in g_devicename, g_testprogram, ...
    ├─ Get lot configuration:
    │   ├─ Call FUNC_GET_CONFIG(0)
    │   └─ Load test config parameters
    ├─ Update lot status on server:
    │   ├─ Query: "SCOPS,SETLOTSTATUS,{lotname},STARTING"
    │   └─ Call FUNC_SEND_QRY(qry)
    ├─ Set status display
    ├─ Start execution loop:
    │   ├─ After 1000ms → FUNC_EXECUTE_LOOP()
    │   └─ Loop runs periodically until lot end
    └─ Ready for test execution
```

---

### 3.5 TEST EXECUTION LOOP FLOW

```
FUNC_EXECUTE_LOOP() [Called every 1000ms or on event]
    ├─ FUNC_GET_HOSTSTATUS()
    │   ├─ Query: "SCOPS,GETHOSTSTATUS,{hostname}"
    │   ├─ Parse response → g_lbl_hoststatus
    │   └─ Check for lot status change
    ├─ Check lot progress:
    │   ├─ Query: "SCOPS,GETLOTPROGRESS,{lotname}"
    │   └─ Update progress display
    ├─ Periodic APL execution (if enabled):
    │   ├─ FUNC_EXECUTE_APL()
    │   ├─ Select APL based on condition:
    │   │   ├─ FUNC_APL_WINDOWS() - For Windows APL
    │   │   ├─ FUNC_APL_T2000() - For T2000 tester
    │   │   ├─ FUNC_APL_XILINX() - For Xilinx
    │   │   ├─ FUNC_APL_T5585() - For T5585 tester
    │   │   ├─ FUNC_APL_MICROCHIP() - For Microchip
    │   │   ├─ FUNC_APL_EVE_SLT() - For EVE SLT
    │   │   └─ FUNC_APL_EVE_UFLEX() - For EVE UFLEX
    │   └─ Execute command/script via xterm or direct
    ├─ Check RFID (if enabled):
    │   ├─ FUNC_RFID_REFRESH()
    │   ├─ FUNC_RFID_INITIALIZE() [First time]
    │   └─ FUNC_RFID_COMPARE_LOTS() - Compare with lot tag
    ├─ Check probe/socket status:
    │   ├─ FUNC_RFID_CHECK_PROBETOUCHDOWN()
    │   ├─ FUNC_RFID_CHECK_SOCKETTOUCHDOWN()
    │   └─ Update touch count
    └─ Schedule next loop → after 1000ms → FUNC_EXECUTE_LOOP
```

---

### 3.6 TEST RESULT INPUT FLOW

```
User: Input test results (TPA, SWR, Temp, Comment)
    + Click "BTN_INPUT_TESTRESULT"
    ↓
BTN_INPUT_TESTRESULT()
    ├─ Validate input:
    │   ├─ FUNC_CHECK_COMMENT() - Check comment format
    │   ├─ FUNC_CHECK_TPA() - Validate TPA value
    │   ├─ FUNC_CHECK_T1T2() - Check T1/T2 values
    │   ├─ FUNC_CHECK_SWR() - Validate SWR format
    │   └─ If any fail → Show error & return
    ├─ Check special conditions:
    │   ├─ FUNC_CHECK_TPGM() - Check test program compatibility
    │   ├─ FUNC_CHECK_DATASTREAM() - Check datastream
    │   └─ FUNC_CHECK_DRL() - Check DRL status
    ├─ Prepare data for upload:
    │   ├─ g_comment = g_ent_comment
    │   ├─ g_tpa = g_ent_tpa
    │   ├─ g_temperature = g_ent_temperature
    │   ├─ g_swrnumber = g_ent_swrnumber
    │   └─ Format into query string
    ├─ Display result:
    │   ├─ FUNC_DISPLAY_SWR() - Show SWR graph/info
    │   └─ FUNC_DISPLAY_MESSAGE() - Show message
    ├─ Send to server:
    │   ├─ Build query: "SCOPS,SETRESULT,{data}"
    │   ├─ Call FUNC_SEND_QRY(qry)
    │   └─ Log response
    ├─ Clear input fields for next entry
    └─ Continue execution loop
```

---

### 3.7 LOT END FLOW (Kết Thúc Lot)

```
User: Click "BTN_END_LOT"
    ↓
BTN_END_LOT()
    ├─ Confirm lot completion:
    │   ├─ FUNC_CONFIRM_VALIDATION() or FUNC_CONFIRM_VALIDATION_LOG()
    │   └─ Show confirmation dialog
    ├─ If User Cancel → Return (không kết thúc)
    ├─ If User OK:
    │   ├─ Check lot data:
    │   │   ├─ FUNC_CHECK_FULLTEST() - Check full test requirement
    │   │   └─ FUNC_CHECK_RETEST() - Check retest info
    │   ├─ Set final lot status:
    │   │   ├─ FUNC_SET_FLAG_END_LOT()
    │   │   └─ Set all end flags
    │   ├─ Prepare final data:
    │   │   ├─ g_downtime = g_ent_downtime
    │   │   ├─ Calculate total_time = end_time - start_time
    │   │   └─ Format lot summary
    │   ├─ Send end query to server:
    │   │   ├─ Query: "SCOPS,ENDLOT,{lotname},{summary_data}"
    │   │   └─ Call FUNC_SEND_QRY(qry)
    │   ├─ Send optional debug/log file:
    │   │   ├─ If g_debug_flag = 1:
    │   │   │   ├─ FUNC_DEBUG_SENDFILE()
    │   │   │   └─ FUNC_SEND_EMAIL() with log file
    │   │   └─ Otherwise: Skip email
    │   ├─ Update UI:
    │   │   ├─ Disable all test buttons
    │   │   └─ Show "Lot Complete" message
    │   ├─ Clear lot data:
    │   │   ├─ FUNC_CLEAR_LOT()
    │   │   ├─ Reset all g_* variables
    │   │   └─ Clear display widgets
    │   ├─ Log action:
    │   │   ├─ Append to g_txt_log with timestamp
    │   │   └─ Save log to file
    │   └─ Ready for next lot (return to Step 1)
    └─ Lot Ended
```

---

### 3.8 RETEST ADDITION FLOW

```
User: Click "BTN_ADD_RETEST"
    ↓
BTN_ADD_RETEST()
    ├─ Verify lot not ended yet
    ├─ Confirm retest request:
    │   ├─ Show confirmation dialog
    │   └─ If Cancel → Return
    ├─ Check lot eligibility for retest:
    │   ├─ g_retest_count < g_retest_limit
    │   ├─ If exceed → Show error & return
    │   └─ Otherwise continue
    ├─ Mark lot for retest:
    │   ├─ Build query: "SCOPS,ADDRETEST,{lotname}"
    │   ├─ Call FUNC_SEND_QRY(qry)
    │   └─ Wait for server confirm
    ├─ Update display:
    │   ├─ Show retest flag indicator
    │   ├─ Increment g_retest_count
    │   └─ Update status message
    ├─ Continue with same lot data
    └─ Ready for another test iteration
```

---

## Phần 4: LUỒNG HOẠT ĐỘNG (Workflow/Operating Process)

### 4.1 WORKFLOW CHÍNH (Main Workflow)

```
START
  │
  ├─→ [Phase 1: Initialization]
  │    └─→ Launch Application
  │        ├─ Load all libraries & configs
  │        ├─ Initialize all variables & flags
  │        ├─ Create GUI windows
  │        └─ Ready for input
  │
  ├─→ [Phase 2: Lot Search]
  │    └─→ User searches for lot
  │        ├─ Input lot name in search box
  │        ├─ Click "Search Lot" button
  │        ├─ System queries server
  │        ├─ Display matching lots in list
  │        └─ User selects one lot from list
  │
  ├─→ [Phase 3: Job Selection]
  │    └─→ User selects job for lot
  │        ├─ Choose Main Description
  │        ├─ Choose Sub Description  
  │        ├─ Choose Job from available list
  │        └─ Lot configuration ready
  │
  ├─→ [Phase 4: Lot Startup]
  │    └─→ User starts lot testing
  │        ├─ Input Operator ID
  │        ├─ Click "Start Lot" button
  │        ├─ System validates all data
  │        ├─ System gets lot configuration
  │        ├─ Server confirms lot started
  │        └─ Begin test execution loop
  │
  ├─→ [Phase 5: Test Execution]
  │    └─→ While lot is running:
  │        ├─ Monitor lot progress (periodic loop)
  │        ├─ Set probe/socket down if needed
  │        ├─ Execute APL commands (if enabled)
  │        ├─ Monitor RFID tag status
  │        ├─ Input test results (TPA, SWR, etc)
  │        ├─ System sends results to server
  │        ├─ Add to retest if needed
  │        └─ Repeat until lot complete
  │
  ├─→ [Phase 6: Lot Completion]
  │    └─→ User ends lot
  │        ├─ Click "End Lot" button
  │        ├─ System confirms lot ending
  │        ├─ Send final data to server
  │        ├─ Send debug/log files if needed
  │        ├─ Clear lot data from memory
  │        └─ Ready for next lot
  │
  └─→ END or Loop back to Phase 2
```

---

### 4.2 LOOP HOẠT ĐỘNG PERIODIC

```
During Test Execution:

Timer: 1000ms (1 second)
    │
    ├─→ FUNC_EXECUTE_LOOP()
    │    ├─ Get host status from server
    │    ├─ Check lot progress
    │    ├─ Execute APL if needed
    │    ├─ Monitor RFID
    │    ├─ Check probe/socket touchdown
    │    └─ Schedule next loop in 1000ms
    │
    └─→ Continuous until Lot Ended
```

---

### 4.3 ERROR & EXCEPTION HANDLING

```
At any point if error occurs:

1. FUNC_CHECK_VARIABLE(variable_name)
   ├─ Validate variable is not empty
   ├─ If invalid → Set flag_error = 1
   └─ Return error status

2. FUNC_DISPLAY_MESSAGE(flag, config, filename, msg)
   ├─ Show error/info/warning dialog
   ├─ Log message to file
   └─ Optionally send via email

3. FUNC_CONFIRM_VALIDATION(flag, title, msg, filename, qry)
   ├─ Show confirmation dialog
   ├─ Allow user to confirm/cancel
   └─ Log action

4. Exception handling:
   ├─ Try/catch blocks in critical functions
   ├─ Graceful error recovery
   └─ State restoration if possible
```

---

## Phần 5: KEYBOARD SHORTCUTS & BUTTON ACTIONS

### 5.1 KEYBOARD BINDINGS

| Phím | Event | Hành Động | Hàm |
|-----|-------|---------|-----|
| `<Button-1>` | Click on Operator ID Field | Enable Start Button | Auto bind in FUNC_BIND_WIDGET |
| `<Return>` | Enter in Search Box | Trigger search | (Nếu có) |
| `<Escape>` | Escape key | Close current dialog | (Depending on window) |
| `<Alt+F4>` or `X` | Close window | Execute close handler | FUNC_CLOSE_SCOPS, FUNC_CLOSE_CONFIRMATION, FUNC_CLOSE_RFID |

### 5.2 MAIN BUTTONS & ACTIONS

#### **Tab 1: LOT SEARCH**
| Button | Shortcut | Action | Function |
|--------|----------|--------|----------|
| Search Lot | Click | Search lot from server | BTN_SEARCH_LOT(1) |
| Clear | Click | Clear all lot data | FUNC_CLEAR_LOT() |

#### **Tab 2: JOB SELECTION**
| Widget | Event | Action | Function |
|--------|-------|--------|----------|
| Main Description Combo | Selection Changed | Load sub descriptions | FUNC_SELECT_MAINDSC_COMBOBOX() |
| Sub Description Combo | Selection Changed | Load jobs | FUNC_SELECT_SUBDSC_COMBOBOX() |
| Job Listbox | Double-Click/Select | Select job | FUNC_SELECT_JOB_LISTBOX() |

#### **Tab 3: LOT EXECUTION**
| Button | Action | Function | Conditions |
|--------|--------|----------|-----------|
| Start Lot | Click | Start test for selected lot | BTN_START_LOT() | Operator ID filled + Job selected |
| Set Down | Click | Lower probe/socket | BTN_SET_DOWN() | Lot started |
| Operator ID Field | Click | Enable Start button | (Auto) | Field clicked |

#### **Tab 4: RFID OPERATIONS**
| Button | Action | Function | Conditions |
|--------|--------|----------|-----------|
| Search RFID | Click | Read RFID tag | BTN_SEARCH_RFID() | Lot started |
| Refresh RFID | Auto | Periodic update | FUNC_RFID_REFRESH() | Every loop iteration |

#### **Tab 5: TEST RESULTS**
| Button | Action | Function | Conditions |
|--------|--------|----------|-----------|
| Input Result | Click | Submit test result | BTN_INPUT_TESTRESULT() | All results filled + valid |

#### **Tab 6: LOT COMPLETION**
| Button | Action | Function | Conditions |
|--------|--------|----------|-----------|
| Add Retest | Click | Mark lot for retest | BTN_ADD_RETEST() | Lot running + Retest eligible |
| End Lot | Click | Complete lot | BTN_END_LOT() | Lot started |

#### **Tab 7: APL EXECUTION**
| Button | Action | Function | Conditions |
|--------|--------|----------|-----------|
| APL Windows | Click | Execute APL on Windows | FUNC_APL_WINDOWS(flag) | APL enabled |
| APL T2000 | Click | Execute T2000 APL | FUNC_APL_T2000(flag) | T2000 tester available |
| APL Xilinx | Click | Execute Xilinx APL | FUNC_APL_XILINX() | Xilinx board present |
| APL Microchip | Click | Execute Microchip APL | FUNC_APL_MICROCHIP(flag) | Microchip device present |
| APL T5585 | Click | Execute T5585 APL | FUNC_APL_T5585() | T5585 tester available |
| APL EVE_SLT | Click | Execute EVE SLT APL | FUNC_APL_EVE_SLT(flag) | EVE SLT available |
| APL EVE_UFLEX | Click | Execute EVE UFLEX APL | FUNC_APL_EVE_UFLEX(flag) | EVE UFLEX available |

#### **Tab 8: DEBUG**
| Button | Action | Function |
|--------|--------|----------|
| Debug Clear | Click | Clear debug log | FUNC_DEBUG_CLEAR() |
| Debug Save | Click | Save debug log to file | FUNC_DEBUG_SAVE() |
| Debug Delete File | Click | Delete log file | FUNC_DEBUG_DELETEFILE() |
| Debug Send | Click | Send log via email | FUNC_DEBUG_SENDFILE() |

---

## Phần 6: GLOBAL VARIABLES (BIẾN TOÀN CỤC)

### 6.1 LOT INFORMATION VARIABLES

```tcl
g_lotname           # Tên lot hiện tại
g_dcc              # DCC code
g_operation        # Operation name
g_job              # Job name
g_devicename       # Device model
g_customer         # Customer name
g_testprogram      # Test program path
g_testprogramrev   # Test program revision
```

### 6.2 TEST RESULT VARIABLES

```tcl
g_comment          # Test comment
g_tpa              # TPA result value
g_temperature      # Temperature value
g_swrnumber        # SWR number
g_swrmessage       # SWR message
g_condition        # Test condition
g_testtime         # Test time
g_yieldlimit       # Yield limit
```

### 6.3 CONFIG & STATUS VARIABLES

```tcl
g_readydiff_flag   # ReadyDiff status flag
g_readydiff_time   # ReadyDiff time
g_traylot_flag     # Tray lot flag
g_reellot_flag     # Reel lot flag
g_hostname         # Computer hostname
g_scopsserver      # SCOPS server IP
g_scopsversion     # SCOPS version
g_tclplatform      # Platform (windows/unix)
g_tcluserid        # User ID
```

### 6.4 RFID VARIABLES

```tcl
g_rfid_tag         # RFID tag value read
g_rfid_lotname     # RFID tag lot name
g_probe_touchdown  # Probe touchdown count
g_socket_touchdown # Socket touchdown count
g_socket_limit     # Socket touch limit
g_probe_limit      # Probe touch limit
```

### 6.5 ARRAY VARIABLES

```tcl
g_lotarray()       # Array containing lot search results
                   # Format: g_lotarray(idx.lotname), g_lotarray(idx.dcc), etc
                   
g_jobarray()       # Array containing job list
                   # Format: g_jobarray(idx.job), g_jobarray(idx.desc), etc

g_config()         # Array containing configuration parameters
```

### 6.6 DELIMITER & SEPARATOR

```tcl
g_rd               # Record delimiter (set to "^")
                   # Used to separate fields in server response
```

---

## Phần 7: NETWORK COMMUNICATION (LIÊN HỆ NETWORK)

### 7.1 QUERY FORMAT

```
SCOPS Server Query Format:
SCOPS,<COMMAND>,<PARAM1>,<PARAM2>,...*

Examples:
- SCOPS,SearchLot,computer-hostname,lotname*
- SCOPS,GETDESCRIPTION,MAIN,*
- SCOPS,GETJOB,main-desc,sub-desc*
- SCOPS,SETLOTSTATUS,lotname,STARTING*
- SCOPS,GETHOSTSTATUS,hostname*
- SCOPS,SETRESULT,result-data*
- SCOPS,ENDLOT,lotname,summary-data*

Response Format:
field1^field2^field3|record2data^data^data|...
```

### 7.2 FUNCTIONS FOR NETWORK

| Function | Purpose |
|----------|---------|
| FUNC_SEND_QRY(query_string) | Send query to SCOPS server & get response |
| FUNC_SEND_QRY_ORG(query_string) | Original version of send query |
| FUNC_SEND_QRY_EXCEPTION(query_string) | Send query with exception handling |
| FUNC_CREATE_SOCKET(host, port, timeout) | Create socket connection |
| FUNC_SEND_TCPSTRING() | Send TCP string to server |
| FUNC_SEND_TCPSTRINGRETURN() | Send TCP and wait for return |
| FUNC_SEND_UDPSTRING() | Send UDP string to server |
| FUNC_SEND_EMAIL(sender, recipient, cc, subject, body, filepath) | Send email with attachment |

---

## Phần 8: KEY FUNCTIONAL MODULES (CÁC MOĐUN CHỨC NĂNG CHÍNH)

### 8.1 LOT MANAGEMENT
- `BTN_SEARCH_LOT()` - Search lots
- `FUNC_SELECT_LOT_LISTBOX()` - Select lot
- `FUNC_CLEAR_LOT()` - Clear lot data

### 8.2 JOB/DESCRIPTION
- `FUNC_GET_DESCRIPTION()` - Get descriptions
- `FUNC_SELECT_MAINDSC_COMBOBOX()` - Select main description
- `FUNC_SELECT_SUBDSC_COMBOBOX()` - Select sub description
- `FUNC_SELECT_JOB_LISTBOX()` - Select job

### 8.3 LOT EXECUTION
- `BTN_START_LOT()` - Start lot
- `BTN_SET_DOWN()` - Set down probe/socket
- `BTN_END_LOT()` - End lot
- `BTN_ADD_RETEST()` - Add to retest

### 8.4 TEST OPERATIONS
- `FUNC_EXECUTE_LOOP()` - Main execution loop
- `BTN_INPUT_TESTRESULT()` - Input test result
- `FUNC_CHECK_*()` - Validation functions

### 8.5 RFID OPERATIONS
- `BTN_SEARCH_RFID()` - Search RFID tag
- `FUNC_RFID_INITIALIZE()` - Initialize RFID reader
- `FUNC_RFID_REFRESH()` - Refresh RFID data
- `FUNC_RFID_COMPARE_LOTS()` - Compare RFID with lot
- `FUNC_RFID_CHECK_PROBETOUCHDOWN()` - Check probe
- `FUNC_RFID_CHECK_SOCKETTOUCHDOWN()` - Check socket

### 8.6 APL EXECUTION
- `FUNC_EXECUTE_APL()` - Main APL executor
- `FUNC_APL_WINDOWS()` - Windows APL
- `FUNC_APL_T2000()` - T2000 APL
- `FUNC_APL_XILINX()` - Xilinx APL
- `FUNC_APL_T5585()` - T5585 APL
- `FUNC_APL_MICROCHIP()` - Microchip APL
- `FUNC_APL_EVE_SLT()` - EVE SLT APL
- `FUNC_APL_EVE_UFLEX()` - EVE UFLEX APL

### 8.7 CONFIGURATION & UTILITIES
- `FUNC_INITIALIZE_VARIABLE()` - Initialize variables
- `FUNC_INITIALIZE_FLAG()` - Initialize flags
- `FUNC_GET_CONFIG()` - Get configuration
- `FUNC_SET_LANGUAGE()` - Set language
- `FUNC_SET_SKIN()` - Set UI theme
- `FUNC_LOAD_FUNCTIONS()` - Load external functions
- `FUNC_BIND_WIDGET()` - Bind widget events

### 8.8 COMMUNICATION
- `FUNC_SEND_QRY()` - Send query to server
- `FUNC_SEND_EMAIL()` - Send email notification
- `FUNC_SEND_TCPSTRING()` - TCP communication
- `FUNC_SEND_UDPSTRING()` - UDP communication

### 8.9 DEBUG & LOGGING
- `FUNC_DEBUG()` - Debug logging
- `FUNC_DEBUG_CLEAR()` - Clear debug log
- `FUNC_DEBUG_SAVE()` - Save debug log
- `FUNC_DEBUG_SENDFILE()` - Send debug file
- `FUNC_DISPLAY_MESSAGE()` - Display message box

### 8.10 VALIDATION
- `FUNC_CHECK_OPERATORID()` - Validate operator ID
- `FUNC_CHECK_VARIABLE()` - Validate variable
- `FUNC_CHECK_COMMENT()` - Validate comment
- `FUNC_CHECK_TPA()` - Validate TPA value
- `FUNC_CHECK_T1T2()` - Validate T1/T2
- `FUNC_CHECK_SWR()` - Validate SWR
- `FUNC_CHECK_TPGM()` - Check test program
- `FUNC_CHECK_DOWNTIME()` - Check downtime
- `FUNC_CHECK_RETEST()` - Check retest status
- `FUNC_CHECK_FULLTEST()` - Check full test

---

## Phần 9: FILE & SYSTEM OPERATIONS

### 9.1 FILE OPERATIONS
- `FUNC_DOWNLOAD_FILE(type, source_file, target_file)` - Download file
- `FUNC_CLEAR_FILE()` - Clear file
- `FUNC_CHECK_FILE(filename)` - Check file existence
- `FUNC_CREATE_CONFIGFILE()` - Create config file
- `FUNC_CREATE_UDPSENDER()` - Create UDP sender tool
- `FUNC_DOWNLOAD_UDPSENDER()` - Download UDP sender

### 9.2 PROCESS OPERATIONS
- `FUNC_KILL_PROCESS(process_name)` - Kill process
- `FUNC_EXECUTE_XTERM(command)` - Execute command in xterm
- `FUNC_CHECK_HP93KDRIVER()` - Check HP93K driver
- `FUNC_CHECK_BINAGENT()` - Check BinAgent process
- `FUNC_UPDATE_OS()` - Update operating system
- `FUNC_UPDATE_IP()` - Update IP address
- `FUNC_UPDATE_SCOPSVERSION()` - Update SCOPS version

---

## Phần 10: SPECIAL FUNCTIONS & TEMPLATES

### 10.1 APL EXECUTION HELPERS
- `CONTACT_POINT(str)` - Determine contact point
- `FUNC_EXECUTE_APL()` - Main APL dispatcher
- `TEMPLATE_MESSAGEBOX()` - Message box template
- `TEMPLATE_QUERY()` - Query template
- `TEMPLATE_SEND_EMAIL()` - Email template
- `TEMPLATE_DISPLAY_MESSAGE()` - Display message template
- `TEMPLATE_TRYCATCH()` - Try-catch template

### 10.2 DATA PARSING & CONVERSION
- `FUNC_PARSE_CONDITION()` - Parse condition string
- `FUNC_PARSEANDSET_STRING()` - Parse and set string
- `FUNC_SET_DELIMITER()` - Set delimiter
- `FUNC_DISPLAY_SWR()` - Display SWR result
- `FUNC_DISPLAY_MESSAGE()` - Display any message
- `FD(str)` - Short debug function
- `FM(contact, msg, result)` - Format message function

### 10.3 LIBRARY FUNCTIONS
- `TCL_LIB_FTP()` - FTP library
- `TCL_LIB_MIME()` - MIME library (email encoding)
- `TCL_LIB_SMTP()` - SMTP library (email sending)
- `TCL_LIB_BASE64()` - Base64 library
- `TCL_LIB_MD5()` - MD5 library

---

## Phần 11: QUICK REFERENCE TABLE

### 11.1 CRITICAL VALIDATION FUNCTIONS

| Function | Input | Output | Use Case |
|----------|-------|--------|----------|
| FUNC_CHECK_OPERATORID(id) | Operator ID string | 1=valid, 0=invalid | Before starting lot |
| FUNC_CHECK_VARIABLE(var) | Variable name | 1=exist, 0=empty | Check any variable |
| FUNC_CHECK_COMMENT() | - | 1=valid, 0=invalid | Before submitting result |
| FUNC_CHECK_TPA() | - | 1=valid, 0=invalid | Validate TPA value |
| FUNC_CHECK_SWR() | - | 1=valid, 0=invalid | Validate SWR format |
| FUNC_CHECK_DOWNTIME() | - | 1=valid, 0=invalid | Before ending lot |

### 11.2 STATUS DISPLAY FUNCTIONS

| Function | Purpose | Output |
|----------|---------|--------|
| FUNC_GET_HOSTSTATUS() | Get host status | Updates g_lbl_hoststatus |
| FUNC_SET_STATUS() | Update status display | Updates UI labels |
| FUNC_GET_TESTINFORMATION() | Get test info | Returns test data |
| FUNC_GET_LOTINFORMATION() | Get lot info | Returns lot data |

### 11.3 QUERY-RELATED FUNCTIONS

| Function | Query Sent | Response Parsed |
|----------|-----------|-----------------|
| BTN_SEARCH_LOT | SCOPS,SearchLot,... | Lot list with DCC, Operation |
| FUNC_GET_DESCRIPTION | SCOPS,GETDESCRIPTION,... | Description list |
| BTN_START_LOT | SCOPS,STARTLOT,... | Lot started confirmation |
| BTN_INPUT_TESTRESULT | SCOPS,SETRESULT,... | Result accepted |
| BTN_END_LOT | SCOPS,ENDLOT,... | Lot ended confirmation |

---

## Phần 12: TROUBLESHOOTING GUIDE

### 12.1 COMMON ISSUES

#### Issue: "Cannot search lot"
**Solution:**
1. Check network connectivity
2. Verify SCOPS server IP (g_scopsserver = "10.201.16.50")
3. Check hostname matches server registry
4. Try refreshing with FUNC_GET_CONFIG()

#### Issue: "Start Lot fails"
**Solution:**
1. Validate Operator ID exists
2. Check Job was selected properly
3. Verify lot status on server
4. Check all required fields filled
5. Run FUNC_CHECK_OPERATORID() to debug

#### Issue: "Test Result not submitted"
**Solution:**
1. Validate all input fields (TPA, SWR, Temperature)
2. Check Comment format
3. Verify SWR number is valid format
4. Check network connection to server
5. Review error message from FUNC_DISPLAY_MESSAGE()

#### Issue: "RFID Read fails"
**Solution:**
1. Check RFID reader connected
2. Verify RFID reader driver installed
3. Check probe/socket positioned correctly
4. Try FUNC_RFID_INITIALIZE() to reset
5. Check socket touchdown status

---

## Phần 13: END-OF-DOCUMENT

**Document Version:** 1.0  
**Last Updated:** May 21, 2026  
**Author:** System Documentation  
**For:** SCOPS 3.8.3 QORVO PGM2

### Notes:
- All functions starting with FUNC_ are custom functions in this script
- All functions starting with BTN_ are button click handlers
- All variables starting with g_ are global scope
- g_cbo_* refers to Combobox widgets
- g_lst_* refers to Listbox widgets
- g_txt_* refers to Text widgets
- g_ent_* refers to Entry widgets
- g_lbl_* refers to Label widgets

---

**END OF DOCUMENTATION**
