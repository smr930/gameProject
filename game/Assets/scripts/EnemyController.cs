using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Transform target;
	public float speed;
	private float minDistance = .5f; // default value is 1f
	private float range;
	private AudioSource caughtThePlayer;
	private bool isFacingRight;
	private Animator animator;

	void Awake() {
		caughtThePlayer = GetComponent<AudioSource>();
	}
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
<<<<<<< HEAD
		//target.GetComponent<PlayerController> ();
=======
>>>>>>> Textured-Level01,-minor-tweaks-to-code
		animator = GetComponent<Animator> ();
		isFacingRight = false;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((target.position.x - transform.position.x < 0 && isFacingRight) || (target.position.x - transform.position.x > 0 && !isFacingRight))
			Flip ();

		// Chase the player algorithm
		range = Vector2.Distance(transform.position, target.position);
		speed = target.GetComponent<PlayerController> ().speed;

		if (range > minDistance)
		{
			//Debug.Log(range);

			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * 2 * Time.deltaTime);
		}
<<<<<<< HEAD
		if ((target.position.x - transform.position.x < 0 && isFacingRight) || (target.position.x - transform.position.x > 0 && !isFacingRight))
			Flip ();
=======
			
>>>>>>> Textured-Level01,-minor-tweaks-to-code
	
	}

	// When the player collides with the enemy, kill the player
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			animator.SetBool ("attack", true);
			// shout is played when killer catches player
			caughtThePlayer.Play ();

			Debug.Log ("The killer got the player!");

			// Code to handle killing the player
			//other.gameObject.SetActive (false);

		}
	}
		
	public void Flip() {
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x * -1;
		transform.localScale = playerScale;
		isFacingRight = !isFacingRight;
	}
}
