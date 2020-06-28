using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    /// <summary>
    /// script to controller and costomuze the movement, speed and distance of spike traps
    /// </summary>
    // Start is called before the first frame update
    private GameObject player;
    private bool triggered=false;
    public float distanceFrom = 800;
    public float stopDistance =120;
    public float speed = 100;
    public bool debug = true; //to test trap behavior without having to start game
    public float x;
    void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.play || debug) 
        if (!triggered && (player.transform.position.y - transform.position.y <= distanceFrom))
        {
                if (transform.rotation.y != 0)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, transform.position.y, transform.position.z), Time.deltaTime * speed); ;
                    if (Vector3.Distance(transform.position, new Vector3(x, transform.position.y, transform.position.z)) < stopDistance)
                    {
                        triggered = true;
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, x), Time.deltaTime * speed); ;
                    if (Vector3.Distance(transform.position, new Vector3(transform.position.x, transform.position.y, x)) < stopDistance)
                    {
                        triggered = true;
                    }
                }
        }
     
    }

  
}
