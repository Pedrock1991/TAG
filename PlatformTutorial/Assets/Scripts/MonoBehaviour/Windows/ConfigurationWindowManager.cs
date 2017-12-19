using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfigurationWindowManager : MonoBehaviour {

	public Text equipName;
	public GameObject SoundOn;
	public GameObject SoundOff;
	public GameObject NotificationOn;
	public GameObject NotificationOff;
	public bool changeLanguage;
	LocalizationManager localizationManager;

	void Start () {
		equipName.text = GameManager.instance.GetTeamName ().ToString ();
		VerifySound ();
		VerifyNotification ();
	}

	
	public void ConfirmConfiguration () {
		if (changeLanguage) {
			localizationManager = GameObject.Find ("LocalizationManager").GetComponent <LocalizationManager> ();
			localizationManager.LoadLocalizedText (GameManager.instance.GetLocalization ());
			SceneManager.LoadScene(SceneManager.GetActiveScene ().name);
		}
	}

	public void TurnLanguage () {
		changeLanguage = true;
	}
	void VerifyNotification () {
		if (GameManager.instance.GetNotificationGame ()) {
			NotificationOn.SetActive (true);
			NotificationOff.SetActive (false);
		} else {
			NotificationOn.SetActive (false);
			NotificationOff.SetActive (true);
		}
	}
	public void TurnNotificationOn () {
		GameManager.instance.SetNotificationGame (true);
	}
	public void TurnNotificationOff () {
		GameManager.instance.SetNotificationGame (false);
	}

	void VerifySound () {
		if (GameManager.instance.GetSoundGame ()) {
			SoundOn.SetActive (true);
			SoundOff.SetActive (false);
		} else {
			SoundOn.SetActive (false);
			SoundOff.SetActive (true);
		}
	}
	public void TurnSoundOn () {
		GameManager.instance.SetSoundGame (true);
		GameObject.Find ("Audio Source").GetComponent <AudioSource> ().mute = false;
	}
	public void TurnSoundOff () {
		GameManager.instance.SetSoundGame (false);
		GameObject.Find ("Audio Source").GetComponent <AudioSource> ().mute = true;
	}

	public void ChangeEquipName (InputField name) {
		GameManager.instance.SetTeamName (name);
		equipName.text = GameManager.instance.GetTeamName ().ToString ();
	}
}
