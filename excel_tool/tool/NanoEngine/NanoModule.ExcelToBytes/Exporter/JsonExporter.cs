// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using NanoModule.ExcelToBytes.ExporterHandler;
using NanoModule.ExcelToBytes.Setting;

namespace NanoModule.ExcelToBytes.Exporter
{
    internal class JsonExporter
    {
        internal void Export(string excelPath, List<string> channelList, DataTable dt, List<ColumnHeader> columnHeaderList)
        {
            //无扩展文件名（原始）
            var fileNameNoneExt = Path.GetFileNameWithoutExtension(excelPath);
            if (null == fileNameNoneExt)
            {
                return;
            }

            //导出临时文件
            var product = Encoding.UTF8.GetBytes(ProduceJson(dt, fileNameNoneExt, columnHeaderList));

            //目标文件地址列表
            List<string> targetFilePathList = new List<string>();

            foreach (var channel in channelList)
            {
                //服务器数据路径
                string serverBytesPath = Path.Combine(SettingInfo.Server_Bytes_Path, channel, fileNameNoneExt + ".json");
                targetFilePathList.Add(serverBytesPath);
            }

            //将临时文件拷贝到目标地址
            FileCopyHandler.FileCopy(product, targetFilePathList);
        }

        private string ProduceJson(DataTable dt, string fileName, List<ColumnHeader> columnHeaderList)
        {
            if (dt.Columns.Count <= 0)
            {
                throw new Exception("Colume.Count <= 0");
            }

            if (dt.Rows.Count <= 0)
            {
                throw new Exception("Rows.Count <= 0");
            }

            using (StringWriter sw = new StringWriter {NewLine = "\r\n"})
            {
                sw.WriteLine("[");

                bool isFirstRow = true;

                const int firstDataRow = 1; //直接忽略前两行
                for (int i = firstDataRow; i < dt.Rows.Count; i++)
                {
                    //第一列为空,忽略整行
                    if (string.IsNullOrWhiteSpace(dt.Rows[i].ItemArray[0].ToString()))
                    {
                        continue;
                    }

                    if (isFirstRow)
                    {
                        sw.WriteLine("  {");
                    }
                    else
                    {
                        sw.WriteLine("  ,{");
                    }
                    isFirstRow = false;

                    bool isFirstColumn = true;
                    DataRow row = dt.Rows[i];
                    for (var columnTempIndex = 0; columnTempIndex < columnHeaderList.Count; columnTempIndex++)
                    {
                        ColumnHeader columnHeader = columnHeaderList[columnTempIndex];

                        string rawColumnStr = columnHeader.RawColumn.Trim();

                        //表格中的值
                        string valueString;

                        object cell = row[columnHeader.ColumnIndex];
                        if (cell is DateTime time)
                        {
                            int millisecond = time.Millisecond;
                            if (millisecond > 990)
                            {
                                time = time.AddSeconds(0.5);
                            }

                            valueString = $"{time:yyyy}/{time:MM}/{time:dd} {time:HH:mm:ss}";
                        }
                        else
                        {
                            valueString = cell.ToString().Trim();
                        }

                        //表头
                        string defaultName = rawColumnStr.Split(':')[0];

                        string content = valueString;

                        switch (columnHeader.Code)
                        {
                            case DataTypeCode.Boolean:
                            case DataTypeCode.Byte:
                            case DataTypeCode.Int32:
                            case DataTypeCode.UInt32:
                            case DataTypeCode.Int64:
                            case DataTypeCode.UInt64:
                            case DataTypeCode.Single:
                            case DataTypeCode.Double:
                                break;
                            default:
                                content = $"\"{content}\"";
                                break;
                        }

                        if (string.IsNullOrWhiteSpace(content))
                        {
                            switch (columnHeader.Code)
                            {
                                case DataTypeCode.Boolean:
                                    content = "false";
                                    break;
                                case DataTypeCode.Byte:
                                case DataTypeCode.Int32:
                                case DataTypeCode.UInt32:
                                case DataTypeCode.Int64:
                                case DataTypeCode.UInt64:
                                case DataTypeCode.Single:
                                case DataTypeCode.Double:
                                    content = "0";
                                    break;
                                default:
                                    content = "\"\"";
                                    break;
                            }
                        }

                        if (isFirstColumn)
                        {
                            sw.WriteLine($"    \"{defaultName}\": {content}");
                        }
                        else
                        {
                            sw.WriteLine($"    ,\"{defaultName}\": {content}");
                        }
                        isFirstColumn = false;
                    }

                    sw.WriteLine("  }");
                }

                sw.WriteLine("]");

                return sw.ToString();
            }
        }
    }
}
