using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject[] levels;
    private void Awake()
    {
        for (int i = 1; i < levels.Length; i++) {
            if (GameManager.levelChart[i - 1] <= 0)
                levels[i].SetActive(false);
            else
                Debug.Log(i);
        }
    }

}
