using UnityEngine;
using System.Collections;

public class volume : MonoBehaviour {
	public AudioSource musicSource;

	// Use this for initialization
	void Start () {
		musicSource = GetComponent<AudioSource> ();
		GameControl.Instance.getmusicVolume(musicSource);


	}
	
	// Update is called once per frame
	void Update () {
	}
}
