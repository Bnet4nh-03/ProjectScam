@echo off
REM This script runs the CommonBaseApp application using run.py
REM It uses the 'json' configuration type.

REM Navigate to the script's directory
cd /d "%~dp0"

REM Define the Python executable (adjust if your Python is not in PATH or named differently)
set PYTHON_EXECUTABLE=python

REM Define the application name and config type
set APP_NAME=CommonBaseApp
set CONFIG_TYPE=json

REM Execute the Python script
%PYTHON_EXECUTABLE% run.py %APP_NAME% --config_type %CONFIG_TYPE%

REM You can add more calls to run.py for other applications here,
REM or implement sequential/parallel execution logic using batch commands.

REM Example for sequential:
REM %PYTHON_EXECUTABLE% run.py AnotherApp --config_type ini

REM Example for parallel (using start /b):
REM start /b %PYTHON_EXECUTABLE% run.py AnotherApp --config_type ini
REM REM Note: 'start /b' runs in background. For robust waiting, you might need a helper script or PowerShell.
