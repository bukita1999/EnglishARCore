using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSY_QuestionManager : MonoBehaviour
{
    public GameObject[] questions;
    public static HSY_QuestionManager instance;     //单例模式
    
    void Awake()
    {
        instance = this;
        SetBrotherIndex();

    }
    void Start()
    {
        questions[0].SetActive(true);
    }

    void SetBrotherIndex()
    {
        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].transform.SetSiblingIndex(i);
        }
    }
}
