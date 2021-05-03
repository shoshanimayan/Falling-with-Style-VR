using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool play = false; // is level started
    public static int score=0; //current score
    public static int[] levelChart = { 0, 0, 0, 0, 0, 0,0,0,0 }; //track scores for each level, need to either expand the array or use alt data struct in future
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
