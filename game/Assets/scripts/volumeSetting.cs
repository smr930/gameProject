using UnityEngine;
using System.Collections;

public class volumeSetting : MonoBehaviour {

	public AudioSource musicSource;

	// Use this for initialization
	void Start () {
		musicSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		GameControl.Instance.getmusicVolume(musicSource);

	}
}
