﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour {

	public static int coins;
	public static bool dead;
    public static bool fakeDead;
    public static bool openDialogue;
    public static bool openTutor;
    public static bool flashOn;
    public GameObject tutorPanel;
    public GameObject dialoguePanel;
    public GameObject heroFlash;
    public static bool heroWasFliped;

	void Start () {

        dialoguePanel = GameObject.Find("dialoguePanel");
        tutorPanel = GameObject.Find("tutorPanel");
        heroFlash = GameObject.Find("heroLight");
        tutorPanel.SetActive(false);
        dialoguePanel.SetActive(false);
        heroFlash.SetActive(false);

	}

	void Update () {
		//DontDestroyOnLoad (this.gameObject);
	    /*
		if (dead) {
			SceneManager.LoadScene (2);
			dead = false;
		}
        */
        dialoguePanel.SetActive(openDialogue);
        tutorPanel.SetActive(openTutor);
        heroFlash.SetActive(flashOn);
       

    }


}
