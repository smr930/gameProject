using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	private Rigidbody2D rb2d;
	public float speed;
	private AudioSource audio;
	private bool isFacingRight;
	private Animator animator;


	void Awake() {
		//LoadPlayerPos (0, -1f, 0);
		audio = GetComponent<AudioSource>();
	}

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		isFacingRight = true;
		speed = 3.0f;
		//LoadPlayerPos (0, 2, 0);

	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal * speed, moveVertical * speed);
		MovePlayer (movement);
		if ((moveHorizontal < 0 && isFacingRight) || (moveHorizontal > 0 && !isFacingRight))
			Flip ();
		//make footsteps sound when player moves
		if (Input.GetButtonDown ("Horizontal") || Input.GetButtonDown ("Vertical")) {
			
			audio.Play ();
		} 
		// stop footsteps soundswhen player stops moving
		else if (Input.GetButtonUp ("Vertical")) {
			
			audio.Stop ();
		}
    }

	void MovePlayer(Vector2 direction) {	
		// Get the player's current position
		Vector2 pos = transform.position;

		// Calculate the new position
		pos += direction * speed * Time.deltaTime;

		// Update the player's position
		transform.position = pos;
	}


	// Destroy the player if the enemy collides with it
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			animator.SetBool("hit", true);

			//other.gameObject.SetActive (false);
			//Debug.Log ("Player collided with the enemy");
			//rb2d.gameObject.SetActive (false);

		}

	}

	void OnDestroy() {
		//SavePlayerPos ();
	}


	public void SavePlayerPos() {
		PlayerPrefs.SetFloat ("X", transform.position.x);
		PlayerPrefs.SetFloat ("Y", transform.position.y);
		PlayerPrefs.SetFloat ("Z", transform.position.z);
	}

	public void LoadPlayerPos(float xOffset, float yOffset, float zOffset) {
		//transform.position.x = PlayerPrefs.GetFloat ("X");
		//transform.position.y = PlayerPrefs.GetFloat ("Y");
		//transform.position.z = PlayerPrefs.GetFloat ("Z");

		Vector3 playerPos = new Vector3 (PlayerPrefs.GetFloat ("X") + xOffset, PlayerPrefs.GetFloat ("Y") 
										+ yOffset, PlayerPrefs.GetFloat ("Z") + zOffset);
		transform.position = playerPos;
	}

	public void Flip() {
		Vector3 playerScale = transform.localScale;
		playerScale.x = playerScale.x * -1;
		transform.localScale = playerScale;
		isFacingRight = !isFacingRight;
	}
}
