// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NanoModule.ExcelToBytes.Setting;

namespace NanoModule.ExcelToBytes
{
    /// <summary>
    ///     Excel处理程序
    /// </summary>
    public static class ExcelHandler
    {
        /// <summary>
        ///     根据渠道获取所有Excel信息
        /// </summary>
        /// <returns>所有Excel路径(NotNull)</returns>
        public static Dictionary<string, Dictionary<string, ExcelInfo>> GetAllExcelChannelInfo()
        {
            var ret = new Dictionary<string, Dictionary<string, ExcelInfo>>();

            var channelTreeDic = SettingInfo.Excel_ChannelTreeDic;

            foreach (var channelTree in channelTreeDic.Values)
            {
                var dic = new Dictionary<string, ExcelInfo>();

                // 下层覆盖上层
                foreach (var excelChannelTreeNode in channelTree.ChannelTreeNodeArray)
                {
                    var excelFiles = GetExcelPathForSubDirectory(excelChannelTreeNode);
                    foreach (var excelFile in excelFiles)
                    {
                        var excelInfo = new ExcelInfo(excelFile, excelChannelTreeNode);
                        dic[excelInfo.FileNameNoneExt] = excelInfo;
                    }
                }

                ret.Add(channelTree.LeafChannel, dic);
            }

            return ret;
        }

        public static Dictionary<string, ExcelTask> GetAllExcelTask()
        {
            var allExcelChannelInfo = GetAllExcelChannelInfo();
            var tasks = new Dictionary<string, ExcelTask>();

            foreach (var excelChannelInfoPair in allExcelChannelInfo)
            {
                string channel = excelChannelInfoPair.Key;
                foreach (var excelInfoPair in excelChannelInfoPair.Value)
                {
                    var excelPath = excelInfoPair.Value.ExcelPath;
                    if (!tasks.ContainsKey(excelPath))
                    {
                        tasks[excelPath] = new ExcelTask(excelPath);
                    }

                    tasks[excelPath].ChannelList.Add(channel);
                }
            }

            return tasks;
        }

        /// <summary>
        ///     获取Base或某一个渠道的所有Excel文件路径
        /// </summary>
        public static List<string> GetExcelPathForSubDirectory(string subDir)
        {
            var subDirPath = Path.Combine(SettingInfo.Excel_Path, subDir);

            if (!Directory.Exists(subDirPath))
            {
                Console.WriteLine($"[错误]设置文件内容错误！AddressInfo={SettingInfo.AddressInfo()}");
                return new List<string>();
            }

            var allExcelPathArrayOrigin = Directory.GetFiles(subDirPath, "*.xlsx", SearchOption.AllDirectories);

            var allExcelPathList = allExcelPathArrayOrigin
                .Where(x => !x.Contains('$'))
                .Select(x => x.Replace('\\', '/'))
                .ToList();

            allExcelPathList.Sort();

            return allExcelPathList;
        }
    }

    /// <summary>
    ///     Excel信息
    /// </summary>
    public class ExcelInfo
    {
        public ExcelInfo(string excelPath, string channel)
        {
            ExcelPath = excelPath;
            DirName = Path.GetDirectoryName(excelPath)?.Split('\\').Last();
            FileName = Path.GetFileName(excelPath);
            FileNameNoneExt = Path.GetFileNameWithoutExtension(excelPath);
            if (null == FileNameNoneExt)
            {
                Console.WriteLine($"[错误]FileNameNoneExt异常！ExcelPath={excelPath}");
                return;
            }

            Channel = channel;
        }

        /// <summary>文件名（不含扩展名）</summary>
        public string FileNameNoneExt { get; set; }

        /// <summary>文件名（含扩展名）</summary>
        public string FileName { get; set; }

        /// <summary>全路径（含扩展名）</summary>
        public string ExcelPath { get; set; }

        /// <summary>目录名</summary>
        public string DirName { get; set; }

        /// <summary>渠道</summary>
        public string Channel { get; set; }
    }

    public class ExcelTask
    {
        /// <summary>全路径（含扩展名）</summary>
        public string ExcelPath;

        /// <summary>渠道列表</summary>
        public readonly List<string> ChannelList = new();

        public ExcelTask(string excelPath)
        {
            ExcelPath = excelPath;
        }
    }
}