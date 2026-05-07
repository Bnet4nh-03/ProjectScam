# This script runs the ATV ESI Monaco Hold Lot Management Service application using run.py
# It uses the 'json' configuration type.

# Get the script's directory
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Definition
$runPy = Join-Path $scriptDir "run.py"

# Define the Python executable (adjust if your Python is not in PATH or named differently)
$pythonExecutable = $env:01_Python_Env_312 + "\python.exe"

#parallel 
Start-Job -ScriptBlock {   
    # Navigate to the script's directory
    Set-Location $using:scriptDir
    & $using:pythonExecutable $using:runPy QTIMTBAParsing --config_type json 
    }

Start-Job -ScriptBlock { 
    # Navigate to the script's directory
    Set-Location $using:scriptDir
    & $using:pythonExecutable $using:runPy SipletMTBAParsing --config_type json 
    }

Start-Job -ScriptBlock { 
    # Navigate to the script's directory
    Set-Location $using:scriptDir
    & $using:pythonExecutable $using:runPy HexaMTBAParsing --config_type json 
    }
Get-Job | Wait-Job | Receive-Job # Wait for jobs and get their output
Write-Host "All parallel applications finished."

# You can add more calls to run.py for other applications here,
# or implement sequential/parallel execution logic using PowerShell commands.
# Example for sequential:
# & $pythonExecutable run.py AnotherApp --config_type ini

# Example for parallel (using Start-Job, requires more setup for output handling):
# Start-Job -ScriptBlock { & $pythonExecutable run.py AnotherApp --config_type ini }
# Get-Job | Wait-Job | Receive-Job