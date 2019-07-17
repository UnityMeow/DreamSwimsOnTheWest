#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CAssetBundleManager
** 版  权:	(C)  
** 创建人:  Unity喵
** 日  期:	2019.6.12
** 描  述: 	AB包资源管理器
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

public class CAssetBundleManager : CInstanceNull<CAssetBundleManager>
{
    //ab包路径
    string m_ab_path;
    //主AB包名
    string main_ab_name;
    //ab包资源表
    Dictionary<string, AssetBundle> m_ab_list;
    //依赖关系
    AssetBundleManifest ab_manifest;
    public CAssetBundleManager()
    {
        //初始AB包路径信息
        m_ab_path = "";
        //初始主包包名
        main_ab_name = "AB";
        m_ab_list = new Dictionary<string, AssetBundle>();
    }
    //Lua调用 加载AB包
    public Object LuaLoadAssetBundle(string path_name,string bag_name, string res_name)
    {
        m_ab_path = path_name;
        return LoadAssetBundle<Object>(bag_name, res_name);
    }
    //AB包加载
    public T LoadAssetBundle<T>(string bag_name, string res_name)
        where T :Object
    {
        if(ab_manifest == null)
        {
             AssetBundle main_ab = AssetBundle.LoadFromFile(m_ab_path + "/" + main_ab_name);
             ab_manifest = main_ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        }
        string[] dependent_name = ab_manifest.GetAllDependencies(res_name);
        for (int i = 0; i < dependent_name.Length; i++)
        {
            if (!m_ab_list.ContainsKey(dependent_name[i]))
                m_ab_list.Add(dependent_name[i], AssetBundle.LoadFromFile(m_ab_path +  "/" + dependent_name[i]));
        }
        if(!m_ab_list.ContainsKey(bag_name))
            m_ab_list.Add(bag_name, AssetBundle.LoadFromFile(m_ab_path +  "/" + bag_name));
        //根据包名资源名获取Obj
        return GetObj<T>(bag_name, res_name);
    }
    //获取Obj
    T GetObj<T>(string bag,string name)
        where T: Object
    {
        return m_ab_list[bag].LoadAsset<T>(name);
    }
}
