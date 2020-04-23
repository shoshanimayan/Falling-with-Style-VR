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
	private bool fall;
	private bool start = false;
	public GameObject menu;
	public Text message;
	public GameObject next;
	public GameObject quit;
	public GameObject retry;
	public GameObject speedLines;
	private void Awake()
	{
	
		//reset manager for level 
		GameManager.score = 0;
		GameManager.play = false;
		//set  variables
		leftHand.GetComponent<XRInteractorLineVisual>().lineLength = 1;
		rightHand.GetComponent<XRInteractorLineVisual>().lineLength = 1;
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
	}

	public void hit(Vector3 position) {
		GameManager.play = false;

		if (fall) {
			speedLines.SetActive(false);
			rb.isKinematic = true;
			fall = false;
			rb.velocity = Vector3.zero;
			transform.parent.transform.rotation = Quaternion.Euler(0, 0, 0);
			transform.position = new Vector3(position.x,position.y+1,position.z);
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
	}


	private void FixedUpdate()
	{
		if (start)
		{
			if (fall)
			{
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
					vel += new Vector3(0, 0, 1);
					if (vel.z > 5)
						vel.z = 5;
				}
				else if (headToLeft.y <= -.6f && headToRight.y <= -.6f)
				{
					vel += new Vector3(0, 0, -1);
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
					vel += new Vector3(1, 0, 0);
					if (vel.x > 5)
						vel.x = 5;
				}
				else if (headToLeft.x < 0 && headToRight.x < 0)
				{
					vel += new Vector3(-1, 0, 0);
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
					vel = new Vector3(vel.x, -20, vel.z);
				}
				else if (handDistance >= 1)
				{
					vel = new Vector3(vel.x, -3, vel.z);

				}
				else
				{
					vel = new Vector3(vel.x, -9.8f, vel.z);

				}
				
				rb.velocity = vel;
				if (vel.y == -20)
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