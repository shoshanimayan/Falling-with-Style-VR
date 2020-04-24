using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] blocks;
    private void Awake()
    {
        if (blocks.Length != 12) { Destroy(gameObject); }
        int numberOff = Random.Range(1, 12);
        int count=0;
        while (count != numberOff) {
            foreach (GameObject block in blocks) {
                if (count < numberOff)
                {
                    if (Random.Range(1, 10) % 2 == 0)
                    {
                        block.SetActive(false);
                        count++;
                    }
                }
                else { break; }
            }
                
        }
    }

}
