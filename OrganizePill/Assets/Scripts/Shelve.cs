using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelve : MonoBehaviour
{
    //variables
    private int _shelveBottlesCount = 0;


    //probs
    public int ShelveBottlesCount
    {
        get
        {
            return _shelveBottlesCount;
        }
        set
        {
            if(value != 0)
            {
                _shelveBottlesCount = value;
            }
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("I have bottles and my name is:  " + this.gameObject.name + " And my bottle count:: " + this.ShelveBottlesCount);
        }
    }

    //Unity Funcs
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "bottle1")
        {
            if (this.gameObject.tag == "shelve01")
            {
                this._shelveBottlesCount += 1;
            }
            else
            {

            }
        }
        else if (other.tag == "bottle2")
        {
            if (this.gameObject.tag == "shelve02")
            {
                this._shelveBottlesCount += 1;
            }
            else
            {
            }
        }
        else if (other.tag == "bottle3")
        {
            if (this.gameObject.tag == "shelve03")
            {
                this._shelveBottlesCount += 1;
            }
            else
            {
            }
        }
    }


    


   
       
}
