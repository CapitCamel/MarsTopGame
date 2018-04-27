using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.IO;

public class GameHalper : MonoBehaviour {


    private string path;
    public List<SavebleObject> objects = new List<SavebleObject>();


    private void Awake()
    {
        path = Application.persistentDataPath + "/testsave.xml";
    }


    public void Start()
    {
        Load();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Save();
        if (Input.GetKeyDown(KeyCode.L))
            Load();
    }


    public void Save()
    {
        XElement root = new XElement("root");

        foreach (SavebleObject obj in objects)
        {
            root.Add(obj.GetElement());
        }

        //root.AddFirst(new XElement("score", GameManeger.coins));

        XDocument saveDoc = new XDocument(root);

        File.WriteAllText(path, saveDoc.ToString());
        Debug.Log(path);
    }


    public void Load() 
    {
        XElement root = null;

        if (!File.Exists(path))
        {
            Debug.Log("Save data not found...");
            if (File.Exists(Application.persistentDataPath + "/lavel.xml"))
                root = XDocument.Parse(File.ReadAllText(Application.persistentDataPath + "/lavel.xml")).Element("root");
        }
        else
        {
            root = XDocument.Parse(File.ReadAllText(path)).Element("root");
        }

        if (root == null)
        {
            Debug.Log("Lavel Load Failed...");
            return;
        }

        GenerateScene(root);
    }

    private void GenerateScene(XElement root) {

        foreach (SavebleObject obj in objects)
        {
            obj.DestroySelf();
        }

        foreach (XElement instance in root.Elements("instance"))
        {
            Vector3 position = Vector3.zero;

            position.x = float.Parse(instance.Attribute("x").Value);
            position.y = float.Parse(instance.Attribute("y").Value);
            position.z = float.Parse(instance.Attribute("z").Value);
            


            Instantiate(Resources.Load<GameObject>(instance.Value), position, Quaternion.identity);
        }


    }
}
