#!/bin/bash

echo "Start parsing"

# Convert asc -> asc_processed
sudo /home/testit/ETC/PythonEnv/01_Python312/bin/python3.12 \
    /home/testit/SRC/SRC/src/KIOXIA/Fullcombine_ADV/convert_asc.py \
    >> /home/testit/SRC/SRC/src/KIOXIA/Fullcombine_ADV/log/convert_asc/convert_asc_adv_$(date +\%Y\%m\%d).log

# Generate TSV summary
sudo /home/testit/ETC/PythonEnv/01_Python312/bin/python3.12 \
    /home/testit/SRC/SRC/src/KIOXIA/Fullcombine_ADV/TSV_Summary_Adv.py \
    >> /home/testit/SRC/SRC/src/KIOXIA/Fullcombine_ADV/log/fullcombine_adv/TSV_Summary_Adv_log_$(date +\%Y\%m\%d).log

echo "End parsing"
