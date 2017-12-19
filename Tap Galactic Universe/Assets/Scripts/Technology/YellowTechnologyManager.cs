using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YellowTechnologyManager : MonoBehaviour {

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
	public YellowClick click2;
	public GameObject yellowClick;
	public YellowModuleManager module;
	public GameObject yellowModule;
	public FactoryManager factory;
	public GameObject yellowFactory;
	public TechnologyManager technology;
	public GameObject probeTechnology;
	public PowerManager power;
	public GameObject powerManager;
	//Add YellowFactory GameObject

	//Yellow Modules Names
	private string[] yellowModules = {"Combustion Propellant Module", "Nuclear Propellant Module", "Atomic Propellant Module", 
										"Hidrogen Propullant Module", "Electromagnetic Repulsion Module", "Ion Propellant Module", 
										"Comet Hitchhiker Module", "Solar Sails Module", "Black Hole Propellant Module", "Space Fold Module"};

	// Use this for initialization
	void Start () {
		bigNumbers = GameObject.Find ("BigNumbers");
		formatter = (BigNumbers)bigNumbers.GetComponent (typeof(BigNumbers));

		greenClick = GameObject.Find ("GreenClick");
		click = (GreenClick)greenClick.GetComponent (typeof(GreenClick));

		yellowClick = GameObject.Find ("YellowClick");
		click2 = (YellowClick)yellowClick.GetComponent (typeof(YellowClick));

		probeTechnology = GameObject.Find ("TechnologyManager");
		technology = (TechnologyManager)probeTechnology.GetComponent (typeof(TechnologyManager));

		powerManager = GameObject.Find ("PowerManager");
		power = (PowerManager)powerManager.GetComponent (typeof(PowerManager));

		if (upgradeType == 0 || upgradeType == 5) {
			moduleName = moduleNumber + "." + mod;
			yellowModule = GameObject.Find (moduleName);
			module = (YellowModuleManager)yellowModule.GetComponent (typeof(YellowModuleManager));
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
			technology.BuyedYellowTech [index] = true;
			switch (upgradeType) {
			case 0:
				click.data -= cost;

				click2.parsecPerProbe -= module.bonus;
				module.bonus *= upgradeBonusScale;
				module.bonusScale *= upgradeBonusScale;
				click2.parsecPerProbe += module.bonus;
				break;
			case 1:
				click.data -= cost;

				yellowFactory = GameObject.Find ("FactoryManager");
				factory = (FactoryManager)yellowFactory.GetComponent (typeof(FactoryManager));

				factory.yellowProbes++;
				click2.probes++;
				break;
			case 2:
				click.data -= cost;

				yellowFactory = GameObject.Find ("FactoryManager");
				factory = (FactoryManager)yellowFactory.GetComponent (typeof(FactoryManager));

				factory.yellowProbes++;
				break;
			case 3:
				click.data -= cost;

				power.nivelPowerOne[2]++;
				power.nivelPowerTwo[2]++;
				power.nivelPowerThree[2]++;
				power.nivelPowerFour[2]++;
				power.nivelPowerFive[2]++;
				//Add Unlock Skill
				break;
			case 4:
				click.data -= cost;

				for (int i = 1; i <= 10; i++) {
					moduleName = i + "." + yellowModules [i-1];
					yellowModule = GameObject.Find (moduleName);
					module = (YellowModuleManager)yellowModule.GetComponent (typeof(YellowModuleManager));

					click2.parsecPerProbe -= module.bonus;
					module.bonus *= upgradeBonusScale;
					module.bonusScale *= upgradeBonusScale;
					click2.parsecPerProbe += module.bonus;
				}

				yellowFactory = GameObject.Find ("FactoryManager");
				factory = (FactoryManager)yellowFactory.GetComponent (typeof(FactoryManager));

				factory.yellowProbes++;
				break;
			case 5:
				click.data -= cost;

				module.cost *= upgradeBonusScale;
				break;
			case 6:
				click.data -= cost;

				power.nivelPowerOne[2]++;
				power.nivelPowerTwo[2]++;
				power.nivelPowerThree[2]++;
				power.nivelPowerFour[2]++;
				power.nivelPowerFive[2]++;
				//Add Upgrade Skill
				break;
			}
			technology.SetYellow ();
			Destroy (transform.gameObject);
		} else {
			SoundManager.PlaySound ("purchaseDenied");
		}
	}
}
