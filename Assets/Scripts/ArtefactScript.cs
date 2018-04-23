using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactScript : MonoBehaviour {

	public GameObject Player;
	public  static bool areaObject = false;

	void Start () {
		
	}



/*	private void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (Input.GetKey (KeyCode.F))
				transform.position = new Vector2 (Player.transform.position.x + 1, Player.transform.position.y);
			
		}
	}
*/

	

	void Update ()
	{
		
		if(Input.GetKey(KeyCode.F) && areaObject)
			transform.position = new Vector2 (Player.transform.position.x+1, Player.transform.position.y);
	
	}
}

