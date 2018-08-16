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

	// Use this for initialization
	void Start ()
	{
		string appId = "ca-app-pub-8350504222422488~7708154151";

		MobileAds.Initialize (appId);

		string adUnitId = "ca-app-pub-8350504222422488/6121177109";

		//this.showBannerAd (adUnitId);
	}

	// Update is called once per frame
	void Update ()
	{

	}
}