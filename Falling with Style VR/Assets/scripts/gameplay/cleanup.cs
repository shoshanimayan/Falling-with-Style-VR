using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
//the **death** in spawnRandom, need to fix names, result of prototyping stage
public class cleanup : MonoBehaviour
{
    public GameObject next;
    public GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("rig");
    }
    public void clean() {
        //move everything up from current location so we never actually fall to far down, to avoid render problems that insued as result
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+745, player.transform.position.z);
        transform.parent.transform.position= new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y+745, transform.parent.transform.position.z);
        next.transform.position = new Vector3(next.transform.position.x, next.transform.position.y+745, next.transform.position.z);
        Destroy(transform.parent.gameObject,15);
    }
}
