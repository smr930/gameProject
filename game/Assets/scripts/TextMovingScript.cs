using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextMovingScript : MonoBehaviour {

	private RectTransform textPosition;
	public float speed;

	// Use this for initialization
	void Start () {
		if (textPosition == null)
		textPosition = GetComponent<RectTransform> ();

	
	}
	
	// Update is called once per frame
	void Update () {

		textPosition.Translate (0, 1 * speed, 0);

		if ((textPosition.position.y >= 1240) || Input.GetKeyDown ("space"))
			LoadGame ();
		else if (Input.GetKeyDown (KeyCode.Escape))  
		{
			SceneManager.LoadScene ("startMenu");
		}
	
	}

	void LoadGame()
	{
		SceneManager.LoadScene ("level01");
	}
}
