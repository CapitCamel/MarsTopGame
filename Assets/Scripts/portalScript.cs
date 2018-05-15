using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip currentSound;
    public float volume = 0.7f;

    public GameObject portal;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            if (Input.GetKeyDown(KeyCode.T))
            {
                audioSource.PlayOneShot(currentSound, volume);
                col.transform.position = portal.transform.position;
            }
            }
}
