/**
@file     atpTsv_summary.cpp
@author   Kim, hyoung-joo
@version
  v0.0.1: 2015-08-18
@Description
  env source
@par Copyright:
  Copyright(c) 2015 Amkor technology CO., All Rights Reserved.
*/
/* Header files */
#include "tsv_main.h"

#if 0
static int s_total_qty = 0;
static int s_good_qty = 0;
static int s_fail_qty = 0;
static int
//processing_total_summary(char* summary_text, const int order, const char* good_qty, const char* fail_qty, const char* total_qty, const char* good_yld, const char* fail_yld)
processing_total_summary(char* summary_text)
{
#if 0
	logging.debug("%s, %d: order(%d) -> IN(%s),Good(%s),Fail(%s),Yield(%s)", __func__, __LINE__, order, total_qty, good_qty, fail_qty, good_yld);

	printf("%d\t%s\t%s\t%s\t%s%%\n", order, total_qty, good_qty, fail_qty, good_yld);

	switch (order) {
		case 0: { s_total_qty = atoi(total_qty); s_good_qty = atoi(good_qty); } break;
		case 1: { s_good_qty += atoi(good_qty); } break;
		case 2: { s_good_qty += atoi(good_qty); s_fail_qty = atoi(fail_qty); } break;
	}
#else
#endif

	return 0;
}
#endif

#if 0
static int
get_total_bin(SltBin_t* sbin, int num, const char* pass_fail)
{
	int total = 0;

	SltBin_t::iterator it1;
	for (it1 = sbin->begin(); it1 != sbin->end(); it1++) {
		ArtBin_t::iterator it2;
		ArtBin_t* abin = it1->second;
		for (it2 = abin->begin(); it2 != abin->end(); it2++) {
			BinInfo_t::iterator it3;
			BinInfo_t* info = it2->second;
			int art = it2->first;
			if (art != num)
				continue;

			for (it3 = info->begin(); it3 != info->end(); it3++) {
				Bin_t* bin = it3->second;
				const char* pf = it3->first;
				if (strcmp(pf, pass_fail))
					continue;

				total += bin->m_bin[0];
				total += bin->m_bin[1];
				total += bin->m_bin[2];
				total += bin->m_bin[3];
				total += bin->m_bin[4];
				total += bin->m_bin[5];
				total += bin->m_bin[6];
				total += bin->m_bin[7];
			}
		}
	}

	return total;
}

static void
printf_bin(SltBin_t* sbin, int num, const char* pass_fail, char* summary_text)
{
	SltBin_t::iterator it1;
	for (it1 = sbin->begin(); it1 != sbin->end(); it1++) {
		ArtBin_t::iterator it2;
		ArtBin_t* abin = it1->second;
		for (it2 = abin->begin(); it2 != abin->end(); it2++) {
			BinInfo_t::iterator it3;
			BinInfo_t* info = it2->second;
			int art = it2->first;
			if (art != num)
				continue;

			for (it3 = info->begin(); it3 != info->end(); it3++) {
				Bin_t* bin = it3->second;
				const char* pf = it3->first;
				if (strcmp(pf, pass_fail))
					continue;

				sprintf(summary_text + strlen(summary_text), "%d\t%d\t%d\t%d\t%d\t%d\t%d\t%d\t", bin->m_bin[0], bin->m_bin[1], bin->m_bin[2], bin->m_bin[3], bin->m_bin[4], bin->m_bin[5], bin->m_bin[6], bin->m_bin[7]);
			}
		}
	}
	sprintf(summary_text + strlen(summary_text), "\n");
}
#endif

static void
make_sbin_summary(SltBin_t* sbin, char* summary_text, const char* operation)
{
	SltBin_t::iterator it1;

	int max_site = 0;

	if (!strncmp(operation, "TEST", 4)) {
		sprintf(summary_text + strlen(summary_text), "\nStation\t\t\tART\tPF\tTotal\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\t11\t12\t13\t14\t15\t16\t17\t18\t19\t20\t21\t22\t23\t24\t25\t26\t27\t28\t29\t30\t31\t32\t");
		max_site = 32;
	}
	else {
		sprintf(summary_text + strlen(summary_text), "\nStation\t\t\tART\tPF\tTotal\t1\t2\t3\t4\t5\t6\t7\t8\t");
		max_site = 8;
	}
	sprintf(summary_text + strlen(summary_text), "\n");

	for (it1 = sbin->begin(); it1 != sbin->end(); it1++) {
		const char* station = it1->first;
		ArtBin_t* abin = it1->second;
		ArtBin_t::iterator it2;

		bool is_station = false;

		for (it2 = abin->begin(); it2 != abin->end(); it2++) {
			int art = it2->first;
			BinInfo_t* info = it2->second;
			BinInfo_t::iterator it3;

			for (it3 = info->begin(); it3 != info->end(); it3++) {
				const char* pass_fail = it3->first;
				Bin_t* bin = it3->second;

				int total = 0;
				for (int i = 0; i < max_site; i++) {
					total += bin->m_bin[i];
				}

				if (is_station == false) {
					
					sprintf(summary_text + strlen(summary_text), "%s\t\t%d\t%s\t%d", station, art-1, pass_fail, total);

					for (int i = 0; i < max_site; i++) {
						sprintf(summary_text + strlen(summary_text), "\t%d", bin->m_bin[i]);
					}

					sprintf(summary_text + strlen(summary_text), "\n");
					is_station = true;
				}
				else {
					sprintf(summary_text + strlen(summary_text), "%s\t\t%d\t%s\t%d", "", art-1, pass_fail, total);

					for (int i = 0; i < max_site; i++) {
						sprintf(summary_text + strlen(summary_text), "\t%d", bin->m_bin[i]);
					}

					sprintf(summary_text + strlen(summary_text), "\n");
				}
			}
		}
		sprintf(summary_text + strlen(summary_text), "\n");
	}
}

static void
execute_command(const char* command, char* result)
{
	FILE* fp = NULL;

	char line[BUFSIZ];
	char buf[BUFSIZ];

	memset(line, 0, sizeof(line));
	memset(buf, 0, sizeof(buf));

	if ((fp = popen(command, "r"))!= NULL) {
		while (fgets(line, sizeof(line), fp) != NULL ) {
			/* AmkorID  SubID   LotNo   Dcc StripID StripX  StripY  Bincode */
			if (strstr(line, "AmkorID"))    continue;
			sscanf(line, "%s", buf);
			strcat(result, line);
			strcat(result, "\n");
			memset(line, '\0', sizeof(line));
		}

		pclose(fp);
	}
}

inline static void
upload_ngstore(const char* operation, const char* sn, const char* result, const char* aid, const char* sid)
{
	char cmd[1024];
	char val[1024];
	memset(cmd, 0, sizeof(cmd));
	memset(val, 0, sizeof(val));

	int opr_code = 0;
	if (!strcmp(operation, "TEST1")) {
		opr_code = 801;
	}
	else if (!strcmp(operation, "SLT1")) {
		opr_code = 984;
	}
	else if (!strcmp(operation, "SLT2")) {
		opr_code = 985;
	}
	else {
		logging.error("%s, %d: Invalid operation -> (%s)", __func__, __LINE__, operation);
		return;
	}

	int bin = 0;
	if (!strcmp(result, "PASS")) {
		bin = 1;
	}
	else if (!strcmp(result, "FAIL")) {
		bin = 2;
	}
	else {
		logging.error("%s, %d: Invalid result -> (%s)", __func__, __LINE__, result);
		return;
	}

	sprintf(cmd, "curl \"http://cim_service.amkor.co.kr:8080/ysj/ultBin/updateUnit?amkorid=%s&subid=%s&operation=%d&unit=%s&bincode=%d&socketid=\"\"&shieldr=0&pgm=K5_TEST&deleteflag=N\" 2>/dev/null", aid, sid, opr_code, sn, bin);
	execute_command(cmd, val);

	if (!strncmp(val, "Success", strlen("Success"))) {
		/* No action */
		logging.debug("%s, %d: AID(%s),SID(%s),SN(%s),OPR(%d),BIN(%d) .. upload success", __func__, __LINE__, aid, sid, sn, opr_code, bin);
	}
	else {
		logging.error("%s, %d: AID(%s),SID(%s),SN(%s),OPR(%d),BIN(%d) .. upload fail", __func__, __LINE__, aid, sid, sn, opr_code, bin);

		char tdir[1024];
		memset(tdir, 0, sizeof(tdir));
#define NG_DIR	"/home/tsv/script/ESI/data/BobcatLog/NG_STORE"
		sprintf(tdir, "%s/%s_%d", NG_DIR, sn, opr_code);

		FILE* fp = fopen(tdir, "w");
		if (fp) {
			fprintf(fp, "%s,%s,%d", aid, sid, bin);
			fclose(fp);
		}
	}
}

static void
get_ft_value(const char* ft_val, const char* token, char* result)
{
	char tmp[BUFSIZ];
	memset(tmp, 0, sizeof(tmp));

	const char* tmp_start = strstr(ft_val, token);
	if (tmp_start) {
		const char* tmp_end = strstr(tmp_start, ",");
		if (tmp_end) {
			strncpy(tmp, tmp_start + strlen(token) + 1, (tmp_end - tmp_start) - strlen(token) - 1);
		}
		else {
			strcpy(tmp, tmp_start + strlen(token) + 1);
		}
	}

#if 0
	if (strlen(tmp)) {
		replace_str(tmp, result);
	}
#else
	strcpy(result, tmp);
#endif
}

static void
changed_str(const char* src, char* dst, char a, char* b)
{
	int j = 0;

	for (int i = 0; i < (int)strlen(src); i++) {
		if (src[i] == a) {
			strcat(dst, b);
			j += strlen(b);
		}
		else {
			dst[j] = src[i];
			j++;
		}
	}
}

static void
remove_str(const char* src, char* dst, const char* token)
{
	const char* tmp1 = src;

	while (1) {
		const char* tmp2 = strstr(tmp1, token);
		if (tmp2 == NULL) {
			strcat(dst, tmp1);
			break;
		}

		strncat(dst, tmp1, tmp2 - tmp1);

		tmp1 += (tmp2 - tmp1 + strlen(token));
	}
}

static void
change_timestamp(const char* src, char* dst)
{
	char tmp[1024];
	memset(tmp, 0, sizeof(tmp));

	/* 2019-02-20+23%3A20%3A13 -> 20190220232013*/
	remove_str(src, tmp, "%3A");

	/* 2019-02-20+232013 */
	char* str = tmp;
	strncat(dst, str, 4);
	str += 5;
	strncat(dst, str, 2);
	str += 3;
	strncat(dst, str, 2);
	str += 3;
	strncat(dst, str, 6);
}

inline static void
upload_ngstore_test(const char* operation, const char* sn, const char* result, const char* aid, const char* sid, const char* tester, const char* start_time, const char* site, const char* fails)
{
	char cmd[BUFSIZ];
	char val[1024];
	memset(cmd, 0, sizeof(cmd));
	memset(val, 0, sizeof(val));

	int opr_code = 0;
	if (!strcmp(operation, "TEST1")) {
		opr_code = 801;
	}
	else if (!strcmp(operation, "SLT1")) {
		opr_code = 984;
	}
	else if (!strcmp(operation, "SLT2")) {
		opr_code = 985;
	}
	else if (!strcmp(operation, "SLT3")) {
		opr_code = 7035;
	}
	else if (!strcmp(operation, "SLT4")) {
		opr_code = 7100;
	}
	else {
		logging.error("%s, %d: Invalid operation -> (%s)", __func__, __LINE__, operation);
		return;
	}

	int bin = 0;
	if (!strcmp(result, "PASS")) {
		bin = 1;
	}
	else if (!strcmp(result, "FAIL")) {
		bin = 2;
	}
	else {
		logging.error("%s, %d: Invalid result -> (%s)", __func__, __LINE__, result);
		return;
	}

	char comment[4096];
	memset(comment, 0, sizeof(comment));
	
	char tester2[128];
	memset(tester2, 0, sizeof(tester2));

	char var23[3];// 20230912
	memset(var23, 0, sizeof(var23));// 20230912
	changed_str(tester, tester2, '#', var23); // 20230912
	//changed_str(tester, tester2, '#', "%23");

	char fails2[2048]; // 20230912 char fails2[4096];
	memset(fails2, 0, sizeof(fails2));

	char fails2_1[1024];
	char fails2_2[1024];
	memset(fails2_1, 0, sizeof(fails2_1));
	memset(fails2_2, 0, sizeof(fails2_2));

	if (strlen(fails)) {
		get_ft_value(fails, "ft_1_test", fails2_1);
		get_ft_value(fails, "ft_1_sub_test", fails2_2);
		sprintf(fails2, "%s@%s", fails2_1, fails2_2);
	}

	sprintf(comment, "%s%%7c%s%%7c%s%%7c%s%%7c%s", start_time, tester2, site, fails2, "0");

	sprintf(cmd, "curl \"http://cim_service.amkor.co.kr:8080/ysj/ultBin/updateUnitComment?amkorid=%s&subid=%s&operation=%d&unit=%s&bincode=%d&socketid=&shieldr=0&pgm=K5_TEST&deleteflag=N&comment1=%s&comment2=&comment3=\" 2>/dev/null",
			aid, sid, opr_code, sn, bin, comment);
#if 1
	execute_command(cmd, val);

	if (!strncmp(val, "Success", strlen("Success"))) {
		/* No action */
		logging.debug("%s, %d: AID(%s),SID(%s),SN(%s),OPR(%d),BIN(%d) .. upload success", __func__, __LINE__, aid, sid, sn, opr_code, bin);
	}
	else {
		logging.error("%s, %d: AID(%s),SID(%s),SN(%s),OPR(%d),BIN(%d) .. upload fail", __func__, __LINE__, aid, sid, sn, opr_code, bin);

		char tdir[1024];
		char timestamp[128];
		memset(tdir, 0, sizeof(tdir));
		memset(timestamp, 0, sizeof(timestamp));
		change_timestamp(start_time, timestamp);
#define NG_DIR2	"/home/tsv/script/ESI/data/BobcatLog/NG_STORE_TEST"
		sprintf(tdir, "%s/%s_%d_%s_%s_%s_%s.txt", NG_DIR2, sn, opr_code, result, "0", site, timestamp);

		FILE* fp = fopen(tdir, "w");
		if (fp) {
			fprintf(fp, "AMKOR_ID,%s\n", aid);
			fprintf(fp, "SUB_ID,%s\n", sid);
			fprintf(fp, "TESTER,%s\n", tester2);
			fprintf(fp, "START_TIME,%s\n", start_time);
			if (strlen(fails2_1)) {
				fprintf(fp, "ft_x_test,ft_x_sub_test\n");
				fprintf(fp, "%s,%s\n", fails2_1, fails2_2);
			}

			fclose(fp);
		}
	}

#else
	logging.debug("%s, %d: cmd(%s)", __func__, __LINE__, cmd);
#endif
}

static int
processing_lot(CDB* db, Result_t* result, const char* idx, const char* tester, const char* lot, const char* dcc, const char* operation, const char* job, const char* operator_id, const char* start_time, const char* end_time)
{
/*
	result->m_tester = tester;
	result->m_lotName = lot;
	result->m_dcc = dcc;
	result->m_operation = operation;
	result->m_testProgram = job;
	result->m_operatorID = operator_id;
	result->m_startTime = start_time;
	result->m_endTime = end_time;
*/
	
#if 0 /* for uploading to NG-Store */ 
	char aid[256];
	char sid[256];
	memset(aid, 0, sizeof(aid));
	memset(sid, 0, sizeof(sid));

	if (db->get_amkorid(lot, dcc, aid, sid) < 0) {
		logging.error("%s, %d: Get Amkor ID .. fail.", __func__, __LINE__);
		return -1;
	}

#if 0
	if (db->get_unit_result_test(lot, dcc, operation, tester, start_time, end_time, aid, sid, upload_ngstore_test) < 0) {
		logging.error("%s, %d: Get Unit Result .. fail.", __func__, __LINE__);
		return -1;
	}
#else
	if (db->get_unit_result_test(lot, dcc, operation, tester, start_time, end_time, aid, sid, NULL) < 0) {
		logging.error("%s, %d: Get Unit Result .. fail.", __func__, __LINE__);
		return -1;
	}

	manual_ng_upload(aid, sid, operation, tester);

	return 0;
#endif
#endif

	/* for TSV */
	char sum_no[128];
	memset(sum_no, 0, sizeof(sum_no));

	if (db->set_summary(idx, tester, lot, dcc, operation, job, operator_id, start_time, end_time, sum_no) < 0)
		return -1;

	if (!strcmp(sum_no, "NO DATA")) {
		logging.error("%s, %d: Set summary .. fail .. (%s)", __func__, __LINE__, sum_no);
		return -1;
	}
	else if (!strcmp(sum_no, "EXIST DATA")) {
		logging.error("%s, %d: Set summary .. fail .. (%s)", __func__, __LINE__, sum_no);
		return -1;
	}

	char summary_text[BUFSIZ*10];
	memset(summary_text, 0, sizeof(summary_text));

	if (db->get_summary_text(lot, dcc, sum_no, start_time, end_time, summary_text) < 0) {
		logging.error("%s, %d: Get summary text .. fail.", __func__, __LINE__);
		return -1;
	}

	if (db->get_sbin_summary(lot, dcc, sum_no, "COUNT", start_time, end_time, result) < 0) {
		logging.error("%s, %d: Get sbin summary .. fail.", __func__, __LINE__);
		return -1;
	}

	sprintf(summary_text + strlen(summary_text), "\n");

	make_sbin_summary(&(result->m_sltBin), summary_text, operation);

	sprintf(summary_text + strlen(summary_text), "\n");

	if (db->get_error_summary(lot, dcc, sum_no, "ERROR", start_time, end_time, summary_text) < 0) {
		logging.error("%s, %d: Get error summary .. fail.", __func__, __LINE__);
		return -1;
	}

	logging.debug("%s, %d: summary len (%d)", __func__, __LINE__, strlen(summary_text));

	if (db->set_summary_text(sum_no, summary_text) < 0) {
		logging.error("%s, %d: Set summary text .. fail.", __func__, __LINE__);
		return -1;
	}

	logging.info("%s, %d:", __func__, __LINE__);

	return 0;
}

CSummary::CSummary()
{
	m_result = SUCCESS;

	CDB* db = new CDB();
	m_result = db->get_result();

	if (m_result == SUCCESS) {
		m_summaryResult = new Result_t;
		db->get_lot_list(db, m_summaryResult, processing_lot);
	}

	delete db;
}

CSummary::~CSummary()
{
	if (m_summaryResult) {
		delete m_summaryResult;
	}
}

int
CSummary::summary_parser(const char* summary, const char* platform, Result_t* result)
{
	CString pf = platform;

	if (pf == "SLT") {
		return summary_parser_slt(summary, result);
	} 
#if 0 /* Not used. */
	if (pf == "V93K") {
		return summary_parser_hp93k(summary, result);
	}
	else if (pf == "UFLEX") {
		return summary_parser_flex(summary, result);
	}
#endif

	return ERROR_INVALID_PLATFORM;
}

void
CSummary::show_result(Result_t* result)
{
	logging.debug("%s, %d: @sumName = '%s'\n@sumDirectory = '%s'\n@Platform = '%s'\n@Customer = '%s'\n@lotName = '%s'\n@dcc = '%s'\n@Device = '%s'\n@DeviceMA = '%s'\n@Operation = '%s'\n@LoadboardNo = '%s'\n@Temperature = '%s'\n@HandlerID = '%s'\n@HandlerType = '%s'\n@OperatorID = '%s'\n@TestProgram = '%s'\n@TestProgramExcel = '%s'\n@TestProgramRev = '%s'\n@ChannelMap = '%s'\n@CreateTime = '%s'\n@Tester = '%s'\n@PUIversion = '%s'\n@goodBin = %d\n@goodYield = %.2f\n@failBin = %d\n@failYield = %.2f\n@totalBin = %d\n@HardBins = '%s'\n@summaryText = '%s'\n@editOperatorID = '%s'\n@comment = '%s'\n@SoftBins = '%s'\n@check_title = '%s'\n@check_value = '%s'\n",
			__func__, __LINE__,
			(const char*)result->m_summaryName, "", (const char*)result->m_platform, (const char*)result->m_customer, (const char*)result->m_lotName,
			(const char*)result->m_dcc, (const char*)result->m_device, "", (const char*)result->m_operation, (const char*)result->m_loadBoardNo,
			(const char*)result->m_temperature, (const char*)result->m_handlerID, (const char*)result->m_handlerType, (const char*)result->m_operatorID, (const char*)result->m_testProgram,
			(const char*)result->m_testProgramExcel, (const char*)result->m_testProgramRev, (const char*)result->m_channelMap, (const char*)result->m_createTime, (const char*)result->m_tester,
			(const char*)result->m_PUIversion, result->m_goodBin, result->m_goodYield, result->m_failBin, result->m_failYield,
			result->m_totalBin, (const char*)result->m_hardBins, (const char*)result->m_summaryText, "", "", (const char*)result->m_softBins, (const char*)result->m_checkTitle, (const char*)result->m_checkValue
		   );
}

static ArtBin_t*
find_sbin(SltBin_t* sbin, const char* station)
{
	SltBin_t::iterator it;
	it = sbin->find(station);
	if (it == sbin->end()) {
		ArtBin_t* abin = new ArtBin_t;
		abin->clear();
		sbin->insert(SltBin_t::value_type(station, abin));

		return abin;
	}
	else {
		return it->second;
	}
}

static BinInfo_t*
find_abin(ArtBin_t* abin, int num)
{
	ArtBin_t::iterator it;
	it = abin->find(num);
	if (it == abin->end()) {
		BinInfo_t* info = new BinInfo_t;
		info->clear();
		abin->insert(ArtBin_t::value_type(num, info));

		return info;
	}
	else {
		return it->second;
	}
}

static Bin_t*
find_bin(BinInfo_t* info, const char* pass_fail)
{
	BinInfo_t::iterator it;
	it = info->find(pass_fail);
	if (it == info->end()) {
		Bin_t* bin = new Bin_t;
		memset(bin->m_bin, 0, sizeof(Bin_t));
		info->insert(BinInfo_t::value_type(pass_fail, bin));

		return bin;
	}
	else {
		return it->second;
	}
}

void
assemble_bin(Result_t* result, int num, const char* station, const char* pass_fail, int* s_qty)
{
	ArtBin_t* abin = find_sbin(&(result->m_sltBin), station);
	if (abin == NULL)
		return;

	BinInfo_t* binfo = find_abin(abin, num);
	if (binfo == NULL)
		return;

	Bin_t* bin = find_bin(binfo, pass_fail);
	if (bin == NULL)
		return;

	for (int i = 0; i < MAX_SITE; i++) {
		bin->m_bin[i] = s_qty[i];
	}
}

void
manual_ng_upload(const char* aid, const char* sid, const char* operation, const char* tester)
{
	FILE* fp = fopen("/tmp/get_unit_result_wodate.list", "r");
	if (fp == NULL)
		return;

	char read_buf[2048];

	while (!feof(fp)) {
		memset(read_buf, 0, sizeof(read_buf));

		if (!fgets(read_buf, sizeof(read_buf), fp))
			break;

		// GTQ93713GBYMQ109U,PASS,25,,2019-09-18+15%3A26%3A56
		CString tmp = read_buf;
		tmp.trim_right();

		CString sn = tmp.left(tmp.find('|', 0));
		tmp = tmp.right(tmp.get_length() - tmp.find('|', 0) - 1);

		CString result = tmp.left(tmp.find('|', 0));
		tmp = tmp.right(tmp.get_length() - tmp.find('|', 0) - 1);

		CString site = tmp.left(tmp.find('|', 0));
		tmp = tmp.right(tmp.get_length() - tmp.find('|', 0) - 1);

		CString fails = tmp.left(tmp.find('|', 0));
		tmp = tmp.right(tmp.get_length() - tmp.find('|', 0) - 1);

		CString st_time = tmp;

		logging.debug("%s, %d: sn(%s),ret(%s),site(%s),fail(%s),st_time(%s)", __func__, __LINE__, (const char*)sn, (const char*)result, (const char*)site, (const char*)fails, (const char*)st_time);

		upload_ngstore_test(operation, sn, result, aid, sid, tester, st_time, site, fails);
	}

	fclose(fp);
}

