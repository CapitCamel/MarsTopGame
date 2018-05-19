using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScript : MonoBehaviour {

    public int maxHP;
    public static int HP;
    public static int lastHP = 100;
    public Slider slider;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volume = 0.7f;

    void Start () {
        audioSource = GameObject.Find("Character").GetComponent<AudioSource>();
        maxHP = 100;
        HP = maxHP;
	}
	
	
	void Update () {

        if (HP <= 0 )
        {
            audioSource.PlayOneShot(audioClip, volume);
        }

        slider.value = HP;

    }
}
