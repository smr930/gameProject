using UnityEngine;
using System.Collections;

public class HighlightText : MonoBehaviour {

	public Color mouseOverColor = Color.green;
	public Color mouseExitColor = Color.white;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() {

		GetComponent<TextMesh> ().color = mouseOverColor;
		GetComponent<TextMesh> ().fontSize = 46;
	}

	void OnMouseExit() {

		GetComponent<TextMesh> ().color = mouseExitColor;
		GetComponent<TextMesh> ().fontSize = 36;
	}
}
