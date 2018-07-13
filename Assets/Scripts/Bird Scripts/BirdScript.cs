using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{

	public static BirdScript instance;

	[SerializeField]
	private Rigidbody2D myRigidBody;

	[SerializeField]
	private Animator anim;

	private float forwardSpeed = 3f;

	private float bounceSpeed = 4f;

	private bool didFlap;

	public bool isAlive;

	private Button flapButton;

	[SerializeField]
	private AudioSource audioSC;
	[SerializeField]
	private AudioClip flapClip, pointClip, diedClip;

	public int score;

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}

		isAlive = true;

		flapButton = GameObject.FindGameObjectWithTag ("FlapButton").GetComponent<Button> ();
		flapButton.onClick.AddListener (() => FlapTheBird ());

		score = 0;
		SetCamerasX ();
	}

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void FixedUpdate ()
	{
		if (isAlive)
		{
			Vector3 temp = transform.position;
			temp.x += forwardSpeed * Time.deltaTime;
			transform.position = temp;
		}

		if (didFlap)
		{
			didFlap = false;
			audioSC.clip = flapClip;
			audioSC.Play ();

			myRigidBody.velocity = new Vector2 (0, bounceSpeed);
			anim.SetTrigger ("Flap");

		}

		if (myRigidBody.velocity.y >= 0)
		{
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
		else
		{
			float angle = 0;
			angle = Mathf.Lerp (0, -45, -myRigidBody.velocity.y / 7);
			//angle = Mathf.Lerp(0, -55, -myRigidBody.velocity.y / 7);
			//angle = Mathf.Lerp(0, -90, -myRigidBody.velocity.y / 7);
			transform.rotation = Quaternion.Euler (0, 0, angle);
		}
	}

	void SetCamerasX ()
	{
		CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
	}

	public float GetPositionX ()
	{
		return transform.position.x;
	}

	public void FlapTheBird ()
	{
		didFlap = true;
	}

	// unsetting the died anim trigger

	public void ResetPlayerState ()
	{
		anim.SetBool ("BirdDied", false);
		isAlive = true;
	}

	// on collison player died method

	void OnCollisionEnter2D (Collision2D target)
	{
		if (target.gameObject.tag == "Ground" || target.gameObject.tag == "Pipe")
		{
			if (isAlive)
			{
				isAlive = false;
				//anim.SetTrigger ("Bird Died");

				anim.SetBool ("BirdDied", true);

				audioSC.PlayOneShot (diedClip);

				// working with save me panel

				Vector3 temp = target.transform.position;

				temp.x = temp.x + 1.5f;
				temp.y = 1.5f;

				if (!GamePlayController.instance.isSaveMeUsed)
				{
					GamePlayController.instance.SaveMeMethod (score, temp);
				}
				else
				{
					// working with gameplay player died option

					GamePlayController.instance.PlayerDied (score);
				}

			}
		}
	}

	// on trigger player score method

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.tag == "PipeHolder")
		{
			score++;
			audioSC.PlayOneShot (pointClip);

			GamePlayController.instance.setScore (score);

			if (score >= 50 && score <= 100)
			{
				PipeCollector.instance.ManipulatingDistance (score);
			}
			else if (score >= 100 && score <= 150)
			{
				PipeCollector.instance.ManipulatingDistance (score);
			}
			else if (score >= 150 && score <= 200)
			{
				PipeCollector.instance.ManipulatingDistance (score);
			}
			else if (score >= 200 && score <= 250)
			{
				PipeCollector.instance.ManipulatingDistance (score);
			}
			else if (score > 250 && score <= 300)
			{
				PipeCollector.instance.ManipulatingDistance (score);
			}
			else if (score > 350 && score <= 400)
			{
				PipeCollector.instance.ManipulatingDistance (score);
			}
			else if (score > 400 && score <= 550)
			{
				PipeCollector.instance.ManipulatingDistance (score);
			}
			else if (score < 550)
			{
				PipeCollector.instance.ManipulatingDistance (score);
			}

		}
	}
}