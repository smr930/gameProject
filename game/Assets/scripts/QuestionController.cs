using UnityEngine;
using System.Collections;

public class QuestionController : MonoBehaviour {

	public TextMesh questionText;
	public TextMesh ans1;
	public TextMesh ans2;
	public TextMesh ans3;
	public TextMesh ans4;
	public Transform resultObj;
	public GameObject qTrigger;
	public GameObject score;
	private AudioSource correctAnsAudio;
	public AudioSource wrongAnsAudio;


	public static string selectedAnswer;
	public static string choiceSelected = "n";
	public int qCounter = 0;

	// Use this for initialization
	void Start () {
		if (correctAnsAudio == null)
			correctAnsAudio = GetComponent <AudioSource> ();

		if (wrongAnsAudio == null)
			wrongAnsAudio = GetComponent <AudioSource> ();
	
	}

	// Update is called once per frame
	void Update () {
		qCounter = GameController.instance.GetQuestionCounter ();

		// Select a question from the array sequentially
		populateQuestion (qCounter);

		if (choiceSelected == "y") {
			choiceSelected = "n";

			// Check the player's choice with the correct answer from the array
			if (GetCorrectAnswer (qCounter) == selectedAnswer) {
				correctAnsAudio.Play ();
				resultObj.GetComponent<TextMesh> ().text = "Correct!   Click next to continue";

				GameController.instance.IncreaseScore ();
				GameControl.Instance.increaseScore (1);
			} 

			if (GetCorrectAnswer (qCounter) != selectedAnswer) {

				switch (int.Parse(GetCorrectAnswer (qCounter))) {
				case 1:
					wrongAnsAudio.Play ();
					resultObj.GetComponent<TextMesh> ().text = "Wrong! " + GetExplanation(qCounter);
					StartCoroutine(ShowCorrectAnswer (ans1, Color.yellow, 30));
					break;

				case 2:
					wrongAnsAudio.Play ();
					resultObj.GetComponent<TextMesh> ().text = "Wrong! " + GetExplanation(qCounter);
					StartCoroutine(ShowCorrectAnswer (ans2, Color.yellow, 30));
					break;
					
				case 3:
					wrongAnsAudio.Play ();
					resultObj.GetComponent<TextMesh> ().text = "Wrong! " + GetExplanation(qCounter);
					StartCoroutine(ShowCorrectAnswer (ans3, Color.yellow, 30));	
					break;
					
				case 4:
					wrongAnsAudio.Play ();
					resultObj.GetComponent<TextMesh> ().text = "Wrong! " + GetExplanation(qCounter);
					StartCoroutine(ShowCorrectAnswer (ans4, Color.yellow, 30));
					break;
				}
			} 
		}

		if (AnswerWithMouse.lockAnswer == true) {
			AllowAnswerSelection (false);
		} else
			AllowAnswerSelection (true);
	}

	public void populateQuestion(int counter) {
		questionText.GetComponent<TextMesh> ().text = Questions.qa [counter, 0];
		ans1.GetComponent<TextMesh> ().text = Questions.qa [counter, 1];
		ans2.GetComponent<TextMesh> ().text = Questions.qa [counter, 2];
		ans3.GetComponent<TextMesh> ().text = Questions.qa [counter, 3];
		ans4.GetComponent<TextMesh> ().text = Questions.qa [counter, 4]; 
	}	

	public string GetCorrectAnswer(int questionIndex) {
		return Questions.qa [questionIndex, 5]; // the answer is stored in the 5th position
	}

	public string GetExplanation(int questionIndex) {
		return Questions.qa [questionIndex, 6]; // explanation is stored in the 6th position
	}

	// This enables/disables the player from clicking on the answer choices
	public void AllowAnswerSelection(bool b) {
		ans1.GetComponent<BoxCollider2D> ().enabled = b;
		ans2.GetComponent<BoxCollider2D> ().enabled = b;
		ans3.GetComponent<BoxCollider2D> ().enabled = b;
		ans4.GetComponent<BoxCollider2D> ().enabled = b;
	}

	// Highlight the correct answer after the player picks the wrong one
	public IEnumerator ShowCorrectAnswer(TextMesh tm, Color c, int fontSize) { 
		tm.GetComponent<TextMesh> ().color = c;
		tm.GetComponent<TextMesh> ().fontSize = fontSize;
		for (int i = 0; i < 3; i++) {	
			yield return new WaitForSeconds (.1f);
			tm.GetComponent<TextMesh> ().color = Color.red;
			tm.GetComponent<TextMesh> ().fontSize = fontSize + 2;
			yield return new WaitForSeconds (.1f);
			tm.GetComponent<TextMesh> ().color = c;
			tm.GetComponent<TextMesh> ().fontSize = fontSize - 2;
		}
	}

	// Reset colors of all the answers
	public void ResetAnswerColors(TextMesh tm, Color c, int fontSize) { 
		tm.GetComponent<TextMesh> ().color = c;
		tm.GetComponent<TextMesh> ().fontSize = fontSize;
	}

	IEnumerator wait(float n) {
		yield return new WaitForSeconds (n);
	}
}
