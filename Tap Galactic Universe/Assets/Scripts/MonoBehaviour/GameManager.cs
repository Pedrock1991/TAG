using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//Prefabs
	public GameObject blueDronePrefab;
	public GameObject greenDronePrefab;
	public GameObject yellowDronePrefab;
	public GameObject redDronePrefab;

	public GameObject colors;
	public YellowClick yellow;
	public GameObject yellowClick;
	public PlanetManager planet;
	public GameObject planetManager;


	//Imersion Variables
	public double beltInterference;
	public int knowledge;

	//Control Variables
	public float activeTime = 0.0f;
	public float timeToActive = 1.0f;
	public float activeTimePlanet = 0.0f;
	public float timeToActivePlanet = 3.0f;
	public bool isRed;
	public bool isYellow;
	public bool isGreen = true;
	public bool isBlue;
	//Power
	public float stackGreen;
	public float stackRed;
	public float stackBlue;
	public float stackYellow;
	SaveGame save;

	void OnApplicationPause () {
		SaveGame ();
	}

	void Awake () {
		yellowClick = GameObject.Find ("YellowClick");
		yellow = (YellowClick)yellowClick.GetComponent (typeof(YellowClick));

		planetManager = GameObject.Find ("PlanetManager");
		planet = (PlanetManager)planetManager.GetComponent (typeof(PlanetManager));

		LoadGame ();
	}

	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.name == "Space Station") {
				activeTime += Time.deltaTime;
				if (activeTime > timeToActive) {
					colors.SetActive (true);
					SoundManager.PlaySound ("button");
					activeTime = 0.0f;
				}
			}
			if (hit.transform.name == "Planet" && yellow.newPlanet == true) {
				activeTimePlanet += Time.deltaTime;
				if (activeTimePlanet > timeToActivePlanet) {
					planet.change = true;
					activeTimePlanet = 0.0f;
				}
			}
		} else {
			activeTime = 0.0f;
			activeTimePlanet = 0.0f;
		}
		if (Random.Range (0.0f, 100.0f) > beltInterference) {
			if (Input.GetMouseButtonDown (0)) {
				if (isRed) {
					GenerateRedDrone ();
					if(Random.Range(0, 100) < stackRed) GenerateRedDrone ();
				}
				if (isYellow) {
					GenerateYellowDrone ();
					if(Random.Range(0, 100) < stackYellow) GenerateYellowDrone ();
				}
				if (isGreen) {
					GenerateGreenDrone ();
					if(Random.Range(0, 100) < stackGreen) GenerateGreenDrone ();
				}
				if (isBlue) {
					GenerateBlueDrone ();
					if(Random.Range(0, 100) < stackBlue) GenerateBlueDrone ();
				}
			}
		}
	}

	public void GenerateGreenDrone () {
		GameObject go;
		SoundManager.PlaySound ("probeLaunch");
		go = Instantiate (greenDronePrefab) as GameObject;
		go.transform.SetParent (transform);
	}

	public void GenerateBlueDrone () {
		GameObject go;
		SoundManager.PlaySound ("probeLaunch");
		go = Instantiate (blueDronePrefab) as GameObject;
		go.transform.SetParent (transform);
	}

	public void GenerateRedDrone () {
		GameObject go;
		SoundManager.PlaySound ("probeLaunch");
		go = Instantiate (redDronePrefab) as GameObject;
		go.transform.SetParent (transform);
	}

	public void GenerateYellowDrone () {
		GameObject go;
		SoundManager.PlaySound ("probeLaunch");
		go = Instantiate (yellowDronePrefab) as GameObject;
		go.transform.SetParent (transform);
	}

	public void SetRed () {
		isRed = true;
		isYellow = false;
		isGreen = false;
		isBlue = false;
	}

	public void SetYellow () {
		isRed = false;
		isYellow = true;
		isGreen = false;
		isBlue = false;
	}

	public void SetGreen () {
		isRed = false;
		isYellow = false;
		isGreen = true;
		isBlue = false;
	}

	public void SetBlue () {
		isRed = false;
		isYellow = false;
		isGreen = false;
		isBlue = true;
	}

	private SaveGame CreateSaveGameObject () {
		SaveGame newSave = new SaveGame ();
		newSave.knowledge = knowledge;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("GameManagerSave", Helper.Serialize<SaveGame> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("GameManagerSave")) {
			save = Helper.DeSerialize<SaveGame>(PlayerPrefs.GetString("GameManagerSave"));

			knowledge = save.knowledge;

		}
	}
}
