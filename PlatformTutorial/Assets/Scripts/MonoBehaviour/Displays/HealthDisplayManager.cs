using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayManager : MonoBehaviour {

	public Sprite[] heartSprite;
	public Image heart1;
	public Image heart2;
	public Image heartBuff;

	void Update () {
		VerifyHealth ();		
	}

	void VerifyHealth () {
		int atualHealth = GameManager.instance.GetHealth ();

		switch(atualHealth){
			case 0:
				heart1.sprite = heartSprite[0];
				heart2.sprite = heartSprite[0];
				heartBuff.sprite = heartSprite[0];
				break;
			case 1:
				heart1.sprite = heartSprite[1];
				heart2.sprite = heartSprite[0];
				heartBuff.sprite = heartSprite[0];
				break;
			case 2:
				heart1.sprite = heartSprite[2];
				heart2.sprite = heartSprite[0];
				heartBuff.sprite = heartSprite[0];
				break;
			case 3:
				heart1.sprite = heartSprite[2];
				heart2.sprite = heartSprite[1];
				heartBuff.sprite = heartSprite[0];
				break;
			case 4:
				heart1.sprite = heartSprite[2];
				heart2.sprite = heartSprite[2];
				heartBuff.sprite = heartSprite[0];
				break;
			case 5:
				heart1.sprite = heartSprite[2];
				heart2.sprite = heartSprite[2];
				heartBuff.sprite = heartSprite[1];
				break;
			case 6:
				heart1.sprite = heartSprite[2];
				heart2.sprite = heartSprite[2];
				heartBuff.sprite = heartSprite[2];
				break;
		}
	}
}
