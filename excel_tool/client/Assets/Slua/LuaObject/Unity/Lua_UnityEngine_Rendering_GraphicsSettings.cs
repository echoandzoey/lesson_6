using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Rendering_GraphicsSettings : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int HasShaderDefine_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.Rendering.BuiltinShaderDefine a1;
				a1 = (UnityEngine.Rendering.BuiltinShaderDefine)LuaDLL.luaL_checkinteger(l, 1);
				var ret=UnityEngine.Rendering.GraphicsSettings.HasShaderDefine(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				UnityEngine.Rendering.GraphicsTier a1;
				a1 = (UnityEngine.Rendering.GraphicsTier)LuaDLL.luaL_checkinteger(l, 1);
				UnityEngine.Rendering.BuiltinShaderDefine a2;
				a2 = (UnityEngine.Rendering.BuiltinShaderDefine)LuaDLL.luaL_checkinteger(l, 2);
				var ret=UnityEngine.Rendering.GraphicsSettings.HasShaderDefine(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function HasShaderDefine to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetGraphicsSettings_s(IntPtr l) {
		try {
			var ret=UnityEngine.Rendering.GraphicsSettings.GetGraphicsSettings();
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
	static public int SetShaderMode_s(IntPtr l) {
		try {
			UnityEngine.Rendering.BuiltinShaderType a1;
			a1 = (UnityEngine.Rendering.BuiltinShaderType)LuaDLL.luaL_checkinteger(l, 1);
			UnityEngine.Rendering.BuiltinShaderMode a2;
			a2 = (UnityEngine.Rendering.BuiltinShaderMode)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Rendering.GraphicsSettings.SetShaderMode(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetShaderMode_s(IntPtr l) {
		try {
			UnityEngine.Rendering.BuiltinShaderType a1;
			a1 = (UnityEngine.Rendering.BuiltinShaderType)LuaDLL.luaL_checkinteger(l, 1);
			var ret=UnityEngine.Rendering.GraphicsSettings.GetShaderMode(a1);
			pushValue(l,true);
			pushEnum(l,(int)ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetCustomShader_s(IntPtr l) {
		try {
			UnityEngine.Rendering.BuiltinShaderType a1;
			a1 = (UnityEngine.Rendering.BuiltinShaderType)LuaDLL.luaL_checkinteger(l, 1);
			UnityEngine.Shader a2;
			checkType(l,2,out a2);
			UnityEngine.Rendering.GraphicsSettings.SetCustomShader(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetCustomShader_s(IntPtr l) {
		try {
			UnityEngine.Rendering.BuiltinShaderType a1;
			a1 = (UnityEngine.Rendering.BuiltinShaderType)LuaDLL.luaL_checkinteger(l, 1);
			var ret=UnityEngine.Rendering.GraphicsSettings.GetCustomShader(a1);
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
	static public int RegisterRenderPipelineSettings_s(IntPtr l) {
		try {
			UnityEngine.Rendering.RenderPipelineGlobalSettings a1;
			checkType(l,1,out a1);
			UnityEngine.Rendering.GraphicsSettings.RegisterRenderPipelineSettings<UnityEngine.Rendering.RenderPipeline>(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UnregisterRenderPipelineSettings_s(IntPtr l) {
		try {
			UnityEngine.Rendering.GraphicsSettings.UnregisterRenderPipelineSettings<UnityEngine.Rendering.RenderPipeline>();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetSettingsForRenderPipeline_s(IntPtr l) {
		try {
			var ret=UnityEngine.Rendering.GraphicsSettings.GetSettingsForRenderPipeline<UnityEngine.Rendering.RenderPipeline>();
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
	static public int get_transparencySortMode(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)UnityEngine.Rendering.GraphicsSettings.transparencySortMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_transparencySortMode(IntPtr l) {
		try {
			UnityEngine.TransparencySortMode v;
			v = (UnityEngine.TransparencySortMode)LuaDLL.luaL_checkinteger(l, 2);
			UnityEngine.Rendering.GraphicsSettings.transparencySortMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_transparencySortAxis(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.transparencySortAxis);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_transparencySortAxis(IntPtr l) {
		try {
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			UnityEngine.Rendering.GraphicsSettings.transparencySortAxis=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_realtimeDirectRectangularAreaLights(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.realtimeDirectRectangularAreaLights);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_realtimeDirectRectangularAreaLights(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Rendering.GraphicsSettings.realtimeDirectRectangularAreaLights=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lightsUseLinearIntensity(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.lightsUseLinearIntensity);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lightsUseLinearIntensity(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Rendering.GraphicsSettings.lightsUseLinearIntensity=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_lightsUseColorTemperature(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.lightsUseColorTemperature);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_lightsUseColorTemperature(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Rendering.GraphicsSettings.lightsUseColorTemperature=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_defaultRenderingLayerMask(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.defaultRenderingLayerMask);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_defaultRenderingLayerMask(IntPtr l) {
		try {
			System.UInt32 v;
			checkType(l,2,out v);
			UnityEngine.Rendering.GraphicsSettings.defaultRenderingLayerMask=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_useScriptableRenderPipelineBatching(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.useScriptableRenderPipelineBatching);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useScriptableRenderPipelineBatching(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Rendering.GraphicsSettings.useScriptableRenderPipelineBatching=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_logWhenShaderIsCompiled(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.logWhenShaderIsCompiled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_logWhenShaderIsCompiled(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Rendering.GraphicsSettings.logWhenShaderIsCompiled=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_disableBuiltinCustomRenderTextureUpdate(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.disableBuiltinCustomRenderTextureUpdate);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_disableBuiltinCustomRenderTextureUpdate(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Rendering.GraphicsSettings.disableBuiltinCustomRenderTextureUpdate=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_currentRenderPipeline(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.currentRenderPipeline);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_renderPipelineAsset(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_renderPipelineAsset(IntPtr l) {
		try {
			UnityEngine.Rendering.RenderPipelineAsset v;
			checkType(l,2,out v);
			UnityEngine.Rendering.GraphicsSettings.renderPipelineAsset=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_defaultRenderPipeline(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.defaultRenderPipeline);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_defaultRenderPipeline(IntPtr l) {
		try {
			UnityEngine.Rendering.RenderPipelineAsset v;
			checkType(l,2,out v);
			UnityEngine.Rendering.GraphicsSettings.defaultRenderPipeline=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_allConfiguredRenderPipelines(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.allConfiguredRenderPipelines);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cameraRelativeLightCulling(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.cameraRelativeLightCulling);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cameraRelativeLightCulling(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Rendering.GraphicsSettings.cameraRelativeLightCulling=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cameraRelativeShadowCulling(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Rendering.GraphicsSettings.cameraRelativeShadowCulling);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cameraRelativeShadowCulling(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			UnityEngine.Rendering.GraphicsSettings.cameraRelativeShadowCulling=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Rendering.GraphicsSettings");
		addMember(l,HasShaderDefine_s);
		addMember(l,GetGraphicsSettings_s);
		addMember(l,SetShaderMode_s);
		addMember(l,GetShaderMode_s);
		addMember(l,SetCustomShader_s);
		addMember(l,GetCustomShader_s);
		addMember(l,RegisterRenderPipelineSettings_s);
		addMember(l,UnregisterRenderPipelineSettings_s);
		addMember(l,GetSettingsForRenderPipeline_s);
		addMember(l,"transparencySortMode",get_transparencySortMode,set_transparencySortMode,false);
		addMember(l,"transparencySortAxis",get_transparencySortAxis,set_transparencySortAxis,false);
		addMember(l,"realtimeDirectRectangularAreaLights",get_realtimeDirectRectangularAreaLights,set_realtimeDirectRectangularAreaLights,false);
		addMember(l,"lightsUseLinearIntensity",get_lightsUseLinearIntensity,set_lightsUseLinearIntensity,false);
		addMember(l,"lightsUseColorTemperature",get_lightsUseColorTemperature,set_lightsUseColorTemperature,false);
		addMember(l,"defaultRenderingLayerMask",get_defaultRenderingLayerMask,set_defaultRenderingLayerMask,false);
		addMember(l,"useScriptableRenderPipelineBatching",get_useScriptableRenderPipelineBatching,set_useScriptableRenderPipelineBatching,false);
		addMember(l,"logWhenShaderIsCompiled",get_logWhenShaderIsCompiled,set_logWhenShaderIsCompiled,false);
		addMember(l,"disableBuiltinCustomRenderTextureUpdate",get_disableBuiltinCustomRenderTextureUpdate,set_disableBuiltinCustomRenderTextureUpdate,false);
		addMember(l,"currentRenderPipeline",get_currentRenderPipeline,null,false);
		addMember(l,"renderPipelineAsset",get_renderPipelineAsset,set_renderPipelineAsset,false);
		addMember(l,"defaultRenderPipeline",get_defaultRenderPipeline,set_defaultRenderPipeline,false);
		addMember(l,"allConfiguredRenderPipelines",get_allConfiguredRenderPipelines,null,false);
		addMember(l,"cameraRelativeLightCulling",get_cameraRelativeLightCulling,set_cameraRelativeLightCulling,false);
		addMember(l,"cameraRelativeShadowCulling",get_cameraRelativeShadowCulling,set_cameraRelativeShadowCulling,false);
		createTypeMetatable(l,null, typeof(UnityEngine.Rendering.GraphicsSettings),typeof(UnityEngine.Object));
	}
}
