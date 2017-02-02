using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverAndWinScript : MonoBehaviour {

	public Button restartButton;
	public Button MenuButton;
	public saveAndReturn save;

	// Use this for initialization
	void Start () {
		restartButton = restartButton.GetComponent<Button> ();
		MenuButton = MenuButton.GetComponent<Button> ();
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void restartPressed() {
		Menu ();
		SceneManager.LoadScene ("level01");
	}

	public void menuPressed() {
		Menu ();
		SceneManager.LoadScene ("startMenu");
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
	}
}
