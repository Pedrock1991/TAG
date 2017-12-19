using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LowLivesWindowManager : MonoBehaviour {

	public GameObject male;
	public GameObject female;
	bool genre = false;
	public GameObject shopWindow;

	void Update () {
		if (!genre) {
			if (GameManager.instance.GetGenreMale ()) {
				male.SetActive (true);
				female.SetActive (false);
				genre = true;
			}
			if (GameManager.instance.GetGenreFemale ()) {
				male.SetActive (false);
				female.SetActive (true);
				genre = true;
			}
		}
	}

	public void BackToMenu () {
		GameManager.instance.SetLoadingScene ("PlanetMenu");
		GameObject.Find("Audio Source").GetComponent<AudioSource> ().Stop();
		GameObject.Find("Audio Source").GetComponent<AudioSource> ().Play();
		Time.timeScale = 1;
		SceneManager.LoadScene ("LoadingScreen");
	}

	public void Buy () {
		if (GameManager.instance.GetGoldCoins () > 10) {
			GameManager.instance.SetGoldCoins (-10);
			GameManager.instance.SetLives (1);
			GameObject.Find ("LowLiveWindow").SetActive (false);
		} else {
			shopWindow.SetActive (true);
		}
	}
}
