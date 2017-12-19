using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour {

	public int gemNumber;
	private InventoryManager IM;
	private AudioSource theSound;

	void Start () {
		theSound = GameObject.Find("Audio Source").GetComponent <AudioSource> ();
	}

	void OnTriggerStay2D (Collider2D col) {
		if(col.CompareTag("Player")) {
			IM = FindObjectOfType <InventoryManager> ();
			if (InteractButton.instance.IsInteract ()) {
				if (IM.slot) {
					Destroy(gameObject, SoundManager.bonusType2GemSound.length/2);
					theSound.PlayOneShot (SoundManager.bonusType2GemSound);
					IM.slot = false;
					IM.itemNumber = gemNumber;
				}
			}
		}
	}
}
