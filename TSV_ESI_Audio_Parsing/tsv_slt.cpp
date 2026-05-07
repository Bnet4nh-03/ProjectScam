/**
@file     atpTsv_slt.cpp
@author   Kim, hyoung-joo
@version
  v0.0.1: 2015-08-20
@Description
  env source
@par Copyright:
  Copyright(c) 2015 Amkor technology CO., All Rights Reserved.
*/
/* Header files */
#include "tsv_main.h"

static void
summary_parser_slt_by_line2(const char* line, Result_t* result)
{
	CString str = line;
	str.trim_right();
	str.trim_left();

	if (str.get_length() <= 0)
		return;

	int start = 0;
	int end = 0;

	/* Header -> [Field] : [Value] */
	end = str.find(':', start);
	if (end != -1) {
		CString field = str.mid(start, end - start);
		field.trim_right();

		start = end + 1;

		CString value = str.mid(start, str.get_length() - start);
		value.trim_left();
		value.trim_right();

		if (field.left(3) == "BIN") {
			const char* bin = field.right(field.get_length() - 3);
			const char* qty = value;

			result->m_totalBin += atoi(qty);

			logging.debug("%s, %d: HARD: bin(%s),qty(%s),total(%d)\n", __func__, __LINE__, bin, qty, result->m_totalBin);
		}
	}
}

static int
set_total_qty(const char* summary, Result_t* result)
{
	FILE* fp = fopen(summary, "r");
	if (fp == NULL) {
		logging.error("%s, %d: file open error !!", __func__, __LINE__);
		return -1;
	}

	char read_buf[2048];

	while (!feof(fp)) {
		memset(read_buf, 0, sizeof(read_buf));

		if (!fgets(read_buf, sizeof(read_buf), fp))
			break;
		
		summary_parser_slt_by_line2(read_buf, result);
	}

	fclose(fp);
	return SUCCESS;
}

int
summary_parser_slt(const char* summary, Result_t* result)
{
	set_total_qty(summary, result);

	FILE* fp = fopen(summary, "r");
	if (fp == NULL) {
		logging.error("%s, %d: file open error !!", __func__, __LINE__);
		return -1;
	}

	char read_buf[2048];

	while (!feof(fp)) {
		memset(read_buf, 0, sizeof(read_buf));

		if (!fgets(read_buf, sizeof(read_buf), fp))
			break;
		
		result->m_summaryText += (const char*)read_buf;

		summary_parser_slt_by_line(read_buf, result);
	}

	result->m_goodYield = (double)result->m_goodBin * 100 / result->m_totalBin;
	result->m_failYield = (double)result->m_failBin * 100 / result->m_totalBin;

	fclose(fp);
	return SUCCESS;
}

void
summary_parser_slt_by_line(const char* line, Result_t* result)
{
	CString str = line;
	str.trim_right();
	str.trim_left();

	if (str.get_length() <= 0)
		return;

	int start = 0;
	int end = 0;

	/* Header -> [Field] : [Value] */
	end = str.find(':', start);
	if (end != -1) {
		CString field = str.mid(start, end - start);
		field.trim_right();

		start = end + 1;

		CString value = str.mid(start, str.get_length() - start);
		value.trim_left();
		value.trim_right();

		if (field == "LOT") {
			result->m_lotName = value;
		} else
		if (field == "DEVICE") {
			result->m_device = value;
		} else
		if (field == "OPERATOR") {
			result->m_operatorID = value;
		} else
		if (field == "OPERATION") {
			result->m_operation = value;
		} else
		if (field == "INSERTION") {
			/* 1A: Full Test, 2A: 1st retest, 3A: 2nd retest */
			if (result->m_operation.left(3) == "SLT") {
				CString tmp;

				if (value == "1A") {
					tmp = result->m_operation;
				} else
				if (value == "2A") { /* 1SR1 */
					tmp = result->m_operation.right(result->m_operation.get_length() - 3/*3:SLT*/);
					tmp += "SR1";
				} else
				if (value == "3A") {
					tmp = result->m_operation.right(result->m_operation.get_length() - 3/*3:SLT*/);
					tmp += "SR2";
				} else
				if (value == "4A") {
					tmp = result->m_operation.right(result->m_operation.get_length() - 3/*3:SLT*/);
					tmp += "SR3";
				}
			
				result->m_operation = tmp;
			}
		} else
		if (field == "BOARD") {
			result->m_loadBoardNo = value;
		} else
		if (field == "HANDLER") {
			result->m_handlerID = value;
		} else
		if (field == "PROGRAM") {
			result->m_testProgram = value;
		} else
		if (field == "TESTER") {
			result->m_tester = value;
		} else
		if (field.left(3) == "BIN") {
			const char* bin = field.right(field.get_length() - 3);
			const char* qty = value;

			if (atoi(qty) <= 0)
				return;

			if (atoi(bin) == 1) {
				result->m_goodBin += atoi(qty);

				char tmp1[BUFSIZ];
				memset(tmp1, 0, sizeof(tmp1));
				double yld = (double)atoi(qty) * 100 / result->m_totalBin;
				sprintf(tmp1, "%.2f", yld);

				result->m_hardBins += "1,1,";
				result->m_hardBins += qty;
				result->m_hardBins += ",";
				result->m_hardBins += tmp1;
				result->m_hardBins += "/";
			
				logging.debug("%s, %d: HARD: bin(%s),qty(%s),yld(%.2f)", __func__, __LINE__, bin, qty, yld);
			}
			else {
				result->m_failBin += atoi(qty);

				char tmp1[BUFSIZ];
				memset(tmp1, 0, sizeof(tmp1));
				double yld = (double)atoi(qty) * 100 / result->m_totalBin;
				sprintf(tmp1, "%.2f", yld);

				result->m_hardBins += bin;
				result->m_hardBins +=",0,";
				result->m_hardBins += qty;
				result->m_hardBins += ",";
				result->m_hardBins += tmp1;
				result->m_hardBins += "/";

				logging.debug("%s, %d: HARD: bin(%s),qty(%s),yld(%.2f)", __func__, __LINE__, bin, qty, yld);
			}
		}
	} else {
		/* No Action */
	}
}
