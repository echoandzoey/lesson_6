﻿using System;
using System.Collections.Generic;
namespace SLua {
	[LuaBinder(3)]
	public class BindCustom {
		public static Action<IntPtr>[] GetBindList() {
			Action<IntPtr>[] list= {
				Lua_Globals.reg,
				Lua_NetworkForLua.reg,
				Lua_System_Collections_Generic_List_1_int.reg,
				Lua_System_String.reg,
			};
			return list;
		}
	}
}
