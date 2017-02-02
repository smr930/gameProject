using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour {
	public Transform resultObj;
	private AudioSource nextButtonAudio;
	QuestionController qc;
	public SpriteRenderer overlay;

	// Use this for initialization
	void Start () {
		if (qc == null)
			qc = GameObject.FindObjectOfType (typeof(QuestionController)) as QuestionController; 
		
		if (nextButtonAudio == null)
			nextButtonAudio = GetComponent <AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {

		nextButtonAudio.Play ();
		int counter = GameController.instance.GetQuestionCounter ();

		// Only allow the player to click next if they have picked an answer
		if (AnswerWithMouse.lockAnswer == true) {	
			int segment = GameController.instance.questionsPerHouse;

			// Change to another question and
			// limit the counter within the question array
			if (counter <= Questions.qa.GetLength (0)) {
				GameController.instance.IncrementQuestionCounter ();
				Debug.Log ("count in NextButton: " + counter);

				// When it's the nth question, change the next button text
				if (counter %  segment == 0) {
					GetComponent<TextMesh> ().text = "Finish";
				}

				// Once it's the last question for the current trigger, change the scene
				if (counter % segment == 0) {
					StartCoroutine (FadeToBlack());

				}
			}
		}

		AnswerWithMouse.lockAnswer = false;

		// Reset result text, answer text and colors
		resultObj.GetComponent<TextMesh> ().text = "Pick an answer";	
		qc.ResetAnswerColors (qc.ans1, Color.white, 30);
		qc.ResetAnswerColors (qc.ans2, Color.white, 30);
		qc.ResetAnswerColors (qc.ans3, Color.white, 30);
		qc.ResetAnswerColors (qc.ans4, Color.white, 30);
	}

	// Fade to black before loading the next scene
	public IEnumerator FadeToBlack() {
		overlay.gameObject.SetActive (true);
		overlay.color = Color.clear;

		float rate = 1.0f / 1.2f;
		float progress = 0.0f;

		while (progress < 1.0f) {
			overlay.color = Color.Lerp (Color.clear, Color.black, progress);
			progress += rate * Time.deltaTime;
			yield return null;
		}

		overlay.color = Color.black;
		SceneManager.LoadScene ("walkingThroughHouse");		
		}
}
