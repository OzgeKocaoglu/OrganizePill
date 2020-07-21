using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField]
   private Transform[] _pill;
   public Transform _spawnPoint;

   void Start()
    {
        CreatePill(); 
    } 

   private void CreatePill(){

       for (int i = 0; i < _pill.Length; i++)
       {
            for(int j = 0; j<3; j++)
            {
                Instantiate(_pill[i], _spawnPoint.transform.position, Quaternion.identity);
            } 
           
        }
   }

}
