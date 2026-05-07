/**
@file     atpTsv_main.cpp
@author   Kim, hyoung-joo
@version
  v0.0.1: 2015-08-18
@Description
  main source
@par Copyright:
  Copyright(c) 2015 Amkor technology CO., All Rights Reserved.
*/

/* Header files */
#include "tsv_main.h"

/* Define variables */
CEnv g_env;
CLog g_logging;

static int process_args(int ac, char** av)
{
	/* check argument */
#if 0
	if (ac <= 2) {
		fprintf(stderr, "Invalid parameter ... give up\n");
		fprintf(stderr, "-> Usage: [Platform] [Customer]\n");
		return -1;
	}
#endif

	return 0;
}

/* parse the ini file & fill environment */
static int read_ini_file(const char* file_name)
{
	int ret;
	CIniFile ini;

	ret = ini.read(file_name);

	switch (ret) {
		case CIniFile::e_FOpen:
			fprintf(stderr, "I can not open the parameter file : '%s'\n", file_name);
			return ret;

		case CIniFile::e_Syntax:
			fprintf(stderr, "It is irregular parameter file : '%s'\n", file_name);
			return ret;
	}

	g_env.read(ini);

	return 0;
}

static void close_thread()
{
	CMsgIn* msg = new CMsgIn(MSG_THREAD_QUIT);

	logging.info("program stopped !!\n");

	logging.post(msg);
	logging.wait_until_complete();

	msg->ref_dec();
}

/* sighup handler */
static void sighup(int sig_num)
{
	logging.info("SIGHUP received");
}

/* sigint handler */
static void sigint(int sig_num)
{
	logging.info("Terminating on signal (%d)", sig_num);

	/* destroy resource */
	close_thread();

#if 0 /* 2014.10.31, for return value of fault */
	static int reenter = 0;
	if (reenter)
		exit(0);
	reenter++;
#else
	exit(1);
#endif
}

/* sigusr1 handler */
static void sigusr1(int sig_num)
{
}
 
static void signal_cleanup(int sig_num, void* client_arg)
{
	switch (sig_num) {
		case SIGFPE:
		case SIGILL:
		case SIGSEGV:
		case SIGBUS:
		case SIGABRT:
		case SIGQUIT:
			sigint(sig_num);
			break;
		case SIGINT:
		case SIGTERM:
			sigint(sig_num);
			exit(0);
			break;
		case SIGHUP:
			sighup(sig_num);
			break;
		case SIGUSR1:
			sigusr1(sig_num);
			break;
	}

	logging.info("%s: finished", __func__);
}

static void signal_handling()
{
	signal_handler_register (SIGQUIT, signal_cleanup, NULL);
	signal_handler_register (SIGILL, signal_cleanup, NULL);
	signal_handler_register (SIGABRT, signal_cleanup, NULL);
	signal_handler_register (SIGBUS, signal_cleanup, NULL);
	signal_handler_register (SIGFPE, signal_cleanup, NULL);
	signal_handler_register (SIGSEGV, signal_cleanup, NULL);

	signal_handler_register (SIGINT, signal_cleanup, NULL);
	signal_handler_register (SIGTERM, signal_cleanup, NULL);

	signal_handler_register (SIGHUP, signal_cleanup, NULL);
	signal_handler_register (SIGUSR1, signal_cleanup, NULL);
}

int main(int ac, char** av)
{
	/* parse & process by arguments */
	if (0 != process_args(ac, av))
		return ERROR_INVALID_PARAM;

	/* get ini_file env variable */
	char* ini_file = getenv("TSV_ENV");
	if (ini_file == NULL) {
		fprintf(stderr, "Can't get TSV_ENV env !!\n");
		return ERROR_GET_ENV;
	}

	/* read configure file */
	if (0 != read_ini_file(ini_file))
		return ERROR_READ_CONFIG;

	/* register signal handler */
	signal_handling();

	/* init error handling */
	err_init();

	logging.set_env(g_env.m_log_level, g_env.m_log_dir);
	if (false == logging.create_thread())		
		return ERROR_LOG_THREAD;

	logging.info("program start !!");

	int result = SUCCESS;

	/* Main loop */
#if 1
	CSummary* summary = new CSummary();
	result = summary->get_result();
	delete summary;
#else
	char* buff = NULL;
	CDB* db = new CDB();

	char aid[256];
	char sid[256];
	memset(aid, 0, sizeof(aid));
	memset(sid, 0, sizeof(sid));

	if (db->get_amkorid(av[1], av[2], aid, sid) < 0) {
		logging.error("%s, %d: Get Amkor ID .. fail.", __func__, __LINE__);
		return -1;
	}

	if (db->get_result() == SUCCESS) {
		db->get_unit_result_wodate(av[1], av[2], av[3], buff);
	}

	manual_ng_upload(aid, sid, av[3], av[4]);

	delete db;
#endif

	logging.info("return result -> (%d), (%s)", result, err_msg(result));

	close_thread();

	fprintf(stdout, "return result -> (%d), (%s)\n", result, err_msg(result));

	return result;
}
