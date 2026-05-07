/**
@file     atpTsv_env.h
@author   Kim, hyoung-joo
@version
  v0.0.1: 2015-08-18
@Description
  env header
@par Copyright:
  Copyright(c) 2015 Amkor technology CO., All Rights Reserved.
*/
#ifndef ENV_H__
#define ENV_H__

/* Header files */
#include "string_class.h"

/* Define varitables */
class CIniFile;

class CEnv
{
	/* Method */
  public:
	  CEnv();
	  ~CEnv();

	  /* initialize parser's environment variables
	   * from ini file */
	  void read(CIniFile&);

	/* Attributes */
  public:
	  /* Log */
	  CString m_log_dir;
	  int m_log_level;

	  /* Database */
	  CString m_server_name;
	  CString m_user_id;
	  CString m_passwd;
};

#endif /* ENV_H__ */
