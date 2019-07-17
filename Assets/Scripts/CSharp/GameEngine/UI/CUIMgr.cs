#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CUIMgr
** 版  权:	(C)  
** 创建人:  Unity喵
** 日  期:	
** 描  述: 	UI管理器 主要管理所有面板的显示隐藏等
**************************** 修改记录 ******************************
** 修改人: 
** 日  期: 
** 描  述: 
*******************************************************************/
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using GameEngin.Instance;
using GameEngin.Res;
using UnityEngine;

namespace GameEngin.UI
{
    //UI层级
    public enum UI_Layer
    {
        Top,
        Mid,
        Bot,
    }
    public class CUIMgr : CInstanceNull<CUIMgr> 
    {
        //面板显示总开关
        public bool m_IsShow;
        //UI
        public Transform m_UI;
        //Canvas层
        public Transform m_UIRoot;
        //UI顶层
        public Transform m_UITopLayer;
        //UI中层
        public Transform m_UIMidLayer;
        //UI底层
        public Transform m_UIBotLayer;
        Dictionary<string, CUIBase> m_UIPanelList;
        public CUIMgr()
        {
            m_IsShow = true;
            m_UIPanelList = new Dictionary<string, CUIBase>();
            m_UI = CResLoadMgr.Instance.LoadPrefab("Prefabs/UI","UI").transform;
            GameObject.DontDestroyOnLoad(m_UI.gameObject);
            m_UIRoot = m_UI.Find("Canvas");
            m_UITopLayer = m_UIRoot.Find("Top");
            m_UIMidLayer = m_UIRoot.Find("Mid");
            m_UIBotLayer = m_UIRoot.Find("Bot");
        }
        //Lua显示面板
        public CUIBase LuaShowPanel(string planeName,UI_Layer layer = UI_Layer.Top)
        {
            return ShowPanel<CUIBase>(planeName,layer);
        }
        //显示面板
        public T ShowPanel<T>(string planeName, UI_Layer layer = UI_Layer.Top)
            where T : CUIBase
        {
            CUIBase plane;
            if(!IsHavePanel(planeName))
            {
                GameObject obj = CResLoadMgr.Instance.LoadPrefab("Prefabs/UI",planeName);
                obj.name = planeName;
                //设置层级
                RectTransform tr = obj.transform as RectTransform;
                switch(layer)
                {
                    case UI_Layer.Top : tr.SetParent(m_UITopLayer); break;
                    case UI_Layer.Mid : tr.SetParent(m_UIMidLayer); break;
                    case UI_Layer.Bot : tr.SetParent(m_UIBotLayer); break;
                }
                tr.localPosition = Vector3.zero;
                tr.localScale = Vector3.one;
                tr.offsetMax = Vector2.zero;
                tr.offsetMin = Vector2.zero;
                plane = obj.AddComponent<T>();
                m_UIPanelList.Add(planeName,plane);
                plane.gameObject.SetActive(true);
                return plane as T;
            }
            plane = m_UIPanelList[planeName];
            plane.gameObject.SetActive(true);
            return plane as T;
        }
        //隐藏面板
        public void HidePanel(string panelName)
        {
            if (!IsHavePanel(panelName))
                return;
            m_UIPanelList[panelName].gameObject.SetActive(false);
        }
        //隐藏所有面板
        public void HideAllPanel()
        {
            Dictionary<string,CUIBase>.Enumerator enumerator = m_UIPanelList.GetEnumerator();
            while(enumerator.MoveNext())
            {
                m_UIPanelList[enumerator.Current.Key].gameObject.SetActive(false);
            }
        }
        //移除面板
        public void DestroyPanel(string panelName)
        {
            if (!IsHavePanel(panelName))
                return;
            GameObject.Destroy(m_UIPanelList[panelName].gameObject);
            m_UIPanelList.Remove(panelName);
        }
        //移除所有面板
        public void DestroyAllPanel()
        {
            Dictionary<string,CUIBase>.Enumerator enumerator = m_UIPanelList.GetEnumerator();
            while(enumerator.MoveNext())
            {
                GameObject.Destroy(m_UIPanelList[enumerator.Current.Key].gameObject);
            }
        }
        //获取面板
        public CUIBase GetPanel(string panelName)
        {
            if (!IsHavePanel(panelName))
                return null;
            return m_UIPanelList[panelName];
        }
        //是否有对应名字的面板
        bool IsHavePanel(string planeName)
        {
            if(!m_UIPanelList.ContainsKey(planeName))
                return false;
            return true;
        }
    }
}
