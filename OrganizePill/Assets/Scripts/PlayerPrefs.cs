using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs : MonoBehaviour
{
    private static int _coin = 10; //default settings
   
    public static int Coin
    {
        get
        {
            return _coin;
        }
        set
        {
            if(value != 0)
            {
                _coin = value;
            }
        }
    }
}
