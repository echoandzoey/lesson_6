using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_NetworkForLua : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			NetworkForLua o;
			o=new NetworkForLua();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RecvConnectOK(IntPtr l) {
		try {
			NetworkForLua self=(NetworkForLua)checkSelf(l);
			self.RecvConnectOK();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetCurrentPlayerResponse(IntPtr l) {
		try {
			NetworkForLua self=(NetworkForLua)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			System.Int32 a3;
			checkType(l,4,out a3);
			self.SetCurrentPlayerResponse(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CreatePlayerResponse(IntPtr l) {
		try {
			NetworkForLua self=(NetworkForLua)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			System.Int32 a3;
			checkType(l,4,out a3);
			System.Single a4;
			checkType(l,5,out a4);
			System.Single a5;
			checkType(l,6,out a5);
			System.Single a6;
			checkType(l,7,out a6);
			self.CreatePlayerResponse(a1,a2,a3,a4,a5,a6);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemovePlayerResponse(IntPtr l) {
		try {
			NetworkForLua self=(NetworkForLua)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.RemovePlayerResponse(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ActionResponse(IntPtr l) {
		try {
			NetworkForLua self=(NetworkForLua)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			System.Int32 a3;
			checkType(l,4,out a3);
			System.Int32 a4;
			checkType(l,5,out a4);
			System.Int32 a5;
			checkType(l,6,out a5);
			System.Int32 a6;
			checkType(l,7,out a6);
			System.Single a7;
			checkType(l,8,out a7);
			System.Single a8;
			checkType(l,9,out a8);
			self.ActionResponse(a1,a2,a3,a4,a5,a6,a7,a8);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SyncInfoResponse(IntPtr l) {
		try {
			NetworkForLua self=(NetworkForLua)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.SyncInfoResponse(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SnapshotResponse(IntPtr l) {
		try {
			NetworkForLua self=(NetworkForLua)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			System.Double a3;
			checkType(l,4,out a3);
			System.Double a4;
			checkType(l,5,out a4);
			System.Double a5;
			checkType(l,6,out a5);
			System.Double a6;
			checkType(l,7,out a6);
			System.Double a7;
			checkType(l,8,out a7);
			System.Double a8;
			checkType(l,9,out a8);
			System.Double a9;
			checkType(l,10,out a9);
			System.Double a10;
			checkType(l,11,out a10);
			System.Double a11;
			checkType(l,12,out a11);
			System.Double a12;
			checkType(l,13,out a12);
			self.SnapshotResponse(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddCoinResponse(IntPtr l) {
		try {
			NetworkForLua self=(NetworkForLua)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			System.Single a4;
			checkType(l,5,out a4);
			System.Int32 a5;
			checkType(l,6,out a5);
			self.AddCoinResponse(a1,a2,a3,a4,a5);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveCoinResponse(IntPtr l) {
		try {
			NetworkForLua self=(NetworkForLua)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.RemoveCoinResponse(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"NetworkForLua");
		addMember(l,RecvConnectOK);
		addMember(l,SetCurrentPlayerResponse);
		addMember(l,CreatePlayerResponse);
		addMember(l,RemovePlayerResponse);
		addMember(l,ActionResponse);
		addMember(l,SyncInfoResponse);
		addMember(l,SnapshotResponse);
		addMember(l,AddCoinResponse);
		addMember(l,RemoveCoinResponse);
		createTypeMetatable(l,constructor, typeof(NetworkForLua));
	}
}
