using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public int moveSpeed = 20;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 2);
    }
}
