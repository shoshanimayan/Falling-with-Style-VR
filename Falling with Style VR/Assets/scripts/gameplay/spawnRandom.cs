using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spawnRandom : MonoBehaviour
{
    public GameObject prefab;
    public cleanup death;
 
    // Start is called before the first frame update
   

    public void spawn() {
        Vector3 position = new Vector3(transform.parent.position.x, transform.parent.position.y-747, transform.parent.position.z);
        death.next=Instantiate(prefab, position, transform.rotation);
    }
}
