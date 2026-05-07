from src.core.base_app import BaseApp
from src.utility.enco_common_api_utils.enco_api_client import EnCoApiClient

class CommonBaseApp(BaseApp):
    def __init__(self, config_path: str, config_type: str):
        super().__init__(self.__class__.__name__, config_path, config_type)
        self.enco_api_client = EnCoApiClient(self.config["API_Common"].get("api_link_1"), self.logger)

    def run(self):
        self.logger.info(f"Starting {self.__class__.__name__} application")
        # Your application logic here
        test = self.enco_api_client.call_sc("SELECT GETDATE()")
        self.logger.info(test)
        self.logger.info(f"{self.__class__.__name__} application finished")