using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MovingWinGameOverScript : MonoBehaviour {


	private Rigidbody2D rigid;
	public float directionX;
	public float directionY;
	public float speed ;
	public string nextScene; 
	//public float move;




	// Use this for initialization
	void Start () {

		rigid = GetComponent<Rigidbody2D> ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
		//directionY = Input.GetAxis ("Vertical");
		//directionX = Input.GetAxis ("Horizontal");

			
			rigid.velocity = new Vector2 (speed * directionX, speed * directionY);

		if (HasReachedLimit () == true) {
			LoadNextScene ();

		} else if (Input.GetKeyDown (KeyCode.Escape)) {
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
		SceneManager.LoadScene (nextScene);
	}


}
