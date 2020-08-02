using System.Collections;
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
    public List<Shelve> shelves;
    public bool IsFirstStepFinish = false, IsSecondStepFinish = false;

    public ParticleSystem confetti;

    #region Controllers
    ScoreController _scoreController;
    public MainUI _myUI;
    #endregion
    //probs

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
        confetti.Stop();
        _scoreController = FindObjectOfType<ScoreController>();
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

    //First Level Finish Method
    public void OnAllLock()
    {
       if (bottles[0].BootleLock && bottles[1].BootleLock && bottles[2].BootleLock)
       {
            Debug.Log("ALL BOTTLES LOCK");
            IsFirstStepFinish = true;
            Debug.Log("Is the first step finish:: " + IsFirstStepFinish);
        }
    }

    //Second Level Finish Method
    public void OnAllBottleAdd()
    {
        Debug.Log("I'm in the on bottle ad");
        if(shelves[0].OnCorrectBottle && shelves[1].OnCorrectBottle && shelves[2].OnCorrectBottle)
        {
            IsSecondStepFinish = true;
            Debug.Log("Second level is finish");
            NextLevel();
        }
    }

    //Change Level Method
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
        if (IsSecondStepFinish)
        {
            _myUI.gameObject.SetActive(true);
            confetti.Play();
        }


    }
}
