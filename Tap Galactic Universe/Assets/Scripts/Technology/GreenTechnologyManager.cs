using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenTechnologyManager : MonoBehaviour {

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
	public GreenModuleManager module;
	public GameObject greenModule;
	public FactoryManager factory;
	public GameObject greenFactory;
	public TechnologyManager technology;
	public GameObject probeTechnology;
	public PowerManager power;
	public GameObject powerManager;

	//Green Modules Names
	private string[] greenModules = {"Micro SD Module", "SD Module", "VMD Module", 
									"EVD Module", "UMD Module", 
									"HVD Module", "Archival Disc Module", "Hard Disc Module", 
									"Galatic Disc Module", "Antimatter Disc Module"};
	
	// Use this for initialization
	void Start () {
		bigNumbers = GameObject.Find ("BigNumbers");
		formatter = (BigNumbers)bigNumbers.GetComponent (typeof(BigNumbers));

		greenClick = GameObject.Find ("GreenClick");
		click = (GreenClick)greenClick.GetComponent (typeof(GreenClick));

		probeTechnology = GameObject.Find ("TechnologyManager");
		technology = (TechnologyManager)probeTechnology.GetComponent (typeof(TechnologyManager));

		powerManager = GameObject.Find ("PowerManager");
		power = (PowerManager)powerManager.GetComponent (typeof(PowerManager));

		if (upgradeType == 0 || upgradeType == 5) {
			moduleName = moduleNumber + "." + mod;
			greenModule = GameObject.Find (moduleName);
			module = (GreenModuleManager)greenModule.GetComponent (typeof(GreenModuleManager));
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
			technology.BuyedGreenTech [index] = true;
			switch (upgradeType) {
			case 0:
				click.data -= cost;

				click.dataPerProbe -= module.bonus;
				module.bonus *= upgradeBonusScale;
				module.bonusScale *= upgradeBonusScale;
				click.dataPerProbe += module.bonus;
				break;
			case 1:
				click.data -= cost;

				greenFactory = GameObject.Find ("FactoryManager");
				factory = (FactoryManager)greenFactory.GetComponent (typeof(FactoryManager));

				factory.greenProbes++;
				click.probes++;
				break;
			case 2:
				click.data -= cost;

				greenFactory = GameObject.Find ("FactoryManager");
				factory = (FactoryManager)greenFactory.GetComponent (typeof(FactoryManager));

				factory.greenProbes++;
				break;
			case 3:
				click.data -= cost;

				power.nivelPowerOne[0]++;
				power.nivelPowerTwo[0]++;
				power.nivelPowerThree[0]++;
				power.nivelPowerFour[0]++;
				power.nivelPowerFive[0]++;
				//Add Unlock Skill
				break;
			case 4:
				click.data -= cost;

				for (int i = 1; i <= 10; i++) {
					moduleName = i + "." + greenModules [i-1];
					greenModule = GameObject.Find (moduleName);
					module = (GreenModuleManager)greenModule.GetComponent (typeof(GreenModuleManager));

					click.dataPerProbe -= module.bonus;
					module.bonus *= upgradeBonusScale;
					module.bonusScale *= upgradeBonusScale;
					click.dataPerProbe += module.bonus;
				}

				greenFactory = GameObject.Find ("FactoryManager");
				factory = (FactoryManager)greenFactory.GetComponent (typeof(FactoryManager));

				factory.greenProbes++;
				break;
			case 5:
				click.data -= cost;

				module.cost *= upgradeBonusScale;
				break;
			case 6:
				click.data -= cost;

				power.nivelPowerOne[0]++;
				power.nivelPowerTwo[0]++;
				power.nivelPowerThree[0]++;
				power.nivelPowerFour[0]++;
				power.nivelPowerFive[0]++;
				//Add Upgrade Skill
				break;
			}
			technology.SetGreen ();
			Destroy (transform.gameObject);
		} else {
			SoundManager.PlaySound ("purchaseDenied");
		}
	}
}
