using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KnockingScript : MonoBehaviour {

	public AudioSource audio;
	private string[] dialogueArray = {"dialogueSerious1", "dialogueSerious2", "dialogueSerious4", "dialogueSerious5",
		"dialogueSerious6"};
	
	// Use this for initialization
	void Start () {

		//if (audio == null)
		//	audio = GetComponent <AudioSource> ();
			
	
	}

	// Update is called once per frame
	void Update () {

		if (audio.time > 7) {
			audio.Stop ();
			LoadNextScene ();

		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("startMenu");
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			LoadNextScene ();
		}
		

	}

	void LoadNextScene()
	{
		string randomDialogue = dialogueArray [Random.Range(0,dialogueArray.Length)];
		SceneManager.LoadScene (randomDialogue);
	}
}
