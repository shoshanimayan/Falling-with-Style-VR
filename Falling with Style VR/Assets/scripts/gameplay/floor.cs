using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    //either causes player to lose or win if this floor is the goal
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
