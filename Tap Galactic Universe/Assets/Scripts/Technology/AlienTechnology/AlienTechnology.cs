using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienTechnology : MonoBehaviour {

	public string techName;
	public string techDescription;
	public string techNumber;
	public Text technologyName;
	public Text technologyDescription;
	public Text technologyNumber;

	// Update is called once per frame
	void Update () {
		technologyName.text = techName;
		technologyDescription.text = techDescription;
		technologyNumber.text = "Numbers: " + techNumber;
	}
}

