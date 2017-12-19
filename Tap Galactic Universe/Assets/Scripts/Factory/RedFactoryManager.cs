using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedFactoryManager : MonoBehaviour {

	public FactoryManager factory;
	public GameObject factoryManager;
	public GreenClick click;
	public GameObject greenClick;
	public RedClick click2;
	public GameObject redClick;
	public BigNumbers formatter;
	public GameObject bigNumbers;

	public Text displayCost;
	public Text numberOfProbe;
	public int probes;

	public double initialCost;
	public double cost;
	public double costVariation;
	SaveFactory save;

	void OnApplicationPause () {
		SaveGame ();
	}

	void OnDisable () {
		SaveGame ();
	}

	// Use this for initialization
	void Awake () {
		factoryManager = GameObject.Find ("FactoryManager");
		factory = (FactoryManager)factoryManager.GetComponent (typeof(FactoryManager));

		greenClick = GameObject.Find ("GreenClick");
		click = (GreenClick)greenClick.GetComponent (typeof(GreenClick));

		redClick = GameObject.Find ("RedClick");
		click2 = (RedClick)redClick.GetComponent (typeof(RedClick));

		bigNumbers = GameObject.Find ("BigNumbers");
		formatter = (BigNumbers)bigNumbers.GetComponent (typeof(BigNumbers));

		LoadGame ();
	}

	void Start () {
		cost = initialCost;
		LoadGame ();
	}

	// Update is called once per frame
	void Update () {
		numberOfProbe.text = "<b>Number Of Probes:</b> " + probes;
		displayCost.text = "<b>Cost:</b> " + formatter.FormatNumber(cost) + "Bytes";
	}

	public void Purchased () {
		if (click.data >= cost) {
			SoundManager.PlaySound ("purchaseAccept");
			click.data -= cost;
			cost = initialCost * System.Math.Pow (costVariation, (probes+1));

			probes++;
			factory.redProbes = probes;
		} else {
			SoundManager.PlaySound ("purchaseDenied");
		}
	}

	private SaveFactory CreateSaveGameObject () {
		SaveFactory newSave = new SaveFactory ();
		newSave.cost = cost;
		newSave.initialCost = initialCost;
		newSave.probes = probes;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("RedFactoryManagerSave", Helper.Serialize<SaveFactory> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("RedFactoryManagerSave")) {
			save = Helper.DeSerialize<SaveFactory>(PlayerPrefs.GetString("RedFactoryManagerSave"));

			cost = save.cost;
			initialCost = save.initialCost;
			probes = save.probes;

		}
	}

}
