using System.Collections;
using System.Collections.Generic;

//是使用XML，JSON以及数据库时必备的实体类
public class QuestionEntity
{
    //题目编号
    private int id;
    private string hashID;
    private int unit_id;
    //问题以string形式进行存储
    private string question;
    //答案以string数组形式进行存储，第一位为正确答案，后面都为错误
    private List<string> answer;

    public QuestionEntity()
    {
        this.id = 9999;
        unit_id = 0;
        this.question = "";
        this.answer = null;
        answer.Add("");
    }


    //获取问题内容
    public string GetQuestion()
    {
        if (question != "")
            return question;
        else return "EMPTY!";
    }
    //写入问题内容
    public void SetQuestion(string input)
    {
        question = input;
    }
    //获取正确答案
    public string GetRightAnswer()
    {
        if (answer.Count > 0)
            return answer[0];
        else return "EMPTY";
    }
    //获取错误答案
    public List<string> GetWrongAnswer()
    {
        return answer.GetRange(1,answer.Count-1);
    }
    //获取所有答案，第0个是正确答案
    public List<string> GetAllAnswer()
    {
        return answer;
    }
    //从XML，JSON，数据库写入答案，输入类型是List<string>
    public void SetAnswer(List<string> Input)
    {
        answer = Input;
    }
}