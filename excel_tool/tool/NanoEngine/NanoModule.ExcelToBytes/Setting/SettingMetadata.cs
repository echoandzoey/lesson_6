// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

using System.Collections.Generic;
using NanoEngineInterface;

namespace NanoModule.ExcelToBytes.Setting
{
    public class SettingMetadata
    {
        private static SettingMetadata m_Instance;

        public static SettingMetadata Instance => m_Instance ?? (m_Instance = new SettingMetadata());

        public string PageName => "数据工具";

        private static readonly Dictionary<string, ValueEnum> m_Dic = new ()
        {
            {SettingInfo.Excel_Path_Name, ValueEnum.String},
            {SettingInfo.Excel_ChannelTree_Name, ValueEnum.String},
            {SettingInfo.Server_Bytes_Path_Name, ValueEnum.String},
        };

        public Dictionary<string, ValueEnum> SettingDic()
        {
            return m_Dic;
        }
    }
}
