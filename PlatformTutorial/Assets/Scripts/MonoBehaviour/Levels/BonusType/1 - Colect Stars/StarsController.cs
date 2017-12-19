using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour {

	private GameManager1 GM;
	private float rotSpeed = 60.0f;
	private AudioSource theSound;
	private bool taked;

	void Start () {
		theSound = GameObject.Find("Audio Source").GetComponent <AudioSource> ();
	}

	void Update () {
		transform.Rotate (0, Time.deltaTime * rotSpeed, 0, Space.World);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if(col.CompareTag("Player")) {
			GM = FindObjectOfType <GameManager1> ();
			if (!taked) {
				Destroy(gameObject, SoundManager.bonusType1StarSound.length/2);
				theSound.PlayOneShot (SoundManager.bonusType1StarSound);
				GM.numberOfStars--;
				taked = true;
			}
		}
	}
}
