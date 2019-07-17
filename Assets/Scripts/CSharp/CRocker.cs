#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CRocker
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
using UnityEngine.EventSystems;

public class CRocker : MonoBehaviour 
{
    //触摸球
    Transform m_ball;
    //重置位置
    Vector3 m_zeroPos;
    //半径
    float m_r;
    CHero m_hero;
    void Start()
    {
        m_r = 150;
        m_ball = transform.Find("ball");
        m_hero = GameObject.Find("Hero").GetComponent<CHero>();
        m_zeroPos = transform.position;
    }
    //拖拽
    public void RDrag(BaseEventData data)
    {
        PointerEventData e_data = data as PointerEventData;
        //鼠标位置
        Vector2 MousePosition;
        //转换鼠标位置
        RectTransformUtility.ScreenPointToLocalPointInRectangle
        (
            //底图的RectTransform
            transform as RectTransform,
            //点击位置
            e_data.position,
            //触发事件的相机
            e_data.pressEventCamera,
            //返回转换后的Vector2
            out MousePosition
        );
        //更改触摸球位置
        m_ball.localPosition = MousePosition;
        //Vector2转换转Vector3
        Vector3 pos = MousePosition;
        //模长大于半径
        if(pos.magnitude > m_r)
        {
            //改变底图位置 = 底图位置+(鼠标位置-鼠标位置单位向量*半径)
            transform.position += pos - pos.normalized * m_r;
        }
        //根据鼠标位置向量进行英雄移动
        m_hero.Move(pos);  
    }
    //抬起
    public void RUp(BaseEventData data)
    {
        //摇杆位置重置
        m_ball.localPosition = Vector3.zero;
        transform.position = m_zeroPos;
        //停止移动
        m_hero.Stop();
    }
}
