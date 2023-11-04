using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_UI_DefaultControls_IFactoryControls : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CreateGameObject(IntPtr l) {
		try {
			UnityEngine.UI.DefaultControls.IFactoryControls self=(UnityEngine.UI.DefaultControls.IFactoryControls)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Type[] a2;
			checkParams(l,3,out a2);
			var ret=self.CreateGameObject(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.UI.DefaultControls.IFactoryControls");
		addMember(l,CreateGameObject);
		createTypeMetatable(l,null, typeof(UnityEngine.UI.DefaultControls.IFactoryControls));
	}
}
