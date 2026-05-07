/**
@file     atpTsv_env.cpp
@author   Kim, hyoung-joo
@version
  v0.0.1: 2015-08-18
@Description
  env source
@par Copyright:
  Copyright(c) 2015 Amkor technology CO., All Rights Reserved.
*/
/* Header files */
#include <stdlib.h>
#include "tsv_env.h"
#include "fw_ini_file.h"

CEnv::CEnv()
{
}

CEnv::~CEnv()
{
}

void CEnv::read(CIniFile& file)
{
	CString section, key;
	
	/* Log section */
	section = "log";

	key = "log_dir";
	m_log_dir = file.get_value(section, key, "../log/");

	key = "log_level";
	m_log_level = atoi(file.get_value(section, key, "30"));

	/* Database */
	section = "database";
	key = "server_name";
	m_server_name = file.get_value(section, key, "CIMitar_ATV");

	key = "user";
	m_user_id = file.get_value(section, key, "cimitar2");

	key = "passwd";
	m_passwd = file.get_value(section, key, "TFAtest1!2!");
}
