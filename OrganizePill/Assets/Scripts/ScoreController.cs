using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor.Animations;

public class ScoreController : MonoBehaviour
{
    //Variables
    private int score;
    private bool IsAllLock = false;
    public List<Bottle> bottles;

    //Props

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayBottles();
        }
    }

    public void DisplayBottles()
    {
        for (int i = 0; i <= bottles.Count; i++)
            Debug.Log(bottles[i].gameObject.name + " This Bottle pill :: " + bottles[i].BottlePill);
    }





}
