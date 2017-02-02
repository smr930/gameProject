using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManualScript : MonoBehaviour {

	private ButtonBehaviorLv01 buttonScript;
	public Canvas manual;

	public Button cancerBasics;
	public Button stepsIncancer;
	public Button signs;
	public Button stages;
	public Button classification;
	public Button treatment;
	public Button genetics;
	public Button statistics;

	public Button returnToGame;

	public Text cancerBasicsText;
	public Text stepsInCancerText;
	public Text signsText;
	public Text stagesText;
	public Text classificationText;
	public Text treatmentText;
	public Text geneticsText;
	public Text statisticsText;

	public Text iButton;



	// Use this for initialization
	void Start () {

		buttonScript = GetComponent<ButtonBehaviorLv01> ();
		cancerBasics = cancerBasics.GetComponent<Button> ();
		stepsIncancer = stepsIncancer.GetComponent<Button> ();
		returnToGame = returnToGame.GetComponent<Button> ();
		signs = signs.GetComponent<Button> ();
		stages = stages.GetComponent<Button> ();
		classification = classification.GetComponent<Button> ();
		treatment = treatment.GetComponent<Button> ();
		genetics = genetics.GetComponent<Button> ();
		statistics = statistics.GetComponent<Button> ();
		signsText = signsText.GetComponent<Text> ();
		stagesText = stagesText.GetComponent<Text> ();
		classificationText = classificationText.GetComponent<Text> ();
		treatmentText = treatmentText.GetComponent<Text> ();
		geneticsText = geneticsText.GetComponent<Text> ();
		statisticsText = statisticsText.GetComponent<Text> ();
		cancerBasicsText = cancerBasicsText.GetComponent<Text> ();
		stepsInCancerText = stepsInCancerText.GetComponent<Text> ();

		iButton = iButton.GetComponent <Text> ();

		manual = GetComponentInChildren<Canvas> ();
		manual.enabled = false;

		DisableText (cancerBasicsText);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.I) && !IsPaused ()) {
			manual.enabled = true;
			buttonScript.PauseGame ();
			DisableText (iButton);
		} 

		else if (Input.GetKeyDown (KeyCode.I) && IsPaused ()) {
			manual.enabled = false;
			buttonScript.ResumeGame ();
			EnableText (iButton);
		}
	}

	public bool IsPaused() {
		if (manual.enabled == true)
			return true;
		else
			return false;
	}

	public void EnableText (Text t) {
		t.GetComponent<Text> ().enabled = true;
	}
	public void DisableText(Text t) {
		t.GetComponent<Text> ().enabled = false;
	}
		
	/// <summary>
	/// DIfferent Buttons Functions 
	/// </summary>

	public void LoadCancerBasics() {

		DisableAllTexts ();
		EnableText (cancerBasicsText);
	}

	public void LoadStepsInCancer() {

		DisableAllTexts ();
		EnableText (stepsInCancerText);
	}

	public void LoadSignsNSymptoms() {

		DisableAllTexts ();
		EnableText (signsText);
	}
	public void LoadStagesText() {
		
		DisableAllTexts ();
		EnableText (stagesText);
	}
	public void LoadClassification() {
		
		DisableAllTexts ();
		EnableText (classificationText);
	}
	public void LoadTreatment() {

		DisableAllTexts ();
		EnableText (treatmentText);
	}
	public void LoadGenetics() {

		DisableAllTexts ();
		EnableText (geneticsText);
	}
	public void LoadStatistic() {

		DisableAllTexts ();
		EnableText(statisticsText);
	}
		

	public void ReturnToGame() {

		manual.enabled = false;
		buttonScript.ResumeGame ();
		EnableText (iButton);
	}

	public void DisableAllTexts() {
		
		DisableText (stepsInCancerText);
		DisableText (cancerBasicsText);
		DisableText (signsText);
		DisableText (stagesText);
		DisableText (classificationText);
		DisableText (treatmentText);
		DisableText (geneticsText);
		DisableText (statisticsText);
	}

}
