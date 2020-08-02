using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor.Animations;

public class ScoreController : MonoBehaviour
{
    //Variables
    private static int score;

    //Props
    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            if(value != 0)
            {
                score = value;
            }
        }
    }

    //Unity Funcs
    private void Awake()
    {
        score = 0;
    }




}
