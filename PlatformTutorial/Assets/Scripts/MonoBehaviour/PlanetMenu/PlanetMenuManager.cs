using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlanetMenuManager : MonoBehaviour {

	//Planets
	public SpriteRenderer[] planets = new SpriteRenderer[6];
	int numberOfUnlockPlanet;
	//SS
	public SpriteRenderer[] ss = new SpriteRenderer[6];
	int numberOfUnlockSS;
	//Control
	int unlock;
	//Ray ray;
	RaycastHit hit;
	float activeTime;
	float timeToActive = 2;

	public bool configurationWindow;

	void Start () {
		numberOfUnlockPlanet = GameManager.instance.GetNumberOfUnlockPlanets ();
	}

	void Update () {
		ShowPlanets ();
		if (!configurationWindow) {
			VerifyClick ();
		}
	}

	public void TurnConfWindowTrue () {
		configurationWindow = true;
	}
	public void TurnConfWindowFalse () {
		configurationWindow = false;
	}
	void VerifyClick () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit)) {
			switch (hit.transform.name) {
			case "Planet 1":
				activeTime += Time.deltaTime;
				if (activeTime > timeToActive) {
					GameManager.instance.SetLoadingScene ("Galaxy 1 - Planet 1");
					GameManager.instance.SetActualPlanet ("Galaxy 1 - Planet 1");
					SceneManager.LoadScene ("LoadingScreen");
					activeTime = 0.0f;
				}
				break;
			case "Planet 2":
				activeTime += Time.deltaTime;
				if (activeTime > timeToActive) {
					GameManager.instance.SetLoadingScene ("Galaxy 1 - Planet 2");
					GameManager.instance.SetActualPlanet ("Galaxy 1 - Planet 2");
					SceneManager.LoadScene ("LoadingScreen");
					activeTime = 0.0f;
				}
				break;
			case "Planet 3":
				activeTime += Time.deltaTime;
				if (activeTime > timeToActive) {
					GameManager.instance.SetLoadingScene ("Galaxy 1 - Planet 3");
					GameManager.instance.SetActualPlanet ("Galaxy 1 - Planet 3");
					SceneManager.LoadScene ("LoadingScreen");
					activeTime = 0.0f;
				}
				break;
			case "Planet 4":
				activeTime += Time.deltaTime;
				if (activeTime > timeToActive) {
					GameManager.instance.SetLoadingScene ("Galaxy 1 - Planet 4");
					GameManager.instance.SetActualPlanet ("Galaxy 1 - Planet 4");
					SceneManager.LoadScene ("LoadingScreen");
					activeTime = 0.0f;
				}
				break;
			case "Planet 5":
				activeTime += Time.deltaTime;
				if (activeTime > timeToActive) {
					GameManager.instance.SetLoadingScene ("Galaxy 1 - Planet 5");
					GameManager.instance.SetActualPlanet ("Galaxy 1 - Planet 5");
					SceneManager.LoadScene ("LoadingScreen");
					activeTime = 0.0f;
				}
				break;
			case "Planet 6":
				activeTime += Time.deltaTime;
				if (activeTime > timeToActive) {
					GameManager.instance.SetLoadingScene ("Galaxy 1 - Planet 6");
					GameManager.instance.SetActualPlanet ("Galaxy 1 - Planet 6");
					SceneManager.LoadScene ("LoadingScreen");
					activeTime = 0.0f;
				}
				break;
			}
		} else {
			activeTime = 0.0f;
		}
	}

	void ShowPlanets () {
		if (numberOfUnlockPlanet >= unlock && unlock < 6) {
			BoxCollider collider;
			collider = planets [unlock].GetComponent<BoxCollider> ();
			collider.enabled = true;
			Color color;
			color = planets [unlock].color;
			color.a = 1;
			planets [unlock].color = color;
			if (unlock > 0) {
				color = ss [unlock-1].color;
				color.a = 0;
				ss [unlock-1].color = color;
			}
			color = ss [unlock].color;
			color.a = 1;
			ss [unlock].color = color;
			unlock++;
		}
	}
}
