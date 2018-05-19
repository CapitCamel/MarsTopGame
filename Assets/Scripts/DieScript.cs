using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DieScript : MonoBehaviour {

    public GameObject destination;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volume = 0.7f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(audioClip, volume);
            col.transform.position = destination.transform.position;
            //GameManeger.fakeDead = true;
            

        }

    }
		
}

