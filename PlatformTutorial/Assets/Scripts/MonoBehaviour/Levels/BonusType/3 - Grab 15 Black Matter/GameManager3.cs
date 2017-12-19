using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager3 : MonoBehaviour {

	public int numberOfDarkMatter;
	public float darkMatterTime;
	public GameObject[] darkMatters;
	public bool change = true;
	public Text darkMatterCounter;
	private int DM;
	private int i;
	private float changeDelay;

	private LevelManager LM;

	void Start () {
		LM = FindObjectOfType <LevelManager> ();
	}
	
	void Update () {
		if (LM.startBonus){
			LM.gameStarted = true;
			LM.startBonus = false;
		}

		if (change) {
			DM = (int) Random.Range (0, darkMatters.Length);
			for (i = 0; i < darkMatters.Length; i++) {
				darkMatters [i].SetActive (false);
			}
			darkMatters [DM].SetActive (true);
			change = false;
			changeDelay = darkMatterTime;
		}

		if (numberOfDarkMatter <= 0) {
			LM.Win ();
		}

		if (changeDelay > 0) {
			changeDelay -= Time.deltaTime;
		}else {
			change = true;
			changeDelay = darkMatterTime;
		}
		darkMatterCounter.text = numberOfDarkMatter.ToString ();
	}
}
