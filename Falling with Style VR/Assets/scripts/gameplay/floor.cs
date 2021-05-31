using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    //either causes player to lose or win if this floor is the goal

    //todo:
    //going forward when i want to introduce a new type of obsticle with different behavior it would probably be better to make floor something a new class inherits 
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
