using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedTechnologyManager : MonoBehaviour {

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
	public RedClick click2;
	public GameObject redClick;
	public RedModuleManager module;
	public GameObject redModule;
	public FactoryManager factory;
	public GameObject redFactory;
	public TechnologyManager technology;
	public GameObject probeTechnology;
	public PowerManager power;
	public GameObject powerManager;
	//Add RedFactory GameObject

	//Red Modules Names
	private string[] redModules = {"Dinamite Module", "C4 Module", "Power Module", "Energy Shield Module", 
									"Armor Module", "Enemy Sensor Module", "Ion Pulse Module", "Communication Module", 
									"Adamantium Armor Module", "Atomic Module"};
	
	// Use this for initialization
	void Start () {
		bigNumbers = GameObject.Find ("BigNumbers");
		formatter = (BigNumbers)bigNumbers.GetComponent (typeof(BigNumbers));

		greenClick = GameObject.Find ("GreenClick");
		click = (GreenClick)greenClick.GetComponent (typeof(GreenClick));

		redClick = GameObject.Find ("RedClick");
		click2 = (RedClick)redClick.GetComponent (typeof(RedClick));

		probeTechnology = GameObject.Find ("TechnologyManager");
		technology = (TechnologyManager)probeTechnology.GetComponent (typeof(TechnologyManager));

		powerManager = GameObject.Find ("PowerManager");
		power = (PowerManager)powerManager.GetComponent (typeof(PowerManager));

		if (upgradeType == 0 || upgradeType == 5) {
			moduleName = moduleNumber + "." + mod;
			redModule = GameObject.Find (moduleName);
			module = (RedModuleManager)redModule.GetComponent (typeof(RedModuleManager));
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
			technology.BuyedRedTech [index] = true;
			switch (upgradeType) {
			case 0:
				click.data -= cost;

				click2.damagePerProbe -= module.bonus;
				module.bonus *= upgradeBonusScale;
				module.bonusScale *= upgradeBonusScale;
				click2.damagePerProbe += module.bonus;
				break;
			case 1:
				click.data -= cost;

				redFactory = GameObject.Find ("FactoryManager");
				factory = (FactoryManager)redFactory.GetComponent (typeof(FactoryManager));

				factory.redProbes++;
				click2.probes++;
				break;
			case 2:
				click.data -= cost;

				redFactory = GameObject.Find ("FactoryManager");
				factory = (FactoryManager)redFactory.GetComponent (typeof(FactoryManager));

				factory.redProbes++;
				break;
			case 3:
				click.data -= cost;

				power.nivelPowerOne[1]++;
				power.nivelPowerTwo[1]++;
				power.nivelPowerThree[1]++;
				power.nivelPowerFour[1]++;
				power.nivelPowerFive[1]++;
				//Add Unlock Skill
				break;
			case 4:
				click.data -= cost;

				for (int i = 1; i <= 10; i++) {
					moduleName = i + "." + redModules [i-1];
					redModule = GameObject.Find (moduleName);
					module = (RedModuleManager)redModule.GetComponent (typeof(RedModuleManager));

					click2.damagePerProbe -= module.bonus;
					module.bonus *= upgradeBonusScale;
					module.bonusScale *= upgradeBonusScale;
					click2.damagePerProbe += module.bonus;
				}

				redFactory = GameObject.Find ("FactoryManager");
				factory = (FactoryManager)redFactory.GetComponent (typeof(FactoryManager));

				factory.redProbes++;
				break;
			case 5:
				click.data -= cost;

				module.cost *= upgradeBonusScale;
				break;
			case 6:
				click.data -= cost;

				power.nivelPowerOne[1]++;
				power.nivelPowerTwo[1]++;
				power.nivelPowerThree[1]++;
				power.nivelPowerFour[1]++;
				power.nivelPowerFive[1]++;
				//Add Upgrade Skill
				break;
			}
			technology.SetRed ();
			Destroy (transform.gameObject);
		} else {
			SoundManager.PlaySound ("purchaseDenied");
		}
	}
}
