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
		
	void Start () {
		Advertisement.Initialize(gameId);
	}

	//public void DontShowRewardedVideo ()
	//{
	//	Destroy (transform.gameObject);
	//}

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
			//Add Gain
			Destroy (transform.gameObject);
		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");
			//Add Normal Gain
			Destroy (transform.gameObject);
		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
			//Add Normal Gain
			Destroy (transform.gameObject);
		}
	}
}
