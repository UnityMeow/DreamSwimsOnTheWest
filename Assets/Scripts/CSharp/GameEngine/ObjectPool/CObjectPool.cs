#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CObjectPool
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
using GameEngin.Res;
using UnityEngine;

//==================待完善
public class CObjectPool : CInstanceNull<CObjectPool> 
{
    Dictionary<string, List<Object>> m_poolList;
    public CObjectPool()
    {
        m_poolList = new Dictionary<string, List<Object>>();
    }
    //获取对象
    public Object GetObj(string name)
    {
        if(!IsHavePool(name))
        {
            //添加池子
            m_poolList.Add(name,new List<Object>());
        }
        //获取缓存池
        List<Object> pool = m_poolList[name];
        //池中无对象
        if(pool.Count == 0)
            return new Object();
        //取第一个
        Object obj = pool[0];
        //从池子中移除
        pool.RemoveAt(0);
        return obj;
    }
    //获取资源对象
    public Object GetObj(string name,string pathName, string resName, string bagName = "")
    {
        if(!IsHavePool(name))
        {
            //添加池子
            m_poolList.Add(name,new List<Object>());
        }
        //获取缓存池
        List<Object> pool = m_poolList[name];
        //池中无对象
        if(pool.Count == 0)
            return CResLoadMgr.Instance.LoadObject(pathName,resName,bagName);
        //取第一个
        Object obj = pool[0];
        //从池子中移除
        pool.RemoveAt(0);
        return obj;
    }
    //回收对象
    public void RevertObj(string name, Object obj)
    {
        if(obj == null)
            return;
        if(!IsHavePool(name))
            m_poolList.Add(name,new List<Object>());
        m_poolList[name].Add(obj);
    }
    //清空缓存池
    public void ClearPool(string poolName = "")
    {
        if(poolName == "")
        {
            m_poolList.Clear();
            return;
        }
        if(IsHavePool(poolName))
            m_poolList.Remove(poolName);
    }
    //池子是否存在
    bool IsHavePool(string name)
    {
        if(m_poolList.ContainsKey(name))
            return true;
        return false;
    }
}
