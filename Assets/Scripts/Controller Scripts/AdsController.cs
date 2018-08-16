using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AdsController : MonoBehaviour
{
	public static AdsController instance;

	private const string sdkKey = "qiFqtOsRnqkTh_avcvzgl4ebU7MvHOn661wzPmOAZ7kG6JAkC7PyC2TgAvaRILTOMSMnCmyntf1-zBhAJ57W8f";

	void Awake ()
	{
		MakeSingleton ();
	}

	// Use this for initialization
	void Start ()
	{
		AppLovin.SetSdkKey(sdkKey);
		AppLovin.InitializeSdk ();

		AppLovin.SetUnityAdListener (this.gameObject.name);
		LoadRewardVideo ();
		StartCoroutine(callBanner());
	}

	IEnumerator callBanner()
	{
		yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(3f));

		AppLovin.SetAdWidth(250);
		AppLovin.ShowAd(AppLovin.AD_POSITION_CENTER, AppLovin.AD_POSITION_BOTTOM);
	}

	void MakeSingleton ()
	{
		if (instance != null)
		{
			Destroy (gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad (instance);
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void LoadRewardVideo ()
	{
		AppLovin.LoadRewardedInterstitial ();
	}

	public void ShowRewardVideo ()
	{
		AppLovin.ShowRewardedInterstitial ();
	}

	void onAppLovinEventReceived (string ev)
	{
		if (ev.Contains ("REWARDAPPROVEDINFO"))
		{

			// The format would be "REWARDAPPROVEDINFO|AMOUNT|CURRENCY" so "REWARDAPPROVEDINFO|10|Coins" for example
			//string delimeter = "|";

			// Split the string based on the delimeter
			//string[] split = ev.Split (delimeter);

			// Pull out the currency amount
			//double amount = double.Parse (split[1]);

			// Pull out the currency name
			//string currencyName = split[2];

			// Do something with the values from above.  For example, grant the coins to the user.
			//updateBalance (amount, currencyName);

			int gem_score = GameController.instance.GetGemScore ();

			gem_score++;

			GameController.instance.SetGemScore (gem_score);
		}
		else if (ev.Contains ("LOADEDREWARDED"))
		{
			// A rewarded video was successfully loaded.
		}
		else if (ev.Contains ("LOADREWARDEDFAILED"))
		{
			// A rewarded video failed to load.
			LoadRewardVideo ();
		}
		else if (ev.Contains ("HIDDENREWARDED"))
		{
			// A rewarded video was closed.  Preload the next rewarded video.
			//AppLovin.LoadRewardedInterstitial ();
			LoadRewardVideo ();
		}
	}
}