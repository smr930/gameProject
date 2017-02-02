using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class winCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		winCk ();
	}

	public void winCk() {
		int temp = GameController.instance.GetCorrectAnswerCount();
		if (temp >= 12) {
			GameController.instance.lv1to2 ();
			SceneManager.LoadScene ("level02");
		}
	}
}
