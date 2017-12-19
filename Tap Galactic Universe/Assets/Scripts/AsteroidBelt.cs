using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidBelt : MonoBehaviour {

	public Text beltInterference;
	public Text asteroids;
 
	public GameObject asteroidPrefab;
	public RedClick redClick;
	public GameManager gameManager;

	public int numberOfAsteroids = 0;

	public float respawnTime = 0.0f;
	public float timeToRespawn = 5.0f;

	public float alarmTime = 0.0f;
	public float timeToAlarm = 0.5f;
	SaveAsteroidBelt save;

	void OnApplicationPause () {
		SaveGame ();
	}
	
	// Update is called once per frame
	void Update () {
		beltInterference.text = " <b>Belt Interference:</b> " + gameManager.beltInterference + "%";
		asteroids.text = " <b>Number of Asteroids:</b> " + numberOfAsteroids;

		redClick.life = redClick.asteroidlife*(numberOfAsteroids);

		respawnTime += Time.deltaTime;

		if (gameManager.beltInterference >= 40) {
			alarmTime += Time.deltaTime;
			if (alarmTime > timeToAlarm) {
				SoundManager.PlaySound ("power1");
				alarmTime = 0.0f;
			}
			beltInterference.color = Color.red;
		} else {
			beltInterference.color = Color.white;
		}
		if (respawnTime > timeToRespawn) {
			GenerateAsteroid ();
			respawnTime = 0.0f;
		}
	}

	private void GenerateAsteroid () {
		GameObject go;
		if (numberOfAsteroids < 50) {
			numberOfAsteroids++;
			go = Instantiate (asteroidPrefab) as GameObject;
			gameManager.beltInterference = 1.0f * numberOfAsteroids;
			go.transform.SetParent (transform);
		}
	}

	private SaveAsteroidBelt CreateSaveGameObject () {
		SaveAsteroidBelt newSave = new SaveAsteroidBelt ();
		newSave.numberOfAsteroids = numberOfAsteroids;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("AsteroidSave", Helper.Serialize<SaveAsteroidBelt> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("AsteroidSave")) {
			save = Helper.DeSerialize<SaveAsteroidBelt>(PlayerPrefs.GetString("AsteroidSave"));

			numberOfAsteroids = save.numberOfAsteroids;

		}
	}
}
