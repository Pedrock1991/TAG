using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

	public BlueClick blue;
	public GameObject blueClick;
	public GreenClick green;
	public GameObject greenClick;
	public RedClick red;
	public GameObject redClick;
	public YellowClick yellow;
	public GameObject yellowClick;
	public PowerManager power;
	public GameObject powerManager;
	public GameManager manager;
	public GameObject gameManager;
	public AlienManager alien;
	public GameObject alienManager;

	//TUTORIAIS
	public bool tutorial = true;
	public bool exibitionTutorial = true;
	public GameObject exibitionDisplay1;
	public GameObject exibitionDisplay2;
	public GameObject exibitionDisplay3;
	public GameObject exibitionDisplay4;
	public GameObject exibitionDisplay5;
	public GameObject exibitionDisplay6;
	public GameObject exibitionDisplay7;
	public GameObject exibitionDisplay8;
	public GameObject exibitionDisplay9;
	public GameObject exibitionDisplay10;
	public GameObject exibitionDisplay11;
	public GameObject exibitionDisplay12;
	public bool tapTutorial;
	public GameObject tapDisplay1;
	public GameObject tapDisplay2;
	public bool modulesTutorial;
	public GameObject modulesDisplay1;
	public GameObject modulesDisplay2;
	public GameObject modulesDisplay3;
	public bool beltTutorial;
	public GameObject beltDisplay1;
	public GameObject beltDisplay2;
	public GameObject beltDisplay3;
	public GameObject beltDisplay4;
	public bool factoryTutorial;
	public GameObject factoryDisplay1;
	public GameObject factoryDisplay2;
	public GameObject factoryDisplay3;
	public bool technologyTutorial;
	public GameObject technologyDisplay1;
	public GameObject technologyDisplay2;
	public GameObject technologyDisplay3;
	public bool newPlanetTutorial;
	public GameObject newPlanetDisplay1;
	public GameObject newPlanetDisplay2;
	public GameObject newPlanetDisplay3;
	public bool shopTutorial;
	public GameObject shopDisplay1;
	public GameObject shopDisplay2;
	public bool alienTutorial;
	public GameObject alienDisplay1;
	public GameObject alienDisplay2;
	public GameObject alienDisplay3;

	SaveTutorial save;

	void OnApplicationPause () {
		SaveGame ();
	}

	void Awake () {
		LoadGame ();
	}

	void Start () {
		greenClick = GameObject.Find ("GreenClick");
		green = (GreenClick)greenClick.GetComponent (typeof(GreenClick));
		redClick = GameObject.Find ("RedClick");
		red = (RedClick)redClick.GetComponent (typeof(RedClick));
		yellowClick = GameObject.Find ("YellowClick");
		yellow = (YellowClick)yellowClick.GetComponent (typeof(YellowClick));
		blueClick = GameObject.Find ("BlueClick");
		blue = (BlueClick)blueClick.GetComponent (typeof(BlueClick));
		powerManager = GameObject.Find ("PowerManager");
		power = (PowerManager)powerManager.GetComponent (typeof(PowerManager));
		gameManager = GameObject.Find ("GameManager");
		manager = (GameManager)gameManager.GetComponent (typeof(GameManager));
		alienManager = GameObject.Find ("AlienManager");
		alien = (AlienManager)alienManager.GetComponent (typeof(AlienManager));
		LoadGame ();
	}

	float displayTime = 0;
	float activeDisplayTime = 6;

	void Update () {
		if (tutorial) {

			if (Input.GetMouseButtonDown (0)){
				displayTime += activeDisplayTime;
			}

			if (exibitionTutorial) {
				//displayTime += Time.deltaTime;
				ExibitionTutorial ();
			}

			if (tapTutorial) {
				//displayTime += Time.deltaTime;
				TapTutorial ();
			}

			if (modulesTutorial && green.data > 50) {
				//displayTime += Time.deltaTime;
				ModulesTutorial ();
			}

			if (beltTutorial && manager.beltInterference >= 40) {
				//displayTime += Time.deltaTime;
				BeltTutorial ();
			}

			if (factoryTutorial && green.data > 5000) {
				//displayTime += Time.deltaTime;
				FactoryTutorial ();
			}

			if (technologyTutorial && blue.nextDiscovery <= 1) {
				//displayTime += Time.deltaTime;
				TechnologyTutorial ();
			}

			if (newPlanetTutorial && yellow.newPlanet) {
				//displayTime += Time.deltaTime;
				NewPlanetTutorial ();
			}

			if (shopTutorial && alien.unknowStone != 0) {
				//displayTime += Time.deltaTime;
				ShopTutorial ();
			}

			if (alienTutorial && manager.knowledge >= 1000) {
				//displayTime += Time.deltaTime;
				AlienTutorial ();
			}
		}
	}

	void TechnologyTutorial () {
		if (displayTime < activeDisplayTime) {
			technologyDisplay1.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*1) {
			technologyDisplay1.SetActive (false);
			technologyDisplay2.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*2) {
			technologyDisplay2.SetActive (false);
			technologyDisplay3.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*3) {
			technologyDisplay3.SetActive (false);
			technologyTutorial = false;
			displayTime = 0;
		}
	}

	void AlienTutorial () {
		if (displayTime < activeDisplayTime) {
			alienDisplay1.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*1) {
			alienDisplay1.SetActive (false);
			alienDisplay2.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*2) {
			alienDisplay2.SetActive (false);
			alienDisplay3.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*3) {
			alienDisplay3.SetActive (false);
			alienTutorial = false;
			tutorial = false;
			displayTime = 0;
		}
	}

	void ShopTutorial () {
		if (displayTime < activeDisplayTime) {
			shopDisplay1.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*1) {
			shopDisplay1.SetActive (false);
			shopDisplay2.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*2) {
			shopDisplay2.SetActive (false);
			shopTutorial = false;
			displayTime = 0;
		}
	}

	void NewPlanetTutorial () {
		if (displayTime < activeDisplayTime) {
			newPlanetDisplay1.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*1) {
			newPlanetDisplay1.SetActive (false);
			newPlanetDisplay2.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*2) {
			newPlanetDisplay2.SetActive (false);
			newPlanetDisplay3.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*3) {
			newPlanetDisplay3.SetActive (false);
			newPlanetTutorial = false;
			alienTutorial = true;
			displayTime = 0;
		}
	}

	void FactoryTutorial () {
		if (displayTime < activeDisplayTime) {
			factoryDisplay1.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*1) {
			factoryDisplay1.SetActive (false);
			factoryDisplay2.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*2) {
			factoryDisplay2.SetActive (false);
			factoryDisplay3.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*3) {
			factoryDisplay3.SetActive (false);
			factoryTutorial = false;
			shopTutorial = true;
			displayTime = 0;
		}
	}

	void BeltTutorial () {
		if (displayTime < activeDisplayTime) {
			beltDisplay1.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*1) {
			beltDisplay1.SetActive (false);
			beltDisplay2.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*2) {
			beltDisplay2.SetActive (false);
			beltDisplay3.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*3) {
			beltDisplay3.SetActive (false);
			beltDisplay4.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*4) {
			beltDisplay4.SetActive (false);
			beltTutorial = false;
			newPlanetTutorial = true;
			displayTime = 0;
		}
	}

	void ModulesTutorial () {
		if (displayTime < activeDisplayTime) {
			modulesDisplay1.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*1) {
			modulesDisplay1.SetActive (false);
			modulesDisplay2.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*2) {
			modulesDisplay2.SetActive (false);
			modulesDisplay3.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*3) {
			modulesDisplay3.SetActive (false);
			modulesTutorial = false;
			technologyTutorial = true;
			factoryTutorial = true;
			displayTime = 0;
		}
	}

	void TapTutorial () {
		if (displayTime < activeDisplayTime) {
			tapDisplay1.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*1) {
			tapDisplay1.SetActive (false);
			tapDisplay2.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*2) {
			tapDisplay2.SetActive (false);
			tapTutorial = false;
			modulesTutorial = true;
			beltTutorial = true;
			displayTime = 0;
		}
	}

	void ExibitionTutorial () {
		if (displayTime < activeDisplayTime) {
			exibitionDisplay1.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*1) {
			exibitionDisplay1.SetActive (false);
			exibitionDisplay2.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*2) {
			exibitionDisplay2.SetActive (false);
			exibitionDisplay3.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*3) {
			exibitionDisplay3.SetActive (false);
			exibitionDisplay4.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*4) {
			exibitionDisplay4.SetActive (false);
			exibitionDisplay5.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*5) {
			exibitionDisplay5.SetActive (false);
			exibitionDisplay6.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*6) {
			exibitionDisplay6.SetActive (false);
			exibitionDisplay7.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*7) {
			exibitionDisplay7.SetActive (false);
			exibitionDisplay8.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*8) {
			exibitionDisplay8.SetActive (false);
			exibitionDisplay9.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*9) {
			exibitionDisplay9.SetActive (false);
			exibitionDisplay10.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*10) {
			exibitionDisplay10.SetActive (false);
			exibitionDisplay11.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*11) {
			exibitionDisplay11.SetActive (false);
			exibitionDisplay12.SetActive (true);
		}
		if (displayTime >= activeDisplayTime*12) {
			exibitionDisplay12.SetActive (false);
			exibitionTutorial = false;
			tapTutorial = true;
			displayTime = 0;
		}
	}

	private SaveTutorial CreateSaveGameObject () {
		SaveTutorial newSave = new SaveTutorial ();
		newSave.tutorial = tutorial;
		newSave.exibitionTutorial = exibitionTutorial;
		newSave.tapTutorial = tapTutorial;
		newSave.modulesTutorial = modulesTutorial;
		newSave.beltTutorial = beltTutorial;
		newSave.factoryTutorial = factoryTutorial;
		newSave.technologyTutorial = technologyTutorial;
		newSave.newPlanetTutorial = newPlanetTutorial;
		newSave.shopTutorial = shopTutorial;
		newSave.alienTutorial = alienTutorial;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("SaveTutorial", Helper.Serialize<SaveTutorial> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("SaveTutorial")) {
			save = Helper.DeSerialize<SaveTutorial> (PlayerPrefs.GetString ("SaveTutorial"));

			tutorial = save.tutorial;
			exibitionTutorial = save.exibitionTutorial;
			tapTutorial = save.tapTutorial;
			modulesTutorial = save.modulesTutorial;
			beltTutorial = save.beltTutorial;
			factoryTutorial = save.factoryTutorial;
			technologyTutorial = save.technologyTutorial;
			newPlanetTutorial = save.newPlanetTutorial;
			shopTutorial = save.shopTutorial;
			alienTutorial = save.alienTutorial;
		}
	}
}
