using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour {

    public Text CoinsText;
   

    void Update () {
		CoinsText.text =GameManeger.coins.ToString ();
	}
}
