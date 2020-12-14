using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSY_QuestionBank : MonoBehaviour
{
    public static HSY_QuestionBank _instance;

    private int No = 0;
    public GameObject[] questions;
    public GameObject current;
    public Vector3 newScale;
    private void Awake()
    {
        _instance = this;
    }


    private void Start()
    {
        if (No == 0)    //开始要生成第一道题
        {
            current = Instantiate(questions[0], transform.position, Quaternion.identity);
            current.transform.parent = gameObject.transform;
            HSY_PositiveAnswerRate._instance.CurrentNO = 1;
            //Debug.Log(current.transform.name);
        }
    }
    void instance()
    {
        No++;
        if(No<questions.Length)
        {
            current = Instantiate(questions[No], transform.position, Quaternion.identity);
            current.transform.parent = gameObject.transform;
            HSY_PositiveAnswerRate._instance.CurrentNO++;
        }
        else
        {
            //Debug.Log(No);
            HSY_PositiveAnswerRate._instance.PositiveAnswerRate.SetActive(true);
        }

    }

    private void Update()
    {
        if (HSY_PlateCollider._instance.isDestroyed == true)
        {
            //Debug.Log(No);
            HSY_PlateCollider._instance.isDestroyed = false;    //确保只执行一次instance()
            Invoke("instance", 2f);
        }
    }
}
