using System.Data;
using OfficeOpenXml;
using System.Data.SqlClient;
using ATV_Common_WebAPI.ASSY.Mounter.BOM_List_Checking.Interfaces;
using ATV_Common_WebAPI.Common.Utilities;
using ATV_Common_WebAPI.ASSY.Mounter.BOM_List_Checking.Models;

namespace ATV_Common_WebAPI.ASSY.Mounter.BOM_List_Checking.Services
{
    public class Placement_Compare : IBOMComparisonService
    {
        private readonly DatabaseUtility _dbUtil;

        public Placement_Compare(DatabaseUtility dbUtil)
        {
            _dbUtil = dbUtil;
        }

        public static DataTable ReadBOMExcelFromBase64(string base64String)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Convert the base64 string to a byte array
            byte[] fileBytes = Convert.FromBase64String(base64String);

            // Load the byte array into a MemoryStream
            using (MemoryStream stream = new MemoryStream(fileBytes))
            {
                // Load the Excel package from the MemoryStream
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    // Get the first worksheet in the workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    // Create a DataTable
                    DataTable dataTable = new DataTable();

                    // Add columns to the DataTable based on the first row of the worksheet
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        dataTable.Columns.Add(worksheet.Cells[1, col].Text);
                    }

                    // Add rows to the DataTable
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                        {
                            dataRow[col - 1] = worksheet.Cells[row, col].Text;
                        }
                        dataTable.Rows.Add(dataRow);
                    }

                    return dataTable;
                }
            }
        }

        public static DataTable ReadPlacementXmlFromBase64(string base64String)
        {
            // Convert the base64 string to a byte array
            byte[] fileBytes = Convert.FromBase64String(base64String);

            using (MemoryStream stream = new MemoryStream(fileBytes))
            {
                // Load the XML into a DataSet
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(stream);

                // Get the first DataTable
                DataTable dataTable = dataSet.Tables[0];

                return dataTable;
            }
        }

        public static List<string> AccessDataByColumnName(DataTable dataTable, string columnName)
        {
            List<string> listOutput = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                // Access data by column name
                var value = row[columnName];
                listOutput.Add(value.ToString());
            }

            return listOutput;
        }

        public static List<string> FlatList(List<string> listIn, string splitChar)
        {
            List<string> result = [];

            foreach (var item in listIn)
            {
                if (item.Contains(splitChar))
                {
                    result.AddRange(item.Split(splitChar));
                }
                else
                {
                    result.Add(item);
                }
            }

            return result;
        }

        private static void ProcessBOMFile(BOMPlacementFileUploadModel file, bool ignoreComparePcb, ref string strBOMListFilename, 
            ref DataTable dtBOMList, ref List<string> lstSID, ref List<string> lstRefDes,
            ref Dictionary<string, List<string>> dictBOMSidRefDes)
        {
            // Set BOM list filename and read Excel content from base64 string
            strBOMListFilename = file.FileName;
            dtBOMList = ReadBOMExcelFromBase64(file.FileContentBase64);

            // Remove PCB material/ref des base on ignoreComparePcb for comparing
            if (ignoreComparePcb)
            {
                int rowIndex = 0;
                if (rowIndex >= 0 && rowIndex < dtBOMList.Rows.Count)
                {
                    dtBOMList.Rows[rowIndex].Delete();
                    dtBOMList.AcceptChanges(); // Commit the changes to the DataTable
                }
            }

            // Remove rows with no data in columns Material, SID#, Usage
            for (int i = dtBOMList.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dtBOMList.Rows[i];
                if (string.IsNullOrEmpty(row["Material"].ToString()) && string.IsNullOrEmpty(row["SID#"].ToString()) && string.IsNullOrEmpty(row["Usage"].ToString()))
                {
                    dtBOMList.Rows.Remove(row);
                }
            }

            // Access data by column name and remove the last row if empty
            int removeRowIdx = AccessDataByColumnName(dtBOMList, "Material").FindLastIndex(string.IsNullOrEmpty);

            lstSID = AccessDataByColumnName(dtBOMList, "SID#");
            lstRefDes = AccessDataByColumnName(dtBOMList, "Ref Des");
            if (removeRowIdx > -1)
            {
                lstSID.RemoveAt(removeRowIdx);
                lstRefDes.RemoveAt(removeRowIdx);
            }

            //foreach (DataRow row in dtBOMList.Rows)
            //{
            //    string component = row["SID#"].ToString().Trim();
            //    string refDesignator = row["Ref Des"].ToString().Trim();

            //    if (!dictBOMSidRefDes.ContainsKey(component))
            //    {
            //        dictBOMSidRefDes[component] = new List<string>();
            //    }
            //    dictBOMSidRefDes[component].AddRange(refDesignator.Split(",").ToList());
            //}

            // Check if lengths are equal
            if (lstSID.Count == lstRefDes.Count)
            {
                for (int i = 0; i < lstSID.Count; i++)
                {
                    dictBOMSidRefDes[lstSID[i]] = lstRefDes[i].Split(',').ToList();
                }
            }
            else
            {
                Console.WriteLine("The lists are not of equal length.");
            }

            lstRefDes = FlatList(lstRefDes, ",");
        }

        private static void ProcessPlacementFile(BOMPlacementFileUploadModel file, ref string strPlacementListFilename, ref DataTable dtPlacementList, 
            ref DataTable dtPlacementListOmit, ref DataTable dtPlacementListWithoutOmit, ref List<string> lstRefDesignator, ref List<string> lstComponent,
            ref List<string> lstRefDesignatorOmit, ref List<string> lstComponentOmit, 
            ref Dictionary<string, List<string>> dictPlacementSidRefDes, ref Dictionary<string, List<string>> dictPlacementSidRefDesOmit)
        {
            // Set Placement list filename and read XML content from base64 string
            strPlacementListFilename = file.FileName;
            dtPlacementList = ReadPlacementXmlFromBase64(file.FileContentBase64);

            // Filter data based on 'Omit' column
            DataRow[] filteredRowsOmit = dtPlacementList.Select("Omit = 'X'");
            if (filteredRowsOmit.Length > 0)
            {
                dtPlacementListOmit = filteredRowsOmit.CopyToDataTable();
            }
            else
            {
                // Handle the case when there are no rows with Omit = 'X' create an empty DataTable with the same schema
                dtPlacementListOmit = dtPlacementList.Clone();
            }

            DataRow[] filteredRowsWithoutOmit = dtPlacementList.Select("Omit <> 'X'");
            if (filteredRowsWithoutOmit.Length > 0)
            {
                dtPlacementListWithoutOmit = filteredRowsWithoutOmit.CopyToDataTable();
            }
            else
            {
                // Handle the case when there are no rows with Omit <> 'X' create an empty DataTable with the same schema
                dtPlacementListWithoutOmit = dtPlacementList.Clone();
            }

            foreach (DataRow row in dtPlacementListWithoutOmit.Rows)
            {
                string component = row["Component"].ToString().Trim();
                string refDesignator = row["RefDesignator"].ToString().Trim();

                if (!dictPlacementSidRefDes.ContainsKey(component))
                {
                    dictPlacementSidRefDes[component] = new List<string>();
                }
                dictPlacementSidRefDes[component].Add(refDesignator);
            }

            foreach (DataRow row in dtPlacementListOmit.Rows)
            {
                string component = row["Component"].ToString().Trim();
                string refDesignator = row["RefDesignator"].ToString().Trim();

                if (!dictPlacementSidRefDesOmit.ContainsKey(component))
                {
                    dictPlacementSidRefDesOmit[component] = new List<string>();
                }
                dictPlacementSidRefDesOmit[component].Add(refDesignator);
            }

            // Access data by column name and get distinct values
            lstRefDesignator = AccessDataByColumnName(dtPlacementListWithoutOmit, "RefDesignator");
            lstComponent = AccessDataByColumnName(dtPlacementListWithoutOmit, "Component").Distinct().ToList();

            lstRefDesignatorOmit = AccessDataByColumnName(dtPlacementListOmit, "RefDesignator");
            lstComponentOmit = AccessDataByColumnName(dtPlacementListOmit, "Component").Distinct().ToList();
        }

        public async Task<IResult> CompareBOMPlacement(HttpRequest request)
        {
            // Read and deserialize the request body
            using var reader = new StreamReader(request.Body);
            var requestBody = await reader.ReadToEndAsync();
            using var jsonDoc = System.Text.Json.JsonDocument.Parse(requestBody);
            var requestData = jsonDoc.RootElement;

            // Check for the ignoreComparePcb key
            bool ignoreComparePcb = false;
            ignoreComparePcb = requestData.GetProperty("ignoreComparePcb").GetBoolean();

            // Deserialize the file list
            List<BOMPlacementFileUploadModel> fileList = new List<BOMPlacementFileUploadModel>();
            try
            {
                fileList = System.Text.Json.JsonSerializer.Deserialize<List<BOMPlacementFileUploadModel>>(requestData.GetProperty("fileList"));
            }
            catch (Exception ex)
            {
                return Results.BadRequest("Wrong JSON format");
            }

            // Return bad request if the file list is null or empty
            if (fileList == null || fileList.Count == 0) return Results.BadRequest("Have no input files");

            // Return bad request if the file list is over than 2 files
            if (fileList.Count > 2) return Results.BadRequest("More than 2 files, please provide correctly 1 BOM List file and 1 Placement List file");

            // Return bad request if input files do not have enough BOM List and Placement List
            var lstFiletype = fileList.Select(x => x.FileType.ToString().ToUpper()).ToList();
            var requiredFiletypes = new HashSet<string> { "BOM", "PLACEMENT" };

            if (!requiredFiletypes.IsSubsetOf(lstFiletype))
            {
                return Results.BadRequest("Need 1 BOM List file and 1 Placement List file");
            }

            // Initialize variables for BOM and Placement files
            string strBOMListFilename = string.Empty, strPlacementListFilename = string.Empty;
            DataTable dtBOMList = new DataTable(), dtPlacementList = new DataTable(), dtPlacementListOmit = new DataTable(), dtPlacementListWithoutOmit = new DataTable();
            List<string> lstSID = new List<string>(), lstRefDes = new List<string>(),
                        lstRefDesignator = new List<string>(), lstComponent = new List<string>(),
                        lstRefDesignatorOmit = new List<string>(), lstComponentOmit = new List<string>();
            Dictionary<string, List<string>> dictBOMSidRefDes = new Dictionary<string, List<string>>(),
                                             dictPlacementSidRefDes = new Dictionary<string, List<string>>(),
                                             dictPlacementSidRefDesOmit = new Dictionary<string, List<string>>();

            // Process each file in the file list
            foreach (var file in fileList)
            {
                if (file.FileType == "BOM" && file.FileFormat.ToLower() == "xlsx")
                    try
                    {
                        ProcessBOMFile(file, ignoreComparePcb, ref strBOMListFilename, ref dtBOMList, ref lstSID, ref lstRefDes, ref dictBOMSidRefDes);
                    }
                    catch
                    {
                        return Results.BadRequest("Wrong BOM List file format");
                    }
                else if (file.FileType == "Placement" && file.FileFormat.ToLower() == "xml")
                    try
                    {
                        ProcessPlacementFile(file, ref strPlacementListFilename, ref dtPlacementList, ref dtPlacementListOmit, ref dtPlacementListWithoutOmit,
                            ref lstRefDesignator, ref lstComponent, ref lstRefDesignatorOmit, ref lstComponentOmit, ref dictPlacementSidRefDes, ref dictPlacementSidRefDesOmit);
                    }
                    catch
                    {
                        return Results.BadRequest("Wrong Placement List file format");
                    }
            }

            // Create dictionaries to store differences
            Dictionary<string, List<string>> inBOMNotInPlacement = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> inPlacementNotInBOM = new Dictionary<string, List<string>>();

            // Find keys only in dictBOMSidRefDes
            foreach (var key in dictBOMSidRefDes.Keys.Except(dictPlacementSidRefDes.Keys))
            {
                inBOMNotInPlacement[key] = dictBOMSidRefDes[key];
            }

            // Find keys only in dictPlacementSidRefDes
            foreach (var key in dictPlacementSidRefDes.Keys.Except(dictBOMSidRefDes.Keys))
            {
                inPlacementNotInBOM[key] = dictPlacementSidRefDes[key];
            }

            // Find keys with different values
            foreach (var key in dictBOMSidRefDes.Keys.Intersect(dictPlacementSidRefDes.Keys))
            {
                var valuesInDictBOM = dictBOMSidRefDes[key];
                var valuesInDictPlacement = dictPlacementSidRefDes[key];

                var valuesOnlyInDictBOM = valuesInDictBOM.Except(valuesInDictPlacement).ToList();
                var valuesOnlyInDictPlacement = valuesInDictPlacement.Except(valuesInDictBOM).ToList();

                if (valuesOnlyInDictBOM.Any())
                {
                    inBOMNotInPlacement[key] = valuesOnlyInDictBOM;
                }

                if (valuesOnlyInDictPlacement.Any())
                {
                    inPlacementNotInBOM[key] = valuesOnlyInDictPlacement;
                }
            }

            // Create the final output dictionary
            var byPairSidRefDes = new
            {
                // Add the differences to the return data
                InBOMNotInPlacement = inBOMNotInPlacement,
                InPlacementNotInBOM = inPlacementNotInBOM,

                // Include the original dictionaries
                dictBOMSidRefDes = dictBOMSidRefDes,
                dictPlacementSidRefDes = dictPlacementSidRefDes,
                dictPlacementSidRefDesOmit = dictPlacementSidRefDesOmit
            };

            // Find differences between BOM and Placement lists
            var returnData = new
            {
                BOMListName = strBOMListFilename,
                BOMListContent = DataConverterUtility.ConvertDataTableToList(dtBOMList),
                BOMListSID = lstSID,
                BOMListRefDes = lstRefDes,

                PlacementListName = strPlacementListFilename,
                PlacementListContent = DataConverterUtility.ConvertDataTableToList(dtPlacementList),
                PlacementListOmit = DataConverterUtility.ConvertDataTableToList(dtPlacementListOmit),
                PlacementListWithoutOmit = DataConverterUtility.ConvertDataTableToList(dtPlacementListWithoutOmit),
                PlacementListSID = lstComponent,
                PlacementListRefDes = lstRefDesignator,

                DiffBOMListSID = lstSID.Except(lstComponent).ToList(),
                DiffBOMListRefDes = lstRefDes.Except(lstRefDesignator).ToList(),

                DiffPlacementListSID = lstComponent.Except(lstSID).ToList(),
                DiffPlacementListRefDes = lstRefDesignator.Except(lstRefDes).ToList(),

                InBOMListButOmitSID = lstComponentOmit.Intersect(lstSID).ToList(),
                InBOMListButOmitRefDes = lstRefDesignatorOmit.Intersect(lstRefDes).ToList(),

                PairSidRefDes = byPairSidRefDes
            };

            return Results.Ok(returnData);
        }


        public IResult GetCompareBOMPlacementPermission(string badgeNo)
        {
            var sqlParamList = new List<SqlParameter> { new SqlParameter("@badgeno", badgeNo) };
            var dataSet = _dbUtil.GetDataSetByStoredProcedure("ATV_Common.dbo.USP_Common_API_Get_User", sqlParamList);

            if (dataSet.Tables[0]?.Rows.Count > 0)
            {
                var dataRow = dataSet.Tables[0].Rows[0];
                var userId = dataRow["user_id"].ToString().Trim();
                var username = dataRow["username"].ToString().Trim();
                var userTitle = dataRow["user_title"].ToString().Trim();
                var userGroup = dataRow["user_group"].ToString().Trim();
                var userConfig = dataRow["user_config"].ToString().Trim();

                var lstReturn = userConfig.Split(';').Where(config => !string.IsNullOrEmpty(config)).ToList();

                var returnData = new
                {
                    UserId = userId,
                    Username = username,
                    UserTitle = userTitle,
                    UserGroup = userGroup,
                    UserConfig = lstReturn
                };

                return Results.Ok(returnData);
            }

            return Results.NotFound();
        }

        public IResult SetBOMListCheckingResult(BOMListCheckingModel param)
        {
            var sqlParamList = new List<SqlParameter>
            {
                new SqlParameter("@lot", param.Lot),
                new SqlParameter("@dcc", param.Dcc),
                new SqlParameter("@bom_filename", param.BomFilename),
                new SqlParameter("@placement_filename", param.PlacementFilename),
                new SqlParameter("@bom_content", param.BomContent),
                new SqlParameter("@placement_content", param.PlacementContent),
                new SqlParameter("@comparison_result", param.ComparisonResult),
                new SqlParameter("@ignore_pcb_compare", param.IgnorePcbCompare),
                new SqlParameter("@different_items", param.DifferentItems),
                new SqlParameter("@badge_no", param.BadgeNo)
            };
            var dataSet = _dbUtil.GetDataSetByStoredProcedure("ATV_Common.dbo.USP_Set_ASSY_SMT_Mounter_BOM_List_Checking", sqlParamList);

            if (dataSet.Tables[0]?.Rows.Count > 0)
            {
                var dataRow = dataSet.Tables[0].Rows[0];
                var result = dataRow["result"].ToString().Trim();
                return Results.Ok(result);
            }
            else
            {
                return Results.BadRequest("Update data comparing is failed");
            }
        }

        public IResult GetBOMListCheckingResult(string startTime, string endTime)
        {
            startTime = DateTimeConverterUtility.ConvertToDateTimeFormat(startTime, "yyyy-MM-dd") + " 00:00:00.000";
            endTime = DateTimeConverterUtility.ConvertToDateTimeFormat(endTime, "yyyy-MM-dd") + " 23:59:59:999";

            if (startTime == "Error" || endTime == "Error")
            {
                return Results.BadRequest("Wrong datetime input format");
            }

            var sqlParamlist = new List<SqlParameter>
            {
                new SqlParameter("@start_time", startTime),
                new SqlParameter("@end_time", endTime)
            };

            // Execute stored procedure to get data BOM List Checking
            var dataSet = _dbUtil.GetDataSetByStoredProcedure("ATV_Common.dbo.USP_Get_ASSY_SMT_Mounter_BOM_List_Checking", sqlParamlist);

            // Check if data is returned and assign values
            if (dataSet.Tables[0]?.Rows.Count > 0)
            {
                return Results.Ok(new
                {
                    BOMListCheckingResultList = DataConverterUtility.ConvertDataTableToList(dataSet.Tables[0])
                });
            }

            return Results.BadRequest("Have no data");
        }

        public IResult GetBOMListCheckingResultStatus(string lot, string? dcc, long? id = 0)
        {
            // Trim input parameters
            lot = lot.Trim();
            dcc = dcc?.Trim() ?? string.Empty;

            // Initialize variables
            string amkorId = string.Empty, subId = string.Empty;

            // Prepare SQL parameters for the first stored procedure
            var sqlParamlist = new List<SqlParameter>
            {
                new SqlParameter("@lot", lot),
                new SqlParameter("@dcc", dcc)
            };

            // Execute stored procedure to get Amkor_ID and Sub_ID
            var dataSet = _dbUtil.GetDataSetByStoredProcedure("ATV_Common.dbo.USP_Get_AmkorID_SubID", sqlParamlist);

            // Check if data is returned and assign values
            if (dataSet.Tables[0]?.Rows.Count > 0)
            {
                var dataRow = dataSet.Tables[0].Rows[0];
                amkorId = dataRow["Amkor_ID"].ToString().Trim();
                subId = dataRow["Sub_ID"].ToString().Trim();
            }

            // Return BadRequest if Amkor_ID and Sub_ID are not found
            if (string.IsNullOrEmpty(amkorId) && string.IsNullOrEmpty(subId))
            {
                return Results.BadRequest("Lot no and dcc provided do not exist");
            }

            // Prepare SQL parameters for the second stored procedure
            sqlParamlist = new List<SqlParameter>
            {
                new SqlParameter("@amkor_id", long.Parse(amkorId)),
                new SqlParameter("@sub_id", long.Parse(subId)),
                new SqlParameter("@id", id)
            };

            // Execute stored procedure to get BOM list checking status
            dataSet = _dbUtil.GetDataSetByStoredProcedure("ATV_Common.dbo.USP_Get_ASSY_SMT_Mounter_BOM_List_Checking_Status", sqlParamlist);

            // Check if data is returned and create the response
            if (dataSet.Tables[0]?.Rows.Count > 0)
            {
                var dataRow = dataSet.Tables[0].Rows[0];

                var returnData = new
                {
                    IsLotCompare = true,
                    ComparisonResult = Convert.ToBoolean(dataRow["comparison_result"].ToString().Trim()),
                    BomFilename = dataRow["bom_filename"].ToString().Trim(),
                    PlacementFilename = dataRow["placement_filename"].ToString().Trim(),
                    BomContent = dataRow["bom_content"].ToString().Trim(),
                    PlacementContent = dataRow["placement_content"].ToString().Trim(),
                    CompareCount = Convert.ToInt32(dataRow["compare_count"].ToString().Trim()),
                    BadgeNo = dataRow["badge_no"].ToString().Trim(),
                    Username = dataRow["username"].ToString().Trim(),
                    UserGroup = dataRow["user_group"].ToString().Trim(),
                    CreateTime = dataRow["create_time"].ToString().Trim()
                };
                return Results.Ok(returnData);
            }
            else
            {
                return Results.Ok(new
                {
                    IsLotCompare = false
                });
            }
        }

        
    }

}