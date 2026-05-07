from __future__ import annotations

from abc import ABC, abstractmethod
from typing import Any, Dict, Optional

from src.core.base_app import BaseApp
from src.utility.enco_common_api_utils.enco_api_client import EnCoApiClient


class CommonBaseParsing(BaseApp, ABC):

    # Mapping param name trong SP -> attribute name trong class
    PARAM_MAP: Dict[str, str] = {
        "@sumName": "sumName",
        "@sumDirectory": "sumDirectory",
        "@Platform": "platform",
        "@Customer": "customer",
        "@lotName": "lotName",
        "@dcc": "dcc",
        "@Device": "device",
        "@DeviceMA": "deviceMA",
        "@Operation": "operation",
        "@LoadboardNo": "loadBoardNo",
        "@Temperature": "temperature",
        "@HandlerID": "handlerId",
        "@HandlerType": "handlerType",
        "@OperatorID": "operatorId",
        "@TestProgram": "testProgram",
        "@TestProgramExcel": "testProgramExcel",
        "@TestProgramRev": "testProgramRev",
        "@ChannelMap": "channelMap",
        "@CreateTime": "createTime",
        "@Tester": "tester",
        "@PUIversion": "PUIversion",
        "@goodBin": "goodBin",
        "@goodYield": "goodYield",
        "@failBin": "failBin",
        "@failYield": "failYield",
        "@totalBin": "totalBin",
        "@HardBins": "hardBin",
        "@summaryText": "summaryText",
        "@editOperatorID": "editOperatorID",
        "@comment": "comment",
        "@SoftBins": "softBin",
    }

    def __init__(self, config_path: str, config_type: str):
        super().__init__(self.__class__.__name__, config_path, config_type)
        self.enco_api_client = EnCoApiClient(self.config["API_Common"].get("api_link_1"), self.logger)
        self.SUMMARY_INSERT_SP = self.config["Stored_procedure"].get("summary_insert")

    # --------------------------
    # Template workflow
    # --------------------------
    def run(self) -> Optional[Any]:
        """
        General Workflow:
        1) reset default attribute
        2) populate attribute (model-specific)
        3) insert summary (common)
        """
        self.logger.info(f"Starting {self.__class__.__name__} application")
        try:
            self.reset_attributes()
            self.populate_attributes()
            # data = self.call_summary_insert()
            self.logger.info(f"Finished {self.__class__.__name__}")
            # self.logger.info(f"{data} application finished")
        except Exception as e:
            self.logger.exception(f"Parsing failed: {e}")

        self.logger.info(f"{self.__class__.__name__} application finished")

    @abstractmethod
    def populate_attributes(self) -> None:
        """
        Model-specific:
        - đọc file, gọi DB SP khác, gọi API...
        - gán giá trị vào attributes chung
        """
        raise NotImplementedError

    # --------------------------
    # Common attributes
    # --------------------------
    def reset_attributes(self) -> None:
        """
        Default value cho tất cả attribute chung.
        Các model khác nhau chỉ thay giá trị trong populate_attributes().
        """
        self.sumName = ''
        self.sumDirectory = ''
        self.platform = ''
        self.customer = ''
        self.lotName = ''
        self.dcc = ''
        self.device = ''
        self.deviceMA = ''
        self.operation = ''
        self.loadBoardNo = ''
        self.temperature = ''
        self.handlerId = ''
        self.handlerType = ''
        self.operatorId = ''
        self.testProgram = ''
        self.testProgramExcel = ''
        self.testProgramRev = ''
        self.channelMap = ''
        self.createTime = ''
        self.tester = ''
        self.PUIversion = ''
        self.goodBin = 0
        self.goodYield = 0.0
        self.failBin = 0
        self.failYield = 0.0
        self.totalBin = 0
        self.hardBin = ''
        self.summaryText = ''
        self.editOperatorID = ''
        self.comment = ''
        self.softBin = ''

    # --------------------------
    # Common insert method
    # --------------------------

    def build_summary_insert_params(self) -> Dict[str, Any]:
        """
        Build dict params gửi vào Stored Procedure.
        Không filter None hoặc "" — giữ nguyên giá trị.
        Nếu attribute bị thiếu (do typo hoặc không khai báo),
        log warning và set giá trị None.
        """
        params: Dict[str, Any] = {}
        missing_attrs = []

        for sp_param, attr_name in self.PARAM_MAP.items():
            # Lấy attribute nếu có, nếu không thì gán None
            if hasattr(self, attr_name):
                params[sp_param] = getattr(self, attr_name)
            else:
                params[sp_param] = None
                missing_attrs.append((sp_param, attr_name))

        # Log danh sách những thuộc tính bị thiếu
        if missing_attrs:
            self.logger.warning(
                "Missing attributes for SP params (set None): "
                + ", ".join([f"{sp_param} <- {attr}" for sp_param, attr in missing_attrs])
            )

        return params

    def call_summary_insert(self) -> Optional[Any]:
        """
        Method dùng chung cho tất cả models:
        - build params từ attributes
        - gọi USP_Summary_Insert
        - trả về data_list theo format bạn đang dùng: result[0]['data']
        """
        params = self.build_summary_insert_params()
        
        if not params['@Platform']:
            return

        result = self.enco_api_client.call_sp(self.SUMMARY_INSERT_SP, params)

        if result:
            self.logger.info("Insert success")
            self.logger.info(f"Query insert: {params}")
            try:
                return result[0].get("data")
            except Exception:
                self.logger.error(f"Unexpected result format: {result}")
                self.logger.debug(f"Query insert: {params}")
                return None

        self.logger.error(f"Insert failed: {result}")
        self.logger.debug(f"Query insert: {params}")
        return None


    