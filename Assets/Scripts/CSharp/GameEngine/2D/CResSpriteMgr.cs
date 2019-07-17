#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CResSpriteMgr
** 版  权:	(C)  
** 创建人:  Unity喵
** 日  期:	2019.6.11
** 描  述: 	2D资源管理器
**************************** 修改记录 ******************************
** 修改人: 
** 日  期: 
** 描  述: 
*******************************************************************/
#endregion

using GameEngin.Instance;
using GameEngin.Res;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CResSpriteMgr : CInstanceNull<CResSpriteMgr>
{
    //图片数据集合
    struct _PICDATA
    {
        public int x;
        public int y;
        public int w;
        public int h;
        public int offx;
        public int offy;
    }
    //数据文件主路径
    string m_data_main_path;
    //图片文件主路径
    string m_texture_main_path;
    //2D资源表
    Dictionary<string,Sprite[]> m_sprite_list;
    public CResSpriteMgr()
    {
        m_sprite_list = new Dictionary<string, Sprite[]>();
    }
    //初始化2D资源相关主路径
    public void Init(string main_path)
    {
        m_data_main_path = main_path + "/data/";
        m_texture_main_path = main_path + "/pic/";
    }
    /* 
        加载动画图集 
        规则：
            bytes放主路径下的data文件夹
            png放主路径下的pic文件夹
        参数：“相对路径#文件名” 用#隔开
    */  
    public Sprite[] LoadAnim(string name)
    {
        if(!m_sprite_list.ContainsKey(name))
        {
            // 字符串分割 name.Split('#');
            string[] str = name.Split('#');
            m_sprite_list.Add(name, LoadSprite(m_texture_main_path + str[0] , str[1] , m_data_main_path + str[0], str[1]));
        }
        return m_sprite_list[name];
    }
    public void RemoveAnim(string name)
    {
        if(!m_sprite_list.ContainsKey(name))
            return;
        m_sprite_list.Remove(name);
    }
    public void ClearAnim()
    {
        m_sprite_list.Clear();
    }
    //精灵资源加载（图片路径，资源名，数据路径，数据名）
    Sprite[] LoadSprite(string texture_path_name, string texture_res_name, string data_path_name, string data_res_name)
    {
        //加载图片
        Texture2D texture = CResLoadMgr.Instance.LoadObject(texture_path_name , texture_res_name) as Texture2D;
        //加载数据
        TextAsset data = CResLoadMgr.Instance.LoadObject(data_path_name , data_res_name) as TextAsset;
        int index = 0;
        int len = BitConverter.ToInt32(data.bytes, index);
        index += 4;
        //数据集合
        _PICDATA[] pic_data = new _PICDATA[len];
        //图片集合
        Sprite[] pic = new Sprite[len];
        //取数据
        for (int i = 0; i < len; i++)
        {
            pic_data[i].x = BitConverter.ToInt32(data.bytes, index);
            index += 4;
            pic_data[i].y = BitConverter.ToInt32(data.bytes, index);
            index += 4;
            pic_data[i].w = BitConverter.ToInt32(data.bytes, index);
            index += 4;
            pic_data[i].h = BitConverter.ToInt32(data.bytes, index);
            index += 4;
            pic_data[i].offx = BitConverter.ToInt32(data.bytes, index);
            index += 4;
            pic_data[i].offy = BitConverter.ToInt32(data.bytes, index);
            index += 4;
            pic_data[i].y = texture.height - pic_data[i].y - pic_data[i].h;
        }
        //裁图片
        for (int i = 0; i < len; i++)
        {
            pic[i] = Sprite.Create(texture, new Rect(pic_data[i].x, pic_data[i].y, pic_data[i].w, pic_data[i].h), new Vector2(pic_data[i].offx / pic_data[i].w, pic_data[i].offy / pic_data[i].h));
        }
        //返回裁剪好的精灵图组
        return pic;
    }
}
