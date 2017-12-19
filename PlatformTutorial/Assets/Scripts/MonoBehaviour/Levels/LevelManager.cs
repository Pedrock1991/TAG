using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	//Character Selection
	public GameObject maleCharacters;
	public GameObject[] male = new GameObject[6];
	public GameObject femaleCharacters;
	public GameObject[] female = new GameObject[6];

	public bool gameStarted = false;
	public bool startBonus = true;

	public GameObject finishStar;
	public AudioSource adSrc;
	public AudioClip finishStarSound;
	public GameObject loseWindow;
	public AudioClip loseSound;

	private bool lose = false;
	private bool win = false;

	void Start () {
		SelectCharacter ();
	}

	void Update () {

		if (GameManager.instance.GetHealth() <= 0) Lose ();
		
	}
	
	void SelectCharacter () {
		int i;
		if (GameManager.instance.GetGenreMale ()) {
			maleCharacters.SetActive (true);
			femaleCharacters.SetActive (false);
			for (i = 1; i < 6; i++) {
				male [i].SetActive (false);
			}
			male [GameManager.instance.GetAlien ()].SetActive (true);
		}

		if (GameManager.instance.GetGenreFemale ()) {
			maleCharacters.SetActive (false);
			femaleCharacters.SetActive (true);
			for (i = 1; i < 6; i++) {
				female [i].SetActive (false);
			}
			female [GameManager.instance.GetAlien ()].SetActive (true);
		}
	}

	public void Lose () {
		if (!lose) {
			Debug.Log("Perdeu");
			adSrc = GetComponent <AudioSource> ();
			adSrc.PlayOneShot (loseSound);
			loseWindow.SetActive (true);
			gameStarted = false;
			lose = true;
		}
	}

	public void Win () {
		if (!win) {
			Debug.Log("Ganhou");
			gameStarted = false;
			adSrc = GetComponent <AudioSource> ();
			adSrc.PlayOneShot (finishStarSound);
			finishStar.SetActive (true);
			win = true;
		}
	}

	public void StartBonus () {
		startBonus = true;
	}
}
