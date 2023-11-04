// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

using System;
using System.IO;
using System.Reflection;
using NanoModule.ExcelToBytes.Manager;

namespace NanoModule.ExcelToBytes
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("NanoModule.ExcelToBytes Running");

            var location = Assembly.GetEntryAssembly()?.Location;
            if (string.IsNullOrWhiteSpace(location))
            {
                Console.WriteLine("NanoModule.ExcelToBytes Program Exception");
                return -1;
            }
            var locationDir = Path.GetDirectoryName(location);
            if (string.IsNullOrWhiteSpace(locationDir))
            {
                Console.WriteLine("NanoModule.ExcelToBytes Program Exception");
                return -1;
            }

            Environment.CurrentDirectory = locationDir;

            bool success = ControlMgr.ExportAllChannel();

            Console.WriteLine("NanoModule.ExcelToBytes Finish");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            return success ? 0 : -1;
        }
    }
}
