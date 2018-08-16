using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds;
using GoogleMobileAds.Android;
using GoogleMobileAds.Api;
using UnityEngine;

public class RewardAdController : MonoBehaviour
{
	private RewardBasedVideoAd rewardVideoAd;

	private float deltaTime = 0.0f;

	// Use this for initialization
	void Start ()
	{
		string appId = "ca-app-pub-8350504222422488~7708154151";

		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize (appId);

		// Get singleton reward based video ad reference.
		this.rewardVideoAd = RewardBasedVideoAd.Instance;

		// Called when an ad request has successfully loaded.
		rewardVideoAd.OnAdLoaded += HandleRewardBasedVideoLoaded;

		// Called when an ad request failed to load.
		rewardVideoAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;

		// Called when an ad is shown.
		rewardVideoAd.OnAdOpening += HandleRewardBasedVideoOpened;

		// Called when the ad starts to play.
		rewardVideoAd.OnAdStarted += HandleRewardBasedVideoStarted;

		// Called when the user should be rewarded for watching a video.
		rewardVideoAd.OnAdRewarded += HandleRewardBasedVideoRewarded;

		// Called when the ad is closed.
		rewardVideoAd.OnAdClosed += HandleRewardBasedVideoClosed;

		// Called when the ad click caused the user to leave the application.
		rewardVideoAd.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

		this.RequestRewardBasedVideo ();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void ShowTheAdd ()
	{
		if (this.rewardVideoAd.IsLoaded ())
		{
			this.rewardVideoAd.Show ();
		}
		else
		{
			MonoBehaviour.print ("Reward based video ad is not ready yet");
		}

	}

	private void RequestRewardBasedVideo ()
	{
		string adUnitId = "ca-app-pub-8350504222422488/7241250290";

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder ().Build ();

		// Load the rewarded video ad with the request.
		this.rewardVideoAd.LoadAd (request, adUnitId);
	}

	/*
		Event Handlers
	*/

	public void HandleRewardBasedVideoLoaded (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoLoaded event received");
	}

	public void HandleRewardBasedVideoFailedToLoad (object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print (
			"HandleRewardBasedVideoFailedToLoad event received with message: " +
			args.Message);
		//this.RequestRewardBasedVideo ();
	}

	public void HandleRewardBasedVideoOpened (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoOpened event received");
	}

	public void HandleRewardBasedVideoStarted (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosed (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoClosed event received");

		this.RequestRewardBasedVideo ();

	}

	public void HandleRewardBasedVideoRewarded (object sender, Reward args)
	{
		

		int gem_score = GameController.instance.GetGemScore();

		gem_score++;

		GameController.instance.SetGemScore(gem_score);

	}

	public void HandleRewardBasedVideoLeftApplication (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoLeftApplication event received");
	}
}