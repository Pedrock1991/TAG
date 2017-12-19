using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMatterController : MonoBehaviour {

	private GameManager3 GM;
	private float rotSpeed = 200.0f;
	private AudioSource theSound;
	public bool taked;

	void OnEnable () {
		taked = false;
	}

	void Start () {
		theSound = GameObject.Find("Audio Source").GetComponent <AudioSource> ();
		GM = FindObjectOfType <GameManager3> ();
		theSound.PlayOneShot (SoundManager.bonusType3DarkMatter);
	}
	
	void Update () {
		transform.Rotate (0, 0, -Time.deltaTime * rotSpeed, Space.World);
		if (taked) {
			transform.gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if(col.CompareTag("Player")) {
			if (!taked) {
				theSound.PlayOneShot (SoundManager.bonusType3DarkMatter);
				GM.numberOfDarkMatter--;
				GM.change = true;
				taked = true;
			}
		}
	}
}
