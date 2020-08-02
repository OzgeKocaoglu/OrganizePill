using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shelve : MonoBehaviour
{
    //variables
    private bool _onCorrectBottle = false;
    UnityEvent OnBottle;

    //probs
    public bool OnCorrectBottle
    {
        get
        {
            return _onCorrectBottle;
        }
        set
        {
            if(value != null)
            {
                _onCorrectBottle = value;
                OnBottle.Invoke();
                Debug.Log("Shelve name: " + this.gameObject.tag + "State: " + _onCorrectBottle);
            }
        }
    }

    //Unity Funcs
    private void Start()
    {
        IniliazeEvents();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "shelve01")
        {
            if (other.tag == "bottle1")
            {

                OnCorrectBottle = true;
            }
            else
            {
                Debug.Log("Wrong");
            }
        }
        if (this.gameObject.tag == "shelve02")
        {
            if (other.tag == "bottle2")
            {
            
                OnCorrectBottle = true;
            }
        }
        if (this.gameObject.tag == "shelve03")
        {
            if (other.tag == "bottle3")
            {
            
                OnCorrectBottle = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "bottle1")
        {
            if (this.gameObject.tag == "shelve01")
            {
                OnCorrectBottle = false;
            }
        }
        else if (other.tag == "bottle2")
        {
            if (this.gameObject.tag == "shelve02")
            {
                OnCorrectBottle = false;
            }
        }
        else if (other.tag == "bottle3")
        {
            if (this.gameObject.tag == "shelve03")
            {
                OnCorrectBottle = false;
            }
        }
    }

    //Functions
    void IniliazeEvents()
    {
        if (OnBottle == null)
        {
            OnBottle = new UnityEvent();
        }

        OnBottle.AddListener(GameManager.Instance.OnAllBottleAdd);
    }



}
