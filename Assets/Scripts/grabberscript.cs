using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabberscript : MonoBehaviour {
 
	public bool grabbed;
    public Transform Holdpoint;
    RaycastHit2D hit;
    public float distance= 0.7f;
    public float ThrowFose;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.F)) {

			if (!grabbed) {

                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x*distance);

                if (hit.collider != null && hit.collider.tag == "Grabbeble") {
                    grabbed = true;
                }

			}

            else
            {
                grabbed = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null) {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, -1) * ThrowFose;
                }
			}
		}

        if (grabbed)
        {
            hit.collider.gameObject.transform.position = Holdpoint.position;
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position +  Vector3.left * transform.localScale.x*distance);
    }
}
