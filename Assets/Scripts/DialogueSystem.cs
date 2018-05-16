using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

    public string[] dialogueText;
    public string openText;
    GameManeger GM;
    public bool open;
    public bool openT;
    public int i;
    public float timeDelay;
    float timer;
    bool enter;

    public AudioSource audioSource;
    public AudioClip currentAmbient;
    public float volume = 0.5f;

    // Use this for initialization
    void Start () {
        GM = GameObject.Find("GameManegger").GetComponent<GameManeger>();
        timer = timeDelay;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManeger.openDialogue && open)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;

            }

            if (Input.GetButtonUp("inBut"))
            {
                timer = 0;
            }

            if (timer <= 0)
            {
                timer = 0;
                if (i <= dialogueText.Length)
                {
                    audioSource.PlayOneShot(currentAmbient, volume);
                    i++;
                    timer = timeDelay;
                }
                if (i == dialogueText.Length)
                {
                    open = false;
                    GameManeger.openDialogue = false;
                }
            }

            if (i < dialogueText.Length)
            {
                
                GM.dialoguePanel.GetComponentInChildren<Text>().text = dialogueText[i];
            }
            if (i == dialogueText.Length)
            {
                //audioSource.PlayOneShot(currentAmbient, volume);
                GM.dialoguePanel.GetComponentInChildren<Text>().text = dialogueText[dialogueText.Length - 1];
            }

        }

        if (GameManeger.openTutor && openT)
        {
            
            GM.tutorPanel.GetComponentInChildren<Text>().text = openText;
        }

        if (enter)
        {
            if (Input.GetButtonUp("inBut") && !open)
            {
                audioSource.PlayOneShot(currentAmbient, volume);
                open = true;
                GameManeger.openDialogue = true;
                GameManeger.openTutor = false;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Character")
        {
            openT = true;
            GameManeger.openTutor = true;
            enter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        i = 0;
        openT = false;
        open = false;
        GameManeger.openTutor = false;
        GameManeger.openDialogue = false;
        enter = false;
    }


}