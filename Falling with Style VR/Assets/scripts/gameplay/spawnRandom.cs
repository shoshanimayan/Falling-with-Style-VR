using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spawnRandom : MonoBehaviour
{
    //script only used in randomly generated level
    public GameObject prefab; //to spawn
    public cleanup death; // trigger for spawning next prefab once gone a certain distance
 
    // Start is called before the first frame update
   

    public void spawn() {
        Vector3 position = new Vector3(transform.parent.position.x, transform.parent.position.y-747, transform.parent.position.z); //spawn below
        death.next=Instantiate(prefab, position, transform.rotation); //add next var for death trigger
    }
}
