using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public int correctAns;
	private int numberOfQuestions;


	// Use this for initialization
	void Start () {
		correctAns = 0;
		numberOfQuestions = 3; //Questions.qa.GetLength (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void IncreaseScore() {
		correctAns++;
	}

	public int GetCorrectAnswerCount() {
		return correctAns;
	}

	public double GetScorePercentage() {
		return correctAns/numberOfQuestions;
	}
}
