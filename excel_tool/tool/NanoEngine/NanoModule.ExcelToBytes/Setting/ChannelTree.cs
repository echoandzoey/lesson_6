// ==++==
// 
//   Copyright (c) Zhenlin Yang.  All rights reserved.
// 
// ==--==

using System.Linq;

namespace NanoModule.ExcelToBytes
{
    public class ChannelTree
    {
        public string[] ChannelTreeNodeArray;

        public string LeafChannel
        {
            get
            {
                if (null != ChannelTreeNodeArray)
                {
                    return ChannelTreeNodeArray[^1];
                }

                return null;
            }
        }

        public ChannelTree(string rawInfo)
        {
            ChannelTreeNodeArray = rawInfo.Trim().Split('/').Select(x => x.Trim()).ToArray();
        }
    }
}
