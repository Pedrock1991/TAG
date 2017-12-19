using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ShopWindowManager : MonoBehaviour {

	#if UNITY_IOS
	private string gameId = "1564386";
	#elif UNITY_ANDROID
	private string gameId = "1564385";
	#endif

	[Header("Free")]
	public GameObject free;
	public GameObject freeMale;
	public GameObject freeFemale;
	[Header("+10")]
	public GameObject more10;
	public GameObject more10Male;
	public GameObject more10Female;
	[Header("+25")]
	public GameObject more25;
	public GameObject more25Male;
	public GameObject more25Female;
	[Header("+50")]
	public GameObject more50;
	public GameObject more50Male;
	public GameObject more50Female;
	[Header("+100")]
	public GameObject more100;
	public GameObject more100Male;
	public GameObject more100Female;
	[Header("+250")]
	public GameObject more250;
	public GameObject more250Male;
	public GameObject more250Female;
	
	void Start () {
		Advertisement.Initialize(gameId);
	}

	public void Free () {
		//Active Button
		free.SetActive (true);
		more10.SetActive (false);
		more25.SetActive (false);
		more50.SetActive (false);
		more100.SetActive (false);
		more250.SetActive (false);
		//Verify Genre
		if (GameManager.instance.GetGenreMale ()) {
			freeMale.SetActive (true);
			freeFemale.SetActive (false);
		}
		if (GameManager.instance.GetGenreFemale ()) {
			freeMale.SetActive (false);
			freeFemale.SetActive (true);
		}
	}

	public void More10 () {
		//Active Button
		free.SetActive (false);
		more10.SetActive (true);
		more25.SetActive (false);
		more50.SetActive (false);
		more100.SetActive (false);
		more250.SetActive (false);
		//Verify Genre
		if (GameManager.instance.GetGenreMale ()) {
			more10Male.SetActive (true);
			more10Female.SetActive (false);
		}
		if (GameManager.instance.GetGenreFemale ()) {
			more10Male.SetActive (false);
			more10Female.SetActive (true);
		}
	}

	public void More25 () {
		//Active Button
		free.SetActive (false);
		more10.SetActive (false);
		more25.SetActive (true);
		more50.SetActive (false);
		more100.SetActive (false);
		more250.SetActive (false);
		//Verify Genre
		if (GameManager.instance.GetGenreMale ()) {
			more25Male.SetActive (true);
			more25Female.SetActive (false);
		}
		if (GameManager.instance.GetGenreFemale ()) {
			more25Male.SetActive (false);
			more25Female.SetActive (true);
		}	
	}

	public void More50 () {
		//Active Button
		free.SetActive (false);
		more10.SetActive (false);
		more25.SetActive (false);
		more50.SetActive (true);
		more100.SetActive (false);
		more250.SetActive (false);
		//Verify Genre
		if (GameManager.instance.GetGenreMale ()) {
			more50Male.SetActive (true);
			more50Female.SetActive (false);
		}
		if (GameManager.instance.GetGenreFemale ()) {
			more50Male.SetActive (false);
			more50Female.SetActive (true);
		}
	}

	public void More100 () {
		//Active Button
		free.SetActive (false);
		more10.SetActive (false);
		more25.SetActive (false);
		more50.SetActive (false);
		more100.SetActive (true);
		more250.SetActive (false);
		//Verify Genre
		if (GameManager.instance.GetGenreMale ()) {
			more100Male.SetActive (true);
			more100Female.SetActive (false);
		}
		if (GameManager.instance.GetGenreFemale ()) {
			more100Male.SetActive (false);
			more100Female.SetActive (true);
		}
	}

	public void More250 () {
		//Active Button
		free.SetActive (false);
		more10.SetActive (false);
		more25.SetActive (false);
		more50.SetActive (false);
		more100.SetActive (false);
		more250.SetActive (true);
		//Verify Genre
		if (GameManager.instance.GetGenreMale ()) {
			more250Male.SetActive (true);
			more250Female.SetActive (false);
		}
		if (GameManager.instance.GetGenreFemale ()) {
			more250Male.SetActive (false);
			more250Female.SetActive (true);
		}
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
			GameManager.instance.SetGoldCoins (1);
		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");
		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}

}
