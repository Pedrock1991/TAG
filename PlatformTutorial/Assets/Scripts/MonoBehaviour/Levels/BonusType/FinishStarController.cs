using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStarController : MonoBehaviour {

	private float rotSpeed = 60.0f;
	private AudioSource theSound;
	private bool taked;
	private LevelManager LM;
	public AudioClip winSound;
	public GameObject winWindow;
	
	void Update () {
		transform.Rotate (0, Time.deltaTime * rotSpeed, 0, Space.World);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if(col.CompareTag("Player")) {
			theSound = GetComponent <AudioSource> ();
			LM = FindObjectOfType <LevelManager> ();
			if (!taked) {
				Destroy(gameObject, winSound.length/2);
				theSound.PlayOneShot (winSound);
				taked = true;
				LM.gameStarted = false;
				Time.timeScale = 0;
				winWindow.SetActive (true);
			}
		}
	}
}
