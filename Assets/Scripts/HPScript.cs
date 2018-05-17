using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScript : MonoBehaviour {

    public int maxHP;
    public static int HP;
    public Slider slider;


	void Start () {
        maxHP = 100;
        HP = maxHP;
	}
	
	
	void Update () {
        
	}
}
