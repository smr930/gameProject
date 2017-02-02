using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviorLv01 : MonoBehaviour {

	public GameObject[] DisplayWhenPaused;
	public GameObject[] DisplayWhenResumed;
	public bool paused;
	public Transform playerTarget;
	public Transform enemyTarget;
	public Transform background;
	public float time;
	public Text JIT1;
	public Text JIT2;
	public Text lv2;

	public saveAndReturn save;


	// Use this for initialization
	void Start () {
		/*DisplayWhenPaused = GameObject.FindGameObjectsWithTag("Paused");
		foreach (GameObject dp in DisplayWhenPaused)
			dp.SetActive (false);
		//if (pauseText == null) {
		DisplayWhenResumed = GameObject.FindGameObjectsWithTag("Unpaused");
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (true);*/
		JIT1 = GameObject.Find("JIT1").GetComponent<Text> ();
		JIT2 = GameObject.Find("JIT2").GetComponent<Text> ();
		lv2 = GameObject.Find("level02").GetComponent<Text> ();

		lv2.enabled = true;

		if (GameControl.Instance.JIT) {
			JIT1.enabled = true;
			JIT2.enabled = true;
			GameControl.Instance.setJIT ();
		}
		Destroy (JIT1, 3);
		Destroy (JIT2, 3);
		Destroy (lv2, 3);

		//pauseText.SetActive(false);
		paused = false;
	}

	// Update is called once per frame
	void Update () {	

		if (Input.GetButtonDown ("Jump") && !paused) 
			PauseGame ();
		else if (Input.GetButtonDown ("Jump") && paused) 
			ResumeGame ();
		else if (Input.GetKeyDown (KeyCode.Escape)) {
			Menu2 ();
			SceneManager.LoadScene("startMenu");
		}
	}

	public void PauseGame()
	{
		
		paused = true;
		playerTarget.GetComponent<PlayerController> ().muteAudio ();
		enemyTarget.GetComponent<EnemyController> ().muteAudio ();
		background.GetComponent<backgroundMusic> ().muteAudio ();
		Time.timeScale = 0.0f;
		//pauseText.SetActive (true);
		foreach (GameObject dp in DisplayWhenPaused)
			dp.SetActive (true);
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (false);
		
	}

	public void ResumeGame()
	{
		paused = false;
		playerTarget.GetComponent<PlayerController> ().unmuteAudio ();
		enemyTarget.GetComponent<EnemyController> ().unmuteAudio ();
		background.GetComponent<backgroundMusic> ().unmuteAudio ();
		Time.timeScale = 1.0f;
		//pauseText.SetActive (false); 
		foreach (GameObject dp in DisplayWhenPaused)
			dp.SetActive (false);
		foreach (GameObject dp in DisplayWhenResumed)
			dp.SetActive (true);
	}

	public void Menu()
	{
		const int NUM_SCORES = 5;

		int pScore = GameControl.Instance.getScore ();
		string pName = GameControl.Instance.getName ();

		string scoreKey = "HighScore";
		string nameKey = "HighScoreName";

		for (int i = 0; i < NUM_SCORES; i++) {
			string curNameKey = (nameKey + i).ToString();
			string curScoreKey = (scoreKey + i).ToString();

			if (!(PlayerPrefs.HasKey (curScoreKey))) {
				print ("no such score");
				PlayerPrefs.SetInt (curScoreKey, pScore);
				PlayerPrefs.SetString (curNameKey, pName);
			} 

			else {
				int score = PlayerPrefs.GetInt (curScoreKey);


				if (pScore > score) {
					int tempScore = score;
					string tempName = PlayerPrefs.GetString (curNameKey);

					PlayerPrefs.SetInt (curScoreKey, pScore);
					PlayerPrefs.SetString (curNameKey, pName);

					pName = tempName;
					pScore = tempScore;
				}
			}
		}		

		for (int i = 0; i < NUM_SCORES; i++)
		{
			print (PlayerPrefs.GetString ("HighScoreName"+i) + " " + PlayerPrefs.GetInt ("HighScore" + i));
		}
		GameControl.Instance.setToZero ();
		GameController.instance.setToZero ();
		SceneManager.LoadScene ("startMenu");
	}

	public void QuitGame() {
		Application.Quit ();
	}

	public void Menu2()
	{
		const int NUM_SCORES = 5;

		int pScore = GameControl.Instance.getScore ();
		string pName = GameControl.Instance.getName ();

		string scoreKey = "HighScore";
		string nameKey = "HighScoreName";

		for (int i = 0; i < NUM_SCORES; i++) {
			string curNameKey = (nameKey + i).ToString();
			string curScoreKey = (scoreKey + i).ToString();

			if (!(PlayerPrefs.HasKey (curScoreKey))) {
				print ("no such score");
				PlayerPrefs.SetInt (curScoreKey, pScore);
				PlayerPrefs.SetString (curNameKey, pName);
			} 

			else {
				int score = PlayerPrefs.GetInt (curScoreKey);


				if (pScore > score) {
					int tempScore = score;
					string tempName = PlayerPrefs.GetString (curNameKey);

					PlayerPrefs.SetInt (curScoreKey, pScore);
					PlayerPrefs.SetString (curNameKey, pName);

					pName = tempName;
					pScore = tempScore;
				}
			}
		}		

		for (int i = 0; i < NUM_SCORES; i++)
		{
			print (PlayerPrefs.GetString ("HighScoreName"+i) + " " + PlayerPrefs.GetInt ("HighScore" + i));
		}
		GameControl.Instance.setToZero ();
		GameController.instance.setToZero ();
	}
}
