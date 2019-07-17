#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CResLoadMgr
** 版  权:	(C)  
** 创建人:  Unity喵
** 日  期:	2019.6.11
** 描  述: 	资源加载管理器 用于管理所有的资源加载
**************************** 修改记录 ******************************
** 修改人: 
** 日  期: 
** 描  述: 
*******************************************************************/
#endregion

using GameEngin.Instance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngin.Res
{
public class CResLoadMgr : CInstanceMono<CResLoadMgr>
{
    //AB加载模式状态
    public static bool IsLoadAssetBundle = false;
    //预设体加载
    public GameObject LoadPrefab(string pathName, string resName, string bagName = "")
    {
        if (IsLoadAssetBundle)
        {
            return Instantiate(CAssetBundleManager.Instance.LuaLoadAssetBundle(pathName,bagName,resName) as GameObject);
         }
        else
        {
            //通过路径加载预设体
            GameObject go = Resources.Load<GameObject>(pathName + "/" +  resName);
            if (go == null)
            {
                CGlobalUtil.Log("CResLoadMgr: Resources加载路径加载失败");
                return null;
            }
            return Instantiate(go);
        }
    }
    //资源加载
    public Object LoadObject(string pathName, string resName, string bagName = "")
    {
        if (IsLoadAssetBundle)
        { 
            return CAssetBundleManager.Instance.LuaLoadAssetBundle(pathName,bagName,resName);
        }
        else
        {
            //通过路径加载资源
            Object go = Resources.Load<Object>(pathName + "/" + resName);
            if (go == null)
            {
                CGlobalUtil.Log("CResLoadMgr: Resources加载路径加载失败");
                return null;
            }
            return go;
        }
    }
}
}
