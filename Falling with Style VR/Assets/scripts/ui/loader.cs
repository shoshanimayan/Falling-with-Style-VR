using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loader : MonoBehaviour
{
    public int level;

    public void LoadLevel() {
        SceneManager.LoadScene(level);
    }
}
