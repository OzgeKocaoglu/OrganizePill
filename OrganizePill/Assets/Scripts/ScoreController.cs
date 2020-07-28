using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor.Animations;

public class ScoreController : MonoBehaviour
{
    private int PL1 = 0, PL2 = 0, PL3 = 0; //pill1 bottle count, pill2 bottle count, pill3 bottle count

    UnityEvent onPillOneChange, onPillTwoChange, onPillThreeChange; //adding point
    UnityEvent onBottleOneChange, onBottleTwoChange, onBottleThreeChange; //falling pill from bottle
    bool BottleOneLock = false, BottleTwoLock = false, BottleThreeLock = false;
    AnimationController _controller;

    private void Start()
    {
        IniliazeEvents();
        _controller = this.gameObject.GetComponentInParent<AnimationController>();
    }
    void IniliazeEvents()
    {
        if (onPillOneChange == null)
        {
            onPillOneChange = new UnityEvent();
        }
        if (onPillTwoChange == null)
        {
            onPillTwoChange = new UnityEvent();
        }
        if (onPillThreeChange == null)
        {
            onPillThreeChange = new UnityEvent();
        }
        if(onBottleOneChange == null)
        {
            onBottleOneChange = new UnityEvent();
        }
        if (onBottleTwoChange == null)
        {
            onBottleTwoChange = new UnityEvent();
        }
        if (onBottleThreeChange == null)
        {
            onBottleThreeChange = new UnityEvent();
        }
        onPillOneChange.AddListener(AddPillOne);
        onPillTwoChange.AddListener(AddPillTwo);
        onPillThreeChange.AddListener(AddPillThree);
        onBottleOneChange.AddListener(MinusPillOne);
        onBottleTwoChange.AddListener(MinusPillTwo);
        onBottleThreeChange.AddListener(MinusPillThree);

    }
    #region EVENT FUNCS
    void AddPillOne()
    {
        if(PL1 < 3)
        {
            PL1 += 1;
            Debug.Log("Puan eklendi. Yeni Puan:: " + PL1);
        }
        else
        {
            Debug.Log("You've finish this bottle! Congrats!");
            BottleOneLock = true;
            _controller.playCoverAnimation();
            //Lock to bottle animation
        }

    }
    void AddPillTwo()
    {
        if(PL2 < 3)
        {
            PL2 += 1;
            Debug.Log("Puan eklendi. Yeni puan:: " + PL2);
        }
        else
        {
            Debug.Log("You've finish this bottle! Congrats!");
            BottleTwoLock = true;
            //Lock to bottle animation
        }

    }
    void AddPillThree()
    {
        if(PL3 < 3)
        {
            PL3 += 1;
            Debug.Log("Puan eklendi. Yeni puan:: " + PL3);
        }
        else
        {
            Debug.Log("You've finish this bottle! Congrats!");
            BottleThreeLock = true;
            //Lock to bottle animation
        }

    }
    void MinusPillOne()
    {
        if (!BottleOneLock)
        {
            PL1 -= 1;
            Debug.Log("Puan eksildi. Yeni puan:: " + PL1);
        } 
    }
    void MinusPillTwo()
    {
        if (!BottleTwoLock)
        {
            PL2 -= 1;
            Debug.Log("Puan eksildi. Yeni puan:: " + PL2);
        }
       
    }
    void MinusPillThree()
    {
        if (!BottleThreeLock)
        {
            PL3 -= 1;
            Debug.Log("Puan eksildi. Yeni puan:: " + PL3);
        }
    }
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pill1")
        {
            if (this.gameObject.tag == "bottle1")
            {
                onPillOneChange.Invoke();
                //AddPoint(1);
                Debug.Log("You have got a point! FOR BOTTLE 1! YOUR POINT IS:: " + PL1);
            }
            else if (this.gameObject.tag == "bottle2")
            {
                //Create new pill for this
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
            else if (this.gameObject.tag == "bottle3")
            {
                //Create new pill for this
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
        }
        else if(other.tag == "pill2")
        {
            if (this.gameObject.tag == "bottle2")
            {
                onPillTwoChange.Invoke();
                Debug.Log("You have got a point! FOR BOTTLE 2! YOUR POINT IS:: " + PL2);
            }
            else if (this.gameObject.tag == "bottle1")
            {
                //Create new pill for this
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
            else if (this.gameObject.tag == "bottle3")
            {
                //Create new pill for this
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
        }
        else if(other.tag == "pill3")
        {
            if (this.gameObject.tag == "bottle3")
            {
                onPillThreeChange.Invoke();
                Debug.Log("You have got a point! FOR BOTTLE 3! YOUR POINT IS: " + PL3);
            }
            else if (this.gameObject.tag == "bottle2")
            {
                //Create new pill for this
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
            else if (this.gameObject.tag == "bottle3")
            {
                //Create new pill for this
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "pill1")
        {
            if(this.gameObject.tag == "bottle1")
            {
                onBottleOneChange.Invoke();
                Debug.Log("You lose your point for bottle 1. Your current bottle point:: " + PL1);
               
            }
        }
        else if(other.gameObject.tag == "pill2")
        {
            if(this.gameObject.tag == "bottle2")
            {
                onBottleTwoChange.Invoke();
                Debug.Log("You lose your point for bottle 1. Your current bottle point:: " + PL2);
               
            }
        }
        else if(other.gameObject.tag == "pill3")
        {
            if(this.gameObject.tag == "bottle3")
            {
                onBottleThreeChange.Invoke();
                Debug.Log("You lose your point for bottle 1. Your current bottle point:: " + PL3);
                
            }
        }
    }
}
