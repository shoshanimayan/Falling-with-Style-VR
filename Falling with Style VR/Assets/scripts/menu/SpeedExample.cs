using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
public class SpeedExample : MonoBehaviour
{

    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject headNode;
    public Text speed;
    public Text directionX;
    public Text directionZ;

    // Start is called before the first frame update
    void Awake()
    {
		speed.text = "";
		directionX.text = "";
		directionZ.text = "";
    }

    // Update is called once per frame
    void Update()
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
		//z direction
		if (headToLeft.y > 0 && headToRight.y > 0)
		{
			directionZ.text = "up";

		}
		else if (headToLeft.y <= -.6f && headToRight.y <= -.6f)
		{
			directionZ.text = "down";


		}
		else
		{
			directionZ.text = "not up or down";
		}



		//x direction
		if (headToLeft.x > 0 && headToRight.x > 0)
		{
			directionX.text = "right";

		}
		else if (headToLeft.x < 0 && headToRight.x < 0)
		{
			directionX.text = "left";

		}
		else
		{
			directionX.text = "not left or right";
		}



		if (handDistance <= .1)
		{
            speed.text = "accelerating fall";
		}
		else if (handDistance >= 1)
		{
            speed.text = "breaking fall";
        }
		else
		{
            speed.text = "normal fall";


		}

	}
}
