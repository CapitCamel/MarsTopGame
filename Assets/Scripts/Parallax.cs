using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public Transform[] backgrounds;

    private float[] parallaxScales;
    public float smoothing;

    private Vector3 previosCameraPosition;
	// Use this for initialization
	void Start () {
        previosCameraPosition = transform.position; //script on camera bliat
        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < parallaxScales.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * (-1);

        }
    }
	
	// Update is called once per frame
	void LateUpdate () {

        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 parallax = (previosCameraPosition - transform.position) * (parallaxScales[i] / smoothing);

            backgrounds[i].position = new Vector3(backgrounds[i].position.x + parallax.x, backgrounds[i].position.y + parallax.y, backgrounds[i].position.z);

        }


        previosCameraPosition = transform.position;

    }
}
