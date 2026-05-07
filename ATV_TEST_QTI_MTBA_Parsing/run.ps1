# This script runs the ATV ESI Monaco Hold Lot Management Service application using run.py
# It uses the 'json' configuration type.

# Navigate to the script's directory
Set-Location (Split-Path -Parent $MyInvocation.MyCommand.Definition)

# Define the Python executable (adjust if your Python is not in PATH or named differently)
$pythonExecutable = $env:01_Python_Env_312 + "\python.exe"

# Define the application name and config type
$appName = "QTIMTBAParsing"
$configType = "json"

# Execute the Python script
& $pythonExecutable run.py $appName --config_type $configType

# You can add more calls to run.py for other applications here,
# or implement sequential/parallel execution logic using PowerShell commands.
# Example for sequential:
# & $pythonExecutable run.py AnotherApp --config_type ini

# Example for parallel (using Start-Job, requires more setup for output handling):
# Start-Job -ScriptBlock { & $pythonExecutable run.py AnotherApp --config_type ini }
# Get-Job | Wait-Job | Receive-Job