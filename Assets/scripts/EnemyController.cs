using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed;
	private Vector2 dir;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		speed = 3.0f;
		dir = new Vector2 (0f, 0f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		FollowPlayer (dir);
		rb2d.velocity = (dir * speed);
	
	}

	// Fire enemy weapon
	void FollowPlayer(Vector2 dir) {
		GameObject player = GameObject.Find ("Player");
		if (player != null) {

			// coumpute the direction towrds the player's position
			dir.x = player.transform.position.x - transform.position.x;
			Debug.Log ("dir = " + dir);
		} 
	}

/*
	// Function called when the object goes out of the screen
	void OnBecameInvisible()
	{ 
		Destroy(gameObject);
		Debug.Log ("Enemy is out of bounds and destroyed!");
	}
	*/
}
