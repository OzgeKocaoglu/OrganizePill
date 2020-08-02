using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor.Animations;

public class ScoreController : MonoBehaviour
{
    //Variables
    private int score;

    //Props
    public int Score
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

    //Functions
    public void AddCoin(int amoint)
    {
        score += amoint;
    }
    public void MinusCoin(int amount)
    {
        score -= amount;
    }




}
