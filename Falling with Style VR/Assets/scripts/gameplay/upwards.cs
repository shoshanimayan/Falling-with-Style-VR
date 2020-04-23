using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upwards : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
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
