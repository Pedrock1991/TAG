using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveTechnology {

	public int numberOfGreenTechDiscovery;
	public int numberOfBlueTechDiscovery;
	public int numberOfRedTechDiscovery;
	public int numberOfYellowTechDiscovery;

	public bool[] BuyedGreenTech = new bool[741];
	public bool[] BuyedBlueTech = new bool[741];
	public bool[] BuyedRedTech = new bool[741];
	public bool[] BuyedYellowTech = new bool[741];
}

