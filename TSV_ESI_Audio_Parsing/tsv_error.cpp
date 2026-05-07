/**
@file     atpTsv_error.cpp
@author   Kim, hyoung-joo
@version
  v0.0.1: 2015-08-18
@Description
  error source
@par Copyright:
  Copyright(c) 2015 Amkor technology CO., All Rights Reserved.
*/

/* Header files */
#include <string.h>
#include "tsv_error.h"

static ErrDef_t err_table[MAX_ERR_DEFINE_TABLE];

#define ERR_SET(val, name) \
{ \
	strcpy(err_table[val].err_name, name); \
}

void
err_init()
{
	ERR_SET(SUCCESS, "success");
	ERR_SET(ERROR_INVALID_PARAM, "invalid param");
	ERR_SET(ERROR_READ_CONFIG, "read config error");
	ERR_SET(ERROR_GET_ENV, "get env error");
	ERR_SET(ERROR_LOG_THREAD, "start log thread error");
	ERR_SET(ERROR_INVALID_PLATFORM, "invalid platform error");
	ERR_SET(ERROR_DB_INIT, "database init error");
	ERR_SET(ERROR_DB_PARSING_INSERT, "database parsing result insert error");
	ERR_SET(ERROR_NOT_PROD_LOT, "not prod data error");
	ERR_SET(ERROR_GET_OPERATION, "get operation error");
}

const char*
err_msg(int type)
{
	return err_table[type].err_name;
}
