/**
  @file     atpTsv_db.cpp
  @author   Kim, hyoung-joo
  @version
    v0.0.1: 2015-08-19
  @Description
    Toshiba DB Process implementation.
  @par Copyright:
    Copyright(c) 2015 Amkor technology CO., All Rights Reserved.
*/

/* Header files */
#include "tsv_main.h"

#ifdef _DBLOG
int 
err_handler(DBPROCESS * dbproc, int severity, int dberr, int oserr, char *dberrstr, char *oserrstr) 
{	 
	printf("(%d), (%d), (%d), (%s), (%s)\n", severity, dberr, oserr, dberrstr, oserrstr);

	return -1;
} 

int
msg_handler(DBPROCESS* dbproc, DBINT msgno, int msgstate, int severity, char* msgtext, char* srvname, char* procname, int line)
{
	printf("Msg %d, Level %d, State %d\n", msgno, severity, msgstate);

	if (strlen(srvname) > 0) 
		printf("Server '%s', ", srvname); 

	if (strlen(procname) > 0) 
		printf("Procedure '%s', ", procname); 

	if (line > 0) 
		printf("Line %d", line); 

	printf("\n%s\n", msgtext); 

	return(0); 
}
#endif

CDB::CDB()
{
	m_result = SUCCESS;

	memset(m_prefix, 0, sizeof(m_prefix));
	sprintf(m_prefix, "[DB]");

	int ret = dbinit();
	logging.debug("%s dbinit -> ret(%d)", m_prefix, ret);

	m_login = dblogin();
	if (m_login == NULL) {
		logging.error("%s dblogin -> fail.", m_prefix);
		m_result = ERROR_DB_INIT;
		return;
	}

	ret = DBSETLUSER(m_login, g_env.m_user_id);
	if (ret != 1) {
		logging.error("%s dbset user -> fail .. ret(%d)", m_prefix, ret);
		m_result = ERROR_DB_INIT;
		return;
	}

	ret = DBSETLPWD(m_login, g_env.m_passwd);
	if (ret != 1) {
		logging.error("%s dbset passwd -> fail .. ret(%d)", m_prefix, ret);
		m_result = ERROR_DB_INIT;
		return;
	}
}

CDB::~CDB()
{
	dbexit();

	if (m_login)
		dbloginfree(m_login);

	logging.debug("%s dbexit.", m_prefix);
}

int
CDB::get_result()
{
	return m_result;
}

int
CDB::set_parseing_result(Result_t* result)
{
	int ret;
	char sql_buf[BUFSIZ * 10];

	DBPROCESS* proc;

#ifdef _DBLOG
	dberrhandle(err_handler);
	dbmsghandle(msg_handler);
#endif

	memset(sql_buf, 0, sizeof(sql_buf));
	sprintf(sql_buf,
			"exec TSV.dbo.USP_Summary_Insert @sumName = '%s', @sumDirectory = '%s', @Platform = '%s', @Customer = '%s', @lotName = '%s', @dcc = '%s', @Device = '%s', @DeviceMA = '%s', @Operation = '%s', @LoadboardNo = '%s', @Temperature = '%s', @HandlerID = '%s', @HandlerType = '%s', @OperatorID = '%s', @TestProgram = '%s', @TestProgramExcel = '%s', @TestProgramRev = '%s', @ChannelMap = '%s', @CreateTime = '%s', @Tester = '%s', @PUIversion = '%s', @goodBin = %d, @goodYield = %.2f, @failBin = %d, @failYield = %.2f, @totalBin = %d, @HardBins = '%s', @summaryText = '%s', @editOperatorID = '%s', @comment = '%s', @SoftBins = '%s'",
			(const char*)result->m_summaryName, "", (const char*)result->m_platform, (const char*)result->m_customer, (const char*)result->m_lotName, 
			(const char*)result->m_dcc, (const char*)result->m_device, "", (const char*)result->m_operation, (const char*)result->m_loadBoardNo,
			(const char*)result->m_temperature, (const char*)result->m_handlerID, (const char*)result->m_handlerType, (const char*)result->m_operatorID, (const char*)result->m_testProgram,
			(const char*)result->m_testProgramExcel, (const char*)result->m_testProgramRev, (const char*)result->m_channelMap, (const char*)result->m_createTime, (const char*)result->m_tester,
			(const char*)result->m_PUIversion, result->m_goodBin, result->m_goodYield, result->m_failBin, result->m_failYield,
			result->m_totalBin, (const char*)result->m_hardBins, (const char*)result->m_summaryText, "", "", (const char*)result->m_softBins
		   );

	logging.debug("[DB] (%s)", sql_buf);

	proc = dbopen(m_login, g_env.m_server_name);
	if (proc == NULL) {
		logging.error("[DB] dbopen -> fail.");
		return ERROR_DB_PARSING_INSERT;
	}

	ret = dbcmd(proc, sql_buf);

	logging.debug("[DB] %s: dbcmd -> ret(%d)", __func__, ret);

	ret = dbsqlexec(proc);
	if (ret != 1) {
		logging.error("[DB] %s: dbsqlexec -> fail.", __func__);
		return ERROR_DB_PARSING_INSERT;
	}
	else {
		while ((ret = dbresults(proc)) != NO_MORE_RESULTS) {
			if ((ret == SUCCEED) && (DBROWS(proc) == SUCCEED)) {
				/* Bind column data to program variables */
			}

			while ((ret = dbnextrow(proc)) != NO_MORE_ROWS) {
				logging.debug("[DB] %s: dbnextrow", __func__);
			}
		}
	}   

	dbclose(proc);
	return 0;
}

int
CDB::set_txt_result(Result_t* result)
{
	int ret;
	char sql_buf[BUFSIZ];
	int ret2 = 0;

	DBPROCESS* proc;

#ifdef _DBLOG
	dberrhandle(err_handler);
	dbmsghandle(msg_handler);
#endif

	if (result->m_checkTitle.get_length() <= 0)
		return SUCCESS;

	CString opr;

	if (result->m_operation.left(2) == "FT") {
		opr = "TEST";
		opr += result->m_operation.right(result->m_operation.get_length() - 2);
	}
	else {
		opr = result->m_operation;
	}

	memset(sql_buf, 0, sizeof(sql_buf));
	sprintf(sql_buf,
			"exec TSV.dbo.USP_setCommonString_test @desc = '%s', @lotname = '%s', @realoperation = '%s', @dcc = '%s', @string1 = '%s', @string2 = '%s', @string3 = '%s', @string4 = '%s'",
			(const char*)result->m_checkTitle, (const char*)result->m_lotName, (const char*)opr, (const char*)result->m_dcc,
			(const char*)result->m_checkValue, "", "", ""
		   );

	logging.debug("[DB] (%s)", sql_buf);

	proc = dbopen(m_login, g_env.m_server_name);
	if (proc == NULL) {
		logging.error("[DB] dbopen -> fail.");
		return ERROR_DB_PARSING_INSERT;
	}

	ret = dbcmd(proc, sql_buf);

	logging.debug("[DB] %s: dbcmd -> ret(%d)", __func__, ret);

	ret = dbsqlexec(proc);
	if (ret != 1) {
		logging.error("[DB] %s: dbsqlexec -> fail.", __func__);
		return ERROR_DB_PARSING_INSERT;
	}
	else {
		while ((ret = dbresults(proc)) != NO_MORE_RESULTS) {
			if ((ret == SUCCEED) && (DBROWS(proc) == SUCCEED)) {
				/* Bind column data to program variables */
				ret = dbbind(proc, 1, INTBIND, (DBCHAR)0, (BYTE*)&ret2);
			}

			while ((ret = dbnextrow(proc)) != NO_MORE_ROWS) {
				logging.debug("%s %s: dbnextrow -> (%d)", m_prefix, __func__, ret2);
			}
		}
	}

	dbclose(proc);
	return ret2;
}

int
CDB::get_lot_list(CDB* db, Result_t* result, int (*func)(CDB* db, Result_t* result, const char* idx, const char* tester, const char* lot, const char* dcc, const char* operation, const char* job, const char* operator_id, const char* start_time, const char* end_time))
{
	int ret;
	char sql_buf[BUFSIZ];

	char idx[128];
	char tester[128];
	char lot[128];
	char dcc[128];
	char operation[128];
	char job[128];
	char operator_id[128];
	char start_time[128];
	char end_time[128];

	DBPROCESS* proc;

#ifdef _DBLOG
	dberrhandle(err_handler);
	dbmsghandle(msg_handler);
#endif

	memset(sql_buf, 0, sizeof(sql_buf));
	sprintf(sql_buf, "exec TSV.dbo.USP_M_getLotList");

	logging.debug("[DB] (%s)", sql_buf);

	proc = dbopen(m_login, g_env.m_server_name);
	if (proc == NULL) {
		logging.error("[DB] dbopen -> fail.");
		return -1;
	}

	ret = dbcmd(proc, sql_buf);

	logging.debug("[DB] %s: dbcmd -> ret(%d)", __func__, ret);

	ret = dbsqlexec(proc);
	if (ret != 1) {
		logging.error("[DB] %s: dbsqlexec -> fail.", __func__);
		return -1;
	}
	else {
		while ((ret = dbresults(proc)) != NO_MORE_RESULTS) {
			if ((ret == SUCCEED) && (DBROWS(proc) == SUCCEED)) {
				memset(idx, 0, sizeof(idx));
				memset(tester, 0, sizeof(tester));
				memset(lot, 0, sizeof(lot));
				memset(dcc, 0, sizeof(dcc));
				memset(operation, 0, sizeof(operation));
				memset(job, 0, sizeof(job));
				memset(operator_id, 0, sizeof(operator_id));
				memset(start_time, 0, sizeof(start_time));
				memset(end_time, 0, sizeof(end_time));

				/* Bind column data to program variables */
				ret = dbbind(proc, 1, STRINGBIND, (DBCHAR)0, (BYTE*)idx);
				ret = dbbind(proc, 2, STRINGBIND, (DBCHAR)0, (BYTE*)tester);
				ret = dbbind(proc, 3, STRINGBIND, (DBCHAR)0, (BYTE*)lot);
				ret = dbbind(proc, 4, STRINGBIND, (DBCHAR)0, (BYTE*)dcc);
				ret = dbbind(proc, 5, STRINGBIND, (DBCHAR)0, (BYTE*)operation);
				ret = dbbind(proc, 6, STRINGBIND, (DBCHAR)0, (BYTE*)job);
				ret = dbbind(proc, 7, STRINGBIND, (DBCHAR)0, (BYTE*)operator_id);
				ret = dbbind(proc, 8, STRINGBIND, (DBCHAR)0, (BYTE*)start_time);
				ret = dbbind(proc, 9, STRINGBIND, (DBCHAR)0, (BYTE*)end_time);
			}

			while ((ret = dbnextrow(proc)) != NO_MORE_ROWS) {
				logging.debug("[DB] %s: idx(%s),tester(%s),lot(%s),dcc(%s),oper(%s),job(%s),operid(%s),start(%s),end(%s)", __func__,
							  idx, tester, lot, dcc, operation, job, operator_id, start_time, end_time);

				func(db, result, idx, tester, lot, dcc, operation, job, operator_id, start_time, end_time);
			}
		}
	}   

	dbclose(proc);
	return 0;
}

int
CDB::set_summary(const char* idx, const char* tester, const char* lot, const char* dcc, const char* operation, const char* job, const char* operator_id, const char* start_time, const char* end_time, char* sum_no)
{
	int ret;
	char sql_buf[BUFSIZ];

	DBPROCESS* proc;

#ifdef _DBLOG
	dberrhandle(err_handler);
	dbmsghandle(msg_handler);
#endif

	memset(sql_buf, 0, sizeof(sql_buf));
	sprintf(sql_buf, "exec TSV.dbo.USP_M_setSummary %s, '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s'",
			idx, lot, dcc, operation, tester, operator_id, job, start_time, end_time);

	logging.debug("[DB] (%s)", sql_buf);

	proc = dbopen(m_login, g_env.m_server_name);
	if (proc == NULL) {
		logging.error("[DB] dbopen -> fail.");
		return -1;
	}

	ret = dbcmd(proc, sql_buf);

	logging.debug("[DB] %s: dbcmd -> ret(%d)", __func__, ret);

	ret = dbsqlexec(proc);
	if (ret != 1) {
		logging.error("[DB] %s: dbsqlexec -> fail.", __func__);
		return -1;
	}
	else {
		while ((ret = dbresults(proc)) != NO_MORE_RESULTS) {
			if ((ret == SUCCEED) && (DBROWS(proc) == SUCCEED)) {

				/* Bind column data to program variables */
				ret = dbbind(proc, 1, STRINGBIND, (DBCHAR)0, (BYTE*)sum_no);
			}

			while ((ret = dbnextrow(proc)) != NO_MORE_ROWS) {
				logging.debug("[DB] %s: sum_no(%s)", __func__, sum_no);
			}
		}
	}   

	dbclose(proc);
	return 0;
}

int
CDB::get_summary_text(const char* lot, const char* dcc, const char* sum_no, const char* start_time, const char* end_time, char* summary_text)
{
	int ret;
	char sql_buf[BUFSIZ];

	DBPROCESS* proc;

#ifdef _DBLOG
	dberrhandle(err_handler);
	dbmsghandle(msg_handler);
#endif

	memset(sql_buf, 0, sizeof(sql_buf));
	sprintf(sql_buf, "exec TSV.dbo.USP_M_getSummaryText '%s', '%s', '%s', '%s', '%s'", lot, dcc, sum_no, start_time, end_time);

	logging.debug("[DB] (%s)", sql_buf);

	proc = dbopen(m_login, g_env.m_server_name);
	if (proc == NULL) {
		logging.error("[DB] dbopen -> fail.");
		return -1;
	}

	ret = dbcmd(proc, sql_buf);

	logging.debug("[DB] %s: dbcmd -> ret(%d)", __func__, ret);

	ret = dbsqlexec(proc);
	if (ret != 1) {
		logging.error("[DB] %s: dbsqlexec -> fail.", __func__);
		return -1;
	}
	else {
		while ((ret = dbresults(proc)) != NO_MORE_RESULTS) {
			if ((ret == SUCCEED) && (DBROWS(proc) == SUCCEED)) {
				ret = dbbind(proc, 1, STRINGBIND, (DBCHAR)0, (BYTE*)summary_text);
			}

			while ((ret = dbnextrow(proc)) != NO_MORE_ROWS) {
			}
		}
	}   

	dbclose(proc);
	return 0;

}

int
CDB::get_sbin_summary(const char* lot, const char* dcc, const char* sum_no, const char* mod, const char* start_time, const char* end_time, Result_t* result)
{
	int ret;
	char sql_buf[BUFSIZ];

	int num = 0;
	char station[1024];
	char pass_fail[128];
	int s_qty[MAX_SITE];

	DBPROCESS* proc;

#ifdef _DBLOG
	dberrhandle(err_handler);
	dbmsghandle(msg_handler);
#endif

	memset(sql_buf, 0, sizeof(sql_buf));
	sprintf(sql_buf, "exec TSV.dbo.USP_M_getSBinSummary '%s', '%s', '%s', '%s', '%s', '%s'", lot, dcc, sum_no, mod, start_time, end_time);

	logging.debug("[DB] (%s)", sql_buf);

	proc = dbopen(m_login, g_env.m_server_name);
	if (proc == NULL) {
		logging.error("[DB] dbopen -> fail.");
		return -1;
	}

	ret = dbcmd(proc, sql_buf);

	logging.debug("[DB] %s: dbcmd -> ret(%d)", __func__, ret);

	ret = dbsqlexec(proc);
	if (ret != 1) {
		logging.error("[DB] %s: dbsqlexec -> fail.", __func__);
		return -1;
	}
	else {
		while ((ret = dbresults(proc)) != NO_MORE_RESULTS) {
			if ((ret == SUCCEED) && (DBROWS(proc) == SUCCEED)) {
				num = 0;
				memset(station, 0, sizeof(station));
				memset(pass_fail, 0, sizeof(pass_fail));
				memset(s_qty, 0, sizeof(s_qty));

				/* Bind column data to program variables */
				ret = dbbind(proc, 1, INTBIND, (DBCHAR)0, (BYTE*)&num);
				ret = dbbind(proc, 2, STRINGBIND, (DBCHAR)0, (BYTE*)station);
				ret = dbbind(proc, 3, STRINGBIND, (DBCHAR)0, (BYTE*)pass_fail);

				for (int i = 0; i < MAX_SITE; i++) {
					ret = dbbind(proc, 4 + i, INTBIND, (DBCHAR)0, (BYTE*)&(s_qty[i]));
				}
			}

			while ((ret = dbnextrow(proc)) != NO_MORE_ROWS) {
				logging.debug("[DB] %s: num(%d) -> station(%s),pass/fail(%s)", __func__, num, station, pass_fail);
				assemble_bin(result, num, station, pass_fail, s_qty);
			}
		}
	}   

	dbclose(proc);
	return 0;
}

int
CDB::set_summary_text(const char* sum_no, const char* summary_text)
{
	int ret;
	char sql_buf[BUFSIZ*10];

	DBPROCESS* proc;

#ifdef _DBLOG
	dberrhandle(err_handler);
	dbmsghandle(msg_handler);
#endif

	memset(sql_buf, 0, sizeof(sql_buf));
	sprintf(sql_buf, "exec TSV.dbo.USP_setSummaryText %s, '%s'", sum_no, summary_text);

	logging.debug("[DB] (%s)", sql_buf);

	proc = dbopen(m_login, g_env.m_server_name);
	if (proc == NULL) {
		logging.error("[DB] dbopen -> fail.");
		return -1;
	}

	ret = dbcmd(proc, sql_buf);

	logging.debug("[DB] %s: dbcmd -> ret(%d)", __func__, ret);

	ret = dbsqlexec(proc);
	if (ret != 1) {
		logging.error("[DB] %s: dbsqlexec -> fail.", __func__);
		return -1;
	}
	else {
		while ((ret = dbresults(proc)) != NO_MORE_RESULTS) {
			if ((ret == SUCCEED) && (DBROWS(proc) == SUCCEED)) {
				/* Bind column data to program variables */
			}

			while ((ret = dbnextrow(proc)) != NO_MORE_ROWS) {
			}
		}
	}   

	dbclose(proc);
	return 0;
}

int
CDB::get_error_summary(const char* lot, const char* dcc, const char* sum_no, const char* mod, const char* start_time, const char* end_time, char* summary_text)
{
	int ret;
	char sql_buf[BUFSIZ];
	char error_msg[BUFSIZ*10];

	DBPROCESS* proc;

#ifdef _DBLOG
	dberrhandle(err_handler);
	dbmsghandle(msg_handler);
#endif

	memset(sql_buf, 0, sizeof(sql_buf));
	sprintf(sql_buf, "exec TSV.dbo.USP_M_getSBinSummary '%s', '%s', '%s', '%s', '%s', '%s'", lot, dcc, sum_no, mod, start_time, end_time);

	logging.debug("[DB] (%s)", sql_buf);

	proc = dbopen(m_login, g_env.m_server_name);
	if (proc == NULL) {
		logging.error("[DB] dbopen -> fail.");
		return -1;
	}

	ret = dbcmd(proc, sql_buf);

	logging.debug("[DB] %s: dbcmd -> ret(%d)", __func__, ret);

	ret = dbsqlexec(proc);
	if (ret != 1) {
		logging.error("[DB] %s: dbsqlexec -> fail.", __func__);
		return -1;
	}
	else {
		while ((ret = dbresults(proc)) != NO_MORE_RESULTS) {
			if ((ret == SUCCEED) && (DBROWS(proc) == SUCCEED)) {
				memset(error_msg, 0, sizeof(error_msg));

				/* Bind column data to program variables */
				ret = dbbind(proc, 1, STRINGBIND, (DBCHAR)0, (BYTE*)error_msg);
			}

			while ((ret = dbnextrow(proc)) != NO_MORE_ROWS) {
				sprintf(summary_text + strlen(summary_text), "%s", error_msg);
			}
		}
	}   

	dbclose(proc);
	return 0;
}

int
CDB::get_unit_result(const char* lot, const char* dcc, const char* operation, const char* tester, const char* start_time, const char* end_time, const char* aid, const char* sid, 
					 void (*func)(const char* operation, const char* sn, const char* result, const char* aid, const char* sid))
{
	int ret;
	char sql_buf[BUFSIZ];
	char sn[1024];
	char result[1024];

	DBPROCESS* proc;

#ifdef _DBLOG
	dberrhandle(err_handler);
	dbmsghandle(msg_handler);
#endif

	memset(sql_buf, 0, sizeof(sql_buf));
	sprintf(sql_buf, "exec TSV.dbo.USP_M_getUnitResult '%s', '%s', '%s', '%s', '%s', '%s'", lot, dcc, operation, tester, start_time, end_time);

	logging.debug("[DB] (%s)", sql_buf);

	proc = dbopen(m_login, g_env.m_server_name);
	if (proc == NULL) {
		logging.error("[DB] dbopen -> fail.");
		return -1;
	}

	ret = dbcmd(proc, sql_buf);

	logging.debug("[DB] %s: dbcmd -> ret(%d)", __func__, ret);

	ret = dbsqlexec(proc);
	if (ret != 1) {
		logging.error("[DB] %s: dbsqlexec -> fail.", __func__);
		return -1;
	}
	else {
		while ((ret = dbresults(proc)) != NO_MORE_RESULTS) {
			if ((ret == SUCCEED) && (DBROWS(proc) == SUCCEED)) {
				memset(sn, 0, sizeof(sn));
				memset(result, 0, sizeof(result));

				/* Bind column data to program variables */
				ret = dbbind(proc, 1, STRINGBIND, (DBCHAR)0, (BYTE*)sn);
				ret = dbbind(proc, 2, STRINGBIND, (DBCHAR)0, (BYTE*)result);
			}

			while ((ret = dbnextrow(proc)) != NO_MORE_ROWS) {
				func(operation, sn, result, aid, sid);
			}
		}
	}   

	dbclose(proc);
	return 0;
}

int
CDB::get_unit_result_test(const char* lot, const char* dcc, const char* operation, const char* tester, const char* start_time, const char* end_time, const char* aid, const char* sid, 
					 void (*func)(const char* operation, const char* sn, const char* result, const char* aid, const char* sid, const char* tester, const char* start_time, const char* site, const char* fails))
{
	int ret;
	char sql_buf[BUFSIZ];
	char sn[1024];
	char result[1024];
	char site[24];
	char fails[4096];
	char st_time[1024];

	DBPROCESS* proc;

#if 1 /* 2019.09.21 */
	FILE* fp = fopen("/tmp/get_unit_result_wodate.list", "w");
	if (fp == NULL)
		return -1;
#endif

#ifdef _DBLOG
	dberrhandle(err_handler);
	dbmsghandle(msg_handler);
#endif

	memset(sql_buf, 0, sizeof(sql_buf));
#if 0
	sprintf(sql_buf, "exec TSV.dbo.USP_M_getUnitResult_Test '%s', '%s', '%s', '%s', '%s', '%s'", lot, dcc, operation, tester, start_time, end_time);
#else
	sprintf(sql_buf, "exec TSV.dbo.USP_M_getUnitResult_bench '%s', '%s', '%s', '%s', '%s', '%s'", lot, dcc, operation, tester, start_time, end_time);
#endif

	logging.debug("[DB] (%s)", sql_buf);

	proc = dbopen(m_login, g_env.m_server_name);
	if (proc == NULL) {
		logging.error("[DB] dbopen -> fail.");
		return -1;
	}

	ret = dbcmd(proc, sql_buf);

	logging.debug("[DB] %s: dbcmd -> ret(%d)", __func__, ret);

	ret = dbsqlexec(proc);
	if (ret != 1) {
		logging.error("[DB] %s: dbsqlexec -> fail.", __func__);
		return -1;
	}
	else {
		while ((ret = dbresults(proc)) != NO_MORE_RESULTS) {
			if ((ret == SUCCEED) && (DBROWS(proc) == SUCCEED)) {
				memset(sn, 0, sizeof(sn));
				memset(result, 0, sizeof(result));
				memset(site, 0, sizeof(site));
				memset(fails, 0, sizeof(fails));
				memset(st_time, 0, sizeof(st_time));

				/* Bind column data to program variables */
				ret = dbbind(proc, 1, STRINGBIND, (DBCHAR)0, (BYTE*)sn);
				ret = dbbind(proc, 2, STRINGBIND, (DBCHAR)0, (BYTE*)result);
				ret = dbbind(proc, 3, STRINGBIND, (DBCHAR)0, (BYTE*)site);
				ret = dbbind(proc, 4, STRINGBIND, (DBCHAR)0, (BYTE*)fails);
				ret = dbbind(proc, 5, STRINGBIND, (DBCHAR)0, (BYTE*)st_time);
			}

			while ((ret = dbnextrow(proc)) != NO_MORE_ROWS) {
#if 0 /* 2019.09.21 */
				func(operation, sn, result, aid, sid, tester, st_time, site, fails);
#else
				fprintf(fp, "%s|%s|%s|%s|%s\n", sn, result, site, fails, st_time);
#endif
			}
		}
	}   

#if 1 /* 2019.09.21 */
	fclose(fp);
#endif
	dbclose(proc);
	return 0;
}

int
CDB::get_amkorid(const char* lot, const char* dcc, char* aid, char* sid)
{
	int ret;
	char sql_buf[BUFSIZ];

	DBPROCESS* proc;

#ifdef _DBLOG
	dberrhandle(err_handler);
	dbmsghandle(msg_handler);
#endif

	memset(sql_buf, 0, sizeof(sql_buf));
	sprintf(sql_buf, "exec WaferMap.dbo.USP_GetAmkorSubID_DATA400 '%s', '%s'", lot, dcc);

	logging.debug("[DB] (%s)", sql_buf);

	proc = dbopen(m_login, g_env.m_server_name);
	if (proc == NULL) {
		logging.error("[DB] dbopen -> fail.");
		return -1;
	}

	ret = dbcmd(proc, sql_buf);

	logging.debug("[DB] %s: dbcmd -> ret(%d)", __func__, ret);

	ret = dbsqlexec(proc);
	if (ret != 1) {
		logging.error("[DB] %s: dbsqlexec -> fail.", __func__);
		return -1;
	}
	else {
		while ((ret = dbresults(proc)) != NO_MORE_RESULTS) {
			if ((ret == SUCCEED) && (DBROWS(proc) == SUCCEED)) {

				/* Bind column data to program variables */
				ret = dbbind(proc, 1, STRINGBIND, (DBCHAR)0, (BYTE*)aid);
				ret = dbbind(proc, 2, STRINGBIND, (DBCHAR)0, (BYTE*)sid);
			}

			while ((ret = dbnextrow(proc)) != NO_MORE_ROWS) {
				logging.debug("%s, %d: Lot(%s),Dcc(%s) -> AID(%s),SID(%s)", __func__, __LINE__, lot, dcc, aid, sid);
			}
		}
	}   

	dbclose(proc);
	return 0;
}

int
CDB::get_unit_result_wodate(const char* lot, const char* dcc, const char* operation, char* buff)
{
	int ret;
	char sql_buf[BUFSIZ];
	char sn[1024];
	char result[1024];
	char site[24];
	char fails[4096];
	char st_time[1024];

	DBPROCESS* proc;

	FILE* fp = fopen("/tmp/get_unit_result_wodate.list", "w");
	if (fp == NULL)
		return -1;

#ifdef _DBLOG
	dberrhandle(err_handler);
	dbmsghandle(msg_handler);
#endif

	memset(sql_buf, 0, sizeof(sql_buf));
	sprintf(sql_buf, "exec TSV.dbo.USP_M_getUnitResult_woDateTime '%s', '%s', '%s'", lot, dcc, operation);

	logging.debug("[DB] (%s)", sql_buf);

	proc = dbopen(m_login, g_env.m_server_name);
	if (proc == NULL) {
		logging.error("[DB] dbopen -> fail.");
		return -1;
	}

	ret = dbcmd(proc, sql_buf);

	logging.debug("[DB] %s: dbcmd -> ret(%d)", __func__, ret);

	ret = dbsqlexec(proc);
	if (ret != 1) {
		logging.error("[DB] %s: dbsqlexec -> fail.", __func__);
		return -1;
	}
	else {
		while ((ret = dbresults(proc)) != NO_MORE_RESULTS) {
			if ((ret == SUCCEED) && (DBROWS(proc) == SUCCEED)) {
				memset(sn, 0, sizeof(sn));
				memset(result, 0, sizeof(result));
				memset(site, 0, sizeof(site));
				memset(fails, 0, sizeof(fails));
				memset(st_time, 0, sizeof(st_time));

				/* Bind column data to program variables */
				ret = dbbind(proc, 1, STRINGBIND, (DBCHAR)0, (BYTE*)sn);
				ret = dbbind(proc, 2, STRINGBIND, (DBCHAR)0, (BYTE*)result);
				ret = dbbind(proc, 3, STRINGBIND, (DBCHAR)0, (BYTE*)site);
				ret = dbbind(proc, 4, STRINGBIND, (DBCHAR)0, (BYTE*)fails);
				ret = dbbind(proc, 5, STRINGBIND, (DBCHAR)0, (BYTE*)st_time);
			}

			while ((ret = dbnextrow(proc)) != NO_MORE_ROWS) {
				//sprintf(buff + strlen(buff), "%s,%s,%s,%s,%s\n", sn, result, site, fails, st_time);
				fprintf(fp, "%s|%s|%s|%s|%s\n", sn, result, site, fails, st_time);
				//logging.debug("%s, %d: sn(%s),ret(%s),site(%s),fail(%s),st_time(%s)", __func__, __LINE__, sn, result, site, fails, st_time);
			}
		}
	}   

	fclose(fp);
	dbclose(proc);
	return 0;
}

