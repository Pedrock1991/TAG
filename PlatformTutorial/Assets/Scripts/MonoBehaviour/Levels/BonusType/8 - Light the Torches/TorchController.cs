using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour {

	private GameManager8 GM;
	private bool lightOn = false;

	public GameObject on;
	public GameObject off;
	public SpriteRenderer dark;

	private AudioSource theSound;
	
	void Start () {
		GM = FindObjectOfType <GameManager8> ();
		theSound = GameObject.Find("Audio Source").GetComponent <AudioSource> ();
		on.SetActive (false);
	}
	
	void Update () {
		if (lightOn) {
			on.SetActive (true);
			theSound.PlayOneShot (SoundManager.bonusType8TorchSound);
			off.SetActive (false);
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if(col.CompareTag("Player")) {
			if (InteractButton.instance.IsInteract ()) {
				if (!lightOn) {
					GM.numberOfTorchs--;
					dark.color = new Color (dark.color.r, dark.color.g, dark.color.b, dark.color.a - (dark.color.a / (GM.torchs.Length*2)));
					lightOn = true;
				}
			}
		}
	}
}
