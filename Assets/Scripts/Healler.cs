using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healler : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volume = 0.7f;

    private void Start()
    {
        audioSource = GameObject.Find("Character").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        audioSource.PlayOneShot(audioClip, volume);
        HPScript.HP = 100;
        Destroy(gameObject);
    }
}
