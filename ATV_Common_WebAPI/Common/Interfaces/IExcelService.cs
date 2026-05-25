using System.Data;
using System.Collections.Generic;

namespace ATV_Common_WebAPI.Common.Interfaces;

public interface IExcelService
{
    void ReadAllSheets(string filePath);
    List<DataTable> ReadExcelToDataTables(string filePath);
}
