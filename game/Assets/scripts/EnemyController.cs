using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Transform target;
	public float speed;
	private float moveH, moveV;
	private float minDistance = .5f; // default value is 1f
	private float range;
	private AudioSource caughtThePlayer;
	private bool isFacingRight;
	private Animator animator;
	public GameObject damageIndicator;

	void Awake() {
		caughtThePlayer = GetComponent<AudioSource>();
	}
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		isFacingRight = false;
		speed = 0f;
		moveH = moveV = 0f;
		GameController.instance.LoadData ("Enemy");

	}
	
	// Update is called once per frame
	void Update ()
	{
		moveH = Input.GetAxis ("Horizontal");
		moveV = Input.GetAxis ("Vertical");

		if (speed == 0)
			if (moveH != 0 || moveV != 0)
				speed = 2.5f;
		if ((target.position.x - transform.position.x < 0 && isFacingRight) || (target.position.x - transform.position.x > 0 && !isFacingRight))
			Flip ();

		// Chase the player algorithm
		range = Vector2.Distance(transform.position, target.position);

		if (range > minDistance)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * 1.7f * Time.deltaTime);
		}			
	
	}

	// When the player collides with the enemy, kill the player
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			damageIndicator.SetActive (true);
			animator.SetBool ("attack", true);

			// shout is played when killer catches player
			caughtThePlayer.Play ();

		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			damageIndicator.SetActive (false);
			animator.SetBool ("attack", false);
		}
	}
		
	public void Flip() {
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x * -1;
		transform.localScale = playerScale;
		isFacingRight = !isFacingRight;
	}

	public void muteAudio() {
		caughtThePlayer.mute = true;
	}

	public void unmuteAudio() {
		caughtThePlayer.mute = false;
	}
}
