#!/bin/bash
# This script runs the CommonBaseApp application using run.py
# It uses the 'json' configuration type.

# Check if another process is already running
LOCKFILE="/tmp/my_unique_script.lock"
exec 9>"$LOCKFILE"

if ! flock -n 9; then
    echo "Another process is running .. skip" >&2
    exit 1
fi
# Navigate to the script's directory
SCRIPT_DIR=$(dirname "$0")
cd "$SCRIPT_DIR"

# Define the Python executable (adjust if your Python is not in PATH or named differently)
PYTHON_EXECUTABLE="/home/testit/01_Environments/01_Python312_Env/bin/python"


#######TSV parsing######
# Define the application name and config type
APP_NAME_TSV="ParsingSummaryTsv"
CONFIG_TYPE="json"
# Execute for ATV_TEST_QXM_Parsing
"$PYTHON_EXECUTABLE" run.py "$APP_NAME_TSV" --config_type "$CONFIG_TYPE"

# Execute for PanelParsing
APP_NAME_PANELPARSING="PanelParsing"
"$PYTHON_EXECUTABLE" run.py "$APP_NAME_PANELPARSING" --config_type "$CONFIG_TYPE"


#######Upload_AWS#######
bash /mnt/v1tstprodlog/04_TEST/006_QTI/ATV_TEST_QXM_Uploader_AWS/run.sh
# Define the application name and config type
# APP_NAME_UPLOADER="QXMUploadAWS"
# # Execute for ATV_TEST_QXM_aws_uploader 
# "$PYTHON_EXECUTABLE" /mnt/v1tstprodlog/04_TEST/006_QTI/ATV_TEST_QXM_Uploader_AWS/run.py "$APP_NAME_UPLOADER" --config_type "$CONFIG_TYPE"
 


# You can add more calls to run.py for other applications here,
# or implement sequential/parallel execution logic using bash commands.

# Example for sequential:
# "$PYTHON_EXECUTABLE" run.py AnotherApp --config_type ini

# Example for parallel (using & and wait):
# "$PYTHON_EXECUTABLE" run.py AnotherApp --config_type ini &
# wait # Waits for all background jobs to complete
