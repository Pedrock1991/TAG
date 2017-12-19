using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSlotController : MonoBehaviour {

	public GameObject slotEmpty;
	public GameObject slotFull;
	public int slotNumber;
	
	private bool change = true;
	private bool oneClick = true;
	private InventoryManager IM;
	private GameManager2 GM;
	private Player player;
	private float timeToRefresh;

	private AudioSource theSound;
	public AudioClip gemSound;
	
	void Start () {
		theSound = GameObject.Find("Audio Source").GetComponent <AudioSource> ();
	}

	void Update () {
		if (change) {
			slotFull.SetActive (false);
			slotEmpty.SetActive (true);
			change = false;
		}
		if (timeToRefresh > 0) {
			timeToRefresh -= Time.deltaTime;
		} else {
			oneClick = true;
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if(col.CompareTag("Player")) {
			IM = FindObjectOfType <InventoryManager> ();
			GM = FindObjectOfType <GameManager2> ();
			player = FindObjectOfType <Player> ();
			if (InteractButton.instance.IsInteract ()) {
				if (!IM.slot && IM.itemNumber == slotNumber) {
					theSound.PlayOneShot (SoundManager.bonusType2GemSlotSound);
					IM.slot = true;
					slotFull.SetActive (true);
					slotEmpty.SetActive (false);
					GM.gemSlots [slotNumber] = true;
					oneClick = true;
				}
				if (oneClick) {
					if (!IM.slot && IM.itemNumber != slotNumber) {
						GameManager.instance.SetCurrentHealth (1);
						StartCoroutine(player.Knockback(0.25f, 10));
						timeToRefresh = 2;
					}
					oneClick = false;
				}
			}
		}
	}
}
