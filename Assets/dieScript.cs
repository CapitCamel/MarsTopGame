using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "dieCollider")
			Application.LoadLevel (Application.loadedLevel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
