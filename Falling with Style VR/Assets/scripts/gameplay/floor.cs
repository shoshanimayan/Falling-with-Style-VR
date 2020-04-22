using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    public bool goal = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().hit(collision.transform.position);
            if (goal) {

                collision.gameObject.GetComponent<PlayerController>().win();

            }
        }
    }
}
