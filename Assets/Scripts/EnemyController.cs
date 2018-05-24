using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	GameObject player;
	Animator anim;
	Rigidbody2D rbEnemy;
	public Transform[] PatrolPoints;
    public Transform groundCheck;
    public Transform frontCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;


    public bool isStuck = false;
    public bool isGrounded = false;

    int currentPoint = 0;
	public float speed=0.05f;
	public float stillTime = 1.5f;
	public float KillSight = 0.1f;


    public int maxHP = 100;
    public int HP;
    public bool dead = false;


    public AudioSource audioSource;
    public AudioSource deathSource;
    public AudioClip audioClip;
    public AudioClip deathClip;
    public float volume = 0.7f;

    public float timeWalkDelay = 0.7f;
    float timer;


    void Start(){

        deathSource = GameObject.Find("Character").GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        HP = maxHP;
        player = GameObject.FindGameObjectWithTag ("Player");
		rbEnemy = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

			anim.SetBool ("Walk", true);
			StartCoroutine ("Patrol");

        

    }

	void Update(){

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        isStuck = Physics2D.OverlapCircle(frontCheck.position, groundRadius, whatIsGround);

        if (HP <= 0)
        {
            deathSource.PlayOneShot(deathClip, 1f);

            HPScript.lastHP = HPScript.HP;
            audioSource.PlayOneShot(deathClip, 1f); 
            dead = true;
            Destroy(gameObject);
        }


    }

	IEnumerator Patrol(){
		while (true){

            

			if (transform.position.x == PatrolPoints [currentPoint].position.x) {
				currentPoint++;
				anim.SetBool ("Walk", false);
				yield return new WaitForSeconds (stillTime);
				anim.SetBool ("Walk", true);
			}

			if (currentPoint >= PatrolPoints.Length) {
				currentPoint = 0;
			}

			transform.position = Vector2.MoveTowards(transform.position, new Vector2 (PatrolPoints[currentPoint].position.x, transform.position.y), speed);

            



            if (isGrounded) //проверка на застревание и прыжок 
            {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }

                if (timer <= 0)
                {
                    audioSource.PlayOneShot(audioClip, volume);
                    timer = timeWalkDelay;
                }
                

                if (isStuck)
                {
                    
                    rbEnemy.AddForce(new Vector2(0, 4000));
                }
            }




            if (transform.position.x > PatrolPoints [currentPoint].position.x) {
				transform.localScale = new Vector3 (-5f, 5f, 1.5f);
			} else if (transform.position.x < PatrolPoints [currentPoint].position.x) {
				transform.localScale = new Vector3 (5f, 5f, 1.5f);
			}


			yield return null;
		}
		Destroy (player);


	}
	//void OnTriggerEnter2D(Collider2D other){
	//	if (other.tag == "Player") {
//			Destroy (other);
//		}
	//}
}
