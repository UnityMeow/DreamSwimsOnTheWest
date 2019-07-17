#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CAnimBase
** 版  权:	(C)  
** 创建人:  Unity喵
** 日  期:	
** 描  述: 	动画基类 相当于动画状态机的作用
**************************** 修改记录 ******************************
** 修改人: 
** 日  期: 
** 描  述: 
*******************************************************************/
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimBase : MonoBehaviour 
{
    //默认动画精灵图组
    Sprite[] m_defaultAnim;
    //默认动画名
    string m_defaultName;
    //当前动画名
    string m_curAnim;
    //当前动画精灵图组
    Sprite[] m_curAnimSprite;
    //当前帧数
    int m_frame;
    //FPS
    float m_fps;
    //是否循环
    bool m_isLoop;
    //是否强制播放
    bool m_isForced;
    //是否播放默认动画
    bool m_isDefault;
    //精灵渲染器
    SpriteRenderer m_sr;
    //计时器
    float m_clock;
    protected virtual void Awake()
    {
        m_frame = 0;
        m_fps = 0.1f;
        m_curAnim = "";
        CResSpriteMgr.Instance.Init("Sprite");
        m_sr = gameObject.GetComponent<SpriteRenderer>();
    }
    protected virtual void Update()
    {
        m_clock += Time.deltaTime;
        if(m_clock > m_fps)
        {
            m_clock = 0.0f;
            if(m_frame >= m_curAnimSprite.Length)
            {
                if(m_isLoop)
                    m_frame = 0;
                else if(m_isDefault)
                {
                    if(m_defaultAnim == null)
                    {
                        CGlobalUtil.Log("CAnimBase: 默认动画为空");
                        return;
                    }
                    m_curAnim = m_defaultName;
                    m_curAnimSprite = m_defaultAnim;
                    m_isLoop = true;
                    m_frame = 0;
                }
                else
                    m_frame = -1;
                m_isForced = false;
            }
            if(m_frame != -1)
                m_sr.sprite = m_curAnimSprite[m_frame++];
        }
    }
    protected void SetFPS(int fps)
    {
        m_fps = 1f / fps;
    }
    //默认动画设置
    protected void SetDefaultAnim(string animName)
    {
        m_defaultName = animName;
        m_defaultAnim = CResSpriteMgr.Instance.LoadAnim(animName);
    }
    //取消默认动画
    protected void OffDefaultAnim()
    {
       m_defaultAnim = null; 
    }
    //播放默认动画
    protected void PlayDefaultAnim()
    {
        if(m_defaultAnim == null)
        {
            CGlobalUtil.Log("CAnimBase: 默认动画为空");
            return;
        }
        m_curAnim = m_defaultName;
        m_curAnimSprite = m_defaultAnim;
        m_isLoop = true;
        m_frame = 0;
    }
    //切换动画(动画名，是否循环播放，是否播放完毕播放默认动画，是否重置动画)
    protected void ChangeAnim(string animName, bool isLoop = false, bool isDefault = false, bool isForced = false, bool reset = false)
    {
        m_isDefault = isDefault;
        m_isLoop = isLoop;
        if(animName == m_curAnim)
        {
            if(reset)
                m_frame = 0;
            return;
        }
        if(!m_isForced)
        {
            m_curAnimSprite = CResSpriteMgr.Instance.LoadAnim(animName);
            m_curAnim = animName;
            m_frame = 0;
            m_isForced = isForced;
        }
    }
    protected bool IsPlayAnim(string name)
    {
        if(m_curAnim == name && m_frame != -1)
            return true;
        else
            return false;
    }
}
