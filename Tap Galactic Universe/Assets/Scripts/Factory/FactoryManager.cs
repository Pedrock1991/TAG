using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour {
	
	public GameManager manager;
	public GameObject gameManager;

	public int blueProbes;
	public int greenProbes;
	public int redProbes;
	public int yellowProbes;
	SaveFactory save;

	void OnApplicationPause () {
		SaveGame ();
	}

	void OnApplicationQuit () {
		SaveGame ();
	}

	// Use this for initialization
	void Awake () {
		gameManager = GameObject.Find ("GameManager");
		manager = (GameManager)gameManager.GetComponent (typeof(GameManager));
		LoadGame ();
	}

	void Start () {
		StartCoroutine (AutoTick ());
	}

	IEnumerator AutoTick () {
		while (true){
			MakeBlue ();
			MakeGreen ();
			MakeRed ();
			MakeYellow ();
			yield return new WaitForSeconds (5f);
		}
	}

	public void MakeBlue () {
		for (int i = 1; i <= blueProbes; i++) {
			manager.GenerateBlueDrone ();
		}
	}

	public void MakeGreen () {
		for (int i = 1; i <= greenProbes; i++) {
			manager.GenerateGreenDrone ();
		}
	}

	public void MakeRed () {
		for (int i = 1; i <= redProbes; i++) {
			manager.GenerateRedDrone ();
		}
	}

	public void MakeYellow () {
		for (int i = 1; i <= yellowProbes; i++) {
			manager.GenerateYellowDrone ();
		}
	}

	private SaveFactory CreateSaveGameObject () {
		SaveFactory newSave = new SaveFactory ();
		newSave.blueProbes = blueProbes;
		newSave.greenProbes = greenProbes;
		newSave.redProbes = redProbes;
		newSave.yellowProbes = yellowProbes;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("FactoryManagerSave", Helper.Serialize<SaveFactory> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("FactoryManagerSave")) {
			save = Helper.DeSerialize<SaveFactory>(PlayerPrefs.GetString("FactoryManagerSave"));

			blueProbes = save.blueProbes;
			greenProbes = save.greenProbes;
			redProbes = save.redProbes;
			yellowProbes = save.yellowProbes;

		}
	}
}
