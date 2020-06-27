using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private bool triggered=false;
    public float speed=1;
    public float x;
    void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!triggered && (player.transform.position.y - transform.position.y <= 800))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, transform.position.y, transform.position.z), Time.deltaTime*100); ;
            if (Vector3.Distance(transform.position, new Vector3(x, transform.position.y, transform.position.z))<120){
                triggered = true;
            }

        }
        /* 
         if (!triggered && (player.transform.position.y - transform.position.y <= 800)) {
             triggered = true;
             ActivateTrap(Time.time);
        }
         if (triggered && !(transform.position.x <= 0)) {
             transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, transform.position.z), 1); ;
         }*/
    }

  
}
