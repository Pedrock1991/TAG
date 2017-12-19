using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SSManager : MonoBehaviour {

	public GameObject outDisplay;
	public bool outTimeCheck = false;

	public int universeData;
	public bool reset;
	public Text unverseDataCounter;
	public Text unverseDataCounter2;
	public Text knowledgeCounter;

	public Text outTime;
	public Text profitDescribe;

	public BigNumbers formatter;
	public GameObject bigNumbers;
	public GameManager manager;
	public GameObject gameManager;
	public AlienTechnologyManager alien;
	public GameObject alienTechnologyManager;
	public FactoryManager factory;
	public GameObject factoryManager;

	public BlueClick blue;
	public GameObject blueClick;
	public GreenClick green;
	public GameObject greenClick;
	public RedClick red;
	public GameObject redClick;
	public YellowClick yellow;
	public GameObject yellowClick;

	public RedModuleManager redModule;
	public GameObject redModuleManager;
	public YellowModuleManager yellowModule;
	public GameObject yellowModuleManager;
	public BlueModuleManager blueModule;
	public GameObject blueModuleManager;
	public GreenModuleManager greenModule;
	public GameObject greenModuleManager;

	public PowerManager power;
	public GameObject powerManager;

	public string moduleName;

	private string[] greenModules = {"Micro SD Module", "SD Module", "VMD Module", 
		"EVD Module", "UMD Module", 
		"HVD Module", "Archival Disc Module", "Hard Disc Module", 
		"Galatic Disc Module", "Antimatter Disc Module"};
	private string[] redModules = {"Dinamite Module", "C4 Module", "Power Module", "Energy Shield Module", 
		"Armor Module", "Enemy Sensor Module", "Ion Pulse Module", "Communication Module", 
		"Adamantium Armor Module", "Atomic Module"};
	private string[] blueModules = {"Scan Module", "Sonar Module", "Power Module", "Infrared Module", 
		"Speed Module", "Collision Detect Module", "Blue Laser Module", 
		"Termal Sensor Module", "Advanced Memory Module", "Atlas Module"};
	private string[] yellowModules = {"Combustion Propellant Module", "Nuclear Propellant Module", "Atomic Propellant Module", 
		"Hidrogen Propullant Module", "Electromagnetic Repulsion Module", "Ion Propellant Module", 
		"Comet Hitchhiker Module", "Solar Sails Module", "Black Hole Propellant Module", "Space Fold Module"};

	public int newTech;
	SaveSS save;
	public int outDays;
	public int inDays;
	public int outHours;
	public int inHours;
	public int outMinutes;
	public int inMinutes;
	public int outSeconds;
	public int inSeconds;


	void OnApplicationPause () {
		SaveGame ();
	}

	void Awake () {
		bigNumbers = GameObject.Find ("BigNumbers");
		formatter = (BigNumbers)bigNumbers.GetComponent (typeof(BigNumbers));
		gameManager = GameObject.Find ("GameManager");
		manager = (GameManager)gameManager.GetComponent (typeof(GameManager));
		alienTechnologyManager = GameObject.Find ("AlienTechnologyManager");
		alien = (AlienTechnologyManager)alienTechnologyManager.GetComponent (typeof(AlienTechnologyManager));

		greenClick = GameObject.Find ("GreenClick");
		green = (GreenClick)greenClick.GetComponent (typeof(GreenClick));
		redClick = GameObject.Find ("RedClick");
		red = (RedClick)redClick.GetComponent (typeof(RedClick));
		yellowClick = GameObject.Find ("YellowClick");
		yellow = (YellowClick)yellowClick.GetComponent (typeof(YellowClick));
		blueClick = GameObject.Find ("BlueClick");
		blue = (BlueClick)blueClick.GetComponent (typeof(BlueClick));

		factoryManager = GameObject.Find ("FactoryManager");
		factory = (FactoryManager)factoryManager.GetComponent (typeof(FactoryManager));

		powerManager = GameObject.Find ("PowerManager");
		power = (PowerManager)powerManager.GetComponent (typeof(PowerManager));

		LoadGame ();

		alienTechnologyManager = GameObject.Find ("AlienTechnologyManager");
		alien = (AlienTechnologyManager)alienTechnologyManager.GetComponent (typeof(AlienTechnologyManager));
	}

	void Start () {
		LoadGame ();
		if (reset == true) {
			for (int i = 0; i <= 100; i++) {
				if (alien.numberOfAlienTech [i] != 0) {
					for(int j = 1; j<=alien.numberOfAlienTech [i];j++){
						ApplieBonus (i);
					}
				}
				reset = false;
			}
		}
		inDays = System.DateTime.Now.Day;
		inHours = System.DateTime.Now.Hour;
		inMinutes = System.DateTime.Now.Minute;
		inSeconds = System.DateTime.Now.Second;
		if (outTimeCheck) {
			CalculateOutTime ();
		}
	}

	// Update is called once per frame
	void Update () {

		unverseDataCounter.text = "<b>Amount of Universe Data</b>\n" + universeData;
		unverseDataCounter2.text = "<b>Amount of Universe Data</b>\n" + universeData;
		knowledgeCounter.text = "<b>Knowledge Adqquired</b>\n" + manager.knowledge;

		outDays = System.DateTime.Now.Day;
		outHours = System.DateTime.Now.Hour;
		outMinutes = System.DateTime.Now.Minute;
		outSeconds = System.DateTime.Now.Second;
		outTimeCheck = true;
	}

	void CalculateOutTime () {
		int passTime;
		if (inDays < outDays) {
			passTime = inDays - outDays + 30;
		} else {
			passTime = inDays - outDays;
		}
		if (passTime == 0) {
			passTime += (inHours - outHours);
		} else {
			passTime += (outHours - inHours) + (passTime * 24);
		}
		passTime *= 60;
		if (inMinutes < outMinutes) {
			passTime += inMinutes - outMinutes + 60;
		} else {
			passTime += inMinutes - outMinutes;
		}
		passTime *= 60;
		if (inSeconds < outSeconds) {
			passTime += inSeconds - outSeconds + 60;
		} else {
			passTime += inSeconds - outSeconds;
		}
		if (passTime != 0) {
			ActiveCard ();
		

			green.data += (passTime / 5) * factory.greenProbes;
			blue.nextDiscovery -= (passTime / 5) * factory.blueProbes;
			yellow.systemSize -= (passTime / 5) * factory.yellowProbes;

			outTime.text = "You Stay out " + passTime + " Sec";
			profitDescribe.text = "Green Production " + formatter.FormatNumber((passTime / 5) * factory.greenProbes) + " Bytes\n"
				+ "Blue Production " + formatter.FormatNumber((passTime / 5) * factory.blueProbes) + " Scan\n"
				+ "Yellow Production " +  formatter.FormatNumber((passTime / 5) * factory.yellowProbes) + " Parsec";

			power.cooldownPowerOne -= passTime;
			power.cooldownPowerTwo -= passTime;
			power.cooldownPowerThree -= passTime;
			power.cooldownPowerFour -= passTime;
			power.cooldownPowerFive -= passTime;

		}
	}

	void ActiveCard () {
		outDisplay.SetActive (true);
	}
		
	public void ResetKnowlodge () {
		if (manager.knowledge >= 1000) {
			SoundManager.PlaySound ("purchaseAccept");
			universeData += (int)(manager.knowledge / 50);
			manager.knowledge = 0;

			RestoreSaves ();
			reset = true;

			SaveGame ();

			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		} else {
			SoundManager.PlaySound ("purchaseDenied");
		}
	}

	public void RestoreSaves () {
		if (PlayerPrefs.HasKey("AsteroidSave")) {
			PlayerPrefs.DeleteKey("AsteroidSave");
		}
		if (PlayerPrefs.HasKey("BlueClickSave")) {
			PlayerPrefs.DeleteKey("BlueClickSave");
		}
		if (PlayerPrefs.HasKey("BlueFactoryManagerSave")) {
			PlayerPrefs.DeleteKey("BlueFactoryManagerSave");
		}
		if (PlayerPrefs.HasKey("FactoryManagerSave")) {
			PlayerPrefs.DeleteKey("FactoryManagerSave");
		}
		if (PlayerPrefs.HasKey("GameManagerSave")) {
			PlayerPrefs.DeleteKey("GameManagerSave");
		}
		if (PlayerPrefs.HasKey("GreenClickSave")) {
			PlayerPrefs.DeleteKey("GreenClickSave");
		}
		if (PlayerPrefs.HasKey("GreenFactoryManagerSave")) {
			PlayerPrefs.DeleteKey("GreenFactoryManagerSave");
		}
		if (PlayerPrefs.HasKey("RedModuleManagerSaveAdamantium Armor")) {
			PlayerPrefs.DeleteKey("RedModuleManagerSaveAdamantium Armor");
		}
		if (PlayerPrefs.HasKey("BlueModuleManagerSaveAdvanced Memory")) {
			PlayerPrefs.DeleteKey("BlueModuleManagerSaveAdvanced Memory");
		}
		if (PlayerPrefs.HasKey("ModuleManagerSaveAntimatter Disc")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveAntimatter Disc");
		}
		if (PlayerPrefs.HasKey("ModuleManagerSaveArchival Disc")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveArchival Disc");
		}
		if (PlayerPrefs.HasKey("RedModuleManagerSaveArmor")) {
			PlayerPrefs.DeleteKey("RedModuleManagerSaveArmor");
		}
		if (PlayerPrefs.HasKey("BlueModuleManagerSaveAtlas")) {
			PlayerPrefs.DeleteKey("BlueModuleManagerSaveAtlas");
		}
		if (PlayerPrefs.HasKey("ModuleManagerSaveAtomic Propellant")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveAtomic Propellant");
		}
		if (PlayerPrefs.HasKey("RedModuleManagerSaveAtomic")) {
			PlayerPrefs.DeleteKey("RedModuleManagerSaveAtomic");
		}
		if (PlayerPrefs.HasKey("ModuleManagerSaveBlack Hole Propellant")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveBlack Hole Propellant");
		}
		if (PlayerPrefs.HasKey("BlueModuleManagerSaveBlue Laser")) {
			PlayerPrefs.DeleteKey("BlueModuleManagerSaveBlue Laser");
		}
		if (PlayerPrefs.HasKey("RedModuleManagerSaveC4")) {
			PlayerPrefs.DeleteKey("RedModuleManagerSaveC4");
		}
		if (PlayerPrefs.HasKey("BlueModuleManagerSaveCollision Detect")) {
			PlayerPrefs.DeleteKey("BlueModuleManagerSaveCollision Detect");
		}
		if (PlayerPrefs.HasKey("ModuleManagerSaveCombustion Propellant")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveCombustion Propellant");
		}
		if (PlayerPrefs.HasKey("ModuleManagerSaveComet Hitchhiker")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveComet Hitchhiker");
		}							
		if (PlayerPrefs.HasKey("RedModuleManagerSaveCommunication")) {
			PlayerPrefs.DeleteKey("RedModuleManagerSaveCommunication");
		}							
		if (PlayerPrefs.HasKey("RedModuleManagerSaveDinamite")) {
			PlayerPrefs.DeleteKey("RedModuleManagerSaveDinamite");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveElectromagnetic Repulsion")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveElectromagnetic Repulsion");
		}							
		if (PlayerPrefs.HasKey("RedModuleManagerSaveEnemy Sensor")) {
			PlayerPrefs.DeleteKey("RedModuleManagerSaveEnemy Sensor");
		}							
		if (PlayerPrefs.HasKey("RedModuleManagerSaveEnergy Shield")) {
			PlayerPrefs.DeleteKey("RedModuleManagerSaveEnergy Shield");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveEVD")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveEVD");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveGalatic Disc")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveGalatic Disc");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveHard Disc")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveHard Disc");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveHidrogen Propullant")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveHidrogen Propullant");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveHVD")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveHVD");
		}							
		if (PlayerPrefs.HasKey("BlueModuleManagerSaveInfrared")) {
			PlayerPrefs.DeleteKey("BlueModuleManagerSaveInfrared");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveIon Propellant")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveIon Propellant");
		}							
		if (PlayerPrefs.HasKey("RedModuleManagerSaveIon Pulse")) {
			PlayerPrefs.DeleteKey("RedModuleManagerSaveIon Pulse");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveMicro SD")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveMicro SD");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveNuclear Propellant")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveNuclear Propellant");
		}							
		if (PlayerPrefs.HasKey("RedModuleManagerSavePower")) {
			PlayerPrefs.DeleteKey("RedModuleManagerSavePower");
		}
		if (PlayerPrefs.HasKey("BlueModuleManagerSavePower")) {
			PlayerPrefs.DeleteKey("BlueModuleManagerSavePower");
		}
		if (PlayerPrefs.HasKey("BlueModuleManagerSaveScan")) {
			PlayerPrefs.DeleteKey("BlueModuleManagerSaveScan");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveSD")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveSD");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveSolar Sails")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveSolar Sails");
		}							
		if (PlayerPrefs.HasKey("BlueModuleManagerSaveSonar")) {
			PlayerPrefs.DeleteKey("BlueModuleManagerSaveSonar");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveSpace Fold")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveSpace Fold");
		}							
		if (PlayerPrefs.HasKey("BlueModuleManagerSaveSpeed")) {
			PlayerPrefs.DeleteKey("BlueModuleManagerSaveSpeed");
		}							
		if (PlayerPrefs.HasKey("BlueModuleManagerSaveTermal Sensor")) {
			PlayerPrefs.DeleteKey("BlueModuleManagerSaveTermal Sensor");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveUMD")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveUMD");
		}							
		if (PlayerPrefs.HasKey("ModuleManagerSaveVMD")) {
			PlayerPrefs.DeleteKey("ModuleManagerSaveVMD");
		}							
		if (PlayerPrefs.HasKey("PlanetManagerSave")) {
			PlayerPrefs.DeleteKey("PlanetManagerSave");
		}							
		if (PlayerPrefs.HasKey("PowerManagerSave")) {
			PlayerPrefs.DeleteKey("PowerManagerSave");
		}							
		if (PlayerPrefs.HasKey("RedClickSave")) {
			PlayerPrefs.DeleteKey("RedClickSave");
		}							
		if (PlayerPrefs.HasKey("RedFactoryManagerSave")) {
			PlayerPrefs.DeleteKey("RedFactoryManagerSave");
		}							
		if (PlayerPrefs.HasKey("TechnologyManagerSave")) {
			PlayerPrefs.DeleteKey("TechnologyManagerSave");
		}							
		if (PlayerPrefs.HasKey("YellowClickSave")) {
			PlayerPrefs.DeleteKey("YellowClickSave");
		}							
		if (PlayerPrefs.HasKey("YellowFactoryManagerSave")) {
			PlayerPrefs.DeleteKey("YellowFactoryManagerSave");
		}
	}

	public void BuyAlienTechnology () {
		if (universeData >= 20) {
			SoundManager.PlaySound ("purchaseAccept");
			universeData -= 20;

			newTech = (int)Random.Range (0, 101);

			alien.numberOfAlienTech [newTech]++;

			ApplieBonus (newTech);
		} else {
			SoundManager.PlaySound ("purchaseDenied");
		}
	}

	void BonusAllColorModule (int index, double bonus) {
		moduleName = index + "." + redModules [index-1];
		redModuleManager = GameObject.Find (moduleName);
		redModule = (RedModuleManager)redModuleManager.GetComponent (typeof(RedModuleManager));
		red.damagePerProbe -= redModule.bonus;
		redModule.bonus *= bonus;
		redModule.bonusScale *= bonus;
		red.damagePerProbe += redModule.bonus;

		moduleName = index + "." + yellowModules [index-1];
		yellowModuleManager = GameObject.Find (moduleName);
		yellowModule = (YellowModuleManager)yellowModuleManager.GetComponent (typeof(YellowModuleManager));
		yellow.parsecPerProbe -= yellowModule.bonus;
		yellowModule.bonus *= bonus;
		yellowModule.bonusScale *= bonus;
		yellow.parsecPerProbe += yellowModule.bonus;

		moduleName = index + "." + blueModules [index-1];
		blueModuleManager = GameObject.Find (moduleName);
		blueModule = (BlueModuleManager)blueModuleManager.GetComponent (typeof(BlueModuleManager));
		blue.scanningPerProbe -= blueModule.bonus;
		blueModule.bonus *= bonus;
		blueModule.bonusScale *= bonus;
		blue.scanningPerProbe += blueModule.bonus;

		moduleName = index + "." + greenModules [index-1];
		greenModuleManager = GameObject.Find (moduleName);
		greenModule = (GreenModuleManager)greenModuleManager.GetComponent (typeof(GreenModuleManager));
		green.dataPerProbe -= greenModule.bonus;
		greenModule.bonus *= bonus;
		greenModule.bonusScale *= bonus;
		green.dataPerProbe += greenModule.bonus;
	}

	void BonusAllColorPerModule (int index, double bonus) {
		moduleName = index + "." + redModules [index-1];
		redModuleManager = GameObject.Find (moduleName);
		redModule = (RedModuleManager)redModuleManager.GetComponent (typeof(RedModuleManager));
		red.damagePerProbe -= redModule.bonus;
		redModule.bonus += (bonus*redModule.level);
		redModule.bonusScale *= bonus;
		red.damagePerProbe += redModule.bonus;

		moduleName = index + "." + yellowModules [index-1];
		yellowModuleManager = GameObject.Find (moduleName);
		yellowModule = (YellowModuleManager)yellowModuleManager.GetComponent (typeof(YellowModuleManager));
		yellow.parsecPerProbe -= yellowModule.bonus;
		yellowModule.bonus += (bonus*redModule.level);
		yellowModule.bonusScale *= bonus;
		yellow.parsecPerProbe += yellowModule.bonus;

		moduleName = index + "." + blueModules [index-1];
		blueModuleManager = GameObject.Find (moduleName);
		blueModule = (BlueModuleManager)blueModuleManager.GetComponent (typeof(BlueModuleManager));
		blue.scanningPerProbe -= blueModule.bonus;
		blueModule.bonus += (bonus*redModule.level);
		blueModule.bonusScale *= bonus;
		blue.scanningPerProbe += blueModule.bonus;

		moduleName = index + "." + greenModules [index-1];
		greenModuleManager = GameObject.Find (moduleName);
		greenModule = (GreenModuleManager)greenModuleManager.GetComponent (typeof(GreenModuleManager));
		green.dataPerProbe -= greenModule.bonus;
		greenModule.bonus += (bonus*redModule.level);
		greenModule.bonusScale *= bonus;
		green.dataPerProbe += greenModule.bonus;
	}

	void BonusAllColorAllModule (double bonus) {
		for (int i = 1; i <= 10; i++) {
			moduleName = i + "." + redModules [i - 1];
			redModuleManager = GameObject.Find (moduleName);
			redModule = (RedModuleManager)redModuleManager.GetComponent (typeof(RedModuleManager));
			red.damagePerProbe -= redModule.bonus;
			redModule.bonus *= bonus;
			redModule.bonusScale *= bonus;
			red.damagePerProbe += redModule.bonus;

			moduleName = i + "." + yellowModules [i - 1];
			yellowModuleManager = GameObject.Find (moduleName);
			yellowModule = (YellowModuleManager)yellowModuleManager.GetComponent (typeof(YellowModuleManager));
			yellow.parsecPerProbe -= yellowModule.bonus;
			yellowModule.bonus *= bonus;
			yellowModule.bonusScale *= bonus;
			yellow.parsecPerProbe += yellowModule.bonus;

			moduleName = i + "." + blueModules [i - 1];
			blueModuleManager = GameObject.Find (moduleName);
			blueModule = (BlueModuleManager)blueModuleManager.GetComponent (typeof(BlueModuleManager));
			blue.scanningPerProbe -= blueModule.bonus;
			blueModule.bonus *= bonus;
			blueModule.bonusScale *= bonus;
			blue.scanningPerProbe += blueModule.bonus;

			moduleName = i + "." + greenModules [i - 1];
			greenModuleManager = GameObject.Find (moduleName);
			greenModule = (GreenModuleManager)greenModuleManager.GetComponent (typeof(GreenModuleManager));
			green.dataPerProbe -= greenModule.bonus;
			greenModule.bonus *= bonus;
			greenModule.bonusScale *= bonus;
			green.dataPerProbe += greenModule.bonus;
		}
	}

	void ApplieBonus (int tech) {
		switch (tech) {
		case 0:
			BonusAllColorModule (1, 2);
			BonusAllColorModule (4, 2);
			BonusAllColorModule (7, 2);
			break;
		case 1:
			BonusAllColorModule (2, 2);
			BonusAllColorModule (5, 2);
			BonusAllColorModule (8, 2);
			break;
		case 2:
			BonusAllColorModule (3, 2);
			BonusAllColorModule (6, 2);
			BonusAllColorModule (9, 2);
			break;
		case 3:
			BonusAllColorAllModule (1.5);
			BonusAllColorModule (1, 2);
			break;
		case 4:
			BonusAllColorAllModule (1.5);
			BonusAllColorModule (2, 2);
			break;
		case 5:
			BonusAllColorAllModule (1.5);
			BonusAllColorModule (3, 2);
			break;
		case 6:
			BonusAllColorAllModule (1.5);
			BonusAllColorModule (4, 2);
			break;
		case 7:
			BonusAllColorAllModule (1.5);
			BonusAllColorModule (5, 2);
			break;
		case 8:
			BonusAllColorAllModule (1.5);
			BonusAllColorModule (6, 2);
			break;
		case 9:
			BonusAllColorAllModule (1.5);
			BonusAllColorModule (7, 2);
			break;
		case 10:
			BonusAllColorAllModule (1.5);
			BonusAllColorModule (8, 2);
			break;
		case 11:
			BonusAllColorAllModule (1.5);
			BonusAllColorModule (9, 2);
			break;
		case 12:
			BonusAllColorAllModule (1.5);
			BonusAllColorModule (10, 2);
			break;
		case 13:
			BonusAllColorAllModule (1.5);
			factory.blueProbes *= 2;
			factory.yellowProbes *= 2;
			factory.redProbes *= 2;
			factory.greenProbes *= 2;
			break;
		case 14:
			BonusAllColorAllModule (1.5);
			factory.blueProbes *= 2;
			factory.yellowProbes *= 2;
			factory.redProbes *= 2;
			factory.greenProbes *= 2;
			break;
		case 15:
			BonusAllColorAllModule (1.5);
			break;
		case 16:
			BonusAllColorAllModule (1.5);
			green.dataPerProbe *= 2;
			break;
		case 17:
			BonusAllColorAllModule (1.5);
			break;
		case 18:
			BonusAllColorAllModule (2);
			break;
		case 19:
			BonusAllColorAllModule (1.5);
			factory.blueProbes *= 2;
			factory.yellowProbes *= 2;
			factory.redProbes *= 2;
			factory.greenProbes *= 2;
			break;
		case 20:
			factory.blueProbes *= 2;
			factory.yellowProbes *= 2;
			factory.redProbes *= 2;
			factory.greenProbes *= 2;
			break;
		case 21:
			BonusAllColorAllModule (1.5);
			break;
		case 22:
			factory.blueProbes *= 2;
			factory.yellowProbes *= 2;
			factory.redProbes *= 2;
			factory.greenProbes *= 2;
			break;
		case 23:
			BonusAllColorAllModule (2);
			break;
		case 24:
			BonusAllColorAllModule (1.5);
			break;
		case 25:
			BonusAllColorPerModule (1, 1.5);
			break;
		case 26:
			BonusAllColorModule (1, 2);
			break;
		case 27:
			BonusAllColorModule (1, 2);
			break;
		case 28:
			BonusAllColorModule (1, 2);
			break;
		case 29:
			BonusAllColorModule (1, 3);
			break;
		case 30:
			BonusAllColorPerModule (2, 1.2);
			break;
		case 31:
			BonusAllColorModule (2, 2);
			break;
		case 32:
			BonusAllColorModule (2, 2);
			break;
		case 33:
			BonusAllColorModule (2, 2);
			break;
		case 34:
			BonusAllColorModule (2, 3);
			break;
		case 35:
			BonusAllColorPerModule (3, 1.2);
			break;
		case 36:
			BonusAllColorModule (3, 2);
			break;
		case 37:
			BonusAllColorModule (3, 2);
			break;
		case 38:
			BonusAllColorModule (3, 2);
			break;
		case 39:
			BonusAllColorModule (3, 3);
			break;
		case 40:
			BonusAllColorPerModule (4, 1.2);
			break;
		case 41:
			BonusAllColorModule (4, 2);
			break;
		case 42:
			BonusAllColorModule (4, 2);
			break;
		case 43:
			BonusAllColorModule (4, 2);
			break;
		case 44:
			BonusAllColorModule (4, 3);
			break;
		case 45:
			BonusAllColorPerModule (5, 1.2);
			break;
		case 46:
			BonusAllColorModule (5, 2);
			break;
		case 47:
			BonusAllColorModule (5, 2);
			break;
		case 48:
			BonusAllColorModule (5, 2);
			break;
		case 49:
			BonusAllColorModule (5, 3);
			break;
		case 50:
			BonusAllColorPerModule (6, 1.2);
			break;
		case 51:
			BonusAllColorModule (6, 2);
			break;
		case 52:
			BonusAllColorModule (6, 2);
			break;
		case 53:
			BonusAllColorModule (6, 2);
			break;
		case 54:
			BonusAllColorModule (6, 3);
			break;
		case 55:
			BonusAllColorPerModule (7, 1.2);
			break;
		case 56:
			BonusAllColorModule (7, 2);
			break;
		case 57:
			BonusAllColorModule (7, 2);
			break;
		case 58:
			BonusAllColorModule (7, 2);
			break;
		case 59:
			BonusAllColorModule (7, 3);
			break;
		case 60:
			BonusAllColorPerModule (8, 1.2);
			break;
		case 61:
			BonusAllColorModule (8, 2);
			break;
		case 62:
			BonusAllColorModule (8, 2);
			break;
		case 63:
			BonusAllColorModule (8, 2);
			break;
		case 64:
			BonusAllColorModule (8, 3);
			break;
		case 65:
			BonusAllColorPerModule (9, 1.2);
			break;
		case 66:
			BonusAllColorModule (9, 2);
			break;
		case 67:
			BonusAllColorModule (9, 2);
			break;
		case 68:
			BonusAllColorModule (9, 2);
			break;
		case 69:
			BonusAllColorModule (9, 3);
			break;
		case 70:
			BonusAllColorPerModule (10, 1.2);
			break;
		case 71:
			BonusAllColorModule (10, 2);
			break;
		case 72:
			BonusAllColorModule (10, 2);
			break;
		case 73:
			BonusAllColorModule (10, 2);
			break;
		case 74:
			BonusAllColorModule (10, 3);
			break;
		case 75:
			manager.stackGreen += 5;
			manager.stackRed += 5;
			manager.stackYellow += 5;
			manager.stackBlue += 5;
			break;
		case 76:
			manager.stackGreen += 1;
			manager.stackRed += 1;
			manager.stackYellow += 1;
			manager.stackBlue += 1;
			break;
		case 77:
			manager.stackGreen += 1;
			manager.stackRed += 1;
			manager.stackYellow += 1;
			manager.stackBlue += 1;
			break;
		case 78:
			manager.stackGreen += 1;
			manager.stackRed += 1;
			manager.stackYellow += 1;
			manager.stackBlue += 1;
			break;
		case 79:
			manager.stackGreen += 1;
			manager.stackRed += 1;
			manager.stackYellow += 1;
			manager.stackBlue += 1;
			break;
		case 80:
			manager.stackGreen += 5;
			manager.stackRed += 5;
			manager.stackYellow += 5;
			manager.stackBlue += 5;
			break;
		case 81:
			manager.stackGreen += 1;
			manager.stackRed += 1;
			manager.stackYellow += 1;
			manager.stackBlue += 1;
			break;
		case 82:
			manager.stackGreen += 1;
			manager.stackRed += 1;
			manager.stackYellow += 1;
			manager.stackBlue += 1;
			break;
		case 83:
			manager.stackGreen += 1;
			manager.stackRed += 1;
			manager.stackYellow += 1;
			manager.stackBlue += 1;
			break;
		case 84:
			manager.stackGreen += 1;
			manager.stackRed += 1;
			manager.stackYellow += 1;
			manager.stackBlue += 1;
			break;
		case 85:
			factory.blueProbes += 2;
			factory.yellowProbes += 2;
			factory.redProbes += 2;
			factory.greenProbes += 2;
			break;
		case 86:
			factory.blueProbes += 2;
			factory.yellowProbes += 2;
			factory.redProbes += 2;
			factory.greenProbes += 2;
			break;
		case 87:
			factory.blueProbes += 2;
			factory.yellowProbes += 2;
			factory.redProbes += 2;
			factory.greenProbes += 2;
			break;
		case 88:
			factory.blueProbes += 2;
			factory.yellowProbes += 2;
			factory.redProbes += 2;
			factory.greenProbes += 2;
			break;
		case 89:
			factory.blueProbes += 2;
			factory.yellowProbes += 2;
			factory.redProbes += 2;
			factory.greenProbes += 2;
			break;
		case 90:
			green.dataPerProbe *= 2;
			break;
		case 91:
			green.dataPerProbe *= 1.5;
			break;
		case 92:
			green.dataPerProbe *= 1.5;
			break;
		case 93:
			green.dataPerProbe *= 1.5;
			break;
		case 94:
			green.dataPerProbe *= 1.5;
			break;
		case 95:
			BonusAllColorModule (1, 2);
			BonusAllColorModule (10, 2);
			break;
		case 96:
			BonusAllColorModule (2, 2);
			BonusAllColorModule (9, 2);
			break;
		case 97:
			BonusAllColorModule (3, 2);
			BonusAllColorModule (8, 2);
			break;
		case 98:
			BonusAllColorModule (4, 2);
			BonusAllColorModule (7, 2);
			break;
		case 99:
			BonusAllColorModule (5, 2);
			BonusAllColorModule (6, 2);
			break;
		}
	}

	private SaveSS CreateSaveGameObject () {
		SaveSS newSave = new SaveSS ();
		newSave.universeData = universeData;
		newSave.reset = reset;
		newSave.outDays = outDays;
		newSave.outHours = outHours;
		newSave.outMinutes = outMinutes;
		newSave.outSeconds = outSeconds;
		newSave.outTimeCheck = outTimeCheck;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("SSSave", Helper.Serialize<SaveSS> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("SSSave")) {
			save = Helper.DeSerialize<SaveSS> (PlayerPrefs.GetString ("SSSave"));

			universeData = save.universeData;
			reset = save.reset;
			outDays = save.outDays;
			outHours = save.outHours;
			outMinutes = save.outMinutes;
			outSeconds = save.outSeconds;
			outTimeCheck = save.outTimeCheck;
		}
	}
}
