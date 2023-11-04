// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using NanoEngineInterface;

namespace NanoModule.ExcelToBytes.Setting
{
    public static class SettingMgr
    {
        private static string ProjectPath => Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? throw new InvalidOperationException(), "Settings.xml");

        private const string kRootName = "Root";

        internal static bool TryGetAllSetting(out Dictionary<string, object> info)
        {
            var ret = new Dictionary<string, object>();

            string path = ProjectPath;
            if (!File.Exists(path))
            {
                info = null;
                return false;
            }

            try
            {
                XDocument doc = GetXmlDoc(path);
                XElement root = doc.Element(kRootName);
                if (null == root)
                {
                    info = null;
                    return false;
                }

                var pageData = root.Element(SettingMetadata.Instance.PageName);
                if (null == pageData)
                {
                    info = null;
                    return false;
                }

                var dic = SettingMetadata.Instance.SettingDic();
                foreach (var pair in dic)
                {
                    var data = pageData.Element(pair.Key)?.Value;
                    if (!string.IsNullOrWhiteSpace(data))
                    {
                        switch (pair.Value)
                        {
                            case ValueEnum.Boolean:
                                ret.Add(pair.Key, bool.Parse(data));
                                break;
                            case ValueEnum.Int:
                                ret.Add(pair.Key, int.Parse(data));
                                break;
                            case ValueEnum.Long:
                                ret.Add(pair.Key, long.Parse(data));
                                break;
                            case ValueEnum.Float:
                                ret.Add(pair.Key, float.Parse(data));
                                break;
                            case ValueEnum.Double:
                                ret.Add(pair.Key, double.Parse(data));
                                break;
                            case ValueEnum.String:
                                ret.Add(pair.Key, data);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    else
                    {
                        ret.Add(pair.Key, DefaultValue(pair.Value));
                    }
                }
                info = ret;
                return true;
            }
            catch
            {
                info = null;
                return false;
            }
        }

        private static object DefaultValue(ValueEnum valueEnum)
        {
            switch (valueEnum)
            {
                case ValueEnum.Boolean:
                    return false;
                case ValueEnum.Int:
                    return 0;
                case ValueEnum.Long:
                    return 0L;
                case ValueEnum.Float:
                    return 0.0f;
                case ValueEnum.Double:
                    return 0.0;
                case ValueEnum.String:
                    return "";
                default:
                    throw new ArgumentOutOfRangeException(nameof(valueEnum), valueEnum, null);
            }
        }

        #region 获取配置

        public static T GetSetting<T>(string key, T defaultValue = default)
        {
            if (!string.IsNullOrWhiteSpace(key) && TryGetAllSetting(out var info) && info.ContainsKey(key))
            {
                return (T)info[key];
            }

            return defaultValue;
        }

        public static string GetPath(string key, string defaultValue = default)
        {
            try
            {
                var relativePath = GetSetting(key, defaultValue);
                if (!string.IsNullOrWhiteSpace(relativePath))
                {
                    if (Path.IsPathRooted(relativePath))
                    {
                        return Path.GetFullPath(relativePath).Replace('\\', '/');
                    }

                    var projectDirPath = Path.GetDirectoryName(ProjectPath);
                    if (null != projectDirPath)
                    {
                        return Path.GetFullPath(Path.Combine(projectDirPath, relativePath)).Replace('\\', '/');
                    }
                }
            }
            catch
            {
                // ignored
            }

            return defaultValue;
        }

        #endregion

        #region Cache

        private static XDocument m_XmlDocCache;

        private static XDocument GetXmlDoc(string path)
        {
            if (null == m_XmlDocCache)
            {
                m_XmlDocCache = XDocument.Load(path);
            }

            return m_XmlDocCache;
        }

        #endregion
    }
}
