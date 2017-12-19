using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenModuleManager : MonoBehaviour {
	public string modName;
	public string modDescription;
	public GameManager manager;
	public GameObject gameManager;
	//GUI Texts
	public Text moduleName;
	public Text moduleLevel;
	public Text moduleDescription;
	public Text moduleCost;
	public Text moduleBonus;
	public Text levelButton;
	public Text lvlScale;
	//GUI Icon
	public Image icon;
	//Control Variable
	public double initialCost;
	public double cost;
	public int initialLevel;
	public int level;
	public int levelScale;
	public int levelScaleStats;
	public double bonusScale;
	public double bonus;
	public double costVariation;
	//Formating and Click
	public BigNumbers formatter;
	public GreenClick greenClick;
	SaveModule save;

	void OnApplicationPause () {
		SaveGame ();
	}

	void OnDisable () {
		SaveGame ();
	}

	// Use this for initialization
	void Awake () {
		gameManager = GameObject.Find ("GameManager");
		manager = (GameManager)gameManager.GetComponent (typeof(GameManager));

		LoadGame ();
	}

	void Start () {
		moduleName.text = modName;
		moduleDescription.text = modDescription;
		cost = initialCost;
		level = initialLevel;
		bonus = bonusScale;
		levelScale = 1;
		levelScaleStats = 2;

		LoadGame ();
	}

	// Update is called once per frame
	void Update () {
		moduleLevel.text = "<b>Lv.</b> " + level;
		moduleCost.text = "<b>Cost:</b> " + formatter.FormatNumber( CalculateCost ()) + "Bytes";
		moduleBonus.text = "Bonus\n\t+ " + formatter.FormatNumber( CalculateBonus ()) + " Data Space";
		lvlScale.text = " +" + levelScale;
		if (level == 0) {
			levelButton.text = "<b>Burn</b>";
		} else {
			levelButton.text = "Progress +" + levelScale + " Lvl";
		}
	}

	public void PurchasedItem () {
		int i;
		if (greenClick.data >= cost) {
			SoundManager.PlaySound ("purchaseAccept");
			switch (levelScale) {
			case 1:
				greenClick.data -= cost;
				for (i = 1; i < (levelScale + 1); i++) {
					cost = initialCost * System.Math.Pow (costVariation, level);
					greenClick.dataPerProbe += bonusScale;
					bonus += bonusScale;
					level++;
					manager.knowledge++;
				}
				break;
			case 5:
				greenClick.data -= cost;
				for (i = 1; i < (levelScale + 1); i++) {
					cost = initialCost * System.Math.Pow (costVariation, level);
					greenClick.dataPerProbe += bonusScale;
					bonus += bonusScale;
					level++;
					manager.knowledge++;
				}
				break;
			case 10:
				greenClick.data -= cost;
				for (i = 1; i < (levelScale + 1); i++) {
					cost = initialCost * System.Math.Pow (costVariation, level);
					greenClick.dataPerProbe += bonusScale;
					bonus += bonusScale;
					level++;
					manager.knowledge++;
				}
				break;
			case 100:
				greenClick.data -= cost;
				for (i = 1; i < (levelScale + 1); i++) {
					cost = initialCost * System.Math.Pow (costVariation, level);
					greenClick.dataPerProbe += bonusScale;
					bonus += bonusScale;
					level++;
					manager.knowledge++;
				}
				break;
			}
		} else {
			SoundManager.PlaySound ("purchaseDenied");
		}
	}

	public double CalculateCost () {
		int i;
		int costController = level;

		switch (levelScale) {
		case 1:
			for (i = 1; i < (levelScale + 1); i++) {
				cost = initialCost * System.Math.Pow (costVariation, costController);
				costController++;
			}
			break;
		case 5:
			for (i = 1; i < (levelScale + 1); i++) {
				cost = initialCost * System.Math.Pow (costVariation, costController);
				costController++;
			}
			break;
		case 10:
			for (i = 1; i < (levelScale + 1); i++) {
				cost = initialCost * System.Math.Pow (costVariation, costController);
				costController++;
			}
			break;
		case 100:
			for (i = 1; i < (levelScale + 1); i++) {
				cost = initialCost * System.Math.Pow (costVariation, costController);
				costController++;
			}
			break;
		}
		return cost;
	}

	public double CalculateBonus () {
		if (level == 0) {
			return bonusScale;
		} else {
			return bonusScale;
		}
	}

	public void LevelScaleController () {
		switch (levelScaleStats) {
		case 1:
			levelScale = 1;
			break;
		case 2:
			levelScale = 5;
			break;
		case 3:
			levelScale = 10;
			break;
		case 4:
			levelScale = 100;
			levelScaleStats = 0;
			break;
		}
		levelScaleStats++;
	}

	private SaveModule CreateSaveGameObject () {
		SaveModule newSave = new SaveModule ();
		newSave.initialCost = initialCost;
		newSave.cost = cost;
		newSave.level = level;
		newSave.bonus = bonus;
		newSave.bonusScale = bonusScale;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("ModuleManagerSave" + modName, Helper.Serialize<SaveModule> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("ModuleManagerSave" + modName)) {
			save = Helper.DeSerialize<SaveModule>(PlayerPrefs.GetString("ModuleManagerSave" + modName));

			initialCost = save.initialCost;
			cost = save.cost;
			level = save.level;
			bonus = save.bonus;
			bonusScale = save.bonusScale;

		}
	}
}
