using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class NextLevel : MonoBehaviour
{
    public void Next() {
        if(SceneManager.GetActiveScene().buildIndex<5)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        else
            SceneManager.LoadScene(0);


    }
}
