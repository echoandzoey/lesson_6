// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

using System;
using System.Collections.Generic;
using System.Linq;

namespace NanoModule.ExcelToBytes.Setting
{
    /// <summary>
    ///     设置信息
    /// </summary>
    public class SettingInfo
    {
        public const string Excel_Path_Name = "Excel目录";

        /// <summary>Excel文件路径</summary>
        public static string Excel_Path => SettingMgr.GetPath(Excel_Path_Name, string.Empty);

        public static string Excel_ChannelTree_Name = "Excel渠道树";

        public static Dictionary<string, ChannelTree> Excel_ChannelTreeDic
        {
            get
            {
                string argStr = SettingMgr.GetSetting<string>(Excel_ChannelTree_Name, "");
                var args = argStr.Split(';');
                var ret = new Dictionary<string, ChannelTree>();
                foreach (var arg in args)
                {
                    var argTrim = arg.Trim();
                    if (!string.IsNullOrWhiteSpace(argTrim))
                    {
                        var tree = new ChannelTree(argTrim);
                        ret.Add(tree.LeafChannel, tree);
                    }
                }

                return ret;
            }
        }

        public const string Server_Bytes_Path_Name = "服务器数据目录";

        /// <summary>服务器配置文件路径</summary>
        public static string Server_Bytes_Path => SettingMgr.GetPath(Server_Bytes_Path_Name, string.Empty);

        public static string AddressInfo()
        {
            return $@"Excel_Path={Excel_Path}, Server_Bytes_Path={Server_Bytes_Path}";
        }
    }
}