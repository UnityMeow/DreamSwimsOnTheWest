#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CHero
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

public class CHero : CAnimBase
{
    //面朝向
    Vector2 m_faceDir;
    float m_speed = 4;
    int num = 0;
    protected override void Awake()
    {
        base.Awake();
        SetDefaultAnim("Hero_1/Stand#Stand_2");
        PlayDefaultAnim(); 
    }
    protected override void Update()
    {
        base.Update();
        transform.Translate(m_faceDir * Time.deltaTime * m_speed);
    }
    public void OnTriggerEnter2D(Collider2D c)
    {
        if(c.transform.parent.name == "Cover")
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
        num++;
    }
    public void OnTriggerExit2D(Collider2D c)
    {
        num--;
        if(c.transform.parent.name == "Cover" && num == 0)
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        
    }
    //停止移动
    public void Stop()
    {
        m_faceDir = Vector2.zero;
        PlayDefaultAnim();
    }
    //移动
    public void Move(Vector2 pos)
    {
        //得到方向单位向量
        m_faceDir = pos.normalized;
        //得到当前夹角角度
        float cur_angle =  Vector2.Angle(new Vector2(0,1),m_faceDir);
        //转角度
        if(m_faceDir.x < 0)
            cur_angle = 360 - cur_angle;
        //根据角度判断 方向 决定动画切什么
        float s_1 = 360 - (360.0f/8)/2;
        float e_1 = (360.0f/8)/2;
        float s_2 = e_1;
        float e_2 = e_1 + (360.0f/8);
        float s_3 = e_2;
        float e_3 = e_2 + (360.0f/8);
        float s_4 = e_3;
        float e_4 = e_3 + (360.0f/8);
        float s_5 = e_4;
        float e_5 = e_4 + (360.0f/8);
        float s_6 = e_5;
        float e_6 = e_5 + (360.0f/8);
        float s_7 = e_6;
        float e_7 = e_6 + (360.0f/8);
        float s_8 = e_7;
        float e_8 = e_7 + (360.0f/8);
        if(cur_angle > s_1 || cur_angle < e_1)
        {
            ChangeAnim("Hero_1/Walk#Walk_1",true);
            SetDefaultAnim("Hero_1/Stand#Stand_1");
        }
        else if(cur_angle > s_2 && cur_angle < e_2)
        {
            ChangeAnim("Hero_1/Walk#Walk_6",true);
            SetDefaultAnim("Hero_1/Stand#Stand_6");
        }
        else if(cur_angle > s_3 && cur_angle < e_3)
        {
            ChangeAnim("Hero_1/Walk#Walk_4",true);
            SetDefaultAnim("Hero_1/Stand#Stand_4");
        }
        else if(cur_angle > s_4 && cur_angle < e_4)
        {
            ChangeAnim("Hero_1/Walk#Walk_8",true);
            SetDefaultAnim("Hero_1/Stand#Stand_8");
        }
        else if(cur_angle > s_5 && cur_angle < e_5)
        {
            ChangeAnim("Hero_1/Walk#Walk_2",true);
            SetDefaultAnim("Hero_1/Stand#Stand_2");
        }
        else if(cur_angle > s_6 && cur_angle < e_6)
        {
            ChangeAnim("Hero_1/Walk#Walk_7",true);
            SetDefaultAnim("Hero_1/Stand#Stand_7");
        }
        else if(cur_angle > s_7 && cur_angle < e_7)
        {
            ChangeAnim("Hero_1/Walk#Walk_3",true);
            SetDefaultAnim("Hero_1/Stand#Stand_3");
        }
        else if(cur_angle > s_8 && cur_angle < e_8)
        {
            ChangeAnim("Hero_1/Walk#Walk_5",true);
            SetDefaultAnim("Hero_1/Stand#Stand_5");
        }
    }
}
