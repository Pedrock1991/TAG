using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlanetManager : MonoBehaviour {

	public Character character;
	public Pin startPin;
	public Text selectedLevelText;
	public VirtualJoystick joystick;
	public GameObject levelWindow;

	Scene activePart;
	Scene activePlanet;
	GameObject level;
	GameObject audioSource;
	AudioSource audioSrc;
	bool levelComplete;

	void Start () {
		character = GameObject.Find ("Character").GetComponent <Character> ();
		selectedLevelText = GameObject.Find ("LevelSelect").GetComponent <Text> ();
		joystick = GameObject.Find ("Joystick").GetComponent <VirtualJoystick> ();
		levelWindow = GameObject.Find ("LevelWindow");

		activePart = SceneManager.GetActiveScene ();
		activePlanet = SceneManager.GetActiveScene (); 
		levelWindow = GameObject.Find ("LevelWindow");
		levelWindow.SetActive (false);
		VerifyLevel ();	
		if (GameManager.instance.GetStartPin (int.Parse (activePart.name.Substring(7,1)), int.Parse (activePart.name.Substring(18,1))) == null) {
			character.Initialise (this, startPin);
		} else {
			character.Initialise (this, GameObject.Find (GameManager.instance.GetStartPin(int.Parse (activePart.name.Substring(7,1)), int.Parse (activePart.name.Substring(18,1)))).GetComponent<Pin> ());
		}
		GameManager.instance.SetGalaxy1LevelCompleted (int.Parse (activePlanet.name.Substring(7,1)), 1);
		ChangeMusic ();
	}
	
	void Update () {
		if (character.isMoving)
			return;

		VerifyMovement ();
		ChangePin ();
	}
	void ChangePin () {
		if (GameManager.instance.GetStartPin (int.Parse (activePart.name.Substring(7,1)), int.Parse (activePart.name.Substring(18,1))) == null) {
			GameManager.instance.SetStartPin (int.Parse (activePart.name.Substring(7,1)), int.Parse (activePart.name.Substring(18,1)), GameObject.Find ("StartPin").name);
		} else {
			GameManager.instance.SetStartPin (int.Parse (activePart.name.Substring(7,1)), int.Parse (activePart.name.Substring(18,1)), character.currentPin.name);
		}
	}
	public void ChangeMusic () { //ADD SONG CHECK VARIABLE
		audioSource = GameObject.Find("Audio Source");
		audioSrc = audioSource.GetComponent<AudioSource> ();
		audioSrc.Stop ();

		switch(GameManager.instance.GetSelectedGalaxy()){
			case 1:
				switch(int.Parse(activePlanet.name.Substring(7,1))) {
					case 1:
						//audioSrc.PlayOneShot(SoundManager.musicPlanet1Galaxy1);
						audioSrc.clip = SoundManager.musicPlanet1Galaxy1;
						audioSrc.Play ();
						break;
					case 2:
						//audioSrc.PlayOneShot(SoundManager.musicPlanet2Galaxy1);
						audioSrc.clip = SoundManager.musicPlanet2Galaxy1;
						audioSrc.Play ();
						break;
					case 3:
						//audioSrc.PlayOneShot(SoundManager.musicPlanet3Galaxy1);
						audioSrc.clip = SoundManager.musicPlanet3Galaxy1;
						audioSrc.Play ();
						break;
					case 4:
						//audioSrc.PlayOneShot(SoundManager.musicPlanet4Galaxy1);
						audioSrc.clip = SoundManager.musicPlanet4Galaxy1;
						audioSrc.Play ();
						break;
					case 5:
						//audioSrc.PlayOneShot(SoundManager.musicPlanet5Galaxy1);
						audioSrc.clip = SoundManager.musicPlanet5Galaxy1;
						audioSrc.Play ();
						break;
					case 6:
						//audioSrc.PlayOneShot(SoundManager.musicPlanet6Galaxy1);
						audioSrc.clip = SoundManager.musicPlanet6Galaxy1;
						audioSrc.Play ();
						break;
				}
				break;
		}
		
	}

	public void ReturnPlanetMenu () {
		GameManager.instance.SetLoadingScene ("PlanetMenu");
		audioSrc.Stop();
		audioSrc.clip = SoundManager.musicPlanetMenu;
		audioSrc.Play();
		SceneManager.LoadScene ("LoadingScreen");
	}

	private void CheckForInput () {
		Vector3 dir = Vector3.zero;

		dir.x = joystick.Horizontal ();
		dir.y = joystick.Vertical ();

		if (dir.y > 0.8 && dir.y < 1.0) { // Up
			character.TrySetDirection (Direction.Up);
		} else if (dir.y < -0.8 && dir.y > -1.0) { // Down
			character.TrySetDirection (Direction.Down);
		} else if (dir.x < -0.8 && dir.x > -1.0) { // Left
			character.TrySetDirection (Direction.Left);
		} else if (dir.x > 0.8 && dir.x < 1.0) { // Right
			character.TrySetDirection (Direction.Right);
		}
	}

	public void UpdateGui () {
		selectedLevelText.text = string.Format(character.currentPin.SceneToLoad);
	}

	public void LoadScene () {
		if(character.currentPin.SceneToLoad.Substring (0, 1) == "P") {
			GameManager.instance.SetLoadingScene (character.currentPin.SceneToLoad);
			SceneManager.LoadScene ("LoadingScreen");
		} else {
			levelWindow.SetActive (true);
			ChangePin ();
		}
	}

	void VerifyLevel () {
		Color alphaColor;

		for (int i = 1; i <= 285; i++) { //Planet 1 285 Levels
			if (GameManager.instance.GetGalaxy1Level (1 , i)){
				level = GameObject.Find("Level (" + i + ")");
				alphaColor = level.GetComponent<SpriteRenderer> ().color;
				alphaColor.a = 1.0f;
				level.GetComponent<SpriteRenderer> ().color = alphaColor;
			}
		}
	}

	void VerifyMovement () {
		Vector3 dir = Vector3.zero;

		dir.x = joystick.Horizontal ();
		dir.y = joystick.Vertical ();

		if (dir.y > 0.8 && dir.y < 1.0) { // Up
			var pin = character.currentPin.GetPinInDirection (Direction.Up);
			if (pin != null) {
				if (pin.SceneToLoad.Equals("PlanetMenu")) {
					character.TrySetDirection (Direction.Up);
				} else {
					if (GameManager.instance.GetGalaxy1Level(int.Parse (pin.SceneToLoad.Substring (0,1)), int.Parse (pin.SceneToLoad.Substring (2)))) {
						character.TrySetDirection (Direction.Up);
					}
				}
			}
		} else if (dir.y < -0.8 && dir.y > -1.0) { // Down
			var pin = character.currentPin.GetPinInDirection (Direction.Down);
			if (pin != null) {
				if (pin.SceneToLoad.Equals("PlanetMenu")) {
					character.TrySetDirection (Direction.Down);
				} else {
					if (GameManager.instance.GetGalaxy1Level(int.Parse (pin.SceneToLoad.Substring (0,1)), int.Parse (pin.SceneToLoad.Substring (2)))) {
						character.TrySetDirection (Direction.Down);
					}
				}
			}
		} else if (dir.x < -0.8 && dir.x > -1.0) { // Left
			var pin = character.currentPin.GetPinInDirection (Direction.Left);
			if (pin != null) {
				if (pin.SceneToLoad.Equals("PlanetMenu")) {
					character.TrySetDirection (Direction.Left);
				} else {
					if (GameManager.instance.GetGalaxy1Level(int.Parse (pin.SceneToLoad.Substring (0,1)), int.Parse (pin.SceneToLoad.Substring (2)))) {
						character.TrySetDirection (Direction.Left);
					}
				}
			}
		} else if (dir.x > 0.8 && dir.x < 1.0) { // Right
			var pin = character.currentPin.GetPinInDirection (Direction.Right);
			if (pin != null) {
				if (pin.SceneToLoad.Equals("PlanetMenu")) {
					character.TrySetDirection (Direction.Right);
				} else {
					if (GameManager.instance.GetGalaxy1Level(int.Parse (pin.SceneToLoad.Substring (0,1)), int.Parse (pin.SceneToLoad.Substring (2)))) {
						character.TrySetDirection (Direction.Right);
					}
				}
			}
		}
	}
}
