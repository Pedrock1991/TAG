using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueClick : MonoBehaviour {

	public GameObject adWindowPrefab;

	public Text discoveryCounter;
	public Text PerProbe;
	public Text numberOfProbe;
	public double discovery = 100;
	public double nextDiscovery;
	public double discoveryVariation = 1.15f;
	public double scanningPerProbe;
	public double scanningPerProbeBooster; // Don't Save this Variable
	public int probes;
	public int discoveryCount;
	public int discoveryFound;

	public BigNumbers formatter;
	public TechnologyManager technology;
	public GameObject probeTechnology;
	public AdScript ad;
	public GameObject adManager;
	public GameObject resetCards;
	SaveClick save;

	public GameObject techDisplay;
	public Text newTech;

	//Bonus Variables
	byte type;
	int bonus;

	void OnApplicationPause () {
		SaveGame ();
	}

	// Use this for initialization
	void Awake () {
		
		probeTechnology = GameObject.Find ("TechnologyManager");
		technology = (TechnologyManager)probeTechnology.GetComponent (typeof(TechnologyManager));
		LoadGame ();
	}

	void Start () {
		nextDiscovery = discovery;
		LoadGame ();
		if (nextDiscovery <= 0) {
			nextDiscovery = discovery;
		}
	}
	
	// Update is called once per frame
	void Update () {
		discoveryCounter.text = "<b>Next Discovery</b>\n" + formatter.FormatNumber(nextDiscovery);
		PerProbe.text = " <b>Scanning/Probe</b>\n " + formatter.FormatNumber((scanningPerProbe + scanningPerProbeBooster));
		numberOfProbe.text = " <b>Number Of Probes</b>\n " + probes;
	}

	public void count ()
	{
		nextDiscovery -= (scanningPerProbe + scanningPerProbeBooster);
		if (nextDiscovery <= 0) {
			discovery *= discoveryVariation;
			nextDiscovery = discovery;

			switch (discoveryCount) {
			case 0: //New Green Technology
				technology.numberOfGreenTechDiscovery++;

				techDisplay.SetActive (true);
				newTech.text = "New Green Technology";

				discoveryCount = 1;
				discoveryFound++;
				break;
			case 1: //Bonus
				type = (byte)Random.Range (1, 4);
				MakeCard ();
				discoveryCount = 2;
				break;
			case 2: //New Red Technology
				technology.numberOfRedTechDiscovery++;

				techDisplay.SetActive (true);
				newTech.text = "New Red Technology";

				discoveryCount = 3;
				break;
			case 3: //Bonus
				type = (byte)Random.Range (1, 4);
				MakeCard ();
				discoveryCount = 4;
				break;
			case 4: //New Blue Technology
				technology.numberOfBlueTechDiscovery++;

				techDisplay.SetActive (true);
				newTech.text = "New Blue Technology";

				discoveryCount = 5;
				break;
			case 5: //Bonus
				type = (byte)Random.Range (1, 4);
				MakeCard ();
				discoveryCount = 6;
				break;
			case 6: //New Yellow Technology
				technology.numberOfYellowTechDiscovery++;

				techDisplay.SetActive (true);
				newTech.text = "New Yellow Technology";

				discoveryCount = 7;
				break;
			case 7: //Bonus
				type = (byte)Random.Range (1, 4);
				MakeCard ();
				discoveryCount = 0;
				break;
			}
		}
	}
	void MakeCard () {
		while (GameObject.Find ("AdWindow(Clone)")) {
			resetCards = GameObject.Find ("AdWindow(Clone)");
			Destroy (resetCards);
		}

		GameObject go;

		go = Instantiate (adWindowPrefab) as GameObject;
		go.transform.SetParent (GameObject.Find ("Game Assets").transform);

		RectTransform myRectTransform = go.transform.GetComponent<RectTransform> ();
		myRectTransform.localPosition = Vector3.zero;

		adManager = GameObject.Find ("AdWindow(Clone)");
		ad = (AdScript)adManager.GetComponent (typeof(AdScript));
		ad.type = type;
	}

	private SaveClick CreateSaveGameObject () {
		SaveClick newSave = new SaveClick ();
		newSave.discovery = discovery;
		newSave.nextDiscovery = nextDiscovery;
		newSave.scanningPerProbe = scanningPerProbe;
		newSave.discoveryCount = discoveryCount;
		newSave.discoveryFound = discoveryFound;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString("BlueClickSave", Helper.Serialize<SaveClick>(save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("BlueClickSave")) {
			save = Helper.DeSerialize<SaveClick>(PlayerPrefs.GetString("BlueClickSave"));

			discovery = save.discovery;
			nextDiscovery = save.nextDiscovery;
			scanningPerProbe = save.scanningPerProbe;
			discoveryCount = save.discoveryCount;
			discoveryFound = save.discoveryFound;

		}
	}
}
