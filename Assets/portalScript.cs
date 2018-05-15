using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{

    public GameObject portal;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            if (Input.GetKeyDown(KeyCode.T))
                col.transform.position = portal.transform.position;
    }
}
