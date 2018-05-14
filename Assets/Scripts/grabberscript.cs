using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabberscript : MonoBehaviour {
 
	public bool grabbed;
    public Transform Holdpoint;
    RaycastHit2D hit;
    public float distance= 0.7f;
    public float ThrowFose;

    public AudioSource audioSource;
    public AudioClip throwClip; //47
    public AudioClip takeClip; //46
    public float volume = 0.7f;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        



        if (Input.GetKeyDown (KeyCode.F)) {

			if (!grabbed) {

                

                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x*distance);

                if (hit.collider != null && hit.collider.tag == "Grabbeble") {
                    audioSource.PlayOneShot(takeClip, volume);
                    grabbed = true;
                }

			}

            else
            {
                audioSource.PlayOneShot(throwClip, volume);

                grabbed = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null) {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, -1) * ThrowFose;
                }
			}
		}

        

        if (grabbed)
        {
                     
                hit.collider.gameObject.transform.position = Holdpoint.position;
                //Объект есть на сцене 
      

        }


	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position +  Vector3.left * transform.localScale.x*distance);
    }
}
