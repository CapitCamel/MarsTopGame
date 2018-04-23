using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaArtefactsScript : MonoBehaviour {


	void Start () {
		
	}
	

	void OnTriggerStay2D (Collider2D col){
		if (col.gameObject.tag == "Player") {
			ArtefactScript.areaObject = true;
		}
		//else ArtefactScript.areaObject = false;
	}
}
