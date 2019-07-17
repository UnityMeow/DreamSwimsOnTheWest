#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CGlobalMonoMgr
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

//=======================待添加
namespace GameEngin.MonoTool
{
    public class CGlobalMonoMgr : CInstanceMono<CGlobalMonoMgr> 
    {
        event CallBack eventUpdate;
        void Update()
        {
            if (eventUpdate != null)
                eventUpdate();
        }
        public void AddUpdateListener(CallBack function)
        {
            eventUpdate += function;
        }
        public void RemoveUpdateListener(CallBack function)
        {
            eventUpdate -= function;
        }
    }
}
