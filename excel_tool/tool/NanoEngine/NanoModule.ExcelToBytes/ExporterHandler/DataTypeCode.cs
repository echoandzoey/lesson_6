// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

namespace NanoModule.ExcelToBytes.ExporterHandler
{
    internal enum DataTypeCode : byte
    {
        #region TypeCode基本类型

        //
        // 摘要:
        //     空引用。
        Empty = 0,
        //
        // 摘要:
        //     简单类型，表示 true 或 false 的布尔值。
        Boolean = 3,
        //
        // 摘要:
        //     整型，表示值介于 0 到 255 之间的无符号 8 位整数。
        Byte = 6,
        //
        // 摘要:
        //     整型，表示值介于 -2147483648 到 2147483647 之间的有符号 32 位整数。
        Int32 = 9,
        //
        // 摘要:
        //     整型，表示值介于 0 到 4294967295 之间的无符号 32 位整数。
        UInt32 = 10,
        //
        // 摘要:
        //     整型，表示值介于 -9223372036854775808 到 9223372036854775807 之间的有符号 64 位整数。
        Int64 = 11,
        //
        // 摘要:
        //     整型，表示值介于 0 到 18446744073709551615 之间的无符号 64 位整数。
        UInt64 = 12,
        //
        // 摘要:
        //     浮点型，表示从大约 1.5 x 10 -45 到 3.4 x 10 38 且精度为 7 位的值。
        Single = 13,
        //
        // 摘要:
        //     浮点型，表示从大约 5.0 x 10 -324 到 1.7 x 10 308 且精度为 15 到 16 位的值。
        Double = 14,
        //
        // 摘要:
        //     密封类类型，表示 Unicode 字符串。
        String = 18,

        #endregion

        #region 扩展

        Vector2 = 128,

        Vector3 = 129,
        
        Vector4 = 130,

        #endregion
    }
}