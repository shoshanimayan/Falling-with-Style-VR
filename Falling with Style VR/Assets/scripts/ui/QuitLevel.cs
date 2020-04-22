using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public QuitLevel() {
        SceneManager.LoadScene(0);


    }
}
