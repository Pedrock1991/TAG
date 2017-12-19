using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioClip interferenceBelt,
							power1, power2, power3, power4, power5,
	probeLaunch, probeMovementGreen, probeMovementRed, probeMovementYellow, probeMovementBlue,
	button, purchaseAccept, purchaseDenied, beltDestroy;

	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
		interferenceBelt = Resources.Load<AudioClip> ("Interference Belt Alert");
		power1 = Resources.Load<AudioClip> ("Power 1 - Quick Probe");
		power2 = Resources.Load<AudioClip> ("Power 2 - Probe Supercharge");
		power3 = Resources.Load<AudioClip> ("Power 3 - Factory Supercharge");
		power4 = Resources.Load<AudioClip> ("Power 4 - Tap Stack Chance");
		power5 = Resources.Load<AudioClip> ("Power 5 - Tap Supercharge");
		probeLaunch = Resources.Load<AudioClip> ("Probe Launch");
		probeMovementBlue = Resources.Load<AudioClip> ("Probe Movement- Blue");
		probeMovementGreen = Resources.Load<AudioClip> ("Probe Movement- Green");
		probeMovementRed = Resources.Load<AudioClip> ("Probe Movement - Red");
		probeMovementYellow = Resources.Load<AudioClip> ("Probe Movement - Yellow");
		button = Resources.Load<AudioClip> ("Menu-Power Button");
		purchaseAccept = Resources.Load<AudioClip> ("Purchase Accept");
		purchaseDenied = Resources.Load<AudioClip> ("Purchase Denied");
		beltDestroy = Resources.Load<AudioClip> ("Belt Destroy"); 


		audioSrc = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void PlaySound (string clip) {
		switch (clip) {
		case "belt":
			audioSrc.PlayOneShot (interferenceBelt);
			break;
		case "power1":
			audioSrc.PlayOneShot (power1);
			break;
		case "power2":
			audioSrc.PlayOneShot (power2);
			break;
		case "power3":
			audioSrc.PlayOneShot (power3);
			break;
		case "power4":
			audioSrc.PlayOneShot (power4);
			break;
		case "power5":
			audioSrc.PlayOneShot (power5);
			break;
		case "probeLaunch":
			audioSrc.PlayOneShot (probeLaunch);
			break;
		case "blueMove":
			audioSrc.PlayOneShot (probeMovementBlue);
			break;
		case "greenMove":
			audioSrc.PlayOneShot (probeMovementGreen);
			break;
		case "redMove":
			audioSrc.PlayOneShot (probeMovementRed);
			break;
		case "yellowMove":
			audioSrc.PlayOneShot (probeMovementYellow);
			break;
		case "button":
			audioSrc.PlayOneShot (button);
			break;
		case "purchaseAccept":
			audioSrc.PlayOneShot (purchaseAccept);
			break;
		case "purchaseDenied":
			audioSrc.PlayOneShot (purchaseDenied);
			break;
		case "beltDestroy":
			audioSrc.PlayOneShot (beltDestroy);
			break;
		}
	}
}
