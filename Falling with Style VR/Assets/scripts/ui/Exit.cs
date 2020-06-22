using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//refactor as part of game manager
public class Exit : MonoBehaviour
{
    public void End() {
        Application.Quit();
    }
}
