/**
@file     atpTsv_error.h
@author   Kim, hyoung-joo
@version
  v0.0.1: 2015-08-18
@Description
  error header
@par Copyright:
  Copyright(c) 2015 Amkor technology CO., All Rights Reserved.
*/

#ifndef ERROR_H__
#define ERROR_H__

/* Define error type */
enum {
	SUCCESS = 0,

	ERROR_INVALID_PARAM = 1,
	ERROR_READ_CONFIG,
	ERROR_GET_ENV,
	ERROR_LOG_THREAD,

	ERROR_INVALID_PLATFORM,
	ERROR_DB_INIT,
	ERROR_DB_PARSING_INSERT,
	ERROR_NOT_PROD_LOT,
	ERROR_GET_OPERATION,
};

/* Define varitables */
typedef struct {
	char err_name[128];
} ErrDef_t;

#define MAX_ERR_DEFINE_TABLE 10

/* Functions */
void err_init();
const char* err_msg(int type);

#endif /* ERROR_H__ */
