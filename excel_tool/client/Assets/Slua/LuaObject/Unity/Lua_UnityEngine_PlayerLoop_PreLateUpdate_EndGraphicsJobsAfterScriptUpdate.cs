﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PlayerLoop_PreLateUpdate_EndGraphicsJobsAfterScriptUpdate : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.PlayerLoop.PreLateUpdate.EndGraphicsJobsAfterScriptUpdate o;
			o=new UnityEngine.PlayerLoop.PreLateUpdate.EndGraphicsJobsAfterScriptUpdate();
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
		getTypeTable(l,"UnityEngine.PlayerLoop.PreLateUpdate.EndGraphicsJobsAfterScriptUpdate");
		createTypeMetatable(l,constructor, typeof(UnityEngine.PlayerLoop.PreLateUpdate.EndGraphicsJobsAfterScriptUpdate),typeof(System.ValueType));
	}
}
