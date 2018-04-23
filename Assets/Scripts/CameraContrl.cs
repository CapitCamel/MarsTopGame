using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContrl : MonoBehaviour {

	public GameObject Player;


	void Start () {
		
	}
	

	void Update () {
		transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y + 2f, -10f);
	}
}
