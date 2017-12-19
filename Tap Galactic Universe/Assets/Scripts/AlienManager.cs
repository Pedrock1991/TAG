using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienManager : MonoBehaviour {

	public int unknowStone;
	//Clicks
	public GreenClick green;
	public GameObject greenClick;
	public BlueClick blue;
	public GameObject blueClick;
	public YellowClick yellow;
	public GameObject yellowClick;
	public RedClick red;
	public GameObject redClick;
	public FactoryManager factory;
	public GameObject factoryManager;
	public PowerManager power;
	public GameObject powerManager;
	public GameManager manager;
	public GameObject gameManager;
	public SSManager ss;
	public GameObject ssManager;
	//Display
	public Text unknowStoneDisplay;
	public Text unknowStoneDisplay2;
	//Power costs
	private int powerOne = 150;
	private int powerTwo = 180;
	private int powerThree = 200;
	SaveAlien save;

	void OnApplicationPause () {
		SaveGame ();
	}

	// Use this for initialization
	void Awake () {
		greenClick = GameObject.Find ("GreenClick");
		green = (GreenClick)greenClick.GetComponent (typeof(GreenClick));

		blueClick = GameObject.Find ("BlueClick");
		blue = (BlueClick)blueClick.GetComponent (typeof(BlueClick));

		yellowClick = GameObject.Find ("YellowClick");
		yellow = (YellowClick)yellowClick.GetComponent (typeof(YellowClick));

		redClick = GameObject.Find ("RedClick");
		red = (RedClick)redClick.GetComponent (typeof(RedClick));

		factoryManager = GameObject.Find ("FactoryManager");
		factory = (FactoryManager)factoryManager.GetComponent (typeof(FactoryManager));

		powerManager = GameObject.Find ("PowerManager");
		power = (PowerManager)powerManager.GetComponent (typeof(PowerManager));

		gameManager = GameObject.Find ("GameManager");
		manager = (GameManager)gameManager.GetComponent (typeof(GameManager));

		ssManager = GameObject.Find ("SSManager");
		ss = (SSManager)ssManager.GetComponent (typeof(SSManager));

		LoadGame ();
	}
	
	// Update is called once per frame
	void Update () {
		unknowStoneDisplay.text = "<b>Amount Of Unknow Stone</b>\n" + unknowStone;
		unknowStoneDisplay2.text = "<b>Unknow Stone</b>\n" + unknowStone;
	}

	public void ActivePowerOne () { //Receive 24 hours of all probe factory production
		if (powerOne < unknowStone) {
			SoundManager.PlaySound ("purchaseAccept");
			unknowStone -= powerOne;
			green.data += (green.dataPerProbe * factory.greenProbes) * 18720;
			blue.nextDiscovery -= (blue.scanningPerProbe * factory.blueProbes) * 18720;
			red.life -= (red.damagePerProbe * factory.redProbes) * 18720;
			yellow.systemSize -= (yellow.parsecPerProbe * factory.yellowProbes) * 18720;
		} else {
			SoundManager.PlaySound ("purchaseDenied");
		}
	}

	public void ActivePowerTwo () { //Reset All cooldown Times
		if (powerTwo < unknowStone) {
			SoundManager.PlaySound ("purchaseAccept");
			unknowStone -= powerTwo;
			power.cooldownPowerOne = 0;
			power.cooldownPowerTwo = 0;
			power.cooldownPowerThree = 0;
			power.cooldownPowerFour = 0;
			power.cooldownPowerFive = 0;
		} else {
			SoundManager.PlaySound ("purchaseDenied");
		}
	}

	public void ActivePowerThree () { //Turn all knowledge acquired into universe data without return to begining
		if (powerThree < unknowStone) {
			SoundManager.PlaySound ("purchaseAccept");
			unknowStone -= powerThree;
			ss.universeData += (int)(manager.knowledge / 50);
		} else {
			SoundManager.PlaySound ("purchaseDenied");
		}
	}

	private SaveAlien CreateSaveGameObject () {
		SaveAlien newSave = new SaveAlien ();
		newSave.unknowStone = unknowStone;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("AlienManagerSave", Helper.Serialize<SaveAlien> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("AlienManagerSave")) {
			save = Helper.DeSerialize<SaveAlien>(PlayerPrefs.GetString("AlienManagerSave"));

			unknowStone = save.unknowStone;

		}
	}
}
