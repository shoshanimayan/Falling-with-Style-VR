using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate2 : MonoBehaviour
{
    //TODO: combine all rotation scripts and modularize
    public int direction = 1;
    public int speed = 50;
    void Update()
    {
        if (GameManager.play)
            transform.Rotate(direction * speed * Time.deltaTime, 0, 0); //rotates 50 degrees per second around z axis
    }
}
