#!/bin/sh

SUFFIX_VALUE="$1"
FILE_LIST="file.list"

ls *.h *.cpp > ${FILE_LIST}

while read line
do
	file_prefix=`echo ${line} | cut -f 1 -d "_"`
	file_suffix=`echo ${line} | cut -f 2 -d "_"`

	mv ${line} "${SUFFIX_VALUE}_${file_suffix}"
	echo "mv ${line} ${SUFFIX_VALUE}_${file_suffix}"

done < ${FILE_LIST}

rm ${FILE_LIST}
