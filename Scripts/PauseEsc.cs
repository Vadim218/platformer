using UnityEngine;
using System.Collections;

public class PauseEsc : MonoBehaviour {
	private bool paused = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!paused) {
				Time.timeScale = 0;
				paused = true;

			} else {
				Time.timeScale = 1;
				paused = false;

			}
		}
	}
}
