using UnityEngine;
using System.Collections;

public class killerSound : MonoBehaviour {

	public AudioSource killer;
	private Rigidbody2D bodyKiller;
	public float signalByPosition;
	private float xPosition;

	// Use this for initialization
	void Start () {
		
		bodyKiller = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		xPosition = bodyKiller.transform.position.x;
	
		if (HasReachedPostion () && killer.isPlaying == false) {
			
			killer.Play ();

		}
	}

	bool HasReachedPostion()
	{
		if (xPosition >= signalByPosition)
			return true;
		else
			return false;
	}
}
