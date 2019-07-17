#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CInstanceMono
** 版  权:	(C)  
** 创建人:  Unity喵
** 日  期:	2019.6.11
** 描  述: 	继承Mono单例基类
**************************** 修改记录 ******************************
** 修改人: 
** 日  期: 
** 描  述: 
*******************************************************************/
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngin.Instance
{
    public class CInstanceMono<T> : MonoBehaviour
        where T : CInstanceMono<T>
    {
        static T m_instance;
        public static T Instance
        {
            get
            {
                if (m_instance == null)
                {
                    GameObject go = GameObject.Find("InstanceMgrMono");
                    if (go == null)
                        go = new GameObject("InstanceMgrMono");
                    m_instance = go.AddComponent<T>();
                }
                return m_instance;
            }
        }
    }
}
