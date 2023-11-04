// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using NanoModule.ExcelToBytes.Exporter;
using NanoModule.ExcelToBytes.ExporterHandler;

namespace NanoModule.ExcelToBytes.Manager
{
    /// <summary>
    ///     控制管理器
    /// </summary>
    public static class ControlMgr
    {
        #region 执行方案

        /// <summary>
        ///     执行导出所有Excel任务
        /// </summary>
        public static bool ExportAllChannel()
        {
            bool success = true;

            var startTime = DateTime.Now;

            Dictionary<string, ExcelTask> allExcelTask = ExcelHandler.GetAllExcelTask();

            var allTask = new List<Task<bool>>();

            foreach (var excelTask in allExcelTask)
            {
                allTask.Add(Task.Run(() => ExportSingleExcelTask(excelTask.Value)));
            }

            Task.WaitAll(allTask.ToArray());

            var interval = DateTime.Now - startTime;
            Console.WriteLine($"[数据处理完成]时间:{interval.TotalSeconds}(s)");

            foreach (var task in allTask)
            {
                success &= task.Result;
            }

            return success;
        }

        /// <summary>
        ///     执行导出单个Excel任务
        /// </summary>
        /// <param name="excelTask">单个Excel任务</param>
        public static bool ExportSingleExcelTask(ExcelTask excelTask)
        {
            return Export(excelTask);
        }

        #endregion

        #region 具体执行

        /// <summary>
        ///     导出数据文件和模板
        /// </summary>
        /// <param name="excelTask">Excel任务</param>
        private static bool Export(ExcelTask excelTask)
        {
            DataTable dt = ExcelReader.GetExcelData(excelTask.ExcelPath);

            if (null == dt)
            {
                return false;
            }

            List<ColumnHeader> columnHeaderList;
            try
            {
                columnHeaderList = ColumnHeaderHandler.GetColumnHeaderList(dt);
            }
            catch (Exception exp)
            {
                Console.WriteLine($"[失败]获取客户端列头信息失败. 请检查列头格式. 没有执行导出过程. Excel路径:{excelTask.ExcelPath}.\nException:{exp}");
                return false;
            }

            var jsonExporter = new JsonExporter();
            try
            {
                if (null != columnHeaderList)
                {
                    jsonExporter.Export(excelTask.ExcelPath, excelTask.ChannelList, dt, columnHeaderList);
                }

                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine($"[失败]导出Json失败. Excel路径:{excelTask.ExcelPath}.\nException:{exp}");
                return false;
            }
        }

        #endregion
    }
}