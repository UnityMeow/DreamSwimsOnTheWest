#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CUIBase
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
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameEngin.UI
{
public class CUIBase : MonoBehaviour 
{
    Dictionary<string, GameObject> m_List;
    protected virtual void Awake()
    {
        m_List = new Dictionary<string, GameObject>();
        List<Transform> list = new List<Transform>();
        FindChild(transform, list);
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].tag == "Event")
            {
                EventTrigger ET = list[i].gameObject.AddComponent<EventTrigger>();
                if (ET.triggers.Count == 0)
                {
                    ET.triggers = new List<EventTrigger.Entry>();
                }
                m_List.Add(list[i].name, list[i].gameObject);
            }
            else if (list[i].gameObject.GetComponent<Image>() != null)
            {
                m_List.Add(list[i].name, list[i].gameObject);
            }
            else if (list[i].gameObject.GetComponent<Text>() != null)
            {
                m_List.Add(list[i].name, list[i].gameObject);
            }
        }
    }
    protected T GetControl<T>(string name) 
        where T : MonoBehaviour
    {
        if (m_List[name] == null)
            return null;
        return m_List[name].GetComponent<T>();
    }
    public GameObject GetGameObject(string name)
    {
        if (m_List[name] == null)
            return null;
        return m_List[name];
    }
    public void AddEventTrigger(string controlName, EventTriggerType type, UnityAction<BaseEventData> callBack)
    {
        if (!m_List.ContainsKey(controlName))
            return;
        if (m_List[controlName].gameObject.GetComponent<EventTrigger>() == null)
            m_List[controlName].AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(callBack);
        entry.eventID = type;
        m_List[controlName].GetComponent<EventTrigger>().triggers.Add(entry);
    }
    // 得到所有子物体
    List<Transform> FindChild(Transform father, List<Transform> list)
    {
        if (father.childCount == 0)
            return list;
        int len = father.childCount;
        for (int i = 0; i < len; i++)
        {
            list.Add(father.GetChild(i));
            FindChild(father.GetChild(i), list);
        }
        return list;
    }
}
}
