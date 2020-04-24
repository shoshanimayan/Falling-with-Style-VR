using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public int direction=1;
    void Update()
    {
        if(GameManager.play)
            transform.Rotate(0, direction*50 * Time.deltaTime, 0); //rotates 50 degrees per second around z axis
    }
}
