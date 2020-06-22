using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRotation : MonoBehaviour
{
    //TODO: combine all rotation scripts and modularize

    public float speed=10; // controls speed
    public Vector3 angle; //controls direction

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //if game has started
          if (!GameManager.play)
          {
            transform.Rotate(angle * speed * Time.deltaTime);
            }
        
    }
}
