/*
 *  This script will hold variables and fuctions, that will
 *  hold their value throughout the game. This can be useful
 *  when we are changing scenes and we want to pass any data
 *  between the scenes.
*/

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private int correctAns = 0;
	private bool[] isTriggerUsed = new bool[8];

	void Awake() {

		// If an instance already exists, destroy this one
		if (instance != null)
			Destroy (this.gameObject);

		// Otherwise, make this the instance
		else
			instance = this;

		// Enable persistence across scenes
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {



		// Score Variables
		//correctAns = 0;


	}

	/////////////////////////////////////////////
	//		QuestionTrigger Methods
	/////////////////////////////////////////////

	public void SetTriggerUse (int index, bool toggle) {
		isTriggerUsed[index] = toggle;
	}

	public bool GetTriggerUsed (int index) {
		return isTriggerUsed[index];
	}

	/////////////////////////////////////////////
	//		Score Methods
	/////////////////////////////////////////////

	public void IncreaseScore() {
		correctAns++;
	}

	public int GetNumberOfQuestions () {
		return Questions.qa.GetLength (0);
	}

	public int GetCorrectAnswerCount() {
		return correctAns;
	}

	public double GetScorePercentage() {
		return GetCorrectAnswerCount() / GetNumberOfQuestions ();
	}

}
