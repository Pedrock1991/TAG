using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienTechnologyManager : MonoBehaviour {

	public int numberOfAlienTechBuyed;

	public int[] numberOfAlienTech;

	public GameObject blackTechCardPrefab;

	public AlienTechnology alienTechnology;

	public GreenClick green;
	public GameObject greenClick;
	public BlueClick blue;
	public GameObject blueClick;
	public YellowClick yellow;
	public GameObject yellowClick;
	public RedClick red;
	public GameObject redClick;

	public GameObject resetCards;
	public bool blackTech;
	public int numberOfBlackCard;
	SaveAlienTechnology save;

	void OnApplicationPause () {
		SaveGame ();
	}

	void Awake () {
		greenClick = GameObject.Find ("GreenClick");
		green = (GreenClick)greenClick.GetComponent (typeof(GreenClick));

		blueClick = GameObject.Find ("BlueClick");
		blue = (BlueClick)blueClick.GetComponent (typeof(BlueClick));

		redClick = GameObject.Find ("RedClick");
		red = (RedClick)redClick.GetComponent (typeof(RedClick));

		yellowClick = GameObject.Find ("YellowClick");
		yellow = (YellowClick)yellowClick.GetComponent (typeof(YellowClick));

		LoadGame ();
	}

	void Start () {
		numberOfAlienTech = new int[100];
		LoadGame ();
	}

	public void MakeCards () {
		for (int i = 0; i < 100; i++) {
			if (numberOfAlienTech [i] != 0) {
				MakeBlackCard (i);
			}
		}
		blackTech = false;
	}

	public void MakeBlackCard (int index) {
		if (blackTech == true) {
			while (GameObject.Find ("Black Technology Card(Clone)")) {
				resetCards = GameObject.Find ("Black Technology Card(Clone)");
				Destroy (resetCards);
			}
			blackTech = false;
			numberOfBlackCard = 0;
		}

		AlienTechnologyCard alienCard = new AlienTechnologyCard ();

		GameObject go;
		go = Instantiate (blackTechCardPrefab) as GameObject;
		go.transform.SetParent (transform);
		alienTechnology = (AlienTechnology)go.GetComponent (typeof(AlienTechnology));

		go.transform.SetParent (GameObject.Find ("TechContent").transform);
		RectTransform myRectTransform = go.transform.GetComponent<RectTransform> ();
		float myY = 160 + (310 * numberOfBlackCard);
		myRectTransform.localPosition = new Vector3 (361.5f, -myY, 0.0f);
		numberOfBlackCard++;

		if (index >= 0 && index <= 4) {
			alienTechnology.techName = alienCard.blackGoldModulesNamesRow1[index];
			alienTechnology.techDescription = alienCard.blackGoldModulesDescribeRow1[index];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 5 && index <= 9) {
			alienTechnology.techName = alienCard.blackGoldModulesNamesRow2[index-5];
			alienTechnology.techDescription = alienCard.blackGoldModulesDescribeRow2[index-5];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 10 && index <= 14) {
			alienTechnology.techName = alienCard.blackGoldModulesNamesRow3[index-10];
			alienTechnology.techDescription = alienCard.blackGoldModulesDescribeRow3[index-10];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 15 && index <= 19) {
			alienTechnology.techName = alienCard.blackGoldModulesNamesRow4[index-15];
			alienTechnology.techDescription = alienCard.blackGoldModulesDescribeRow4[index-15];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 20 && index <= 24) {
			alienTechnology.techName = alienCard.blackGoldModulesNamesRow5[index-20];
			alienTechnology.techDescription = alienCard.blackGoldModulesDescribeRow5[index-20];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 25 && index <= 29) {
			alienTechnology.techName = alienCard.blackSilverModulesNamesRow6[index-25];
			alienTechnology.techDescription = alienCard.blackSilverModulesDescribeRow6[index-25];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 30 && index <= 34) {
			alienTechnology.techName = alienCard.blackSilverModulesNamesRow7[index-30];
			alienTechnology.techDescription = alienCard.blackSilverModulesDescribeRow7[index-30];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 35 && index <= 39) {
			alienTechnology.techName = alienCard.blackSilverModulesNamesRow8[index-35];
			alienTechnology.techDescription = alienCard.blackSilverModulesDescribeRow8[index-35];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 40 && index <= 44) {
			alienTechnology.techName = alienCard.blackSilverModulesNamesRow9[index-40];
			alienTechnology.techDescription = alienCard.blackSilverModulesDescribeRow9[index-40];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 45 && index <= 49) {
			alienTechnology.techName = alienCard.blackSilverModulesNamesRow10[index-45];
			alienTechnology.techDescription = alienCard.blackSilverModulesDescribeRow10[index-45];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 50 && index <= 54) {
			alienTechnology.techName = alienCard.blackSilverModulesNamesRow11[index-50];
			alienTechnology.techDescription = alienCard.blackSilverModulesDescribeRow11[index-50];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 55 && index <= 59) {
			alienTechnology.techName = alienCard.blackSilverModulesNamesRow12[index-55];
			alienTechnology.techDescription = alienCard.blackSilverModulesDescribeRow12[index-55];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 60 && index <= 64) {
			alienTechnology.techName = alienCard.blackSilverModulesNamesRow13[index-60];
			alienTechnology.techDescription = alienCard.blackSilverModulesDescribeRow13[index-60];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 65 && index <= 69) {
			alienTechnology.techName = alienCard.blackSilverModulesNamesRow14[index-65];
			alienTechnology.techDescription = alienCard.blackSilverModulesDescribeRow14[index-65];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 70 && index <= 74) {
			alienTechnology.techName = alienCard.blackSilverModulesNamesRow15[index-70];
			alienTechnology.techDescription = alienCard.blackSilverModulesDescribeRow15[index-70];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 75 && index <= 79) {
			alienTechnology.techName = alienCard.blackCopperModulesNamesRow16[index-75];
			alienTechnology.techDescription = alienCard.blackCopperModulesDescribeRow16[index-75];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 80 && index <= 84) {
			alienTechnology.techName = alienCard.blackCopperModulesNamesRow17[index-80];
			alienTechnology.techDescription = alienCard.blackCopperModulesDescribeRow17[index-80];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 85 && index <= 89) {
			alienTechnology.techName = alienCard.blackCopperModulesNamesRow18[index-85];
			alienTechnology.techDescription = alienCard.blackCopperModulesDescribeRow18[index-85];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 90 && index <= 94) {
			alienTechnology.techName = alienCard.blackCopperModulesNamesRow19[index-90];
			alienTechnology.techDescription = alienCard.blackCopperModulesDescribeRow19[index-90];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
		if (index >= 95 && index <= 99) {
			alienTechnology.techName = alienCard.blackCopperModulesNamesRow20[index-95];
			alienTechnology.techDescription = alienCard.blackCopperModulesDescribeRow20[index-95];
			alienTechnology.techNumber = numberOfAlienTech[index].ToString();
		}
	}

	private SaveAlienTechnology CreateSaveGameObject () {
		SaveAlienTechnology newSave = new SaveAlienTechnology ();
		newSave.numberOfAlienTechBuyed = numberOfAlienTechBuyed;
		newSave.numberOfAlienTech = numberOfAlienTech;

		return newSave;
	}

	public void SaveGame () {
		save = CreateSaveGameObject ();

		PlayerPrefs.SetString ("AlienTechnologyManagerSave", Helper.Serialize<SaveAlienTechnology> (save));
	}

	public void LoadGame () {
		if (PlayerPrefs.HasKey ("AlienTechnologyManagerSave")) {
			save = Helper.DeSerialize<SaveAlienTechnology>(PlayerPrefs.GetString("AlienTechnologyManagerSave"));

			numberOfAlienTechBuyed = save.numberOfAlienTechBuyed;
			numberOfAlienTech = save.numberOfAlienTech;

		}
	}
}