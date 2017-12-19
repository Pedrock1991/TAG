using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YellowClick : MonoBehaviour {

	public Text distanceCounter;
	public Text PerProbe;
	public Text numberOfProbe;
	public double size;
	public double systemSize;
	public double sizeVariation;
	public double parsecPerProbe;
	public double parsecPerProbeBooster; // Don't Save this Variable
	public int probes;
	public int planetFound = 1;
	public bool newPlanet;
	public BigNumbers formatter;
	SaveClick save;

	void OnApplicationPause () {
		SaveGame ();
	}

	// Use this for initialization
	void Awake () {
		LoadGame ();
	}

	void Start () {
		systemSize = size;
		LoadGame ();
		if (systemSize <= 0) {
			systemSize = size;
		}
	}

	// Update is called once per frame
	void Update () {
		if (newPlanet == true) {
			distanceCounter.text = "<b>New Planet Found</b>";
		} else {
			distanceCounter.text = "<b>System Size</b>\n" + formatter.FormatNumber (systemSize);
		}
		PerProbe.text = " <b>Probe Speed</b>\n " + formatter.FormatNumber((parsecPerProbe + parsecPerProbeBooster)) + " Parsec";
		numberOfProbe.text = " <b>Number Of Probes</b>\n " + probes;
	}

	public void count ()
	{
		systemSize -= (parsecPerProbe + parsecPerProbeBooster);
		if (systemSize <= 0) {
			size *= sizeVariation;
			systemSize = size;
			newPlanet = true;
		}
	}

	private SaveClick CreateSaveGameObject () {
		SaveClick newSave = new SaveClick ();
		newSave.size = size;
		newSave.systemSize = systemSize;
		newSave.parsecPerProbe = parsecPerProbe;
		newSave.planetFound = planetFound;
		newSave.newPlanet = newPlanet;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("YellowClickSave", Helper.Serialize<SaveClick> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("YellowClickSave")) {
			save = Helper.DeSerialize<SaveClick>(PlayerPrefs.GetString("YellowClickSave"));

			size = save.size;
			systemSize = save.systemSize;
			parsecPerProbe = save.parsecPerProbe;
			planetFound = save.planetFound;
			newPlanet = save.newPlanet;

		}
	}
}
