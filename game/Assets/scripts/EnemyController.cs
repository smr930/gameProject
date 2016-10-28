using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

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

	}
	
	// Update is called once per frame
	void Update ()
	{
		range = Vector2.Distance(transform.position, target.position);
		speed = target.GetComponent<PlayerController> ().speed;

		if (range > minDistance)
		{
			//Debug.Log(range);

			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * 2 * Time.deltaTime);
		}
	}

	// When the player collides with the enemy, kill the player
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			// shout is played when killer catches player
			caughtThePlayer.Play ();

			Debug.Log ("The killer got the player!");
			//other.gameObject.SetActive (false);

		}
	}
		
}
