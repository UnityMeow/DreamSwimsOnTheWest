#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CCamera
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

public class CCamera : MonoBehaviour 
{
    GameObject go;
    void Awake()
    {
        go = GameObject.Find("Hero");
    }
    void LateUpdate()
    {
        if(go == null)
            return;
        Vector2 pos = Vector2.Lerp(transform.position,go.transform.position,0.05f);
        transform.position = new Vector3(pos.x, pos.y,-10);
        if(transform.position.x >= 11.5f)
            transform.position = new Vector3(11.5f,transform.position.y,-10);
        if(transform.position.x <= -11.5f)
            transform.position = new Vector3(-11.5f,transform.position.y,-10);
        if(transform.position.y >= 6f)
            transform.position = new Vector3(transform.position.x,6f,-10);
        if(transform.position.y <= -6f)
            transform.position = new Vector3(transform.position.x,-6f,-10);
    }
}
