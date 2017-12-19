using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseWindowManager : MonoBehaviour {

	public GameObject tryAgain;

	void Awake () {
		Time.timeScale = 0;
	}

	public void BackToMenu () {
		GameManager.instance.SetLoadingScene ("PlanetMenu");
		GameObject.Find("Audio Source").GetComponent<AudioSource> ().Stop ();
		GameObject.Find("Audio Source").GetComponent<AudioSource> ().Play ();
		Time.timeScale = 1;
		SceneManager.LoadScene ("LoadingScreen");
	}

	public void TryAgain () {
		tryAgain.SetActive(true);
	}

}
