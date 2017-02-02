using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextMovingScriptGameOver : MonoBehaviour {

	private RectTransform textPosition;
	public float speed;

	// Use this for initialization
	void Start () {
		if (textPosition == null)
		textPosition = GetComponent<RectTransform> ();

	
	}
	
	// Update is called once per frame
	void Update () {

		if(textPosition.position.y < 110 )
		textPosition.Translate (0, 1 * speed, 0);

		else if ((textPosition.position.y >= 110) || Input.GetKeyDown ("space")){
			textPosition.Translate (0, -1 * speed, 0);
		}

		else if (Input.GetKeyDown (KeyCode.Escape))  
		{
			SceneManager.LoadScene ("startMenu");
		}
	
	}

	void LoadMenu()
	{
		SceneManager.LoadScene ("startMenu");
	}
}
