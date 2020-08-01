﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance { get; private set; }

    //Variables
    [SerializeField]
    private Transform[] _pill;
    public Transform _spawnPoint;
    public List<Bottle> bottles;
    private int lockCount = 0;
    public bool IsFirstStepFinish = false;
    
    //probs
    public int LockCount
    {
        get { return lockCount; }
        set
        {
            if(value != 0)
            {
                lockCount = value;
            }
        }
    }

    //Unity Functions
   private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   void Start()
    {
        CreatePill();
    }

    //Functions
   private void CreatePill(){

       for (int i = 0; i < _pill.Length; i++)
       {
            for(int j = 0; j<5; j++)
            {
                if (i == 0)
                {
                    Instantiate(_pill[i], _spawnPoint.transform.position, Quaternion.identity);
                }
                else if(i == 1)
                {
                    Instantiate(_pill[i], _spawnPoint.transform.position + new Vector3(0.1f, 0.1f, 0f), Quaternion.identity);
                }
                else if(i == 2)
                {
                    Instantiate(_pill[i], _spawnPoint.transform.position + new Vector3(-0.1f, -0.1f, 0f), Quaternion.identity);
                }
               
            } 
        }
   }
   public void RespawnPill(string pillTag)
    {
        for(int i =0; i< _pill.Length; i++)
        {
            if(pillTag == _pill[i].tag)
            {
                Instantiate(_pill[i], _spawnPoint.transform.position, Quaternion.identity);
            }
        }
    }
    public void OnAllLock()
    {
       if (bottles[0].BootleLock && bottles[1].BootleLock && bottles[2].BootleLock)
       {
            Debug.Log("ALL BOTTLES LOCK");
            IsFirstStepFinish = true;
            Debug.Log("Is the first step finish:: " + IsFirstStepFinish);
        }
    }



    public void NextLevel()
    {
        if (IsFirstStepFinish)
        {
            bottles[2]._controller.playFinish();
            bottles[1]._controller.playFinish();
            bottles[0]._controller.playFinish();
            bottles[0].MakeChildren();
            bottles[1].MakeChildren();
            bottles[2].MakeChildren();

        }

    }
}
