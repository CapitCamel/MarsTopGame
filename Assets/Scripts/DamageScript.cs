using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

    
    public GameObject destination;
    public int damage = 35;
    float lastHitTime = 2;
    float timeToHit = 0;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioDeathClip;
    public float volume = 0.7f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    private void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player" && lastHitTime == 0)
        {

            HPScript.HP -= damage;
            audioSource.PlayOneShot(audioClip, volume);

            if (HPScript.HP <= 0)
            {
                audioSource.PlayOneShot(audioDeathClip, volume);
                col.transform.position = destination.transform.position;
                
                HPScript.HP = HPScript.lastHP;
            }


        }


        if (col.gameObject.tag == "Player" && Time.time > timeToHit)
        {
            timeToHit = Time.time + lastHitTime;
            audioSource.PlayOneShot(audioClip, volume);

            Debug.Log(timeToHit + "   " + Time.time);
            HPScript.HP -= damage;

            

            if (HPScript.HP <= 0)
            {
                audioSource.PlayOneShot(audioDeathClip, volume);
                col.transform.position = destination.transform.position;

                HPScript.HP = HPScript.lastHP;
            }

            
            
        }
    }
}
