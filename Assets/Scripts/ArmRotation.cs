using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

    public int rotationOffset = 180;
    public GameObject arm;

    // Use this for initialization
    void Start () {
        arm = GameObject.Find("arm");
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arm.transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        arm.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

        if (GameManeger.heroWasFliped)
        {
            FlipX(arm);
            FlipY(arm);
            GameManeger.heroWasFliped = false;
        }



    }

    private void FlipX(GameObject arm)
    {
        //меняем направление движения персонажа
        
        //получаем размеры персонажа
        Vector3 theScale = arm.transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        arm.transform.localScale = theScale;
    }

    private void FlipY(GameObject arm)
    {
        //меняем направление движения персонажа

        //получаем размеры персонажа
        Vector3 theScale = arm.transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.y*= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        arm.transform.localScale = theScale;
    }
}
