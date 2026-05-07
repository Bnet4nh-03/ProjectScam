/**
  @file     atpTsv_db.h
  @author   Kim, hyoung-joo
  @version
    v0.0.1: 2015-08-19
  @Description
    Toshiba parser DB Process header.
  @par Copyright:
    Copyright(c) 2015 Amkor technology CO., All Rights Reserved.
*/

#ifndef DB_H__
#define DB_H__

/* Header files */
#include <list>
#include <sybdb.h>
#include "string_class.h"
#include "tsv_summary.h"

/* Define varitables */
class CDB
{
	/* Method */
  public:
	  CDB();
	  ~CDB();

	  int get_result();
	  int set_parseing_result(Result_t* result);
	  int set_txt_result(Result_t* result);

	  int get_lot_list(CDB* db, Result_t* result, int (*func)(CDB* db, Result_t* result, const char* idx, const char* tester, const char* lot, const char* dcc, const char* operation, const char* job, const char* operator_id, const char* start_time, const char* end_time));
	  int set_summary(const char* idx, const char* tester, const char* lot, const char* dcc, const char* operation, const char* job, const char* operator_id, const char* start_time, const char* end_time, char* sum_no);
	  int get_summary_text(const char* lot, const char* dcc, const char* sum_no, const char* start_time, const char* end_time, char* summary_text);
	  int get_sbin_summary(const char* lot, const char* dcc, const char* sum_no, const char* mod, const char* start_time, const char* end_time, Result_t* result);
	  int set_summary_text(const char* sum_no, const char* summary_text);
	  int get_error_summary(const char* lot, const char* dcc, const char* sum_no, const char* mod, const char* start_time, const char* end_time, char* summary_text);
	  int get_unit_result(const char* lot, const char* dcc, const char* operation, const char* tester, const char* start_time, const char* end_time, const char* aid, const char* sid, void (*func)(const char* operation, const char* sn, const char* result, const char* aid, const char* sid));
	  int get_amkorid(const char* lot, const char* dcc, char* aid, char* sid);

	  int get_unit_result_test(const char* lot, const char* dcc, const char* operation, const char* tester, const char* start_time, const char* end_time, const char* aid, const char* sid, 
							   void (*func)(const char* operation, const char* sn, const char* result, const char* aid, const char* sid, const char* tester, const char* start_time, const char* site, const char* fails));

	  int get_unit_result_wodate(const char* lot, const char* dcc, const char* operation, char* buff);

	  /* Attributes */
  private:
	  LOGINREC* m_login;
	  int m_result;
	  char m_prefix[64];
};

#endif /* DB_H__ */
