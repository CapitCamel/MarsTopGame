using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grabbeble")
        {
            Destroy(col.gameObject);
            
        }
    }
}
