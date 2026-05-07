/**
@file     atpTsv_hp93k.h
@author   Kim, hyoung-joo
@version
  v0.0.1: 2015-08-20
@Description
  env header
@par Copyright:
  Copyright(c) 2015 Amkor technology CO., All Rights Reserved.
*/
#ifndef SLT_H__
#define SLT_H__

/* Header files */
#include "tsv_summary.h"

/* for HP93K */
int summary_parser_slt(const char* summary, Result_t* result);
void set_slt_mode(const char* summary, Result_t* result);
void set_slt_operation(const char* summary, Result_t* result);
void summary_parser_slt_by_line(const char* line, Result_t* result);

#endif /* SLT_H__ */
