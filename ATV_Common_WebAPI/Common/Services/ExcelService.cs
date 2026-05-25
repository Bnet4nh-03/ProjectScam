using ATV_Common_WebAPI.Common.Interfaces;
using OfficeOpenXml;
using System.Data;

namespace ATV_Common_WebAPI.Common.Services
{
    public class ExcelService : IExcelService
    {
        public void ReadAllSheets(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo fileInfo = new FileInfo(filePath);
            List<DataTable> lstDatatable = new List<DataTable>();

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                foreach (var worksheet in package.Workbook.Worksheets)
                {
                    Console.WriteLine($"Reading sheet: {worksheet.Name}");
                    var start = worksheet.Dimension.Start;
                    var end = worksheet.Dimension.End;

                    for (int row = start.Row; row <= end.Row; row++)
                    {
                        for (int col = start.Column; col <= end.Column; col++)
                        {
                            var cellValue = worksheet.Cells[row, col].Text;
                            Console.Write($"{cellValue}\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        public List<DataTable> ReadExcelToDataTables(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<DataTable> tables = new List<DataTable>();
            FileInfo fileInfo = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                foreach (var worksheet in package.Workbook.Worksheets)
                {
                    DataTable table = new DataTable(worksheet.Name);

                    // Add columns to DataTable
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        table.Columns.Add(firstRowCell.Text);
                    }

                    // Add rows to DataTable
                    for (int rowNum = 2; rowNum <= worksheet.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = worksheet.Cells[rowNum, 1, rowNum, worksheet.Dimension.End.Column];
                        DataRow row = table.NewRow();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                        table.Rows.Add(row);
                    }

                    tables.Add(table);
                }
            }

            return tables;
        }
    }
}