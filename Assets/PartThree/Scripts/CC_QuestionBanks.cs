﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC_QuestionBank : MonoBehaviour
{
    public static CC_QuestionBank _instance;

    private int No = 0;
    public GameObject[] questions;
    public GameObject current;
    public Vector3 newScale;
    private bool finished = false;
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
            CC_PositiveAnswerRate._instance.CurrentNO = 1;
            //Debug.Log(current.transform.name);
        }
    }
    void instance()
    {
        //HSY_RayController.instance.EndStation();
        No++;
        if (No < questions.Length)   //题目没有全部出现
        {
            current = Instantiate(questions[No], transform.position, Quaternion.identity);
            current.transform.parent = gameObject.transform;
            CC_PositiveAnswerRate._instance.CurrentNO++;
        }
        else    //题目全部做完，出现正答率
        {
            //Debug.Log(No);
            finished = true;
        }

    }

    private void Update()
    {
        if (HSY_PlateCollider._instance.isDestroyed == true)
        {
            //Debug.Log(No);
            HSY_PlateCollider._instance.isDestroyed = false;    //确保只执行一次instance()
            Invoke("instance", 2f);   //两秒后判断是该现实下一题还是出现正答率
        }
        else if (finished && !CC_PositiveAnswerRate._instance.PositiveAnswerRate.activeSelf)
        {
            CC_PositiveAnswerRate._instance.PositiveAnswerRate.SetActive(true);
        }
    }
}
