/**
@file     atpTsv_summary.h
@author   Kim, hyoung-joo
@version
  v0.0.1: 2015-08-18
@Description
  env header
@par Copyright:
  Copyright(c) 2015 Amkor technology CO., All Rights Reserved.
*/
#ifndef SUMMARY_H__
#define SUMMARY_H__

/* Header files */
#include "string_class.h"
#include <map>

using namespace std;

/* Define varitables */
typedef struct {
#define MAX_SITE	32
	int	m_bin[MAX_SITE];
} Bin_t;
typedef map<CString/*PASS/FAIL*/, Bin_t*> BinInfo_t;
typedef map<int/*ART*/, BinInfo_t*> ArtBin_t;
typedef map<CString/*station*/, ArtBin_t*> SltBin_t;

typedef struct Result
{
  Result() : m_goodBin(0),m_failBin(0),m_totalBin(0) {}
	CString m_summaryName;
	CString m_platform;
	CString m_customer;
	CString m_lotName;
	CString m_dcc;
	CString m_device;
	CString m_mode;
	CString m_operation;
	CString m_loadBoardNo;
	CString m_temperature;
	CString m_handlerID;
	CString m_handlerType;
	CString m_operatorID;
	CString m_testProgram;
	CString m_testProgramRev;
	CString m_testProgramExcel;
	CString m_channelMap;
	CString m_createTime;
	CString m_tester;
	CString m_PUIversion;
	CString m_checkTitle;
	CString m_checkValue;
	CString m_startTime;
	CString m_endTime;

	int m_goodBin;
	double m_goodYield;

	int m_failBin;
	double m_failYield;

	int m_totalBin;
	CString m_hardBins;
	CString m_softBins;
	CString m_summaryText;

	SltBin_t m_sltBin;
} Result_t;

class CSummary
{
	/* Method */
  public:
	  CSummary();
	  ~CSummary();

	  int get_result() { return m_result; }
  private:
	  int summary_parser(const char* summary, const char* platform, Result_t* result);
	  void show_result(Result_t* result);

	/* Attributes */
  private:
	  int m_result;

	  Result_t* m_summaryResult;
};

void assemble_bin(Result_t* result, int num, const char* station, const char* pass_fail, int* s_qty);
void manual_ng_upload(const char* aid, const char* sid, const char* operation, const char* tester);

#endif /* SUMMARY_H__ */
