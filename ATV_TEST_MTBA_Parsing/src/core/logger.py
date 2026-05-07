import logging
import os
from datetime import datetime
import sys

def setup_logging(app_name: str, config: dict):
    """
    Configure root logger with:
        - daily log files in log/YYYY/MM/YYYY-MM-DD.log format
        - console output
    """
    level = getattr(logging, config.get("LOG_LEVEL", "INFO"))
    logger = logging.getLogger(app_name)
    
    # Prevent adding handlers multiple times if this function is called again
    if logger.hasHandlers():
        logger.handlers.clear()
        
    logger.setLevel(level)

    # Formatter
    fmt = logging.Formatter('%(asctime)s [%(levelname)s] [%(filename)s:%(lineno)d] %(message)s')

    # Create log directory structure (log/YYYY/MM)
    log_dir = os.path.join(config.get("LOG_DIR", "logs"), datetime.now().strftime('%Y'), datetime.now().strftime('%m'))
    os.makedirs(log_dir, exist_ok=True)
    
    # Format log filename as YYYY-MM-DD.log
    log_path = os.path.join(log_dir, f"{app_name}_{datetime.now().strftime('%Y-%m-%d')}.log")
    
    # File handler
    file_handler = logging.FileHandler(filename=log_path, encoding='utf-8')
    file_handler.setFormatter(fmt)
    logger.addHandler(file_handler)

    # Console handler
    console_handler = logging.StreamHandler(sys.stdout)
    console_handler.setFormatter(fmt)
    logger.addHandler(console_handler)

    return logger