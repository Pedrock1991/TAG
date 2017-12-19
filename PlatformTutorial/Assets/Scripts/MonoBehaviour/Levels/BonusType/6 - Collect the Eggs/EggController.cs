using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour {

	private GameManager6 GM;
	private bool taked;

	private AudioSource theSound;
	public AudioClip eggPickSound;

	void Start () {
		GM = FindObjectOfType <GameManager6> ();
		theSound = GameObject.Find("Audio Source").GetComponent <AudioSource> ();
	}
	
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D col) {
		if(col.CompareTag("Player")) {
			if (InteractButton.instance.IsInteract ()) {
				if (!taked) {
					GM.numberOfEggs--;
					Destroy(gameObject, SoundManager.bonusType6EggPickSound.length/2);
					theSound.PlayOneShot (SoundManager.bonusType6EggPickSound);
					taked = true;
				}
			}
		}
	}
}
