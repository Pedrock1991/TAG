using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour {

	private GameManager9 GM;
	private bool taked;

	private Animator anim;
	private AudioSource theSound;
	public AudioClip flagSound;

	private float downTime;
	private bool upFlag;
	private bool midFlag;
	private bool downFlag;

	void Start () {
		GM = FindObjectOfType <GameManager9> ();
		theSound = GetComponent <AudioSource> ();
		anim = gameObject.GetComponent <Animator> ();
		downFlag = true;
	}
	
	void Update () {
		if (upFlag) {
			anim.SetBool ("Up", true);
			anim.SetBool ("Mid", false);
			anim.SetBool ("Down", false);
		}

		if (midFlag) {
			anim.SetBool ("Up", false);
			anim.SetBool ("Mid", true);
			anim.SetBool ("Down", false);
		}

		if (downFlag) {
			anim.SetBool ("Up", false);
			anim.SetBool ("Mid", false);
			anim.SetBool ("Down", true);
		}

		if (downTime > 0) {
			downTime -= Time.deltaTime;
		} else {
			if (midFlag) {
				upFlag = false;
				midFlag = false;
				downFlag = true;
				taked = false;
				GM.numberOfFlags++;
				theSound.Stop ();
			}
			if (upFlag) {
				upFlag = false;
				midFlag = true;
				downFlag = false;
				downTime = GM.flagTime;
			}
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if(col.CompareTag("Player")) {
			if (InteractButton.instance.IsInteract ()) {
				if (!taked) {
					upFlag = true;
					midFlag = false;
					downFlag = false;
					downTime = GM.flagTime;
					GM.numberOfFlags--;
					taked = true;
					theSound.Play ();
				}
			}
		}
	}
}
