using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public string playerName;
	public int score;
	public float musicVolume;
	public bool JIT;



	public static GameControl Instance;

	// Use this for initialization
	void Start () {
		playerName = "";
		score = 0;
		musicVolume = 1f;
		JIT = true;
	}

	void Awake()
	{
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	public void setToZero() {
		playerName = "";
		score = 0;
		JIT = true;
	}

	public void setScore(int s)
	{
		score = s;
	}

	public int getScore()
	{
		return score;
	}

	public void increaseScore (int a)
	{
		score += a;
	}

	public void setName (string n)
	{
		playerName = n;
	}

	public string getName()
	{
		return playerName;
	}

	public void getmusicVolume (AudioSource audio)
	{
		audio.volume = musicVolume;
	}

	public void setJIT() {
		JIT = false;
	}
}

