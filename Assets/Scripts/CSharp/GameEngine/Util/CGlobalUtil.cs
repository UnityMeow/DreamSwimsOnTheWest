#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CGlobalUtil
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
using UnityEngine;

public class CGlobalUtil
{
    //是否进行Debug调试
    private static bool isDebug = true;
    //统一输出Debug
    public static void Log(object info)
    {
        if (isDebug)
            Debug.Log(info);
    }
}
