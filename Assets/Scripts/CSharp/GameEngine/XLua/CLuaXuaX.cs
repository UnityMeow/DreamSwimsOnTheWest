#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CLuaXuaX
** 版  权:	(C)  
** 创建人:  Unity喵
** 日  期:	
** 描  述: 	
**************************** 修改记录 ******************************
** 修改人: 
** 日  期: 
** 描  述: 
*******************************************************************/
#endregion

using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameEngin.Instance;
using UnityEngine;
using XLua;

public class CLuaXuaX : CInstanceNull<CLuaXuaX> 
{
    //解析器
    private LuaEnv luaEnv;
    public CLuaXuaX()
    {
        luaEnv = new LuaEnv();
        //添加解析方法
        luaEnv.AddLoader(MyLoader);
    }
    //委托
    public byte[] MyLoader(ref string str)
    {
        string path = Application.dataPath + "/Scripts/Lua/" + str + ".lua";
        //如果有转字节数组
        if( File.Exists(path))
            return File.ReadAllBytes(path);
        return null;
    }
    //执行Lua脚本
    public void DoString(string path)
    {
        string str = "require('" + path + "')";
        //执行Lua语句
        luaEnv.DoString(str);
    }
    //销毁
    public void Dispose()
    {
        luaEnv.Dispose();
        m_instance = null;
    } 
}
