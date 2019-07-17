#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CEventListener
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

namespace GameEngin.Event
{
    public class CEventListener
    {
        //监听事件的对象
        object m_listener;
        //委托
        EventCenterFunction m_callback;
        public CEventListener(object listener,EventCenterFunction callback)
        {
            m_listener = listener;
            m_callback = callback;
        }
        public object listener
        {
            get { return m_listener; }
            set { m_listener = value; }
        }
        public EventCenterFunction function
        {
            get { return m_callback; }
            set { m_callback = value; }
        }

    }
}
