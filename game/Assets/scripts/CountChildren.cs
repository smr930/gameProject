using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CountChildren : MonoBehaviour {
	Transform[] children;
	public static int count = 0;


	void Start() {
		children = gameObject.GetComponentsInChildren<Transform> ();

		foreach(Transform child in children) {
			count++;
		}

		Debug.Log ("trigger count: " + count);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
