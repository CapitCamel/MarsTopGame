using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {

    public int playerArtQuantity;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grabbeble")
        {
            playerArtQuantity =+ playerArtQuantity; 
            Destroy(col.gameObject);
            
        }
    }
}
