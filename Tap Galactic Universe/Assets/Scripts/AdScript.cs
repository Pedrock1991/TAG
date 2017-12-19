using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdScript : MonoBehaviour {

	#if UNITY_IOS
	private string gameId = "1564386";
	#elif UNITY_ANDROID
	private string gameId = "1564385";
	#endif

	public bool reward;
	public byte type;
	public byte powerNumber;

	public GreenClick green;
	public GameObject greenClick;
	public AlienManager alien;
	public GameObject alienManager;
	public PowerManager power;
	public GameObject powerManager;
	public BigNumbers formatter;
	public GameObject bigNumbers;

	public GameObject adRewardPrefab;
	public GameObject resetCard;
	public Text RewardName;
	public Text RewardDescribe;


	public Text adName;
	public Text adDescribe;
	public Text adNormalButton;
	public Text adBoosterButton;
	public AdScript ad;
	public GameObject adManager;

	// Use this for initialization
	void Start () {
		Advertisement.Initialize(gameId);

		greenClick = GameObject.Find ("GreenClick");
		green = (GreenClick)greenClick.GetComponent (typeof(GreenClick));

		alienManager = GameObject.Find ("AlienManager");
		alien = (AlienManager)alienManager.GetComponent (typeof(AlienManager));

		powerManager = GameObject.Find ("PowerManager");
		power = (PowerManager)powerManager.GetComponent (typeof(PowerManager));

		bigNumbers = GameObject.Find ("BigNumbers");
		formatter = (BigNumbers)bigNumbers.GetComponent (typeof(BigNumbers));

		powerNumber = (byte)Random.Range (1, 6);

		//Debug.Log (gameObject.transform.position.x);
	}

	void Update () {
		switch (type) {
		case 1: //Artifact
			adName.text = "Artifact Found";
			adDescribe.text = "Our probe discovered an alien artifact";
			adNormalButton.text = "Receive\n" + formatter.FormatNumber (green.dataPerProbe * 100);
			adBoosterButton.text = "Receive\n" + formatter.FormatNumber (green.dataPerProbe * 1000);

			RewardName.text = "Artifact Boosted";
			RewardDescribe.text = "Received" + formatter.FormatNumber (green.dataPerProbe * 1000);
			break;
		case 2: //UnknowStone
			adName.text = "Unknow Stone";
			adDescribe.text = "Our probe discovered fragments of the galaxy";
			adNormalButton.text = "Receiven\n1 unknow Stone";
			adBoosterButton.text = "Receive\n5 unknow Stone";

			RewardName.text = "Unknow Stone Boosted";
			RewardDescribe.text = "Received\n5 unknow Stone";
			break;
		case 3: //Power Active
			switch (powerNumber) {
			case 1:
				adName.text = "Green Quick Probe";
				adDescribe.text = "Our probe discovered core of green quick probe";
				adNormalButton.text = "Active Power";
				adBoosterButton.text = "Active Power\nx2";

				RewardName.text = "Quick Probe Boosted";
				RewardDescribe.text = "Actived Power\nx2";
				break;
			case 2:
				adName.text = "Probe Supercharge";
				adDescribe.text = "Our probe discovered core of green Probe Supercharge";
				adNormalButton.text = "Active Power\n10 seconds";
				adBoosterButton.text = "Active Power\n30 seconds";

				RewardName.text = "Probe Supercharge Boosted";
				RewardDescribe.text = "Actived Power by\n30 seconds";
				break;
			case 3:
				adName.text = "Factory SuperCharge";
				adDescribe.text = "Our probe discovered core of green Factory Supercharge";
				adNormalButton.text = "Active Power\n10 seconds";
				adBoosterButton.text = "Active Power\n30 seconds";

				RewardName.text = "Factory SuperCharge Boosted";
				RewardDescribe.text = "Actived Power by\n30 seconds";
				break;
			case 4:
				adName.text = "Tap Stack Chance";
				adDescribe.text = "Our probe discovered core of green Tap Stack Chance";
				adNormalButton.text = "Active Power\n10 seconds";
				adBoosterButton.text = "Active Power\n30 seconds";

				RewardName.text = "Tap Stack Chance Boosted";
				RewardDescribe.text = "Actived Power by\n30 seconds";
				break;
			case 5:
				adName.text = "Tap Supercharge";
				adDescribe.text = "Our probe discovered core of green Tap Supercharge";
				adNormalButton.text = "Active Power 5\n10 seconds";
				adBoosterButton.text = "Active Power 5\n30 seconds";

				RewardName.text = "Tap Supercharg Boosted";
				RewardDescribe.text = "Actived Power by\n30 seconds";
				break;
			}
			break;
		}
		RectTransform myRectTransform = transform.GetComponent<RectTransform> ();
		myRectTransform.localPosition = Vector3.zero;
	}

	public void DontShowRewardedVideo ()
	{
		switch (type) {
		case 1: //Artefact
			green.data += green.dataPerProbe*100;
			break;
		case 2: //UnknowStone
			alien.unknowStone += 1;
			break;
		case 3: //Power Active
			switch (powerNumber) {
			case 1:
				green.data += ((green.dataPerProbe * 100) * power.nivelPowerOne[0]);
				break;
			case 2:
				power.timePowerTwo = 10;
				power.activeGreenPowerTwo = true;
				break;
			case 3:
				power.timePowerThree = 10;
				power.activeGreenPowerThree = true;
				break;
			case 4:
				power.timePowerFour = 10;
				power.activeGreenPowerFour = true;
				break;
			case 5:
				power.timePowerFive = 10;
				power.activeGreenPowerFive = true;
				break;
			}
			break;
		}
		Destroy (transform.gameObject);
	}

	public void ShowRewardedVideo ()
	{
		reward = false;
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show("rewardedVideo", options);
	}

	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			Debug.Log("Video completed - Offer a reward to the player");
			reward = true;
			switch (type) {
			case 1: //Artefact
				MakeCard ();
				green.data += green.dataPerProbe*1000;
				break;
			case 2: //UnknowStone
				MakeCard ();
				alien.unknowStone += 5;
				break;
			case 3: //Power Active
				switch (powerNumber) {
				case 1:
					MakeCard ();
					green.data += ((green.dataPerProbe * 100) * power.nivelPowerOne[0]);
					green.data += ((green.dataPerProbe * 100) * power.nivelPowerOne[0]);
					break;
				case 2:
					MakeCard ();
					power.timePowerTwo = 30;
					power.activeGreenPowerTwo = true;
					break;
				case 3:
					MakeCard ();
					power.timePowerThree = 30;
					power.activeGreenPowerThree = true;
					break;
				case 4:
					MakeCard ();
					power.timePowerFour = 30;
					power.activeGreenPowerFour = true;
					break;
				case 5:
					MakeCard ();
					power.timePowerFive = 30;
					power.activeGreenPowerFive = true;
					break;
				}
				break;
			}
			Destroy (transform.gameObject);
		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");
			reward = false;
			switch (type) {
			case 1: //Artefact
				green.data += green.dataPerProbe*100;
				break;
			case 2: //UnknowStone
				alien.unknowStone += 1;
				break;
			case 3: //Power Active
				switch (powerNumber) {
				case 1:
					green.data += ((green.dataPerProbe * 100) * power.nivelPowerOne[0]);
					break;
				case 2:
					power.timePowerTwo = 10;
					power.activeGreenPowerTwo = true;
					break;
				case 3:
					power.timePowerThree = 10;
					power.activeGreenPowerThree = true;
					break;
				case 4:
					power.timePowerFour = 10;
					power.activeGreenPowerFour = true;
					break;
				case 5:
					power.timePowerFive = 10;
					power.activeGreenPowerFive = true;
					break;
				}
				break;
			}
			Destroy (transform.gameObject);
		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
			reward = false;
			switch (type) {
			case 1: //Artefact
				green.data += green.dataPerProbe*100;
				break;
			case 2: //UnknowStone
				alien.unknowStone += 1;
				break;
			case 3: //Power Active
				switch (powerNumber) {
				case 1:
					green.data += ((green.dataPerProbe * 100) * power.nivelPowerOne[0]);
					break;
				case 2:
					power.timePowerTwo = 10;
					power.activeGreenPowerTwo = true;
					break;
				case 3:
					power.timePowerThree = 10;
					power.activeGreenPowerThree = true;
					break;
				case 4:
					power.timePowerFour = 10;
					power.activeGreenPowerFour = true;
					break;
				case 5:
					power.timePowerFive = 10;
					power.activeGreenPowerFive = true;
					break;
				}
				break;
			}
			Destroy (transform.gameObject);
		}
	}

	void MakeCard () {
		GameObject go;

		go = Instantiate (adRewardPrefab) as GameObject;
		go.transform.SetParent (GameObject.Find ("Game Assets").transform);

		RectTransform myRectTransform = go.transform.GetComponent<RectTransform> ();
		myRectTransform.localPosition = Vector3.zero;

		adManager = GameObject.Find ("AdReward(Clone)");
		ad = (AdScript)adManager.GetComponent (typeof(AdScript));
		ad.type = type;
	}

	public void DestroyCard () {
		Destroy (transform.gameObject);
	}
}
