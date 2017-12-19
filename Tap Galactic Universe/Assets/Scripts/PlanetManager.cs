using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetManager : MonoBehaviour {

	public int planetNumber;
	public bool change;

	public Text planetDisplay;

	public YellowClick yellow;
	public GameObject yellowClick;

	public GameObject planet;

	public string[] planetName = {"SandStorm","Spectrum","Twilight","Archaic","Nystalux",
		"Uragyad","Hydronaut","Droyne","Unicorn","Starcharts",
		"Alkahest","Warbor","Gamma","Aid","Tethys",
		"Nithus","Pen-Latol","Stazhlekh","Skylin","Zhodani"};

	public Texture[] textures;
	SavePlanet save;

	public GameObject planetCard;
	public GameObject planetSample;
	public bool makeCard = true;

	void OnApplicationPause () {
		SaveGame ();
	}

	// Use this for initialization
	void Awake () {
		yellowClick = GameObject.Find ("YellowClick");
		yellow = (YellowClick)yellowClick.GetComponent (typeof(YellowClick));

		LoadGame ();
	}

	void Start () {
		LoadGame ();
		ChangePlanet ();
	}
	
	// Update is called once per frame
	void Update () {
		planetDisplay.text = "Planet - " + planetName [planetNumber];
		if (change == true) {
			planetNumber++;
			ChangePlanet ();
		}
		if (yellow.newPlanet == true && makeCard == true) {
			MakeCard ();
		}
	}

	void MakeCard () {
		Renderer rend;
		makeCard = false;

		planetCard.SetActive (true);

		rend = planetSample.GetComponent<Renderer> ();
		rend.material.mainTexture = textures [planetNumber + 1];
	}

	void ChangePlanet () {
		Renderer rend;

		change = false;
		yellow.newPlanet = false;

		planet = GameObject.Find ("Planet");

		rend = planet.GetComponent<Renderer> ();

		rend.material.mainTexture = textures [planetNumber];
	}

	private SavePlanet CreateSaveGameObject () {
		SavePlanet newSave = new SavePlanet ();
		newSave.planetNumber = planetNumber;
		newSave.change = change;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("PlanetManagerSave", Helper.Serialize<SavePlanet> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("PlanetManagerSave")) {
			save = Helper.DeSerialize<SavePlanet>(PlayerPrefs.GetString("PlanetManagerSave"));

			planetNumber = save.planetNumber;
			change = save.change;

		}
	}
}
