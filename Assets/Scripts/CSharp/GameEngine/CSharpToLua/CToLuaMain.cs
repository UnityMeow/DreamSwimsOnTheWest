#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CToLuaMain
** 版  权:	(C)  
** 创建人:  Unity喵
** 日  期:	
** 描  述: 	执行Lua脚本主入口
**************************** 修改记录 ******************************
** 修改人: 
** 日  期: 
** 描  述: 
*******************************************************************/
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CToLuaMain : MonoBehaviour 
{
    void Awake()
    {
        //执行Lua脚本
        CLuaXuaX.Instance.DoString("Main");
    }
    
}
