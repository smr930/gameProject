using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	private Rigidbody2D killer;



	// Use this for initialization
	void Start () {

		killer = GetComponent<Rigidbody2D> ();

	
	
	}
	
	// Update is called once per frame
	void Update () {
		

		StartCoroutine(Example());
		//yield return new WaitForSeconds (3f);


	
	}


	IEnumerator Example() {
		//doNothing ();
		yield return new WaitForSeconds(2);
		moveKiller ();
	
	}

	public void doNothing() {
		
	}

	public void moveKiller() {
		killer.transform.localScale += new Vector3 (0.1F, 0.1F, 0.1F);
	}
}
