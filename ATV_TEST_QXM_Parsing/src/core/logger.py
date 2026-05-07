import logging
import os
import re
from datetime import datetime
from typing import Dict, Any
import socket

class LogPatternProcessor:
    """Handles processing of various log patterns with flexible placeholder support."""
    
    # Default values for placeholders
    DEFAULT_VALUES = {
        'hostname': lambda: socket.gethostname() if socket.gethostname() else 'localhost',
        'local-ip': lambda: socket.gethostbyname(socket.gethostname()) if socket.gethostname() else '127.0.0.1',
        'app': lambda: 'application',
        'date': lambda: datetime.now().strftime('%Y-%m-%d'),
        'time': lambda: datetime.now().strftime('%H-%M-%S'),
        'datetime': lambda: datetime.now().strftime('%Y-%m-%d_%H-%M-%S'),
        'year': lambda: datetime.now().strftime('%Y'),
        'month': lambda: datetime.now().strftime('%m'),
        'day': lambda: datetime.now().strftime('%d'),
        'hour': lambda: datetime.now().strftime('%H'),
        'minute': lambda: datetime.now().strftime('%M'),
        'second': lambda: datetime.now().strftime('%S'),
        'pid': lambda: str(os.getpid()),
        'level': lambda: 'INFO',
    }

    @classmethod
    def process_pattern(cls, pattern: str, app_name: str = None, **kwargs) -> str:
        """
        Process a log pattern string, replacing placeholders with actual values.
        
        Args:
            pattern: The log pattern string containing placeholders
            app_name: Application name (will override 'app' placeholder)
            **kwargs: Additional values to override defaults
            
        Returns:
            Processed path string
        """
        # Merge default values with provided values
        values = {k: v() for k, v in cls.DEFAULT_VALUES.items()}
        if app_name:
            values['app'] = app_name
        values.update(kwargs)
        
        # Find all placeholders in the pattern
        placeholders = re.findall(r'\{([^}]+)\}', pattern)
        
        # Replace each placeholder
        result = pattern
        for placeholder in placeholders:
            value = values.get(placeholder, '')
            result = result.replace(f'{{{placeholder}}}', str(value))
            
        return result

def setup_logging(app_name: str, config: Dict[str, Any]) -> logging.Logger:
    """
    Configure logger with flexible pattern support.
    
    Args:
        app_name: Name of the application
        config: Configuration dictionary containing logging settings
        
    Returns:
        Configured logger instance
    """
    
    # Get configuration values
    log_level = config.get("LOG_LEVEL", "INFO")
    log_dir = config.get("LOG_DIR", "./logs")
    log_pattern = config.get("LOG_PATTERN", "{app}_{date}.log")
    
    # Setup logger
    level = getattr(logging, log_level.upper())
    logger = logging.getLogger(app_name)
    
    # Clear existing handlers
    if logger.hasHandlers():
        logger.handlers.clear()
        
    logger.setLevel(level)

    # Setup formatter
    fmt = logging.Formatter(
        '%(asctime)s [%(levelname)s] [%(filename)s:%(lineno)d] %(message)s'
    )

    # Process log pattern
    log_path = os.path.join(
        log_dir,
        LogPatternProcessor.process_pattern(
            log_pattern,
            app_name=app_name,
            level=log_level
        )
    )
    
    # Ensure directory exists
    log_dir = os.path.dirname(log_path)
    if log_dir:
        os.makedirs(log_dir, exist_ok=True)
    
    # Setup file handler
    file_handler = logging.FileHandler(
        filename=log_path,
        encoding='utf-8',
        mode='a'  # Append mode
    )
    file_handler.setFormatter(fmt)
    logger.addHandler(file_handler)

    # Setup console handler
    console_handler = logging.StreamHandler()
    console_handler.setFormatter(fmt)
    logger.addHandler(console_handler)

    return logger