using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedClick : MonoBehaviour {

	public Text lifeCounter;
	public Text PerProbe;
	public Text numberOfProbe;
	public double life;
	public double asteroidlife = 0.5;
	public double damagePerProbe;
	public double damagePerProbeBooster; // Don't Save this Variable
	public int probes;

	//Manager Variable
	GameObject asteroid;
	public GameManager gameManager;

	public double numberOfDestroyedAsteroids = 0;
	public AsteroidBelt belt;
	public double lifeVariation = 1.15f;
	public double totalDamage;
	public BigNumbers formatter;
	SaveClick save;

	void OnApplicationPause () {
		SaveGame ();
	}

	void Awake () {
		LoadGame ();
	}

	// Update is called once per frame
	void Update () {
		lifeCounter.text = "<b>Asteroid Belt HP</b>\n" + formatter.FormatNumber(life);
		PerProbe.text = " <b>Damage/Probe</b>\n " + formatter.FormatNumber((damagePerProbe + damagePerProbeBooster));
		numberOfProbe.text = " <b>Number Of Probes</b>\n " + probes;
	}

	public void count ()
	{
		asteroid = GameObject.Find ("Asteroid(Clone)");
		if (life > 0) {
			if (asteroid != null) {
				life -= (damagePerProbe + damagePerProbeBooster);

				totalDamage += damagePerProbe;
				if (totalDamage > asteroidlife) {
					Destroy (asteroid);

					belt.numberOfAsteroids--;
					numberOfDestroyedAsteroids++;
					gameManager.beltInterference = 1.0f * belt.numberOfAsteroids;
					totalDamage = 0;

					if (numberOfDestroyedAsteroids > 15) {
						asteroidlife *= lifeVariation;
						numberOfDestroyedAsteroids = 0;
					}
				}
			}
		} else {
			if (life < 0) {
				life = 0;
				SoundManager.PlaySound ("beltDestroy");
			}
		}
	}

	private SaveClick CreateSaveGameObject () {
		SaveClick newSave = new SaveClick ();
		newSave.life = life;
		newSave.asteroidlife = asteroidlife;
		newSave.damagePerProbe = damagePerProbe;
		newSave.numberOfDestroyedAsteroids = numberOfDestroyedAsteroids;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("RedClickSave", Helper.Serialize<SaveClick> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("RedClickSave")) {
			save = Helper.DeSerialize<SaveClick>(PlayerPrefs.GetString("RedClickSave"));

			life = save.life;
			asteroidlife = save.asteroidlife;
			damagePerProbe = save.damagePerProbe;
			numberOfDestroyedAsteroids = save.numberOfDestroyedAsteroids;

		}
	}
}
