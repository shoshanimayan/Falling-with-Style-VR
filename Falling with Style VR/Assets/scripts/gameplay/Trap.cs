using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private bool triggered=false;

    public float speed=1;
    void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!triggered && (player.transform.position.y - transform.position.y <= 800)) {
            triggered = true;
            ActivateTrap(Time.time);
       }
        if (triggered && !(transform.position.x <= 0)) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, transform.position.z), 1); ;
        }
    }

    public void ActivateTrap(float timeStarted, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStarted;
        float percentComplete = timeSinceStarted / lerpTime;
        transform.position = Vector3.Lerp(transform.position,new Vector3(0,transform.position.y, transform.position.z),percentComplete);

    }
}
