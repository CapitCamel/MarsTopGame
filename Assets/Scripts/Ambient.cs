using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip currentAmbient;
    public float volume = 0.3f;
    bool paused = false;


    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.name == "Character")
        {

            if (paused)
            {
                audioSource.UnPause();
            }
            else
            {
                audioSource.clip = currentAmbient;
                audioSource.PlayOneShot(currentAmbient, volume);
            }
        }
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "Character")
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(currentAmbient, volume);
            }
           
            //audioSource.Play();

        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.name == "Character")
        {

            audioSource.Pause();
            paused = true;

        }
        
    }
}
