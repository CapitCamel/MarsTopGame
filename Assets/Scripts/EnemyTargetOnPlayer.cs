using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetOnPlayer : MonoBehaviour {

    EnemyController EC;

	// Use this for initialization
	void Start () {


        EC = GetComponentInParent<EnemyController>();

        //EC = GameObject.Find("Enemy").GetComponent<EnemyController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!EC.dead)
        {

            if ( col.gameObject.tag == "Player")
            {
                EC.PatrolPoints[0].position = GameObject.Find("EnemyFollowPoint").transform.position;
                EC.PatrolPoints[1].position = GameObject.Find("EnemyFollowPoint").transform.position;
            }
        }

    }


}
