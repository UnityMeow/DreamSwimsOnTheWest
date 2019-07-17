#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CInstanceNull
** 版  权:	(C)  
** 创建人:  Unity喵
** 日  期:	2019.6.11
** 描  述: 	不继承Mono单例基类
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
    public class CInstanceNull<T>
        where T : new()
    {
        protected static T m_instance;
        public static T Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new T();
                }
                return m_instance;
            }
        }
        protected CInstanceNull()
        { }
    }
}
