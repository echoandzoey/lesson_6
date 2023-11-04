// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

using System;
using System.Collections.Generic;
using System.IO;

namespace NanoModule.ExcelToBytes.ExporterHandler
{
    /// <summary>
    ///     文件拷贝处理程序
    /// </summary>
    internal static class FileCopyHandler
    {
        /// <summary>
        ///     拷贝文件到目标路径
        /// </summary>
        /// <param name="product">产出数据</param>
        /// <param name="targetFilePathList">目标文件路径列表</param>
        internal static void FileCopy(byte[] product, List<string> targetFilePathList)
        {
            foreach (string targetFilePath in targetFilePathList)
            {
                var dir = Path.GetDirectoryName(targetFilePath);
                if (null != dir && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                if (!File.Exists(targetFilePath))
                {
                    try
                    {
                        File.WriteAllBytes(targetFilePath, product);
                        Console.WriteLine($"[成功]创建成功! 路径={targetFilePath}");
                    }
                    catch
                    {
                        Console.WriteLine($"[失败]文件写入失败。写入路径={targetFilePath}");
                    }
                }
                else
                {
                    try
                    {
                        string md5Product = MD5Handler.ComputeByteArray(product);
                        string md5File = MD5Handler.ComputeFile(targetFilePath);

                        if (md5Product == md5File)
                        {
                            continue;
                        }

                        File.WriteAllBytes(targetFilePath, product);
                        Console.WriteLine($"[成功]更新成功! 路径={targetFilePath}");
                    }
                    catch
                    {
                        Console.WriteLine($"[失败]文件写入失败。写入路径={targetFilePath}");
                    }
                }
            }
        }
    }
}