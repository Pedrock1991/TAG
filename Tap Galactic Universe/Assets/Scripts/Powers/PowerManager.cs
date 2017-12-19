using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour {

	public FactoryManager factory;
	public GameObject factoryManager;
	public GameManager manager;
	public GameObject gameManager;
	//Cooldown Times
	public float cooldownPowerOne = 600; 	//Quick Probe 			- 10min	- 600
	public float cooldownPowerTwo = 900; 	//Probe Supercharge		- 15min	- 900
	public float cooldownPowerThree = 1200; //Factory Supercharge	- 20min	- 1200
	public float cooldownPowerFour = 1500; 	//Tap Stack Chance		- 25min	- 1500
	public float cooldownPowerFive = 1800;	 //Tap Supercharge		- 30min	- 1800
	//Cooldown Display
	public Text cooldownDisplayPowerOne;
	public Text cooldownDisplayPowerTwo;
	public Text cooldownDisplayPowerThree;
	public Text cooldownDisplayPowerFour;
	public Text cooldownDisplayPowerFive;
	//Active Display
	public Text activeDisplayPowerTwo;
	public Text activeDisplayPowerThree;
	public Text activeDisplayPowerFour;
	public Text activeDisplayPowerFive;
	//Powers Key
	public bool powerOneReady;
	public bool powerTwoReady;
	public bool powerThreeReady;
	public bool powerFourReady;
	public bool powerFiveReady;
	//Click
	public GreenClick green;
	public GameObject greenClick;
	public BlueClick blue;
	public GameObject blueClick;
	public YellowClick yellow;
	public GameObject yellowClick;
	public RedClick red;
	public GameObject redClick;
	//Active Power Time
	public float timePowerTwo = 30;  
	public float timePowerThree = 30;
	public float timePowerFour = 30;
	public float timePowerFive = 30;
	//Power Nivel
	public int[] nivelPowerOne = new int[4];	// 0-Green / 1-Red / 2-Yellow / 3-Blue
	public int[] nivelPowerTwo = new int[4];	// 0-Green / 1-Red / 2-Yellow / 3-Blue
	public int[] nivelPowerThree = new int[4];	// 0-Green / 1-Red / 2-Yellow / 3-Blue
	public int[] nivelPowerFour = new int[4];	// 0-Green / 1-Red / 2-Yellow / 3-Blue
	public int[] nivelPowerFive = new int[4];	// 0-Green / 1-Red / 2-Yellow / 3-Blue
	//Active Power Green
	public bool activeGreenPowerTwo;
	public bool activeGreenPowerThree;
	public bool activeGreenPowerFour;
	public bool activeGreenPowerFive;
	//Active Power Red
	public bool activeRedPowerTwo;
	public bool activeRedPowerThree;
	public bool activeRedPowerFour;
	public bool activeRedPowerFive;
	//Active Power Yellow
	public bool activeYellowPowerTwo;
	public bool activeYellowPowerThree;
	public bool activeYellowPowerFour;
	public bool activeYellowPowerFive;
	//Active Power Blue
	public bool activeBluePowerTwo;
	public bool activeBluePowerThree;
	public bool activeBluePowerFour;
	public bool activeBluePowerFive;

	public bool isRed;
	public bool isYellow;
	public bool isGreen = true;
	public bool isBlue;
	SavePower save;

	void OnApplicationPause () {
		SaveGame ();
	}

	void Awake () {
		factoryManager = GameObject.Find ("FactoryManager");
		factory = (FactoryManager)factoryManager.GetComponent (typeof(FactoryManager));

		gameManager = GameObject.Find ("GameManager");
		manager = (GameManager)gameManager.GetComponent (typeof(GameManager));

		greenClick = GameObject.Find ("GreenClick");
		green = (GreenClick)greenClick.GetComponent (typeof(GreenClick));

		blueClick = GameObject.Find ("BlueClick");
		blue = (BlueClick)blueClick.GetComponent (typeof(BlueClick));

		yellowClick = GameObject.Find ("YellowClick");
		yellow = (YellowClick)yellowClick.GetComponent (typeof(YellowClick));

		redClick = GameObject.Find ("RedClick");
		red = (RedClick)redClick.GetComponent (typeof(RedClick));

		LoadGame ();
	}

	void Start () {
		for (int i = 0; i < 4; i++) {
			nivelPowerOne [i] = 1;
			nivelPowerTwo [i] = 1;
			nivelPowerThree [i] = 1;
			nivelPowerFour [i] = 1;
			nivelPowerFive [i] = 1;
		}
		LoadGame ();
	}

	// Update is called once per frame
	void Update () {
		if (!powerOneReady) {
			cooldownPowerOne -= Time.deltaTime;
			cooldownDisplayPowerOne.text = Mathf.Round((cooldownPowerOne / 60)) + " min";
			if (cooldownPowerOne <= 0) {
				cooldownDisplayPowerOne.text = "";
				powerOneReady = true;
				cooldownPowerOne = 600;
			}
		}
		if (!powerTwoReady) {
			cooldownPowerTwo -= Time.deltaTime;
			cooldownDisplayPowerTwo.text = Mathf.Round((cooldownPowerTwo / 60)) + " min";
			if (cooldownPowerTwo <= 0) {
				cooldownDisplayPowerTwo.text = "";
				powerTwoReady = true;
				cooldownPowerTwo = 900;
			}
		}
		if (!powerThreeReady) {
			cooldownPowerThree -= Time.deltaTime;
			cooldownDisplayPowerThree.text = Mathf.Round((cooldownPowerThree / 60)) + " min";
			if (cooldownPowerThree <= 0) {
				cooldownDisplayPowerThree.text = "";
				powerThreeReady = true;
				cooldownPowerThree = 1200;
			}
		}
		if (!powerFourReady) {
			cooldownPowerFour -= Time.deltaTime;
			cooldownDisplayPowerFour.text = Mathf.Round((cooldownPowerFour / 60)) + " min";
			if (cooldownPowerFour <= 0) {
				cooldownDisplayPowerFour.text = "";
				powerFourReady = true;
				cooldownPowerFour = 1500;
			}
		}
		if (!powerFiveReady) {
			cooldownPowerFive -= Time.deltaTime;
			cooldownDisplayPowerFive.text = Mathf.Round((cooldownPowerFive / 60)) + " min";
			if (cooldownPowerFive <= 0) {
				cooldownDisplayPowerFive.text = "";
				powerFiveReady = true;
				cooldownPowerFive = 1800;
			}
		}
		VerifyGreenPower ();
		VerifyRedPower ();
		VerifyYellowPower ();
		VerifyBluePower ();
	}

	void VerifyGreenPower () {
		if (activeGreenPowerTwo) {
			timePowerTwo -= Time.deltaTime;
			activeDisplayPowerTwo.text = Mathf.Round (timePowerTwo) + " sec";
			if (timePowerTwo <= 0) {
				activeDisplayPowerTwo.text = "";
				green.dataPerProbeBooster = 0;
				timePowerTwo = 30;
				activeGreenPowerTwo = false;
			}
		}
		if (activeGreenPowerThree) {
			timePowerThree -= Time.deltaTime;
			activeDisplayPowerThree.text = Mathf.Round (timePowerThree) + " sec";
			if (timePowerThree <= 0) {
				activeDisplayPowerThree.text = "";
				factory.greenProbes /= (2 * nivelPowerOne [0]);
				timePowerThree = 30;
				activeGreenPowerThree = false;
			}
		}
		if (activeGreenPowerFour) {
			timePowerFour -= Time.deltaTime;
			activeDisplayPowerFour.text = Mathf.Round (timePowerFour) + " sec";
			if (timePowerFour <= 0) {
				activeDisplayPowerFour.text = "";
				manager.stackGreen -= 50 + (10 * nivelPowerFour [0] - 10);
				timePowerFour = 30;
				activeGreenPowerFour = false;
			}
		}
		if (activeGreenPowerFive) {
			timePowerFive -= Time.deltaTime;
			activeDisplayPowerFive.text = Mathf.Round (timePowerFive) + " sec";
			if (timePowerFive <= 0) {
				activeDisplayPowerFive.text = "";
				green.dataPerProbeBooster = 0;
				timePowerFive = 30;
				activeGreenPowerFive = false;
			}
		}
	}

	void VerifyRedPower () {
		if (activeRedPowerTwo) {
			timePowerTwo -= Time.deltaTime;
			activeDisplayPowerTwo.text = Mathf.Round (timePowerTwo) + "sec";
			if (timePowerTwo <= 0) {
				activeDisplayPowerTwo.text = "";
				red.damagePerProbeBooster = 0;
				timePowerTwo = 30;
				activeRedPowerTwo = false;
			}
		}
		if (activeRedPowerThree) {
			timePowerThree -= Time.deltaTime;
			activeDisplayPowerThree.text = Mathf.Round (timePowerThree) + "sec";
			if (timePowerThree <= 0) {
				activeDisplayPowerThree.text = "";
				factory.redProbes /= (2 * nivelPowerOne [0]);
				timePowerThree = 30;
				activeRedPowerThree = false;
			}
		}
		if (activeRedPowerFour) {
			timePowerFour -= Time.deltaTime;
			activeDisplayPowerFour.text = Mathf.Round (timePowerFour) + "sec";
			if (timePowerFour <= 0) {
				activeDisplayPowerFour.text = "";
				manager.stackRed -= 50 + (10 * nivelPowerFour [1] - 10);
				timePowerFour = 30;
				activeRedPowerFour = false;
			}
		}
		if (activeRedPowerFive) {
			timePowerFive -= Time.deltaTime;
			activeDisplayPowerFive.text = Mathf.Round (timePowerFive) + "sec";
			if (timePowerFive <= 0) {
				activeDisplayPowerFive.text = "";
				red.damagePerProbeBooster = 0;
				timePowerFive = 30;
				activeRedPowerFive = false;
			}
		}
	}

	void VerifyYellowPower () {
		if (activeYellowPowerTwo) {
			timePowerTwo -= Time.deltaTime;
			activeDisplayPowerTwo.text = Mathf.Round (timePowerTwo) + "sec";
			if (timePowerTwo <= 0) {
				activeDisplayPowerTwo.text = "";
				yellow.parsecPerProbeBooster = 0;
				timePowerTwo = 30;
				activeYellowPowerTwo = false;
			}
		}
		if (activeYellowPowerThree) {
			timePowerThree -= Time.deltaTime;
			activeDisplayPowerThree.text = Mathf.Round (timePowerThree) + "sec";
			if (timePowerThree <= 0) {
				activeDisplayPowerThree.text = "";
				factory.yellowProbes /= (2 * nivelPowerOne [0]);
				timePowerThree = 30;
				activeYellowPowerThree = false;
			}
		}
		if (activeYellowPowerFour) {
			timePowerFour -= Time.deltaTime;
			activeDisplayPowerFour.text = Mathf.Round (timePowerFour) + "sec";
			if (timePowerFour <= 0) {
				activeDisplayPowerFour.text = "";
				manager.stackYellow -= 50 + (10 * nivelPowerFour [2] - 10);
				timePowerFour = 30;
				activeYellowPowerFour = false;
			}
		}
		if (activeYellowPowerFive) {
			timePowerFive -= Time.deltaTime;
			activeDisplayPowerFive.text = Mathf.Round (timePowerFive) + "sec";
			if (timePowerFive <= 0) {
				activeDisplayPowerFive.text = "";
				yellow.parsecPerProbeBooster = 0;
				timePowerFive = 30;
				activeYellowPowerFive = false;
			}
		}
	}

	void VerifyBluePower () {
		if (activeBluePowerTwo) {
			timePowerTwo -= Time.deltaTime;
			activeDisplayPowerTwo.text = Mathf.Round (timePowerTwo) + " sec";
			if (timePowerTwo <= 0) {
				activeDisplayPowerTwo.text = "";
				blue.scanningPerProbeBooster = 0;
				timePowerTwo = 30;
				activeBluePowerTwo = false;
			}
		}
		if (activeBluePowerThree) {
			timePowerThree -= Time.deltaTime;
			activeDisplayPowerThree.text = Mathf.Round (timePowerThree) + " sec";
			if (timePowerThree <= 0) {
				activeDisplayPowerThree.text = "";
				factory.blueProbes /= (2 * nivelPowerOne [0]);
				timePowerThree = 30;
				activeBluePowerThree = false;
			}
		}
		if (activeBluePowerFour) {
			timePowerFour -= Time.deltaTime;
			activeDisplayPowerFour.text = Mathf.Round (timePowerFour) + " sec";
			if (timePowerFour <= 0) {
				activeDisplayPowerFour.text = "";
				manager.stackBlue -= 50 + (10 * nivelPowerFour [3] - 10);
				timePowerFour = 30;
				activeBluePowerFour = false;
			}
		}
		if (activeBluePowerFive) {
			timePowerFive -= Time.deltaTime;
			activeDisplayPowerFive.text = Mathf.Round (timePowerFive) + " sec";
			if (timePowerFive <= 0) {
				activeDisplayPowerFive.text = "";
				blue.scanningPerProbeBooster = 0;
				timePowerFive = 30;
				activeBluePowerFive = false;
			}
		}
	}

	public void ActivePowerOne () { //Gain Probe Production x100
		if (powerOneReady) {
			if (isGreen) {
				green.data += ((green.dataPerProbe * 100));
			}
			if (isRed) {
				red.life -= ((red.damagePerProbe * 100));
			}
			if (isYellow) {
				yellow.systemSize -= ((yellow.parsecPerProbe * 100));
			}
			if (isBlue) {
				blue.nextDiscovery -= ((blue.scanningPerProbe * 100));
			}
			powerOneReady = false;
		}
	}

	public void ActivePowerTwo () { //Probe Production x2
		if (powerTwoReady) {
			if (isGreen) {
				green.dataPerProbeBooster = green.dataPerProbe * (2) - green.dataPerProbe;
				activeGreenPowerTwo = true;
			}
			if (isRed) {
				red.damagePerProbeBooster = red.damagePerProbe * (2) - red.damagePerProbe;
				activeRedPowerTwo = true;
			}
			if (isYellow) {
				yellow.parsecPerProbeBooster = yellow.parsecPerProbe * (2) - yellow.parsecPerProbe;
				activeYellowPowerTwo = true;
			}
			if (isBlue) {
				blue.scanningPerProbeBooster = blue.scanningPerProbe * (2) - blue.scanningPerProbe;
				activeBluePowerTwo = true;
			}
			powerTwoReady = false;
		}
	}

	public void ActivePowerThree () { //Automatically Fabrication x2
		if (powerThreeReady) {
			if (isGreen) {
				factory.greenProbes *= (2);
				activeGreenPowerThree = true;
			}
			if (isRed) {
				factory.redProbes *= (2);
				activeRedPowerThree = true;
			}
			if (isYellow) {
				factory.yellowProbes *= (2);
				activeYellowPowerThree = true;
			}
			if (isBlue) {
				factory.blueProbes *= (2);
				activeBluePowerThree = true;
			}
			powerThreeReady = false;
		}
	}

	public void ActivePowerFour () { //Chance to get x2 probe per tap
		if (powerFourReady) {
			if (isGreen) {
				manager.stackGreen = 50;
				activeGreenPowerFour = true;
			}
			if (isRed) {
				manager.stackRed = 50;
				activeRedPowerFour = true;
			}
			if (isYellow) {
				manager.stackYellow = 50;
				activeYellowPowerFour = true;
			}
			if (isBlue) {
				manager.stackBlue = 50;
				activeBluePowerFour = true;
			}
			powerFourReady = false;
		}
	}

	public void ActivePowerFive () { //Tap production x10
		if (powerFiveReady) {
			if (isGreen) {
				green.dataPerProbeBooster = green.dataPerProbe * (10) - green.dataPerProbe;
				activeGreenPowerFive = true;
			}
			if (isRed) {
				red.damagePerProbeBooster = red.damagePerProbe * (10) - red.damagePerProbe;
				activeRedPowerFive = true;
			}
			if (isYellow) {
				yellow.parsecPerProbeBooster = yellow.parsecPerProbe * (10) - yellow.parsecPerProbe;
				activeYellowPowerFive = true;
			}
			if (isBlue) {
				blue.scanningPerProbeBooster = blue.scanningPerProbe * (10) - blue.scanningPerProbe;
				activeBluePowerFive = true;
			}
			powerFiveReady = false;
		}
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

	private SavePower CreateSaveGameObject () {
		SavePower newSave = new SavePower ();
		newSave.powerOneReady = powerOneReady;
		newSave.powerTwoReady = powerTwoReady;
		newSave.powerThreeReady = powerThreeReady;
		newSave.powerFourReady = powerFourReady;
		newSave.powerFiveReady = powerFiveReady;

		newSave.nivelPowerOne = nivelPowerOne;
		newSave.nivelPowerTwo = nivelPowerTwo;
		newSave.nivelPowerThree = nivelPowerThree;
		newSave.nivelPowerFour = nivelPowerFour;
		newSave.nivelPowerFive = nivelPowerFive;

		newSave.cooldownPowerOne = cooldownPowerOne; 	
		newSave.cooldownPowerTwo = cooldownPowerTwo; 	
		newSave.cooldownPowerThree = cooldownPowerThree; 
		newSave.cooldownPowerFour = cooldownPowerFour; 	
		newSave.cooldownPowerFive = cooldownPowerFive;	

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("PowerManagerSave", Helper.Serialize<SavePower> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("PowerManagerSave")) {
			save = Helper.DeSerialize<SavePower>(PlayerPrefs.GetString("PowerManagerSave"));

			powerOneReady = save.powerOneReady;
			powerTwoReady = save.powerTwoReady;
			powerThreeReady = save.powerThreeReady;
			powerFourReady = save.powerFourReady;
			powerFiveReady = save.powerFiveReady;

			nivelPowerOne = save.nivelPowerOne;
			nivelPowerTwo = save.nivelPowerTwo;
			nivelPowerThree = save.nivelPowerThree;
			nivelPowerFour = save.nivelPowerFour;
			nivelPowerFive = save.nivelPowerFive;

			cooldownPowerOne = save.cooldownPowerOne; 	
			cooldownPowerTwo = save.cooldownPowerTwo; 	
			cooldownPowerThree = save.cooldownPowerThree; 
			cooldownPowerFour = save.cooldownPowerFour; 	
			cooldownPowerFive = save.cooldownPowerFive;	
		}
	}
}
