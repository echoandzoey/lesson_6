﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_EarlyUpdate : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.EarlyUpdate o;
			o=new UnityEngine.PlayerLoop.EarlyUpdate();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.PlayerLoop.EarlyUpdate");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.EarlyUpdate),typeof(System.ValueType));
	}
}
