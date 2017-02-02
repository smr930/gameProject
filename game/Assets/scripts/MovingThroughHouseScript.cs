using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MovingThroughHouseScript : MonoBehaviour {

	private Rigidbody2D rigid;
	public float directionX;
	public float directionY;
	public float speed ;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
				
		rigid.velocity = new Vector2 (speed * directionX, speed * directionY);
		if (HasReachedLimit () == true || Input.GetKeyDown (KeyCode.Space)) {
			LoadNextScene ();
		}
		 else if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("startMenu");
		}
	}
	bool HasReachedLimit()
	{
		if (rigid.transform.position.x >= 15)
			return true;
		else
			return false;
	}
	void LoadNextScene()
	{
		SceneManager.LoadScene ("level01");
	}
}
