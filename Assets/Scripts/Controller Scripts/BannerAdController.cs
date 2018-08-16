using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds;
using GoogleMobileAds.Android;
using GoogleMobileAds.Api;
using UnityEngine;

public class BannerAdController : MonoBehaviour
{
	public static BannerAdController instance;

	private BannerView bannerView;

	void Awake ()
	{
		MakeSingleton ();
	}

	// Use this for initialization
	void Start ()
	{
		string appId = "ca-app-pub-8350504222422488~9384849244";

		MobileAds.Initialize (appId);

		string adUnitId = "ca-app-pub-8350504222422488/8846627340";

		//this.showBannerAd (adUnitId);
	}

	/*
	 * It's singleton pattern in C# scripts
	 */

	void MakeSingleton ()
	{
		if (instance != null)
		{
			Destroy (gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	private void showBannerAd (string adUnitId)
	{
		//Create a custom ad size at the bottom of the screen

		AdSize adSize = new AdSize (250, 50);
		bannerView = new BannerView (adUnitId, adSize, AdPosition.Bottom);

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder ().Build ();

		// Load the banner with the request.
		bannerView.LoadAd (request);

	}

}