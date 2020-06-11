using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] blocks;
    private bool randomized = false;
    public GameObject gateObject;
    public GameObject gateObject2;
    public GameObject gateObject3;
    private GameObject prefab;
    private GameObject[] gateList;
    private void Awake()
    {
        if (blocks.Length != 12) { Destroy(gameObject); }
        gateList = new GameObject[] { gateObject, gateObject2, gateObject3 };
      
    }
    private void Update()
    {
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
