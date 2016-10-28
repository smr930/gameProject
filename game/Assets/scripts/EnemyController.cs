using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Transform target;
	public float speed;
	private float minDistance = 1f;
	private float range;
	private AudioSource caughtThePlayer;


	void Awake() {
		caughtThePlayer = GetComponent<AudioSource>();
	}
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		//target.GetComponent<PlayerController> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		range = Vector2.Distance(transform.position, target.position);
		speed = target.GetComponent<PlayerController> ().speed * 2;

		if (range > minDistance)
		{
			//Debug.Log(range);

			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
	}

	// When the player collides with the enemy, kill the player
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			// shout is played when killer catches player
			caughtThePlayer.Play ();

			Debug.Log ("The killer got the player!");


		}
	}
		
}
