using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public bool slot = true;
	private bool change = true;
	public GameObject[] itens;
	public int itemNumber;
	
	void Update () {
		if (!slot) {
			itens [itemNumber].SetActive (true);
			change = true;
		} else {
			if (change) {
				for (int i = 0; i < itens.Length; i++) {
					itens [i].SetActive (false);
				} 
				change = false;
			}
		}
	}
}
