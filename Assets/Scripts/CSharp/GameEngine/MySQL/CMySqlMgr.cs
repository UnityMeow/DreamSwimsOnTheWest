#region --------------------------文件信息--------------------------------------
/******************************************************************
** 文件名:	CMySqlMgr
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using GameEngin.Instance;
using MySql.Data.MySqlClient;
using UnityEngine;

namespace GameEngin.MySQL
{
    //MySqlConnection 用来控制数据库链接
    //DataSet 用于数据存储 获取到的数据会以DataSet的形式返回
    //MySqlCommand 用于执行Sql语句的对象
    //MySqlDataAdapter 用于执行Sql语句并且返回数据的对象 返回对象为DataSet
    public class CMySqlMgr : CInstanceNull<CMySqlMgr>  
    {
        //连接类对象
        MySqlConnection m_mySqlConnection;
        //打开数据库(ip = 127.0.0.1, port = 3306, userName = root, password = 数据库密码, databaseName = gamedatabase)
        public void OpenSql(string ip,string port, string userName, string password, string databaseName) 
        {
            //捕获开启时异常
            try
            {
                //拼接链接数据库的语句
                string mySqlString = string.Format("Database={0}; Data Source={1}; User Id={2}; Password={3}; port={4}; charset=utf8", databaseName, ip, userName, password, port);
                //新建一个mysql链接对象
                m_mySqlConnection = new MySqlConnection(mySqlString);
                //开启链接
                m_mySqlConnection.Open();
            }
            catch(Exception e)
            {
                throw new Exception("服务器连接失败，请重新检查MySql服务是否打开。" + e.Message.ToString());
            }
        }
        //关闭数据库
        public void CloseSql() 
        {
            if (m_mySqlConnection != null) 
            {
                m_mySqlConnection.Close();
                m_mySqlConnection.Dispose();
                m_mySqlConnection = null;
            }
        }
        //增加数据(表名，字段名，值)
        public void Insert(string tableName,string[] items,string[] value)
        {
            if(items.Length != value.Length)
                throw new Exception("输入不正确：要增加的字段名 值 的数量不一致！");
            //拼接增加字段
            string sql = "INSERT INTO " + tableName + "(" + items[0];
            for (int i = 1; i < items.Length; i++) 
            {
                sql += "," + items[i];
            }
            sql += ") VALUES(" + value[0];
            for (int i = 1; i < value.Length; i++) 
            {
                sql += "," + value[i];
            }
            sql += ")";
            ExecuteSql(sql);
        }
        //查询数据（表名，字段名，限制条件字段名，限制条件运算符，值）
        public DataSet Select(string tableName,string[] items,string[] whereColumnName, string[] operation,string[] value)
        {
            if (whereColumnName.Length != operation.Length || operation.Length != value.Length) 
                throw new Exception("输入不正确：要查询的条件、条件操作符、条件值 的数量不一致！");
            //拼接查询字段
            string sql = "SELECT " + items[0];
            for (int i = 1; i < items.Length; i++) 
            {
                sql += "," + items[i];
            }
            //拼接查询语句后面的 查哪张表  条件时什么
            sql += " FROM " + tableName + " WHERE " + whereColumnName[0] + " " + operation[0] + " '" + value[0] + "'";
            for (int i = 1; i < whereColumnName.Length; i++) 
            {
                sql += " and " + whereColumnName[i] + " " + operation[i] + " '" + value[i] + "'";
            }
            //执行sql语句  执行后返回查找到的信息
            return ExecGetTableInfo(sql);
        }
        //ds.Tables[0].Rows[0]["Password"] 可拿到查找数据返回值
        //执行有返回值的sql语句
        DataSet ExecGetTableInfo(string sqlString) 
        {
            //判断是否开启
            if (m_mySqlConnection.State == ConnectionState.Open) 
            {
        	    //新建data信息
                DataSet ds = new DataSet();
                try 
                {
                    //执行sql语句
                    MySqlDataAdapter mySqlAdapter = new MySqlDataAdapter(sqlString, m_mySqlConnection);
                    //得到的数据填充进data信息
                    mySqlAdapter.Fill(ds);
                } 
                catch (Exception e) 
                {
                    throw new Exception("SQL:" + sqlString + "/n" + e.Message.ToString());
                } 
                return ds;
            }
            return null;
        }
        //执行没有返回值的sql语句
        private void ExecuteSql(string command)
        {
            try 
            {
                //执行sql语句对象
                MySqlCommand cmd = new MySqlCommand(command, m_mySqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw new Exception("SQL:" + command + "/n" + e.Message.ToString());
            }  
        }
    }
}
