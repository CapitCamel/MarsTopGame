using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

    public int maxHP;
    public static int HP;
    


    void Start()
    {
        maxHP = 100;
        HP = maxHP;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            HP -= 30;
        if (HP <= 0)
            Destroy(gameObject);
    }
}
