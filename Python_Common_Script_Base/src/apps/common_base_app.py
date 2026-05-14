
from src.core.base_app import BaseApp
from src.utility.enco_common_api_utils.enco_api_client import EnCoApiClient
from src.core.excel_update_processor import ExcelUpdateProcessor


class CommonBaseApp(BaseApp):

    def __init__(self, config_path: str, config_type: str):
        super().__init__(self.__class__.__name__, config_path, config_type)

        self.enco_api_client = EnCoApiClient(
            self.config["API_Common"]["api_link_1"],
            self.logger
        )

    def run(self):
        self.logger.info("=== START EXCEL UPDATE APP ===")

        try:
            file_path = self.config["INPUT_FILE"]
            excel_conf = self.config["EXCEL_UPDATE"]

            processor = ExcelUpdateProcessor(excel_conf, self.logger)

            payloads = processor.process_file(file_path)

            success = 0
            fail = 0

            for payload in payloads:
                try:
                    self.logger.info(f"Calling SP with payload: {payload}")

                    # result = self.enco_api_client.call_sp(
                    #     "sp_dynamic_update",
                    #     json.dumps(payload)
                    # )

                    self.logger.info(f"SP result: {result}")

                    # optional: check result content
                    if not result:
                        self.logger.warning("SP returned empty result")

                    success += 1

                except Exception as e:
                    fail += 1
                    self.logger.error(f"SP failed: {str(e)}", exc_info=True)
        

            self.logger.info(f"Done → Success: {success}, Fail: {fail}")

        except Exception as e:
            self.logger.error(f"APP ERROR: {str(e)}", exc_info=True)

        self.logger.info("=== END EXCEL UPDATE APP ===")

