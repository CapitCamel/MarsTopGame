using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

    public int maxHP = 100;
    public int HP;
    public static bool dead = false;
    


    void Start()
    {
        HP = maxHP;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            HP -= 30;

        if (HP <= 0)

            dead = true;

        Destroy(gameObject);
    }
}
