#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CMusicMgr
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
using GameEngin.Res;
using UnityEngine;

namespace GameEngin.Music
{
public class CMusicMgr : CInstanceNull<CMusicMgr> 
{
    string m_bgmPath = "";
    string m_soundPath = "";
    string m_soundBagName = "";
    string m_bgmBagName = "";
    AudioSource m_bgmAS = null;
    Dictionary<string,AudioSource> m_soundList = new Dictionary<string, AudioSource>();
    //改变背景音乐大小
    public void ChangeBGMValue(float value)
    {
        if (m_bgmAS == null)
            return;
        m_bgmAS.volume = value;
    }
    //改变音效音乐大小
    public void ChangeSoundValue(float value)
    {
        if (m_soundList.Count == 0)
            return;
        Dictionary<string,AudioSource>.Enumerator enumerator = m_soundList.GetEnumerator();
        while(enumerator.MoveNext())
        {
            m_soundList[enumerator.Current.Key].volume = value;
        }
    }
    //播放背景音乐
    public void PlayBGM(string name)
    {
        if (m_bgmAS == null)
        {
            GameObject BGM = new GameObject("BGM");
            GameObject.DontDestroyOnLoad(BGM);
            m_bgmAS = BGM.AddComponent<AudioSource>();
            m_bgmAS.loop = true;
        }
        if (m_bgmAS.isPlaying)
            m_bgmAS.Stop();
        m_bgmAS.clip = CResLoadMgr.Instance.LoadObject(m_bgmPath, name, m_bgmBagName) as AudioClip;
        m_bgmAS.Play();
    }
    //停止背景音乐
    public void StopBGM()
    {
        if (m_bgmAS != null && m_bgmAS.isPlaying)
            m_bgmAS.Stop();
    }
    //暂停背景音乐
    public void PauseBGM()
    {
        if (m_bgmAS != null && m_bgmAS.isPlaying)
            m_bgmAS.Pause();
    }
    //播放音效音乐
    public void PlaySound(string name,bool isLoop = false)
    {
        if(!m_soundList.ContainsKey(name))
        {
            if(GameObject.Find("Sound") == null)
            {
                GameObject go = new GameObject("Sound");
                GameObject.DontDestroyOnLoad(go);
            }
            AudioSource tmp = GameObject.Find("Sound").AddComponent<AudioSource>();
            tmp.clip = CResLoadMgr.Instance.LoadObject(m_soundPath, name, m_soundBagName) as AudioClip;
            tmp.name = name;
            m_soundList.Add(name,tmp);
        }
        m_soundList[name].loop = isLoop;
        m_soundList[name].Play();
    }
    //停止音效音乐
    public void StopSound(string name)
    {
        if(!m_soundList.ContainsKey(name))
            return;
        if(m_soundList[name].isPlaying)
            m_soundList[name].Stop();
    }
    //停止所有音效
    public void StopAllSound()
    {
        Dictionary<string,AudioSource>.Enumerator enumerator = m_soundList.GetEnumerator();
        while(enumerator.MoveNext())
        {
            m_soundList[enumerator.Current.Key].Stop();
        }
    }
}
}
