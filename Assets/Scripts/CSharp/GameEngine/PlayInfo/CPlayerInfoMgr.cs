#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CPlayerInfoMgr
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
using GameEngin.Instance;
using UnityEngine;

//[LuaCallCSharp]
//public static List<Type> LuaCallCSharp = new List<Type>(){
//    typeof(UnityEngine.Events.UnityAction<bool>)
//};

public class CPlayerInfoMgr : CInstanceNull<CPlayerInfoMgr> 
{
    public string m_ID = "";
    //查找本地记录
    public bool FindRecord()
    {
        string ID = PlayerPrefs.GetString("账号","");
        if(ID == "")
            return false;
        m_ID = ID;
        return true;
    }
    //修改本地记录
    public void ChangeRecord(string ID)
    {
        PlayerPrefs.SetString("账号",ID);
    }
}
