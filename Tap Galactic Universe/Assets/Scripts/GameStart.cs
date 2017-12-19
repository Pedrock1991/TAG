using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameStart : MonoBehaviour {

	float time;
	public float disableTime = 2;

	void Update () {
		time += Time.deltaTime;
		if (time >= disableTime) {
			time = 0;
			if (GameObject.Find ("OutTimeReward") != null) {
				GameObject.Find ("OutTimeReward").SetActive (false);
			}
			if (GameObject.Find ("Tech") != null) {
				GameObject.Find ("Tech").SetActive (false);
			}
			if (GameObject.Find ("NewPlanetFound") != null) {
				GameObject.Find ("NewPlanetFound").SetActive (false);
			}
		}
	}

	IEnumerator AutoTick () {
		while (true){
			yield return new WaitForSeconds (3f);
			StopCoroutine (AutoTick ());
			GameObject.Find ("Tech").SetActive (false);
		}
	}
}
