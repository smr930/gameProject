using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class saveAndReturn : MonoBehaviour {
	const int NUM_SCORES = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Menu()
	{
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

	public void QuitGame() {
		Application.Quit ();
	}

}
