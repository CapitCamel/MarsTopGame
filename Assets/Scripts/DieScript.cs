using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DieScript : MonoBehaviour {

    public GameObject destination;


   

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.position = destination.transform.position;
            //GameManeger.fakeDead = true;


        }

    }
		
}

