using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spawnRandom : MonoBehaviour
{
    public GameObject prefab;
    private void Awake()
    {
       // spawn();
    }
    // Start is called before the first frame update
   

    public void spawn() {
        Vector3 position = new Vector3(transform.parent.position.x, transform.parent.position.y-745, transform.parent.position.z);
        Instantiate(prefab, position, transform.rotation);
    }
}
