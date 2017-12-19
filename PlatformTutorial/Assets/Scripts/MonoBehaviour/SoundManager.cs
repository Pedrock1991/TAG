using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioClip musicPlanetMenu,
	musicPlanet1Galaxy1,
	musicPlanet2Galaxy1,
	musicPlanet3Galaxy1,
	musicPlanet4Galaxy1,
	musicPlanet5Galaxy1,
	musicPlanet6Galaxy1,
	//Bonus Sounds
	bonusType1StarSound,
	bonusType2GemSound,
	bonusType2GemSlotSound,
	bonusType3DarkMatter,
	bonusType5BlueLightSound,
	bonusType5RedLightSound,
	bonusType5GreenLightSound,
	bonusType5YellowLightSound,
	bonusType5CorrectSound,
	bonusType6EggPickSound,
	bonusType8TorchSound,
	bonusType9FlagSound;
	


	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
		musicPlanetMenu = Resources.Load<AudioClip>("Audio/Music/Happy Loop");
		musicPlanet1Galaxy1 = Resources.Load<AudioClip>("Audio/Music/Digital Kid Loop");
		musicPlanet2Galaxy1 = Resources.Load<AudioClip>("Audio/Music/Indie Kid");
		musicPlanet3Galaxy1 = Resources.Load<AudioClip>("Audio/Music/Pacific Paradise");
		musicPlanet4Galaxy1 = Resources.Load<AudioClip>("Audio/Music/HallowBlood");
		musicPlanet5Galaxy1 = Resources.Load<AudioClip>("Audio/Music/Jambalaya Loop");
		musicPlanet6Galaxy1 = Resources.Load<AudioClip>("Audio/Music/Angels we have heard");
		bonusType1StarSound = Resources.Load<AudioClip>("Audio/BonusSounds/1 - Colect Stars/Star");
		bonusType2GemSound = Resources.Load<AudioClip>("Audio/BonusSounds/2 - Find the Gem/Gem Pick");
		bonusType2GemSlotSound = Resources.Load<AudioClip>("Audio/BonusSounds/2 - Find the Gem/Gem Slot");
		bonusType3DarkMatter = Resources.Load<AudioClip>("Audio/BonusSounds/3 - Grab 15 Black Matter/Dark Matter");
		bonusType5BlueLightSound = Resources.Load<AudioClip>("Audio/BonusSounds/5 - Remember the Order/Blue");
		bonusType5RedLightSound = Resources.Load<AudioClip>("Audio/BonusSounds/5 - Remember the Order/Red");
		bonusType5GreenLightSound = Resources.Load<AudioClip>("Audio/BonusSounds/5 - Remember the Order/Green");
		bonusType5YellowLightSound = Resources.Load<AudioClip>("Audio/BonusSounds/5 - Remember the Order/Yellow");
		bonusType5CorrectSound = Resources.Load<AudioClip>("Audio/BonusSounds/5 - Remember the Order/Correct");
		bonusType6EggPickSound = Resources.Load<AudioClip>("Audio/BonusSounds/6 - Collect the Eggs/Egg Pick");
		bonusType8TorchSound = Resources.Load<AudioClip>("Audio/BonusSounds/8 - Light the Torches/Torch");
		bonusType9FlagSound = Resources.Load<AudioClip>("Audio/BonusSounds/9 - Pull up the Flags/Flag");

		audioSrc = GetComponent<AudioSource> ();
	}

	public static void PlaySound (string clip) {
		switch (clip) {
		case "PlanetMenu":
			audioSrc.PlayOneShot (musicPlanetMenu);
			break;
		case "Planet 1":
			audioSrc.PlayOneShot (musicPlanet1Galaxy1);
			break;
		case "Planet 2":
			audioSrc.PlayOneShot (musicPlanet2Galaxy1);
			break;
		case "Planet 3":
			audioSrc.PlayOneShot (musicPlanet3Galaxy1);
			break;
		case "Planet 4":
			audioSrc.PlayOneShot (musicPlanet4Galaxy1);
			break;
		case "Planet 5":
			audioSrc.PlayOneShot (musicPlanet5Galaxy1);
			break;
		case "Planet 6":
			audioSrc.PlayOneShot (musicPlanet6Galaxy1);
			break;
		}
	}
}
