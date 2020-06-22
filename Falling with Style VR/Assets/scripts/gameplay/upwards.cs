using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upwards : MonoBehaviour
{
  // todo: combine all movement scripts, make more modular
    void Update()
    {
        if(GameManager.play)
            transform.Translate(Vector3.up*Time.deltaTime*10);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
