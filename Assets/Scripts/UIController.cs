using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour {

    public Text CoinsText;
    public RocketScript RS;

    void Start()
    {
        RS = GameObject.Find("Rockets").GetComponent<RocketScript>();
    }

    void Update () {
		CoinsText.text = RS.playerArtQuantity.ToString () + "/3";
	}
}
