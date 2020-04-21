using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public GameObject leftHand;
	public GameObject rightHand;
	public GameObject headNode;
	private Rigidbody rb;
	private Vector3 prev;
	private Vector3 vel;
	public float thrust = 2;
	private bool fall;
	public GameObject menu;

	private void Awake()
	{
		leftHand.GetComponent<XRInteractorLineVisual>().lineLength = 1;
		rightHand.GetComponent<XRInteractorLineVisual>().lineLength = 1;

		rb = GetComponent<Rigidbody>();
		prev = Vector3.zero;
		Vector3 vel = Vector3.zero;
		fall = true;
		menu.SetActive(false);
	}
	public void hit(Vector3 position) {
		if (fall) {
			rb.isKinematic = true;
		fall = false;
		rb.velocity = Vector3.zero;
		transform.parent.transform.rotation = Quaternion.Euler(0, 0, 0);
			transform.position = new Vector3(position.x,position.y+1,position.z);
			menu.SetActive(true);
			leftHand.GetComponent<XRInteractorLineVisual>().lineLength = 10;
			rightHand.GetComponent<XRInteractorLineVisual>().lineLength = 10;
		}
	}
	private void FixedUpdate()
	{

		if (fall)
		{
			bool triggerL = false;
			Vector3 positionL = Vector3.zero;


			bool triggerR = false;
			Vector3 positionR = Vector3.zero;



			Vector3 positionH = Vector3.zero;

			//1. Collect controller data
			InputDevice handL = InputDevices.GetDeviceAtXRNode(leftHand.GetComponent<XRController>().controllerNode);
			InputDevice handR = InputDevices.GetDeviceAtXRNode(rightHand.GetComponent<XRController>().controllerNode);
			InputDevice head = InputDevices.GetDeviceAtXRNode(headNode.GetComponent<XRController>().controllerNode);

			handL.TryGetFeatureValue(CommonUsages.triggerButton, out triggerL);
			handL.TryGetFeatureValue(CommonUsages.devicePosition, out positionL);


			handR.TryGetFeatureValue(CommonUsages.triggerButton, out triggerR);
			handR.TryGetFeatureValue(CommonUsages.devicePosition, out positionR);


			head.TryGetFeatureValue(CommonUsages.devicePosition, out positionH);

			Vector3 headToRight = (positionR - positionH);
			Vector3 headToLeft = (positionL - positionH);
			float handDistance = Vector3.Distance(positionL, positionR);

			if (headToLeft.y > 0 && headToRight.y > 0)
			{
				//rb.AddForce(new Vector3(0,0,1)*thrust);
				vel += new Vector3(0, 0, 1);
				if (vel.z > 5)
					vel.z = 5;
			}
			else if (headToLeft.y <= -.6f && headToRight.y <= -.6f)
			{
				//rb.AddForce(new Vector3(0, 0, -1) * thrust);
				vel += new Vector3(0, 0, -1);
				if (vel.z < -5)
					vel.z = -5;

			}
			else
			{
				if (vel.z > 0) { vel.z -= 0; }
				if (vel.z < 0) { vel.z += 0; }
			}

			if (headToLeft.x > 0 && headToRight.x > 0)
			{
				//rb.AddForce(new Vector3(1, 0, 0) * thrust);
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
				if (vel.x > 0) { vel.x -= 0; }
				if (vel.x < 0) { vel.x += 0; }
			}


			if (handDistance <= .1)
			{// Physics.gravity=new Vector3(0, -10, 0);
				vel = new Vector3(vel.x, -20, vel.z);
			}
			else if (handDistance >= 1)
			{// Physics.gravity=new Vector3(0, 0, 0);
				vel = new Vector3(vel.x, -3, vel.z);

			}
			else
			{ //Physics.gravity = new Vector3(0, 0, 0); 
				vel = new Vector3(vel.x, -9.8f, vel.z);

			}
			rb.velocity = vel;




		}
	}
}