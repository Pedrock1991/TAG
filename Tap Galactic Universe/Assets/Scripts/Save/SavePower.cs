using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavePower {

	public bool powerOneReady;
	public bool powerTwoReady;
	public bool powerThreeReady;
	public bool powerFourReady;
	public bool powerFiveReady;

	public int[] nivelPowerOne;	// 0-Green / 1-Red / 2-Yellow / 3-Blue
	public int[] nivelPowerTwo;	// 0-Green / 1-Red / 2-Yellow / 3-Blue
	public int[] nivelPowerThree;	// 0-Green / 1-Red / 2-Yellow / 3-Blue
	public int[] nivelPowerFour;	// 0-Green / 1-Red / 2-Yellow / 3-Blue
	public int[] nivelPowerFive;	// 0-Green / 1-Red / 2-Yellow / 3-Blue

	public float cooldownPowerOne = 600; 	//Quick Probe 			- 10min	- 600
	public float cooldownPowerTwo = 900; 	//Probe Supercharge		- 15min	- 900
	public float cooldownPowerThree = 1200; //Factory Supercharge	- 20min	- 1200
	public float cooldownPowerFour = 1500; 	//Tap Stack Chance		- 25min	- 1500
	public float cooldownPowerFive = 1800;	 //Tap Supercharge		- 30min	- 1800
}

