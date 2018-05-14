using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowMouse : MonoBehaviour {

    GameManeger GM;
    public GameObject lightSource;
    public float moveSpeed = 0.004f;
    public bool flashOn = true;
    bool pressed;

    public AudioSource audioSource;
    public AudioClip onOffClip; //32
    public float volume = 0.7f;

    // Use this for initialization
    void Start()
    {
        GM = GameObject.Find("GameManegger").GetComponent<GameManeger>();
        lightSource = GameObject.Find("heroLight");
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        //lightSource = GameObject.Find("heroLight");
        //lightSource = GM.heroFlash;

        // transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), moveSpeed);
        if (Input.GetButtonDown("light") && !flashOn)
        {

            audioSource.PlayOneShot(onOffClip, 0.5f);

            GameManeger.flashOn = true;
            flashOn = !flashOn;
            lightSource = GM.heroFlash;
            pressed = true;
        }



        if (GameManeger.flashOn)
        {
            //GameManeger.flashOn = true;

            
           
            //СЮДА ССЫЛКУ НА СВЕТ, А САМ СКРИПТ НА ПЕРСОНАЖА
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lightSource.transform.position;
            difference.Normalize();
            float rotation_z = (Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg) - 90;
            lightSource.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);


            if (Input.GetButtonDown("light") && flashOn && !pressed)
            {
                audioSource.PlayOneShot(onOffClip, volume);
                flashOn = false;
                GameManeger.flashOn = false;
                
            }

            pressed = false;
        
        }
    }

    
}
