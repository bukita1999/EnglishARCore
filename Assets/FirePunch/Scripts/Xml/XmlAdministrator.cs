using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class XmlAdministrator : MonoBehaviour {
    private static ArrayList nameList = new ArrayList();
    public static string path;
    // Use this for initialization
    void Start () {
        path=Application.persistentDataPath + "/data.xml";
        CreateXML();
        LoadXml();
    }

    // Update is called once per frame
    void Update () {

    }

    public static void CreateXML()
    {
        if (!File.Exists(path))
        {
            //创建最上一层的节点。
            XmlDocument xml = new XmlDocument();
            //创建最上一层的节点。
            XmlElement root = xml.CreateElement("objects");
           
            xml.AppendChild(root);
            
            xml.Save(path);
        }
        
    }


    public static void LoadXml()
    {
        //创建xml文档
        XmlDocument xml = new XmlDocument();
        xml.Load(path);
        //得到objects节点下的所有子节点
        XmlNodeList xmlNodeList = xml.SelectSingleNode("objects").ChildNodes;
        //遍历所有子节点
        foreach (XmlElement x in xmlNodeList)
        {
            nameList.Add(x.GetAttribute("objectname"));
        }
    }

    public static bool addXMLData(string objectname){
        if(nameList.Contains(objectname)){
            return false;
        }
        if (File.Exists(path)){
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNode root = xml.SelectSingleNode("objects");
            XmlElement element = xml.CreateElement("message");
            element.SetAttribute("objectname", objectname);
            root.AppendChild(element);
            xml.AppendChild(root);
            xml.Save(path);
            nameList.Add(objectname);
            return true;
        }else{
            return false;
        }
    }

    public static void clearData(){
        if (File.Exists(path))
        {
            nameList.Clear();
        }
    }
    
}