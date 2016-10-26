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

	public static string selectedAnswer;
	public static string choiceSelected = "n";
	public static int counter = 0;

	// Use this for initialization
	void Start () {
		//counter = qTrigger.GetComponent<QuestionTrigger>().GetCounter();
		if (qTrigger.gameObject.CompareTag ("Trigger")) {
			counter = qTrigger.gameObject.GetComponent<QuestionTrigger> ().GetCounter();
		}
		Debug.Log (counter);
	}

	// Update is called once per frame
	void Update () {

		// Select a question from the array sequentially
		populateQuestion (counter);

		if (choiceSelected == "y") {
			choiceSelected = "n";

			// Check the player's choice with the correct answer from the array
			if (GetCorrectAnswer (counter) == selectedAnswer) {
				resultObj.GetComponent<TextMesh> ().text = "Correct!   Click next to continue";
				//score.GetComponent<Score> ().IncreaseScore ();
				GameController.instance.IncreaseScore ();
				Debug.Log ("Correct answer count: " + GameController.instance.GetCorrectAnswerCount ());

			} 

			if (GetCorrectAnswer (counter) != selectedAnswer) {

				switch (int.Parse(GetCorrectAnswer (counter))) {
				case 1:
					Debug.Log ("one");
					resultObj.GetComponent<TextMesh> ().text = "Wrong! The correct answer is the first choice!\n\t\t\tClick next to continue";
					break;

				case 2:
					resultObj.GetComponent<TextMesh> ().text = "Wrong! The correct answer is the second choice!\n\t\t\tClick next to continue";
					break;
					
				case 3:
					Debug.Log ("three");
					resultObj.GetComponent<TextMesh> ().text = "Wrong! The correct answer is the third choice!\n\t\t\tClick next to continue";
					break;
					
				case 4:
					resultObj.GetComponent<TextMesh> ().text = "Wrong! The correct answer is the forth choice!\n\t\t\tClick next to continue";
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

	// This enables/disables the player from clicking on the answer choices
	public void AllowAnswerSelection(bool b) {
		ans1.GetComponent<BoxCollider2D> ().enabled = b;
		ans2.GetComponent<BoxCollider2D> ().enabled = b;
		ans3.GetComponent<BoxCollider2D> ().enabled = b;
		ans4.GetComponent<BoxCollider2D> ().enabled = b;
	}

	IEnumerator wait(float n) {
		yield return new WaitForSeconds (n);
	}
}
