using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] _pill;
    public Transform _spawnPoint;
    public static GameManager Instance { get; private set; }
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

}
