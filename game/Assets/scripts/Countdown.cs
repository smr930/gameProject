using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	public GameObject countdownAnim;
	ButtonBehaviorLv01 behave;

	public bool pause = false;

	// Use this for initialization
	void Start () {
		if (behave == null)
			behave = GameObject.FindObjectOfType (typeof(ButtonBehaviorLv01)) as ButtonBehaviorLv01; 

		//behave.PauseGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

     
 

}
