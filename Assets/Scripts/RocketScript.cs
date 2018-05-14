using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {

    public int playerArtQuantity;
    public AudioSource audioSource;
    public AudioClip currentAmbient;
    public float volume = 0.7f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Grabbeble")
        {
            audioSource.PlayOneShot(currentAmbient, volume);
            playerArtQuantity =+ playerArtQuantity; 
            Destroy(col.gameObject);
            
        }
    }
}
