from src.core.config import Config
from src.core.logger import setup_logging

class BaseApp:
    def __init__(self, app_name: str, config_path: str, config_type: str):
        self.app_name = app_name
        self.config = Config(config_path, config_type).get(app_name)
        self.logger = setup_logging(self.app_name, self.config["Logging"])

    def run(self):
        raise NotImplementedError
