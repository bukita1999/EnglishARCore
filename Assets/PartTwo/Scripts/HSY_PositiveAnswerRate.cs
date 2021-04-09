using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HSY_PositiveAnswerRate : MonoBehaviour
{
    public static HSY_PositiveAnswerRate _instance;

    public float PositiveNum = 0;     //答对题目数
    public float NegativeNum = 0;     //答错题目数
    public int CurrentNO = 1;   //当前作答题目的题号（用以防止错误数多次统计）
    //public float PositiveRate = 0.0f;   //正答率


    public GameObject PositiveAnswerRate;  //本物体，接下来三个是子物体
    public TextMeshPro Positive;
    public TextMeshPro Negative;
    public TextMeshPro PositiveRate;

    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;

        //可在Unity中拖拽赋值，故注释
        //PositiveAnswerRate = this.gameObject;
        //Positive = transform.GetChild(0).gameObject;
        //Negative = transform.GetChild(1).gameObject;
        //PositiveRate = transform.GetChild(2).gameObject;
        this.gameObject.SetActive(false);
        this.transform.position = this.transform.parent.position+new Vector3(-0.15f,0.2f,0);
    }

    private void Update()
    {
        ChangeText();   //及时更新作答情况
    }

    void ChangeText()
    {
        Positive.text = "Positive: "+PositiveNum.ToString();
        Negative.text = "Negative: "+NegativeNum.ToString();
        //除数不能为0
        if(PositiveNum + NegativeNum==0)
        {
            PositiveRate.text = "0.0%";
        }
        else
        {
            PositiveRate.text ="PositiveRate: "+ (PositiveNum / (PositiveNum + NegativeNum)).ToString("p2");
        }
        
    }
}
