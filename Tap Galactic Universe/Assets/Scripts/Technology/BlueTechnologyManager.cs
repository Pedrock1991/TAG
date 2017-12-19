using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueTechnologyManager : MonoBehaviour {

	public string techName;
	public string techDescription;
	public string moduleName;
	public string mod;
	//GUI Texts
	public Text technologyName;
	public Text technologyDescription;
	public Text technologyCost;
	//GUI Icon
	public Image icon;
	//Control Variable
	public double cost;
	public float upgradeBonusScale;
	public int moduleNumber;
	public int upgradeType;
	public int index;
	//Formating and Click
	public BigNumbers formatter;
	public GameObject bigNumbers;
	public GreenClick click;
	public GameObject greenClick;
	public BlueClick click2;
	public GameObject blueClick;
	public BlueModuleManager module;
	public GameObject blueModule;
	public FactoryManager factory;
	public GameObject blueFactory;
	public TechnologyManager technology;
	public GameObject probeTechnology;
	public PowerManager power;
	public GameObject powerManager;
	//Add BlueFactory GameObject

	//Blue Modules Names
	private string[] blueModules = {"Scan Module", "Sonar Module", "Power Module", "Infrared Module", 
									"Speed Module", "Collision Detect Module", "Blue Laser Module", 
									"Termal Sensor Module", "Advanced Memory Module", "Atlas Module"};
	
	// Use this for initialization
	void Start () {
		bigNumbers = GameObject.Find ("BigNumbers");
		formatter = (BigNumbers)bigNumbers.GetComponent (typeof(BigNumbers));

		greenClick = GameObject.Find ("GreenClick");
		click = (GreenClick)greenClick.GetComponent (typeof(GreenClick));

		blueClick = GameObject.Find ("BlueClick");
		click2 = (BlueClick)blueClick.GetComponent (typeof(BlueClick));

		probeTechnology = GameObject.Find ("TechnologyManager");
		technology = (TechnologyManager)probeTechnology.GetComponent (typeof(TechnologyManager));

		powerManager = GameObject.Find ("PowerManager");
		power = (PowerManager)powerManager.GetComponent (typeof(PowerManager));

		if (upgradeType == 0 || upgradeType == 5) {
			moduleName = moduleNumber + "." + mod;
			blueModule = GameObject.Find (moduleName);
			module = (BlueModuleManager)blueModule.GetComponent (typeof(BlueModuleManager));
		}
	}
	
	// Update is called once per frame
	void Update () {
		technologyName.text = techName;
		technologyDescription.text = techDescription;
		technologyCost.text = "<b>Cost:</b> " + formatter.FormatNumber(cost) + "Bytes";
	}

	public void PurchasedTech () {
		if (click.data >= cost) {
			SoundManager.PlaySound ("purchaseAccept");
			technology.BuyedBlueTech[index] = true;
			switch (upgradeType) {
			case 0:
				click.data -= cost;

				click2.scanningPerProbe -= module.bonus;
				module.bonus *= upgradeBonusScale;
				module.bonusScale *= upgradeBonusScale;
				click2.scanningPerProbe += module.bonus;
				break;
			case 1:
				click.data -= cost;

				blueFactory = GameObject.Find ("FactoryManager");
				factory = (FactoryManager)blueFactory.GetComponent (typeof(FactoryManager));

				factory.blueProbes++;
				click2.probes++;
				break;
			case 2:
				click.data -= cost;

				blueFactory = GameObject.Find ("FactoryManager");
				factory = (FactoryManager)blueFactory.GetComponent (typeof(FactoryManager));

				factory.blueProbes++;
				break;
			case 3:
				click.data -= cost;

				power.nivelPowerOne[3]++;
				power.nivelPowerTwo[3]++;
				power.nivelPowerThree[3]++;
				power.nivelPowerFour[3]++;
				power.nivelPowerFive[3]++;
				//Add Unlock Skill
				break;
			case 4:
				click.data -= cost;

				for (int i = 1; i <= 10; i++) {
					moduleName = i + "." + blueModules [i - 1];
					blueModule = GameObject.Find (moduleName);
					module = (BlueModuleManager)blueModule.GetComponent (typeof(BlueModuleManager));

					click2.scanningPerProbe -= module.bonus;
					module.bonus *= upgradeBonusScale;
					module.bonusScale *= upgradeBonusScale;
					click2.scanningPerProbe += module.bonus;
				}

				blueFactory = GameObject.Find ("FactoryManager");
				factory = (FactoryManager)blueFactory.GetComponent (typeof(FactoryManager));

				factory.blueProbes++;
				break;
			case 5:
				click.data -= cost;

				module.cost *= upgradeBonusScale;
				break;
			case 6:
				click.data -= cost;

				power.nivelPowerOne[3]++;
				power.nivelPowerTwo[3]++;
				power.nivelPowerThree[3]++;
				power.nivelPowerFour[3]++;
				power.nivelPowerFive[3]++;
			//Add Upgrade Skill
				break;
			}
			technology.SetBlue ();
			Destroy (transform.gameObject);
		} else {
			SoundManager.PlaySound ("purchaseDenied");
		}
	}
}
