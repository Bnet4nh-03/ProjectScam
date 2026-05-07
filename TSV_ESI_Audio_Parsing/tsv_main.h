/**
@file     tsv_main.h
@author   Kim, hyoung-joo
@version
  v0.0.1: 2015-08-18
@Description
  main header
@par Copyright:
  Copyright(c) 2015 Amkor technology CO., All Rights Reserved.
*/
#ifndef MAIN_H__
#define MAIN_H__

/* Header files */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <signal.h>
#include <err.h>

#include "fw_log.h"
#include "fw_ini_file.h"
#include "fw_signal.h"
#include "fw_msg_in.h"

#include "tsv_env.h"
#include "tsv_error.h"
#include "tsv_summary.h"
#include "tsv_db.h"

/* for each platform */
#include "tsv_slt.h"

/* Define macro */
#define g_logging logging

/* Define variables */
extern CEnv g_env;
extern CLog g_logging;

#endif /* MAIN_H__ */
