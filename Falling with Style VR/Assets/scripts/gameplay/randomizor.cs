using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used for randomization of which panels will be active and where rings spawn, only for use in random generation level
public class randomizor : MonoBehaviour
{
    //array of block objects childed
    public GameObject[] blocks;
    private bool randomized = false;

    // score gates
    public GameObject gateObject;
    public GameObject gateObject2;
    public GameObject gateObject3;
    //selected gate
    private GameObject prefab;
    //list of all gates
    private GameObject[] gateList;
    private void Awake()
    {
        if (blocks.Length != 12) { Destroy(gameObject); }
        gateList = new GameObject[] { gateObject, gateObject2, gateObject3 };
      
    }
    private void Update()
    {
        //on frame one randomize the object
        //todo refactor to be on start instead of in update
        if (!randomized && GameManager.play)
        {

            int numberOff = Random.Range(1, 6);
            int count = 0;
            bool gate = false;

            while (count != numberOff)
            {
                foreach (GameObject block in blocks)
                {
                    if (count < numberOff)
                    {
                        if (Random.Range(1, 100) % 2 == 0)
                        {
                            block.SetActive(false);
                            if (!gate && Random.Range(count,numberOff)%2==0) {
                                prefab = gateList[Random.Range(0, 3)];
                                Instantiate(prefab, block.transform.position, block.transform.rotation).transform.parent=transform;
                                gate = true;
                            }
                            count++;
                        }
                    }
                    else { break; }
                }

            }
            randomized = true;
        }
    }

}
