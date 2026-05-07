import configparser
import os
import json

class Config:
    def __init__(self, config_path: str, config_type: str):
        if config_type == 'ini':
            self.config = self.load_config_ini(os.path.join(config_path, 'config.ini'))
        elif config_type == 'json':
            self.config = self.load_config_json(os.path.join(config_path, 'config.json'))

    def load_config_ini(self, config_file_path: str):
        config = configparser.ConfigParser()
        config.read(config_file_path)
        
        nested_config = {}
        for section in config.sections():
            parts = section.split('.')
            app_name = parts[0]
            if app_name not in nested_config:
                nested_config[app_name] = {}
            
            if len(parts) > 1:
                sub_section = parts[1]
                if sub_section not in nested_config[app_name]:
                    nested_config[app_name][sub_section] = {}
                for key, value in config.items(section):
                    nested_config[app_name][sub_section][key] = value
            else:
                for key, value in config.items(section):
                    nested_config[app_name][key] = value
                    
        return nested_config

    def load_config_json(self, config_file_path: str):
        with open(config_file_path, 'r') as file:
            return json.load(file)

    def get(self, app_name: str):
        return self.config.get(app_name)
