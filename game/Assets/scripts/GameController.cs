/*
 *  This script will hold variables and fuctions, that will
 *  hold their value throughout the game. This can be useful
 *  when we are changing scenes and we want to pass any data
 *  between the scenes.
*/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private int correctAns = 0;
	private bool[] isTriggerUsed = new bool[11];
	private int questionCounter = 1;
	public int questionsPerHouse = 3; 
	private bool countdown = false;
	GameObject player;
	Vector2 playerPos;
	GameObject enemy;
	Vector2 enemyPos;
	public Vector2 playerStartPos;
	public Vector2 enemyStartPos;
	public float playerHealth = 100;
	bool debuggingGame = false; // Set this to false on final build
	public bool JIT;
	public int tempCorrectAns;

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
		JIT = true;
		playerStartPos = playerPos;
		enemyStartPos = enemyPos;



	}

	void Update () {
		if (IsDebugging()) {
			if (Input.GetKeyDown (KeyCode.Alpha1))
				SceneManager.LoadScene ("level01");

			if (Input.GetKeyDown (KeyCode.Alpha2))
				SceneManager.LoadScene ("QA_scene");
		}
	}

	public bool IsDebugging() {
		return debuggingGame;
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

	public int GetQuestionCounter() {
		return questionCounter;
	}

	public void IncrementQuestionCounter() {
		if (questionCounter >= 33)
			questionCounter = 1;
		else
			questionCounter++;
	}

	/////////////////////////////////////////////
	//		Score Methods
	/////////////////////////////////////////////

	public void IncreaseScore() {
		correctAns++;
	}

	public int GetNumberOfQuestions () {
		return Questions.qa.GetLength (0) - 1;
	}

	public int GetCorrectAnswerCount() {
		return correctAns;
	}

	public double GetScorePercentage() {
		return GetCorrectAnswerCount() / GetNumberOfQuestions ();
	}

	/////////////////////////////////////////////
	//		UI Methods
	/////////////////////////////////////////////

	public bool isCountdownPlaying() {
		return countdown;
	}

	public void SetCountdownActive(bool toggle) {
		countdown = toggle;
	}

	/////////////////////////////////////////////
	//		Data Persistent Methods
	/////////////////////////////////////////////

	public void SaveData (string str) {
		switch(str) {
		case "Player":
			if (player == null)
				player = GameObject.Find (str);
			
			tempCorrectAns = correctAns;
			playerPos = player.transform.position;
			break;

		case "Enemy":
			if (enemy == null)
				enemy = GameObject.Find (str);

			enemyPos = enemy.transform.position;
			break;

		}

	}

	public void LoadData (string str) {
		switch(str) {
		case "Player":
			if (player == null)
				player = GameObject.Find (str);

			playerPos = playerPos + new Vector2 (0, 10f);
			player.transform.position = playerPos;
			break;

		case "Enemy":
			if (enemy == null)
				enemy = GameObject.Find (str);

			int temp = correctAns - tempCorrectAns;
			enemyPos = enemyPos - new Vector2 (0, -1f * temp);
			enemy.transform.position = enemyPos;
			break;

		}

	}

	public void setJIT() {
		JIT = false;
	}

	public void setToZero() {
		correctAns = 0;
		isTriggerUsed = new bool[11];
		questionCounter = 1;
		questionsPerHouse = 3; 
		countdown = false;
		playerHealth = 100;
		JIT = true;
		enemyPos = enemyStartPos;
		playerPos = playerStartPos;
	}

	public void lv1to2() {
		playerHealth = 100;
		enemyPos = enemyStartPos;
		playerPos = playerStartPos;
	}
}
