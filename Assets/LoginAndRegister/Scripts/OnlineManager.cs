using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class OnlineManager : MonoBehaviour
{
    
    public InputField signup_user_inputfield;
    public InputField signup_password_inputfield;
    public static MySqlConnection mySqlConnection;
    private static string database = "test";
    private static string host = "127.0.0.1";
    private static string id = "root";
    private static string pwd = "123";
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Register()
    {

    }
}
