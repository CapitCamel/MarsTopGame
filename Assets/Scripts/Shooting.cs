using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    private Animator anim;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public float volume = 0.7f;

    public GameObject light;


    EnemyController enemy;

    public float fireRate = 5;
    public int damage = 10;
    public LayerMask whatToHit;

    public Transform BulletPrefab;
    float timeToSpwanEffect = 0;
    public float effectSpwanRate = 10;


    float timeToFire = 0;
    Transform firePoint;


    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        light = GameObject.Find("FireLight");
        light.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Awake () {
        

        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("no fire point!");
        }
	}

    // Update is called once per frame
    void Update() {
        
        /* 
            if (anim.GetBool("Shoot"))
            anim.SetBool("Shoot", false);
        */
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                
                Shoot();
            }
           
                
        }

        

    }

    void Shoot() {


        light.gameObject.SetActive(true);
        anim.SetBool("Shoot", true);
        audioSource.PlayOneShot(audioClip, volume);
        Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit); //100 shoot distance

        if (Time.time >= timeToSpwanEffect)
        {
            Effect();
            timeToSpwanEffect = Time.time + 1 / effectSpwanRate;
        }

        if (hit.collider != null)
        {
            

            enemy = hit.collider.gameObject.GetComponentInParent<EnemyController>();
            

            enemy.HP -= damage;

        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
        {
            // do something
        }

        //Effect();

        Debug.DrawLine(firePointPosition, mousePosition);


    }

    void Effect()
    {
        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);



    }

    void AnimationComplete()
    {
        anim.SetBool("Shoot",false);
        light.gameObject.SetActive(false);
    }
}
