#!/bin/bash
# This script runs the CommonBaseApp application using run.py
# It uses the 'json' configuration type.

# Navigate to the script's directory
SCRIPT_DIR=$(dirname "$0")
cd "$SCRIPT_DIR"

# Define the Python executable (adjust if your Python is not in PATH or named differently)
PYTHON_EXECUTABLE="python"

# Define the application name and config type
APP_NAME="CommonBaseApp"
CONFIG_TYPE="json"

# Execute the Python script
"$PYTHON_EXECUTABLE" run.py "$APP_NAME" --config_type "$CONFIG_TYPE"

# You can add more calls to run.py for other applications here,
# or implement sequential/parallel execution logic using bash commands.

# Example for sequential:
# "$PYTHON_EXECUTABLE" run.py AnotherApp --config_type ini

# Example for parallel (using & and wait):
# "$PYTHON_EXECUTABLE" run.py AnotherApp --config_type ini &
# wait # Waits for all background jobs to complete
