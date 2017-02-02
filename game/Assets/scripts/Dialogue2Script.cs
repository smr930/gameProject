using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue2Script : MonoBehaviour {

	public Text frameWoman;
	public Text frameMan;
	public Text [] textsMan = new Text[6];
	public Text [] textsWoman = new Text[6];
	private int textWomanNumber = 0;
	private int textManNumber = 0;
	public Camera camera;
	public AudioSource babyCry;
	public Button skipScene;


	// Use this for initialization
	void Start () 
	{

		babyCry = GetComponent<AudioSource> ();
		WomanSpeaking ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space") && IsMan() && textManNumber > 3) 
		{
			SceneManager.LoadScene ("QA_scene");
		}

		if (Input.GetKeyDown ("space") && IsWoman () && textWomanNumber != 4) {
				
			ManSpeaking ();
			textWomanNumber++;
		
		} else if (Input.GetKeyDown ("space") && IsMan () && textManNumber <= 3) {
			WomanSpeaking ();
			textManNumber++;

		} else if (Input.GetKeyDown ("space") && textWomanNumber == 4) {
			

			baby ();

		} else if (Input.GetKeyDown ("space") && IsWoman () == false && IsMan () == false) {

			WomanSpeaking ();

		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("startMenu");
		}
			
	
	}

	void WomanSpeaking()
	{
		camera.transform.position = new Vector3 (0, 0, -10);
		frameWoman.enabled = true;
		frameMan.enabled = false;
		textsWoman [textWomanNumber].enabled = true;
		textsMan [textManNumber].enabled = false;


	}
	bool IsWoman()
	{
		if (frameWoman.enabled == true)
			return true;
		else
			return false;
	}

	void ManSpeaking ()
	{

		camera.transform.position = new Vector3 (20, 0, -10);
		frameMan.enabled = true;
		frameWoman.enabled = false;
		textsWoman[textWomanNumber].enabled = false;
		textsMan [textManNumber].enabled = true;

	}
	bool IsMan()
	{
		if (frameMan.enabled == true)
			return true;
		else
			return false;
	}

	void baby ()
	{
		camera.transform.position = new Vector3 (51, 0, -10);
		babyCry.Play ();
		frameMan.enabled = false;
		frameWoman.enabled = false;
		textsWoman [textWomanNumber].enabled = false;
		textsMan [textManNumber].enabled = false;
		textWomanNumber++;

	}

	public void SkipScene() {
		
		SceneManager.LoadScene ("QA_scene");
	}
}
