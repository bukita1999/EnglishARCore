using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MySql.Data.MySqlClient;
using MySql.Data;
using System;

public class OnlineManager : MonoBehaviour
{
    private static OnlineManager instance;
    public InputField signup_user_inputfield;
    public InputField signup_password_inputfield;
    public InputField signin_user_inputfield;
    public InputField signin_password_inputfield;
    public static MySqlConnection mySqlConnection;
    MySqlDataReader reader;
    public GameObject notification_obj;
    public int user_number;
    private static string database = "englisharcore";
    private static string host = "139.196.204.248";
    private static string id = "EnglishARCore";
    private static string pwd = "C4xdhGZNzH7DiwDS";
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            return;
        }
        else
        {
            instance = this;
            //避免场景加载时该对象销毁
            DontDestroyOnLoad(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public static OnlineManager GetInstance()
    {
        return instance;
    }

    //让构造函数为 private，这样该类就不会被其他类实例化
    //private OnlineManager() { }
    
    public void Register()
    {
        string notification = "注册失败";
        try
        {
            OpenSql();
            Debug.Log("SQL打开！");
            string sqlString = string.Format("INSERT INTO `user` (`No.`, `name`, `password`) VALUES (NULL, '{0}','{1}') ",
                signup_user_inputfield.text, signup_password_inputfield.text);
            Debug.Log(sqlString);
            
            MySqlCommand mysqlcom = new MySqlCommand(sqlString, mySqlConnection);
            mysqlcom.ExecuteNonQuery();
            notification = "注册成功";
            Debug.Log("注册成功");
            
        }
        catch (MySqlException ex)
        {
            
            Debug.Log("注册失败");
        }
        finally
        {
            notification_obj.GetComponent<CC_notification_textchanged>().TextChanged(notification);
            CloseSql();
            Debug.Log("关闭连接");
        }
    }
    public void Login()
    {
        string notification = "登录失败";
        try
        {
            OpenSql();
            Debug.Log("Sql has opened");
            string sqlString = string.Format("SELECT DISTINCT `No.` FROM `user` " +
                "WHERE `name` = '{0}' AND `password` = '{1}';",
                signin_user_inputfield.text,signin_password_inputfield.text);
            Debug.Log(sqlString);

            MySqlCommand mysqlcom = new MySqlCommand(sqlString, mySqlConnection);
            reader = mysqlcom.ExecuteReader();
            if (reader.Read())
            {
                Debug.Log(reader["No."].ToString());
                notification = "登录成功";
                user_number = Convert.ToInt32(reader["No."]);
            }
            else
            {
                notification = "用户名或密码错误";
            }
            reader.Close();
            
        }
        catch(MySqlException ex)
        {
            notification = "登陆失败";
        }
        finally
        {
            
            CloseSql();
            Debug.Log(notification);
            notification_obj.GetComponent<CC_notification_textchanged>().TextChanged(notification);
        }
        if(notification is "登录成功")
        {
            Invoke(nameof(SceneChange), 2f);
        }
    }
    private void SceneChange()
    {
        SceneManager.LoadScene("WaitinRoom");
    }
    private void OpenSql()
    {
        Debug.Log("开始打开SQL");
        try
        {
            //string.Format是将指定的 String类型的数据中的每个格式项替换为相应对象的值的文本等效项。
            string sqlString = string.Format("Database={0};Data Source={1};User Id={2};Password={3};", database, host, id, pwd, "3306");
            mySqlConnection = new MySqlConnection(sqlString);
            
            mySqlConnection.Open();
            Debug.Log("After Open");
        }
        catch (MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:
                    Debug.LogError("Cannot connect to server.  Contact administrator");
                    break;
            }
            
        }

    }
    private bool CloseSql()
    {
        try
        {
            mySqlConnection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            Debug.LogError(ex.Message);
            return false;
        }
    }
}
