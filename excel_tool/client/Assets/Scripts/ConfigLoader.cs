using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SLua;
using UnityEditor;
using UnityEngine;

[CustomLuaClass]
public class ConfigLoader
{
    public static string Load(string configName)
    {
        var textAsset = Resources.Load<TextAsset>("Config/" + configName);
        return textAsset != null ? textAsset.text : throw new Exception();
    }
}

public class Role
{
    public int Id;
    public string Name;
    public string Resource;
    public float BaseMaxHP;
    // ...
}

public class ConfigLoaderTest
{
    [MenuItem("ConfigLoaderTest/TestCSharp")]
    public static void TestCSharp()
    {
        string str = ConfigLoader.Load("Role");
        List<Role> roleConfig = JsonConvert.DeserializeObject<List<Role>>(str);
        Debug.Log("Count:" + roleConfig.Count);

        Debug.Log(roleConfig[3].Id + " " + roleConfig[3].BaseMaxHP);

        Dictionary<int, Role> roleConfigDic = roleConfig.ToDictionary(x => x.Id);
        Debug.Log(roleConfigDic[105].Id + " " + roleConfigDic[105].BaseMaxHP);
    }

    [MenuItem("ConfigLoaderTest/TestLua")]
    public static void TestLua()
    {
        var luaSvr = new LuaSvr();
        luaSvr.init(null, () =>
        {
            LuaTable luaSelf = (LuaTable)luaSvr.start("config");
            LuaFunction luaConfigTest = (LuaFunction)luaSelf["config_test"];
            luaConfigTest.call(luaSelf);
        });
    }
}
