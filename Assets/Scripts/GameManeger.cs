using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour {

	public static int coins;
	public static bool dead;

	void Start () {
		
	}

	void Update () {
		//DontDestroyOnLoad (this.gameObject);
	
		if (dead) {
			SceneManager.LoadScene (0);
			dead = false;
		}
	}
}
