using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	//Localization TextFile
	static string localizationFile;
	//Initial Window
	static bool configSetted;
		//Genre
		static bool male = true;
		static bool female = false;
		//Team Name
		static string teamName;
	//Planet Menu
		//Configuration Window
		static bool soundGame = true;
		static bool notificationGame = true;
		//Coins
		static int cooper;
		static int silver;
		static int gold;
		//Lives
		[Range(0,5)]
		static int lives = 5;
		bool verifyLives = true; //Dont Save
		float liveCooldown = 1800;
		//Planets
		static int numberOfUnlockPlanets = 0;
	//Loading Scene
	static string loadingScene;
	//Planet's Galaxy
	static string actualPlanet;
	static int selectedGalaxy = 1;
	static string[,] planetPin = new string[7, 7]; //Pin [Galaxy, Planet]
	static bool[] galaxy1Planet1Levels = new bool[286]; //Levels 1 at 285
	//Plataform Meschanism
	//Player Health
	[Range(1, 5)]
	static int alien = 1; // 1 - Beige || 2 - Blue || 3 - Green || 4 - Pink || 5 - Yellow
	static int BeigeCurrentHealth = 4;
	static int BlueCurrentHealth = 4;
	static int GreenCurrentHealth = 4;
	static int PinkCurrentHealth = 4;
	static int YellowCurrentHealth = 4;
	[Range(1,6)]
	static int MaxHealth = 4;
	//Player Buffs
	static bool buff1; // +1 Heart
	static int numberOfBuff1 = 1;
	static bool buff2; // Magnetism
	static int numberOfBuff2 = 1;
	static bool buff3; // +1/3 Time
	static int numberOfBuff3 = 1;
	static bool buff4; // Greate View Range
	static int numberOfBuff4 = 1;
	

	// Use this for initialization
	void Awake () 
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this)
		{
			Destroy (gameObject);
		}
		VerifyConfig ();
	}

	void Start () {
		VerifyConfig ();
	}

	void Update () {
		LiveTimer ();
		VerifyHealth ();

		//TEST SPACE
	}

	//Control Functions
	void VerifyHealth () {
		if (BeigeCurrentHealth > MaxHealth) BeigeCurrentHealth = MaxHealth;
		if (BlueCurrentHealth > MaxHealth) BlueCurrentHealth = MaxHealth;
		if (GreenCurrentHealth > MaxHealth) GreenCurrentHealth = MaxHealth;
		if (PinkCurrentHealth > MaxHealth) PinkCurrentHealth = MaxHealth;
		if (YellowCurrentHealth > MaxHealth) YellowCurrentHealth = MaxHealth;
	}
	void VerifyConfig () {
		if (configSetted) {
			LocalizationManager.instance.LoadLocalizedText (localizationFile);
			InitialWindowManager.instance.SetReady ();
		}
		if (soundGame) {
			GameObject.Find ("Audio Source").GetComponent <AudioSource> ().mute = false;
		} else {
			GameObject.Find ("Audio Source").GetComponent <AudioSource> ().mute = true;
		}
	}
	void LiveTimer () {
		int numberOfLostLives = 5 - lives;
		if (numberOfLostLives > 0) {
			liveCooldown -= Time.deltaTime;
			if (liveCooldown <= 0) {
				SetLives (1);
				verifyLives = true;
				liveCooldown = 1800;
			}
		}
	}
	//Variables Functions
	public void SetActualPlanet (string planet) {
		actualPlanet = planet;
	}
	public string GetActualPlanet () {
		return actualPlanet;
	}
	public void SetNotificationGame (bool turn) {
		notificationGame = turn;
	}
	public bool GetNotificationGame () {
		return notificationGame;
	}
	public void SetSoundGame (bool turn) {
		soundGame = turn;
	}
	public bool GetSoundGame () {
		return soundGame;
	}
	public void SetGalaxy1LevelCompleted (int planet, int level) {
		switch (planet){
		case 1: //Planet 1
			galaxy1Planet1Levels[level] = true;
			break;
		case 2: //Planet 2
			break;
		case 3: //Planet 3
			break;
		case 4: //Planet 4
			break;
		case 5: //Planet 5
			break;
		case 6: //Planet 6
			break;
		}
	}
	public bool GetGalaxy1Level (int planet, int level) {
		switch (planet){
		case 1: //Planet 1
			return galaxy1Planet1Levels[level];
		case 2: //Planet 2
			return false;
		case 3: //Planet 3
			return false;
		case 4: //Planet 4
			return false;
		case 5: //Planet 5
			return false;
		case 6: //Planet 6
			return false;
		default:
			return false;
		}
	}
	public void SetStartPin (int galaxy, int planet, string actualPin) {
		planetPin [galaxy, planet] = actualPin;
	}
	public string GetStartPin (int galaxy, int planet) {
		return planetPin [galaxy, planet];
	}
	public void SetNumberOFBuff4 (int value) {
		numberOfBuff4 += value;
	}
	public int GetNumberOFBuff4 () {
		return numberOfBuff4;
	}
	public void SetNumberOFBuff3 (int value) {
		numberOfBuff3 += value;
	}
	public int GetNumberOFBuff3 () {
		return numberOfBuff3;
	}
	public void SetNumberOFBuff2 (int value) {
		numberOfBuff2 += value;
	}
	public int GetNumberOFBuff2 () {
		return numberOfBuff2;
	}
	public void SetNumberOFBuff1 (int value) {
		numberOfBuff1 += value;
	}
	public int GetNumberOFBuff1 () {
		return numberOfBuff1;
	}
	public void SetBuff4 (bool turn) {
		buff4 = turn;
	}
	public bool GetBuff4 () {
		return buff4;
	}
	public void SetBuff3 (bool turn) {
		buff3 = turn;
	}
	public bool GetBuff3 () {
		return buff3;
	}
	public void SetBuff2 (bool turn) {
		buff2 = turn;
	}
	public bool GetBuff2 () {
		return buff2;
	}
	public void SetBuff1 (bool turn) {
		buff1 = turn;
	}
	public bool GetBuff1 () {
		return buff1;
	}
	public void SetYellowHealth (int health) {
		YellowCurrentHealth = health;
	}
	public void SetPinkHealth (int health) {
		PinkCurrentHealth = health;
	}
	public void SetGreenHealth (int health) {
		GreenCurrentHealth = health;
	}
	public void SetBlueHealth (int health) {
		BlueCurrentHealth = health;
	}
	public void SetBeigeHealth (int health) {
		BeigeCurrentHealth = health;
	}
	public int GetYellowHealth () {
		return YellowCurrentHealth;
	}
	public int GetPinkHealth () {
		return PinkCurrentHealth;
	}
	public int GetGreenHealth () {
		return GreenCurrentHealth;
	}
	public int GetBlueHealth () {
		return BlueCurrentHealth;
	}
	public int GetBeigeHealth () {
		return BeigeCurrentHealth;
	}
	public void SetSelectedAlien(int alienChoose) {
		alien = alienChoose;
	}
	public int GetAlien () {
		return alien;
	}
	public void SetCurrentHealth(int damage) {
		switch(alien){
			case 1:
				BeigeCurrentHealth -= damage;
				break;
			case 2:
				BlueCurrentHealth -= damage;
				break;
			case 3:
				GreenCurrentHealth -= damage;
				break;
			case 4:
				PinkCurrentHealth -= damage;
				break;
			case 5:
				YellowCurrentHealth -= damage;
				break;
		}
	}
	public int GetHealth () {
		switch(alien){
			case 1:
				return BeigeCurrentHealth;
			case 2:
				return BlueCurrentHealth;
			case 3:
				return GreenCurrentHealth;
			case 4:
				return PinkCurrentHealth;
			case 5:
				return YellowCurrentHealth;
			default:
				return 0;
		}	
	}
	public void SetSelectedGalaxy (int galaxy) {
			selectedGalaxy = galaxy;
	}
	public int GetSelectedGalaxy () {
		return selectedGalaxy;
	}
	public void SetLoadingScene (string scene) {
		loadingScene = scene;
	}
	public string GetLoadingScene () {
		return loadingScene;
	}
	public void SetNumberOfUnlockPlanets (int value) {
		numberOfUnlockPlanets += value;
	}
	public int GetNumberOfUnlockPlanets () {
		return numberOfUnlockPlanets;
	}
	public void SetVerifyLives (bool verify) {
		verifyLives = verify;
	}
	public bool GetVerifyLives () {
		return verifyLives;
	}

	public void SetLives (int numberOfLives) {
		lives += numberOfLives;
	}
	public int GetLives () {
		return lives;
	}
	public void SetCooperCoins (int numberOfCoins) {
		cooper += numberOfCoins;
		while (cooper >= 100) {
			cooper -= 100;
			SetSilverCoins (1);
		}
	}
	public int GetCooperCoins () {
		return cooper;
	}
	public void SetSilverCoins (int numberOfCoins) {
		silver += numberOfCoins;
		while (silver >= 100) {
			silver -= 100;
			SetGoldCoins (1);
		}
	}
	public int GetSiverCoins () {
		return silver;
	}
	public void SetGoldCoins (int numberOfCoins) {
		gold += numberOfCoins;
	}
	public int GetGoldCoins () {
		return gold;
	}

	public void CompleteConfiguration () {
		configSetted = true;
	}

	public void VerifyName () {
		if (teamName == null) {
			//Play Sound Denied
		} else {
			InitialWindowManager.instance.SetReady ();
		}
	}

	public void SetTeamName (InputField input) {
		teamName = input.text;
		configSetted = true;
	}
	public string GetTeamName () {
		return teamName;
	}

	public void SetGenreMale () {
		male = true;
		female = false;
	}
	public bool GetGenreMale () {
		return male;
	}
	public void SetGenreFemale () {
		male = false;
		female = true;
	}
	public bool GetGenreFemale () {
		return female;
	}
	public string GetLocalization () {
		return localizationFile;
	}
	public void SetLocalization (string filename) {
		localizationFile = filename;
	}
}
