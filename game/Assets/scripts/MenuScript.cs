using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startButton;
	public Button exitButton;
	public Button instructionsButton;
	public Canvas playMenu;
	public InputField input;
	public Slider musicSlider;
	const int NUM_SCORES = 5;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startButton = startButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		playMenu = playMenu.GetComponent < Canvas> ();
		instructionsButton = instructionsButton.GetComponent<Button>();

		input = GetComponent<InputField> ();


		quitMenu.enabled = false;
		playMenu.enabled = false;
	}

	public void ExitPressed()
	{
		quitMenu.enabled = true;
		exitButton.enabled = false;
		startButton.enabled = false;
		instructionsButton.enabled = false;
	}

	public void DontQuitPress()
	{
		quitMenu.enabled = false;
		startButton.enabled = true;
		exitButton.enabled = true;
		playMenu.enabled = false;
		instructionsButton.enabled = true;

	}

	public void PlayPress()
	{
		quitMenu.enabled = false;
		playMenu.enabled = true;
		exitButton.enabled = false;
		startButton.enabled = false;
		instructionsButton.enabled = false;
	}

	public void InstructionsPressed(){

		SceneManager.LoadScene ("Instructions");
	}



	public void StartGame()
	{
    //  string pName = input.text;
	//	print (pName);	
	//	GameControl.Instance.setName (pName);
		SceneManager.LoadScene("IntroCutscene");
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	public void HighScore()
	{
		SceneManager.LoadScene("HighScore");
	}

	public void Instuction()
	{
		SceneManager.LoadScene("Instuction");
	}

	public void Setting()
	{
		SceneManager.LoadScene("Setting");
	}

	public void returnToMain()
	{
		SceneManager.LoadScene("startMenu");
	}

	public void OnMusicVolumeChange() {
		GameControl.Instance.musicVolume = musicSlider.value;
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
		SceneManager.LoadScene ("startMenu");
	}

}
	
