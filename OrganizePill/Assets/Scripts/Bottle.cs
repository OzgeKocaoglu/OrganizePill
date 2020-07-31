using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bottle : MonoBehaviour
{
    //Variables
    private int bottlePillCount;
    private bool IsLock;
    //Events
    UnityEvent onPillChange;
    UnityEvent onWrongPill;
    UnityEvent onBottleChange;

    AnimationController _controller;
    //Props
    public int BottlePill
    {
        get
        {
            return bottlePillCount;

        }
        set
        {
            if(value != 0)
            {
                bottlePillCount = value;
            }
        }
    }
    public bool BootleLock
    {
        get
        {
            return IsLock;
        }
        set
        {
            if(value != null)
            {
                IsLock = value;
            }
        }
    }
    
    //Functions
    private void Start()
    {
        IniliazeEvents();
        _controller = this.gameObject.GetComponentInParent<AnimationController>();
    }
    void IniliazeEvents()
    {
        if (onPillChange == null)
        {
            onPillChange = new UnityEvent();
        }
        if (onWrongPill == null)
        {
            onWrongPill = new UnityEvent();
        }
        if(onBottleChange == null)
        {
            onBottleChange = new UnityEvent();
        }
        onPillChange.AddListener(AddPill);
        onBottleChange.AddListener(MinusPill);
        onWrongPill.AddListener(WrongPill);
    }
    #region EVENT FUNCS
    void AddPill()
    {
        if (this.BottlePill < 3)
        {
            this.BottlePill += 1;
            Debug.Log("Puan eklendi. Yeni Puan:: " + this.BottlePill);
            _controller.playCheck();

        }
        else
        {
            Debug.Log("You've finish this bottle! Congrats!");
            this.BootleLock = true;
            _controller.playCoverAnimation();
            //Lock to bottle animation
        }

    }
    void MinusPill()
    {
        if (!this.BootleLock)
        {
            this.BottlePill -= 1;
            Debug.Log("Puan eksildi. Yeni puan:: " + this.BottlePill);
        }
    }
    void WrongPill()
    {
        _controller.playCross();
        //Create pill
        Debug.Log("WRONG PILL ANIMATION!");
    }
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pill1")
        {
            if (this.gameObject.tag == "bottle1")
            {
                onPillChange.Invoke();
                //AddPoint(1);
                Debug.Log("You have got a point! FOR BOTTLE 1! YOUR POINT IS:: " + this.BottlePill);
            }
            else if (this.gameObject.tag == "bottle2" || this.gameObject.tag == "bottle3")
            {
                //Create new pill for this
                if (!this.BootleLock)
                {
                    onWrongPill.Invoke();
                    GameManager.Instance.RespawnPill(other.tag);
                } 
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
        }
        else if (other.tag == "pill2")
        {
            if (this.gameObject.tag == "bottle2")
            {
                onPillChange.Invoke();
                Debug.Log("You have got a point! FOR BOTTLE 2! YOUR POINT IS:: " + this.BottlePill);
            }
            else if (this.gameObject.tag == "bottle1" || this.gameObject.tag == "bottle3")
            {
                //Create new pill for this
                if (!this.BootleLock)
                {
                    onWrongPill.Invoke();
                    GameManager.Instance.RespawnPill(other.tag);
                }
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
        }
        else if (other.tag == "pill3")
        {
            if (this.gameObject.tag == "bottle3")
            {
                onPillChange.Invoke();
                Debug.Log("You have got a point! FOR BOTTLE 3! YOUR POINT IS: " + this.BottlePill);
            }
            else if (this.gameObject.tag == "bottle2" || this.gameObject.tag == "bottle1")
            {
                //Create new pill for this
                if (!this.BootleLock)
                {
                    onWrongPill.Invoke();
                    GameManager.Instance.RespawnPill(other.tag);
                }
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "pill1")
        {
            if (this.gameObject.tag == "bottle1")
            {
                onBottleChange.Invoke();
                Debug.Log("You lose your point for bottle 1. Your current bottle point:: " + this.BottlePill);

            }
        }
        else if (other.gameObject.tag == "pill2")
        {
            if (this.gameObject.tag == "bottle2")
            {
                onBottleChange.Invoke();
                Debug.Log("You lose your point for bottle 2. Your current bottle point:: " + this.BottlePill);

            }
        }
        else if (other.gameObject.tag == "pill3")
        {
            if (this.gameObject.tag == "bottle3")
            {
                onBottleChange.Invoke();
                Debug.Log("You lose your point for bottle 3. Your current bottle point:: " + this.BottlePill);

            }
        }
    }


}
