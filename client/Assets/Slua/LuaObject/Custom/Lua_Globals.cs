using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Globals : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int LoadScene(IntPtr l) {
		try {
			Globals self=(Globals)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.LoadScene(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsSceneLoaded(IntPtr l) {
		try {
			Globals self=(Globals)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			var ret=self.IsSceneLoaded(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_NetworkForCS(IntPtr l) {
		try {
			Globals self=(Globals)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.NetworkForCS);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_NetworkForCS(IntPtr l) {
		try {
			Globals self=(Globals)checkSelf(l);
			NetworkForCS v;
			checkType(l,2,out v);
			self.NetworkForCS=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_NetworkForLua(IntPtr l) {
		try {
			Globals self=(Globals)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.NetworkForLua);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_NetworkForLua(IntPtr l) {
		try {
			Globals self=(Globals)checkSelf(l);
			NetworkForLua v;
			checkType(l,2,out v);
			self.NetworkForLua=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_DataMgr(IntPtr l) {
		try {
			Globals self=(Globals)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.DataMgr);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_DataMgr(IntPtr l) {
		try {
			Globals self=(Globals)checkSelf(l);
			DataMgr v;
			checkType(l,2,out v);
			self.DataMgr=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_Instance(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,Globals.Instance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"Globals");
		addMember(l,LoadScene);
		addMember(l,IsSceneLoaded);
		addMember(l,"NetworkForCS",get_NetworkForCS,set_NetworkForCS,true);
		addMember(l,"NetworkForLua",get_NetworkForLua,set_NetworkForLua,true);
		addMember(l,"DataMgr",get_DataMgr,set_DataMgr,true);
		addMember(l,"Instance",get_Instance,null,false);
		createTypeMetatable(l,null, typeof(Globals),typeof(UnityEngine.MonoBehaviour));
	}
}
