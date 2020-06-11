using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	//controllers and headset
	public GameObject leftHand;
	public GameObject rightHand;
	public GameObject headNode;
	///player variables 
	private Rigidbody rb;
	private Vector3 vel;
	public float dropSpeed=-9.8f;
	private bool fall;
	private bool start = false;
	public GameObject menu;
	public Text message;
	public GameObject next;
	public GameObject quit;
	public GameObject retry;
	public GameObject speedLines;


	//sound
	public AudioSource AS;
	public AudioClip wind;
	public AudioClip wind2;
	public AudioClip point;


	private void Awake()
	{
		//reset manager for level 
		GameManager.score = 0;
		GameManager.play = false;
		//set  variables
		leftHand.GetComponent<XRInteractorLineVisual>().lineLength = .5f;
		rightHand.GetComponent<XRInteractorLineVisual>().lineLength = .5f;
		rb = GetComponent<Rigidbody>();
		fall = false;
		//ui setup
		next.SetActive(false);
		quit.SetActive(false);
		retry.SetActive(false);
		message.text = "hit trigger to start";
		speedLines.SetActive(false);
		//velocity
		Vector3 vel = Vector3.zero;
		
	}
	public void win() {
		message.text = "Won!\n Score: "+GameManager.score.ToString();
		next.SetActive(true);
		if (GameManager.levelChart[SceneManager.GetActiveScene().buildIndex-1] < GameManager.score)
			GameManager.levelChart[SceneManager.GetActiveScene().buildIndex-1] = GameManager.score;


	}
	public void ScoreIncrement(int x) {
	

		GameManager.score += x;
		AS.PlayOneShot(point);
	}

	public void hit(Vector3 position) {
		GameManager.play = false;
		AS.Pause();
		if (fall) {
		
			speedLines.SetActive(false);
			rb.isKinematic = true;
			fall = false;
			rb.velocity = Vector3.zero;
			transform.position = new Vector3(position.x,position.y+2,position.z);
			menu.SetActive(true);
			next.SetActive(false);
			quit.SetActive(true);
			retry.SetActive(true);
			leftHand.GetComponent<XRInteractorLineVisual>().lineLength = 10;
			rightHand.GetComponent<XRInteractorLineVisual>().lineLength = 10;
			message.text = "Lose!";
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "red") { ScoreIncrement(100); }
		if (other.gameObject.tag == "green") { ScoreIncrement(50); }
		if (other.gameObject.tag == "blue") { ScoreIncrement(10); }

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "red") { ScoreIncrement(100); }
		if (other.gameObject.tag == "green") { ScoreIncrement(50); }
		if (other.gameObject.tag == "blue") { ScoreIncrement(10); }
		if (other.gameObject.tag == "random") { other.GetComponent<spawnRandom>().spawn(); }
		if (other.gameObject.tag == "cleanup") {
			other.GetComponent<cleanup>().clean();
		}

	}


	private void FixedUpdate()
	{
		if (start) //game has started
		{
			if (fall) //is falling
			{
				if (rb.velocity.y > -10)
					AS.clip = wind;
				else
					AS.clip = wind2;
				if (!AS.isPlaying)
					AS.Play();
				vel = Vector3.zero;
				Vector3 positionL = Vector3.zero;
				Vector3 positionR = Vector3.zero;
				Vector3 positionH = Vector3.zero;
				

				InputDevice handL = InputDevices.GetDeviceAtXRNode(leftHand.GetComponent<XRController>().controllerNode);
				InputDevice handR = InputDevices.GetDeviceAtXRNode(rightHand.GetComponent<XRController>().controllerNode);
				InputDevice head = InputDevices.GetDeviceAtXRNode(headNode.GetComponent<XRController>().controllerNode);
				handL.TryGetFeatureValue(CommonUsages.devicePosition, out positionL);
				handR.TryGetFeatureValue(CommonUsages.devicePosition, out positionR);
				head.TryGetFeatureValue(CommonUsages.devicePosition, out positionH);
			
				Vector3 headToRight = (positionR - positionH);
				Vector3 headToLeft = (positionL - positionH);
				float handDistance = Vector3.Distance(positionL, positionR);

				if (headToLeft.y > 0 && headToRight.y > 0)
				{
					vel += new Vector3(0, 0, 5);
					if (vel.z > 5)
						vel.z = 5;
				}
				else if (headToLeft.y <= -.6f && headToRight.y <= -.6f)
				{
					vel += new Vector3(0, 0, -5);
					if (vel.z < -5)
						vel.z = -5;

				}
				else
				{
					if (vel.z > 0) { vel.z -= .1f; }
					if (vel.z < 0) { vel.z += .1f; }
				}

				if (headToLeft.x > 0 && headToRight.x > 0)
				{
					vel += new Vector3(5, 0, 0);
					if (vel.x > 5)
						vel.x = 5;
				}
				else if (headToLeft.x < 0 && headToRight.x < 0)
				{
					vel += new Vector3(-5, 0, 0);
					if (vel.x < -5)
						vel.x = -5;
				}
				else
				{
					if (vel.x > 0) { vel.x -= .1f; }
					if (vel.x < 0) { vel.x += .1f; }
				}


				if (handDistance <= .1)
				{
					//vel = new Vector3(vel.x, -20, vel.z);
					dropSpeed -= .1f;
					if (dropSpeed < -30)
						dropSpeed = -30;
				}
				else if (handDistance >= 1)
				{
					//vel = new Vector3(vel.x, -3, vel.z);
					dropSpeed += .3f;
					if (dropSpeed > -3) {
						dropSpeed = -3;
					}
				}
				else
				{
					if (dropSpeed > -9.8)
						dropSpeed -= .1f;
					else if (dropSpeed < -9.8)
						dropSpeed += .2f;
					
					//vel = new Vector3(vel.x, -9.8f, vel.z);
					
				}
				vel = new Vector3(vel.x, dropSpeed, vel.z);
				rb.velocity = vel;
				if (vel.y <=-15)
					speedLines.SetActive(true);
				else
					speedLines.SetActive(false);
			}
		}
		else
		{

			bool triggerL = false;
			bool triggerR = false;

			InputDevice handL = InputDevices.GetDeviceAtXRNode(leftHand.GetComponent<XRController>().controllerNode);
			InputDevice handR = InputDevices.GetDeviceAtXRNode(rightHand.GetComponent<XRController>().controllerNode);
			handL.TryGetFeatureValue(CommonUsages.triggerButton, out triggerL);
			handR.TryGetFeatureValue(CommonUsages.triggerButton, out triggerR);
			if (triggerL || triggerR)
			{
				start = true;
				fall = true;
				GameManager.play = true;
				menu.SetActive(false);

			}

		}
	}
}