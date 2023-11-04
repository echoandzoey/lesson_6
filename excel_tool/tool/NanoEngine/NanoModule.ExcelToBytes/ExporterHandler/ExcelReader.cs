// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

using System;
using System.Data;
using System.IO;
using ExcelDataReader;

namespace NanoModule.ExcelToBytes.ExporterHandler
{
    public static class ExcelReader
    {
        static ExcelReader()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        ///     获取Excel数据
        /// </summary>
        /// <param name="excelPath">Excel路径</param>
        /// <returns>Excel的第0个Table的数据（首行是列头行）</returns>
        public static DataTable GetExcelData(string excelPath)
        {
            if (!File.Exists(excelPath))
            {
                Console.WriteLine($"[失败]Excel文件不存在。数据表路径={excelPath}");
                return null;
            }

            var tempExcelPath = excelPath + ".bak";

            DataSet book;

            TryDeleteTempFile(tempExcelPath);

            try
            {
                book = GetDataSet(excelPath);
            }
            catch (Exception exp)
            {
                if (exp.Message.Contains("Sharing violation on path") || exp.Message.Contains("正由另一进程使用，因此该进程无法访问此文件。") || exp.Message.Contains("The process cannot access the file") || exp.Message.Contains("because it is being used by another process"))
                {
                    try
                    {
                        File.Copy(excelPath, tempExcelPath, true);
                        book = GetDataSet(tempExcelPath);
                    }
                    catch
                    {
                        Console.WriteLine(exp.Message);
                        return null;
                    }
                    finally
                    {
                        TryDeleteTempFile(tempExcelPath);
                    }
                }
                else
                {
                    Console.WriteLine(exp.Message);
                    return null;
                }
            }

            // 检测存在Table[0]
            if (book.Tables.Count < 1)
            {
                Console.WriteLine($"[失败]Excel文件中没有找到Sheet。数据表路径={excelPath}");
                return null;
            }

            // 取得Tables[0]数据
            DataTable sheet = book.Tables[0];
            // 检测存在行
            if (sheet.Rows.Count <= 0)
            {
                Console.WriteLine($"[失败]Excel的Sheet[0]中没有数据。数据表路径={excelPath}");
                return null;
            }

            return sheet;
        }

        private static DataSet GetDataSet(string path)
        {
            // 加载Excel文件
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                var excelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                //Excel首行是列头行
                //excelReader.IsFirstRowAsColumnNames = true;
                var book = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    // Gets or sets a value indicating whether to set the DataColumn.DataType 
                    // property in a second pass.
                    UseColumnDataType = true,

                    // Gets or sets a callback to obtain configuration options for a DataTable. 
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        // Gets or sets a value indicating the prefix of generated column names.
                        //EmptyColumnNamePrefix = "Column",

                        // Gets or sets a value indicating whether to use a row from the 
                        // data as column names.
                        UseHeaderRow = true,

                        // Gets or sets a callback to determine which row is the header row. 
                        // Only called when UseHeaderRow = true.
                        ReadHeaderRow = (rowReader) =>
                        {
                            // F.ex skip the first row and use the 2nd row as column headers:
                            //rowReader.Read();
                        },

                        // Gets or sets a callback to determine whether to include the 
                        // current row in the DataTable.
                        FilterRow = (rowReader) => true,
                    }
                });

                fs.Close();
                return book;
            }
        }

        private static void TryDeleteTempFile(string tempExcelPath)
        {
            try
            {
                if (File.Exists(tempExcelPath))
                {
                    File.SetAttributes(tempExcelPath, FileAttributes.Normal);
                    File.Delete(tempExcelPath);
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}