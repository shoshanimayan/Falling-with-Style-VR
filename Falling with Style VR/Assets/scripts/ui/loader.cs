using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// refactor to be part of game manger
/// </summary>
public class loader : MonoBehaviour
{
    public int level;

    public void LoadLevel() {
        SceneManager.LoadScene(level);
    }
}
