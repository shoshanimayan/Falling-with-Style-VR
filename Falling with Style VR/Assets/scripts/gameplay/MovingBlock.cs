using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public int direction=1;
    public float distance=10;
    public float speed = 5;
    private Vector3 start;

    private void Awake()
    {
        start = transform.position;
    }
    void Update()
    {
        if(GameManager.play){
        if (Vector3.Distance(transform.position, start) < distance)
            transform.Translate(Vector3.left * direction * Time.deltaTime * speed);
        else {
            direction = direction * -1;
            start = transform.position;
        }
       }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
