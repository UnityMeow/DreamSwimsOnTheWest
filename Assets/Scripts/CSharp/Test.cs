#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	Test
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

public class Test : CAnimBase
{
    protected override void Awake()
    {
        base.Awake();
        SetDefaultAnim("a#idle");
        PlayDefaultAnim(); 
    }
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeAnim("a#att",false,true,true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ChangeAnim("a#run",true,false,true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            PlayDefaultAnim();
        }
    }
}
