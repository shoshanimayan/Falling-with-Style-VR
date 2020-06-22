using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//todo refactor to be in gamemanager, this is from prototypes stages
public class QuitLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit() {
        if (SceneManager.GetActiveScene().buildIndex == 7) {
            if (GameManager.levelChart[SceneManager.GetActiveScene().buildIndex - 1] < GameManager.score)
                GameManager.levelChart[SceneManager.GetActiveScene().buildIndex - 1] = GameManager.score;
        }
        SceneManager.LoadScene(0);


    }
}
