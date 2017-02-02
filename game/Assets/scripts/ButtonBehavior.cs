using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour {

	public void StartGame () {
		SceneManager.LoadScene ("level01");
	}

	public void QuitGame () {
		Application.Quit ();
	}
}
