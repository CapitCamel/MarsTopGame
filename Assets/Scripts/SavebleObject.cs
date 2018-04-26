using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class SavebleObject : MonoBehaviour {

    [SerializeField]
    private string objectName;

    private GameHalper helper;


    private void Awake()
    {
        helper = FindObjectOfType<GameHalper>();
    }


    private void Start()
    {
        helper.objects.Add(this);
    }

    private void OnDestroy()
    {
        helper.objects.Remove(this);
    }

    public XElement GetElement()
    {
        XAttribute x = new XAttribute("x", transform.position.x);
        XAttribute y = new XAttribute("y", transform.position.y);
        XAttribute z = new XAttribute("z", transform.position.z);

        XElement element = new XElement("instance", objectName, x, y, z);

        return element;
    }
}
