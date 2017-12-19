using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

	private SpriteRenderer theSprite;
	private float stayLitCounter = 0;
	private bool oneClick = true;

	public int thisLightNumber;

	private GameManager5 GM;

	private AudioSource theSound;

	void Start () {
		theSprite = GetComponent <SpriteRenderer> ();
		GM = FindObjectOfType <GameManager5> ();
		theSound = GetComponent <AudioSource> ();
	}
	
	void Update () {
		if (stayLitCounter > 0) {
			stayLitCounter -= Time.deltaTime;
		} else {
			theSprite.color = new Color (theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.5f);
			oneClick = true;
			theSound.Stop ();
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("Player")) {
			if (InteractButton.instance.IsInteract ()) {
				if (oneClick) {
					theSprite.color = new Color (theSprite.color.r, theSprite.color.g, theSprite.color.b, 1f);
					GM.ColourPressed (thisLightNumber);
					stayLitCounter = 0.25f;
					oneClick = false;
					theSound.Play ();
				}
			}
		}
	}
}
