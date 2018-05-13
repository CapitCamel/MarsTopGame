using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    GameManeger GM;
    public bool open;
    public string tutorText;

	// Use this for initialization
	void Start () {
        GM = GameObject.Find("GameManegger").GetComponent<GameManeger>();
        

	}
	
	// Update is called once per frame
	void Update () {

        if (GameManeger.openTutor && open)
        {
            GM.tutorPanel.GetComponentInChildren<Text>().text = tutorText;
        }

	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Character")
        {
            open = true;
            GameManeger.openTutor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         open = false;
         GameManeger.openTutor = false;
    }
}
