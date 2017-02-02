using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {
	
	private Rigidbody2D rb2d;
	public float speed;
	private AudioSource audio;
	private bool isFacingRight;
	private Animator animator;
	private float moveHorizontal;
	private float moveVertical;


	void Awake() {

		if (audio == null) {
			audio = GetComponent<AudioSource> ();
		}
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
		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal * speed, .5f * speed);
		MovePlayer (movement);
		if ((moveHorizontal < 0 && isFacingRight) || (moveHorizontal > 0 && !isFacingRight))
			Flip ();
		//make footsteps sound when player moves
		if (IsMoving () && audio.isPlaying == false) {
			audio.Play ();
		} 
		// stop footsteps soundswhen player stops moving
		else if (!IsMoving () && audio.isPlaying) {
			audio.Stop ();
		}
	}


	//Is the player moving?
	bool IsMoving() {

		if (moveVertical == 0 && moveHorizontal == 0)
			return false;
		else
			return true;
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
			rb2d.gameObject.SetActive (false);

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
