using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSY_PlateCollider : MonoBehaviour
{
 
    public static HSY_PlateCollider _instance;  //单例模式
    public bool isDestroyed = false;    //判断实例化的对象是否被销毁
    //因为Destroy后对象为被赋值为null，只能用一个标记变量

    public AudioClip T, F;      //答案正确和错误时的声音

    private void Awake()    //确保单例模式在使用前已经被初始化
    {
        _instance = this;
    }

    public void OnCollisionEnter(Collision collision)
    {
        HSY_Status_Change.EndFollow(collision.gameObject);      //碰撞后物体即不被选中，这时应使箭头消失
        HSY_RayController.instance.item=null;
        //Destroy(collision.gameObject.GetComponent<Rigidbody>());    //触发后销毁刚体组件，防止多次触发
        //collision.gameObject.layer=2;
        string COLLISION = collision.gameObject.name.ToUpper();
        GameObject GrandPa = gameObject.transform.parent.parent.gameObject;
        string gradpa = GrandPa.transform.name.Replace("(Clone)", "");
        if (COLLISION == gradpa)
        {
            Destroy(collision.gameObject.GetComponent<Rigidbody>());    //触发后销毁刚体组件，防止多次触发
            AudioSource.PlayClipAtPoint(T, transform.position);
            //播放正确音效
            Destroy(GrandPa,1.5f);      //1.5s后本题消失，2s后下一题产生
            //因为Destory之后未赋值为null，所以设置一个标记变量
            isDestroyed = true;

            if (HSY_PositiveAnswerRate._instance.PositiveNum + HSY_PositiveAnswerRate._instance.NegativeNum < HSY_PositiveAnswerRate._instance.CurrentNO)
            {
                HSY_PositiveAnswerRate._instance.PositiveNum++;  //正确数目加一
            }
        }
        else if (COLLISION == null)
        {
            //未发生碰撞
        }
        else
        {
            AudioSource.PlayClipAtPoint(F, transform.localPosition);
            Destroy(collision.gameObject);
            //播放错误声音

            if (HSY_PositiveAnswerRate._instance.PositiveNum + HSY_PositiveAnswerRate._instance.NegativeNum < HSY_PositiveAnswerRate._instance.CurrentNO)
            {
                HSY_PositiveAnswerRate._instance.NegativeNum++;
                //因为咱们的题目可以容许多次答错，故需要做一个判断
            }
        }
    }
}
