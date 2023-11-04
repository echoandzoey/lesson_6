// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

using System;
using System.Collections.Generic;
using System.Data;
using NanoModule.ExcelToBytes.ExporterHandler;

namespace NanoModule.ExcelToBytes.Exporter
{
    internal class ColumnHeader
    {
        public int ColumnIndex; //索引
        public string DefaultName; //默认名（表格）
        public string PropertyName; //处理后的属性名(首字母大写)
        public string ElementType; //元素类型
        public string Type; //数据类型,包括高维数组
        public DataTypeCode Code; //数据结构类型
        public string Comment; //注释
        public bool Hexadecimal; //是否是16进制
        public string RawColumn; //原始数据(不含主键标记）

        public bool IsKey;

        internal ColumnHeader(int index)
        {
            ColumnIndex = index;
        }
    }

    internal class ColumnHeaderHandler
    {
        public static List<ColumnHeader> GetColumnHeaderList(DataTable sheet)
        {
            var ret = new List<ColumnHeader>();

            //没有列头和注释行不操作
            if (sheet.Rows.Count < 1)
            {
                return ret;
            }

            DataColumnCollection columns = sheet.Columns;

            //注释行
            DataRow commentRow = sheet.Rows[0];

            for (var index = 0; index < columns.Count; index++)
            {
                DataColumn column = columns[index];
                //表头为空,忽略整列,一般作注释用
                if (column.ColumnName.StartsWith("Column") || string.IsNullOrWhiteSpace(column.ColumnName))
                {
                    continue;
                }

                string comment = !string.IsNullOrWhiteSpace(commentRow[column].ToString()) ? commentRow[column].ToString() : "Missing comment";
                var columnHeader = GetColumnHeader(column, comment, index);
                ret.Add(columnHeader);
            }

            return ret;
        }

        public static ColumnHeader GetColumnHeader(DataColumn column, string comment, int index)
        {
            ColumnHeader columnHeader = new ColumnHeader(index);

            string rawColumnStr = column.ToString().Trim();
            if (rawColumnStr.StartsWith("#"))
            {
                columnHeader.IsKey = true;
                rawColumnStr = rawColumnStr.Substring(1).Trim();
            }

            columnHeader.RawColumn = rawColumnStr;

            string[] headerContentArr = rawColumnStr.Split(':');
            if (headerContentArr.Length <= 1)
            {
                throw new Exception("请检查列头" + rawColumnStr);
            }

            var type = headerContentArr[1];

            if (type.Contains("hex"))
            {
                columnHeader.Hexadecimal = true;
                type = type.Substring(0, type.Length - "hex".Length);
            }


            if (headerContentArr.Length == 2)
            {
                columnHeader.ElementType = type;
                columnHeader.Type = type;
                columnHeader.Code = GetDataTypeCode(columnHeader.Type);

                // Unity Vector2/Vector3/Vector4 support
                if (columnHeader.Type.StartsWith("vector"))
                {
                    columnHeader.Type = string.Format("UnityEngine.Vector{0}", columnHeader.Type.Remove(0, "vector".Length));
                }
            }
            else
            {
                throw new NotSupportedException();
            }
            
            columnHeader.DefaultName = headerContentArr[0];
            columnHeader.PropertyName = headerContentArr[0].Substring(0, 1).ToUpper() + headerContentArr[0].Substring(1);
            columnHeader.Comment = comment;

            return columnHeader;
        }

        /// <summary>
        ///     获得DataTypeCode
        /// </summary>
        /// <param name="type">数据类型（字符串）</param>
        /// <returns></returns>
        private static DataTypeCode GetDataTypeCode(string type)
        {
            switch (type)
            {
                case "bool":
                    return DataTypeCode.Boolean;
                case "byte":
                    return DataTypeCode.Byte;
                case "int":
                    return DataTypeCode.Int32;
                case "uint":
                    return DataTypeCode.UInt32;
                case "long":
                    return DataTypeCode.Int64;
                case "ulong":
                    return DataTypeCode.UInt64;
                case "float":
                    return DataTypeCode.Single;
                case "double":
                    return DataTypeCode.Double;
                case "string":
                    return DataTypeCode.String;
                case "vector2":
                    return DataTypeCode.Vector2;
                case "vector3":
                    return DataTypeCode.Vector3;
                case "vector4":
                    return DataTypeCode.Vector4;
                default:
                    throw new Exception("数据类型不存在：" + type);
            }
        }
    }
}