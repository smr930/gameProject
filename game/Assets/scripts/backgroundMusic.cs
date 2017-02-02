using UnityEngine;
using System.Collections;

public class backgroundMusic : MonoBehaviour {
	private AudioSource backgroundAudio;

	void Start () {
		backgroundAudio = GetComponent<AudioSource> ();
	}

	public void muteAudio() {
		backgroundAudio.mute = true;
	}

	public void unmuteAudio() {
		backgroundAudio.mute = false;
	}
}
