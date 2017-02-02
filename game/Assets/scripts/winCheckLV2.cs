using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class winCheckLV2 : MonoBehaviour {

	public saveAndReturn save;
	// Update is called once per frame
	void Update () {
		winCk ();
	}

	public void winCk()  {
		int temp = GameController.instance.GetCorrectAnswerCount ();
		if (temp >= 24) {
			SceneManager.LoadScene ("winScene0");
			
		}
	}
}

