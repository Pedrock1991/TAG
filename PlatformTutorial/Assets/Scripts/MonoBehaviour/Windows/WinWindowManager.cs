using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class WinWindowManager : MonoBehaviour {

	#if UNITY_IOS
	private string gameId = "1564386";
	#elif UNITY_ANDROID
	private string gameId = "1564385";
	#endif

	public Text timeDisplay;
	public Text goldCoinCounter;
	public Text silverCoinCounter;
	public Text copperCoinCounter;

	private Timer timer;
	private LevelManager LM;

	private int timeLeft;

	private int goldCoinReward;
	private int silverCoinReward;
	private int copperCoinReward;
	private int totalReward;
	private bool timeToReward = true;

	public string planet;
	public string level;

	void Start () {
		Advertisement.Initialize(gameId);
		timer = FindObjectOfType <Timer> ();
		timeLeft = (int) timer.time;
		totalReward = timer.timer * 50;

		//Check reward
		copperCoinReward = totalReward;
		if (copperCoinReward > 100){
			silverCoinReward = copperCoinReward / 100;
			copperCoinReward %= 100;
		}
		if (silverCoinReward > 100) {
			goldCoinReward = silverCoinReward / 100;
			silverCoinReward %= 100;
		}

		//Complete Level
		planet = SceneManager.GetActiveScene ().name.Substring(0, 1);
		level = SceneManager.GetActiveScene ().name.Substring(2, 1);

		GameManager.instance.SetGalaxy1LevelCompleted (int.Parse(planet), (int.Parse(level)+1));
	}
	
	void Update () {
		timeDisplay.text = timeLeft.ToString ();
		copperCoinCounter.text = copperCoinReward.ToString ();
		silverCoinCounter.text = silverCoinReward.ToString ();
		goldCoinCounter.text = goldCoinReward.ToString ();
		if (timeToReward && timeLeft > 0) {
			timeLeft--;
			silverCoinReward++;
			if (silverCoinReward > 100) {
				goldCoinReward = silverCoinReward / 100;
				silverCoinReward %= 100;
			}
			timeToReward = false;
		} else {
			timeToReward = true;
		}
	}

	public void Go () {
		Time.timeScale = 1;
		GameManager.instance.SetLoadingScene (GameManager.instance.GetActualPlanet ());

		GameManager.instance.SetCooperCoins (copperCoinReward);
		GameManager.instance.SetSilverCoins (silverCoinReward);
		GameManager.instance.SetGoldCoins (goldCoinReward);

		SceneManager.LoadScene ("LoadingScreen");
	}

	public void doubleReward () {
		Time.timeScale = 1;
		ShowRewardedVideo ();
	}

	public void ShowRewardedVideo ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show("rewardedVideo", options);
	}

	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			Debug.Log("Video completed - Offer a reward to the player");
			GameManager.instance.SetLoadingScene (GameManager.instance.GetActualPlanet ());

			GameManager.instance.SetCooperCoins (copperCoinReward*2);
			GameManager.instance.SetSilverCoins (silverCoinReward*2);
			GameManager.instance.SetGoldCoins (goldCoinReward*2);

			SceneManager.LoadScene ("LoadingScreen");
			Destroy (transform.gameObject);
		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");
			GameManager.instance.SetLoadingScene (GameManager.instance.GetActualPlanet ());

			GameManager.instance.SetCooperCoins (copperCoinReward);
			GameManager.instance.SetSilverCoins (silverCoinReward);
			GameManager.instance.SetGoldCoins (goldCoinReward);

			SceneManager.LoadScene ("LoadingScreen");
			Destroy (transform.gameObject);
		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
			GameManager.instance.SetLoadingScene (GameManager.instance.GetActualPlanet ());

			GameManager.instance.SetCooperCoins (copperCoinReward);
			GameManager.instance.SetSilverCoins (silverCoinReward);
			GameManager.instance.SetGoldCoins (goldCoinReward);

			SceneManager.LoadScene ("LoadingScreen");
			Destroy (transform.gameObject);
		}
	}
}
