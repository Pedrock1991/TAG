using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelWindowManager : MonoBehaviour {
	//LevelDisplay
	public Character character;
	public Text selectedLevelText;

	//Character Selection
	bool displayCharacter = true;
	public GameObject male;
	public GameObject female;
	public Button[] maleCharacters = new Button[5];
	public Button[] femaleCharacters = new Button[5];
	//Heart Display
	bool displayHeart = true;
	public Sprite[] heartSprite = new Sprite[3];
	[Header("Hearts")]
	public Image[] beigeHeart = new Image[2];
	public Image[] blueHeart = new Image[2];
	public Image[] greenHeart = new Image[2];
	public Image[] pinkHeart = new Image[2];
	public Image[] yellowHeart = new Image[2];
	//Button GO
	bool goOk = false;
	//Buffs
	bool selectBuff1 = false;
	bool selectBuff2 = false;
	bool selectBuff3 = false;
	bool selectBuff4 = false;
	[Header("Buffs")]
	public Button[] buffs = new Button[4];
	public Text numberOfbuff1;
	public Text numberOfbuff2;
	public Text numberOfbuff3;
	public Text numberOfbuff4;
	//Level Describe
	[Header("Level Describes")]
	public Text levelDescribe;
	public int stageType;

	void Start () {
		character = GameObject.Find ("Character").GetComponent <Character> ();
		levelDescribe = GameObject.Find ("LevelDescribe").GetComponent <Text> ();
	}
	void Update () {
		if (displayCharacter) DisplaySelectCharacter ();
		if (displayHeart) DisplayCurrentHealth ();
		DisplayNumberOfBuffs ();
		DisplayLevelDescribe ();
	}

	void DisplayLevelDescribe () {
		stageType = character.currentPin.stageType;
		switch (stageType) {
		case 1:
			levelDescribe.text = LocalizationManager.instance.GetLocalizedValue ("level_describe1");
			break;
		case 2:
			levelDescribe.text = LocalizationManager.instance.GetLocalizedValue ("level_describe2");
			break;
		case 3:
			levelDescribe.text = LocalizationManager.instance.GetLocalizedValue ("level_describe3");
			break;
		case 4:
			levelDescribe.text = LocalizationManager.instance.GetLocalizedValue ("level_describe4"); 
			break;
		case 5:
			levelDescribe.text = LocalizationManager.instance.GetLocalizedValue ("level_describe5");
			break;
		case 6:
			levelDescribe.text = LocalizationManager.instance.GetLocalizedValue ("level_describe6");
			break;
		case 7:
			levelDescribe.text = LocalizationManager.instance.GetLocalizedValue ("level_describe7");
			break;
		case 8:
			levelDescribe.text = LocalizationManager.instance.GetLocalizedValue ("level_describe8");
			break;
		case 9:
			levelDescribe.text = LocalizationManager.instance.GetLocalizedValue ("level_describe9");
			break;
		}
	}
	void DisplayNumberOfBuffs () {
		numberOfbuff1.text = GameManager.instance.GetNumberOFBuff1 ().ToString ();
		numberOfbuff2.text = GameManager.instance.GetNumberOFBuff2 ().ToString ();
		numberOfbuff3.text = GameManager.instance.GetNumberOFBuff3 ().ToString ();
		numberOfbuff4.text = GameManager.instance.GetNumberOFBuff4 ().ToString ();
	}
	public void SelectBuff4 () {
		if (!selectBuff4) {
			if (GameManager.instance.GetNumberOFBuff4 () > 0) {
				ColorBlock cb = buffs [3].colors;
				cb.highlightedColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
				buffs [3].colors = cb;
				selectBuff4 = true;
				GameManager.instance.SetBuff4 (true);
				GameManager.instance.SetNumberOFBuff4 (-1);
			}
		} else {
			if (GameManager.instance.GetNumberOFBuff4 () >= 0) {
				ColorBlock cb = buffs [3].colors;
				cb.highlightedColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				buffs [3].colors = cb;
				selectBuff4 = false;
				GameManager.instance.SetBuff4 (false);
				GameManager.instance.SetNumberOFBuff4 (1);
			}
		}
	}
	public void SelectBuff3 () {
		if (!selectBuff3) {
			if (GameManager.instance.GetNumberOFBuff3 () > 0) {
				ColorBlock cb = buffs [2].colors;
				cb.highlightedColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
				buffs [2].colors = cb;
				selectBuff3 = true;
				GameManager.instance.SetBuff3 (true);
				GameManager.instance.SetNumberOFBuff3 (-1);
			}
		} else {
			if (GameManager.instance.GetNumberOFBuff3 () >= 0) {
				ColorBlock cb = buffs [2].colors;
				cb.highlightedColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				buffs [2].colors = cb;
				selectBuff3 = false;
				GameManager.instance.SetBuff3 (false);
				GameManager.instance.SetNumberOFBuff3 (1);				
			}
		}
	}
	public void SelectBuff2 () {
		if (!selectBuff2) {
			if (GameManager.instance.GetNumberOFBuff2 () > 0) {
				ColorBlock cb = buffs [1].colors;
				cb.highlightedColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
				buffs [1].colors = cb;
				selectBuff2 = true;
				GameManager.instance.SetBuff2 (true);
				GameManager.instance.SetNumberOFBuff2 (-1);
			}
		} else {
			if (GameManager.instance.GetNumberOFBuff2 () >= 0) {
				ColorBlock cb = buffs [1].colors;
				cb.highlightedColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				buffs [1].colors = cb;
				selectBuff2 = false;
				GameManager.instance.SetBuff2 (false);
				GameManager.instance.SetNumberOFBuff2 (1);
			}
		}
	}
	public void SelectBuff1 () {
		if (!selectBuff1) {
			if (GameManager.instance.GetNumberOFBuff1 () > 0) {
				ColorBlock cb = buffs [0].colors;
				cb.highlightedColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
				buffs [0].colors = cb;
				selectBuff1 = true;
				GameManager.instance.SetBuff1 (true);
				GameManager.instance.SetNumberOFBuff1 (-1);
			}
		} else {
			if (GameManager.instance.GetNumberOFBuff1 () >= 0) {
				ColorBlock cb = buffs [0].colors;
				cb.highlightedColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				buffs [0].colors = cb;
				selectBuff1 = false;
				GameManager.instance.SetBuff1 (false);
				GameManager.instance.SetNumberOFBuff1 (1);
			}
		}
	}
	public void LoadScene () { // Go Button
		if (goOk) {
			if (GameManager.instance.GetHealth () < 4) {
			GameObject.Find ("LowLifeWindow").SetActive (true);
			} else  if (GameManager.instance.GetLives () == 0) {
				GameObject.Find ("LowLiveWindow").SetActive (true);
			} else {
				GameManager.instance.SetLoadingScene (character.currentPin.SceneToLoad);
				SceneManager.LoadScene ("LoadingScreen");
			}
		} else {
			// Sound Denied
		}
	}
	public void SelectYellow () {
		int i;
		ColorBlock cb;
		if (GameManager.instance.GetGenreMale ()) {
			for (i=0; i<5; i++) {
				cb = maleCharacters [i].colors;
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				maleCharacters [i].colors = cb;
			}
			cb = maleCharacters [4].colors;
			cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
			maleCharacters [4].colors = cb;
		}

		if (GameManager.instance.GetGenreFemale ()) {
			for (i=0; i<5; i++) {
				cb = femaleCharacters [i].colors;
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				femaleCharacters [i].colors = cb;
			}
			cb = femaleCharacters [4].colors;
			cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
			femaleCharacters [4].colors = cb;
		}
		GameManager.instance.SetSelectedAlien(5); // Yellow Alien
		goOk = true;
	}
	public void SelectPink () {
		int i;
		ColorBlock cb;
		if (GameManager.instance.GetGenreMale ()) {
			for (i=0; i<5; i++) {
				cb = maleCharacters [i].colors;
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				maleCharacters [i].colors = cb;
			}
			cb = maleCharacters [3].colors;
			cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
			maleCharacters [3].colors = cb;
		}

		if (GameManager.instance.GetGenreFemale ()) {
			for (i=0; i<5; i++) {
				cb = femaleCharacters [i].colors;
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				femaleCharacters [i].colors = cb;
			}
			cb = femaleCharacters [3].colors;
			cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
			femaleCharacters [3].colors = cb;
		}
		GameManager.instance.SetSelectedAlien(4); // Pink Alien
		goOk = true;
	}
	public void SelectGreen () {
		int i;
		ColorBlock cb;
		if (GameManager.instance.GetGenreMale ()) {
			for (i=0; i<5; i++) {
				cb = maleCharacters [i].colors;
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				maleCharacters [i].colors = cb;
			}
			cb = maleCharacters [2].colors;
			cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
			maleCharacters [2].colors = cb;
		}

		if (GameManager.instance.GetGenreFemale ()) {
			for (i=0; i<5; i++) {
				cb = femaleCharacters [i].colors;
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				femaleCharacters [i].colors = cb;
			}
			cb = femaleCharacters [2].colors;
			cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
			femaleCharacters [2].colors = cb;
		}
		GameManager.instance.SetSelectedAlien(3); // Green Alien
		goOk = true;
	}
	public void SelectBlue () {
		int i;
		ColorBlock cb;
		if (GameManager.instance.GetGenreMale ()) {
			for (i=0; i<5; i++) {
				cb = maleCharacters [i].colors;
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				maleCharacters [i].colors = cb;
			}
			cb = maleCharacters [1].colors;
			cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
			maleCharacters [1].colors = cb;
		}

		if (GameManager.instance.GetGenreFemale ()) {
			for (i=0; i<5; i++) {
				cb = femaleCharacters [i].colors;
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				femaleCharacters [i].colors = cb;
			}
			cb = femaleCharacters [1].colors;
			cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
			femaleCharacters [1].colors = cb;
		}
		GameManager.instance.SetSelectedAlien(2); // Blue Alien
		goOk = true;
	}
	public void SelectBeige () {
		int i;
		ColorBlock cb;
		if (GameManager.instance.GetGenreMale ()) {
			for (i=0; i<5; i++) {
				cb = maleCharacters [i].colors;
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				maleCharacters [i].colors = cb;
			}
			cb = maleCharacters [0].colors;
			cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
			maleCharacters [0].colors = cb;
		}

		if (GameManager.instance.GetGenreFemale ()) {
			for (i=0; i<5; i++) {
				cb = femaleCharacters [i].colors;
				cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 0.5f);
				femaleCharacters [i].colors = cb;
			}
			cb = femaleCharacters [0].colors;
			cb.normalColor = new Color (cb.normalColor.r, cb.normalColor.g, cb.normalColor.b  , 1.0f);
			femaleCharacters [0].colors = cb;
		}
		GameManager.instance.SetSelectedAlien(1); // Beige Alien
		goOk = true;
	}
	void DisplayCurrentHealth () {
		switch (GameManager.instance.GetBeigeHealth ()) {
			case 0:
				beigeHeart [0].sprite = heartSprite [0];
				beigeHeart [1].sprite = heartSprite [0];
				break;
			case 1:
				beigeHeart [0].sprite = heartSprite[1];
				beigeHeart [1].sprite = heartSprite[0];
				break;
			case 2:
				beigeHeart [0].sprite = heartSprite[2];
				beigeHeart [1].sprite = heartSprite[0];
				break;
			case 3:
				beigeHeart [0].sprite = heartSprite[2];
				beigeHeart [1].sprite = heartSprite[1];
				break;
			case 4:
				beigeHeart [0].sprite = heartSprite[2];
				beigeHeart [1].sprite = heartSprite[2];
				break;
		}
		switch (GameManager.instance.GetBlueHealth()) {
			case 0:
				blueHeart [0].sprite = heartSprite [0];
				blueHeart [1].sprite = heartSprite [0];
				break;
			case 1:
				blueHeart [0].sprite = heartSprite[1];
				blueHeart [1].sprite = heartSprite[0];
				break;
			case 2:
				blueHeart [0].sprite = heartSprite[2];
				blueHeart [1].sprite = heartSprite[0];
				break;
			case 3:
				blueHeart [0].sprite = heartSprite[2];
				blueHeart [1].sprite = heartSprite[1];
				break;
			case 4:
				blueHeart [0].sprite = heartSprite[2];
				blueHeart [1].sprite = heartSprite[2];
				break;
		}
		switch (GameManager.instance.GetGreenHealth()) {
			case 0:
				greenHeart [0].sprite = heartSprite [0];
				greenHeart [1].sprite = heartSprite [0];
				break;
			case 1:
				greenHeart [0].sprite = heartSprite[1];
				greenHeart [1].sprite = heartSprite[0];
				break;
			case 2:
				greenHeart [0].sprite = heartSprite[2];
				greenHeart [1].sprite = heartSprite[0];
				break;
			case 3:
				greenHeart [0].sprite = heartSprite[2];
				greenHeart [1].sprite = heartSprite[1];
				break;
			case 4:
				greenHeart [0].sprite = heartSprite[2];
				greenHeart [1].sprite = heartSprite[2];
				break;
		}
		switch (GameManager.instance.GetPinkHealth()) {
			case 0:
				pinkHeart [0].sprite = heartSprite [0];
				pinkHeart [1].sprite = heartSprite [0];
				break;
			case 1:
				pinkHeart [0].sprite = heartSprite[1];
				pinkHeart [1].sprite = heartSprite[0];
				break;
			case 2:
				pinkHeart [0].sprite = heartSprite[2];
				pinkHeart [1].sprite = heartSprite[0];
				break;
			case 3:
				pinkHeart [0].sprite = heartSprite[2];
				pinkHeart [1].sprite = heartSprite[1];
				break;
			case 4:
				pinkHeart [0].sprite = heartSprite[2];
				pinkHeart [1].sprite = heartSprite[2];
				break;
		}
		switch (GameManager.instance.GetYellowHealth()) {
			case 0:
				yellowHeart [0].sprite = heartSprite [0];
				yellowHeart [1].sprite = heartSprite [0];
				break;
			case 1:
				yellowHeart [0].sprite = heartSprite[1];
				yellowHeart [1].sprite = heartSprite[0];
				break;
			case 2:
				yellowHeart [0].sprite = heartSprite[2];
				yellowHeart [1].sprite = heartSprite[0];
				break;
			case 3:
				yellowHeart [0].sprite = heartSprite[2];
				yellowHeart [1].sprite = heartSprite[1];
				break;
			case 4:
				yellowHeart [0].sprite = heartSprite[2];
				yellowHeart [1].sprite = heartSprite[2];
				break;
		}
		displayHeart = false;
	}
	void DisplaySelectCharacter () {
		if (GameManager.instance.GetGenreMale ()) {
			male.SetActive(true);
			female.SetActive(false);
		}

		if (GameManager.instance.GetGenreFemale ()) {
			male.SetActive(false);
			female.SetActive(true);
		}
		displayCharacter = false;
	}
}
