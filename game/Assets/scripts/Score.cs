using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour {
	public Text scoreText;


	// Use this for initialization
	void Start () {
		scoreText = scoreText.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		DisplayScore ();
	}

	public void DisplayScore() {
		scoreText.text = "Score: " + GameController.instance.GetCorrectAnswerCount() + "/" +
				GameController.instance.GetNumberOfQuestions();
	}
		


	public Text scoreTxt;
	public Text nameTxt;
	public Text levelTxt;
	int targetScore;


	public void IncreaseScore(int addend)
	{
		GameControl.Instance.increaseScore (addend);
		int score = GameControl.Instance.getScore ();

	}

	public void IncreaseScore ()
	{
		IncreaseScore (1);
	}

}
