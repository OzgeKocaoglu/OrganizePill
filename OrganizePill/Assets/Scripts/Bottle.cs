using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bottle : MonoBehaviour
{
    //Variables
    private int bottlePillCount;
    private bool IsLock = false;
    private List<GameObject> pillsAdded;
    [SerializeField]
    private GameObject _bottleCover;
    public AnimationController _controller;

    //Events
    UnityEvent onPillChange;
    UnityEvent onWrongPill;
    UnityEvent onBottleChange;
    UnityEvent onLockChange;

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
                Debug.Log("Bottlelock is change");
                onLockChange.Invoke();
            }
        }
    }

   //Unity Functions
    private void Start()
    {
        IniliazeEvents();
        _controller = this.gameObject.GetComponentInParent<AnimationController>();
        pillsAdded = new List<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pill1")
        {
            if (this.gameObject.tag == "bottle1")
            {
                if (!this.BootleLock)
                {
                    onPillChange.Invoke();
                    //AddPoint(1);
                    Debug.Log("You have got a point! FOR BOTTLE 1! YOUR POINT IS:: " + this.BottlePill);
                    other.tag = "addedPill";
                    pillsAdded.Add(other.gameObject);
                }

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
                if (!this.BootleLock)
                {
                    onPillChange.Invoke();
                    Debug.Log("You have got a point! FOR BOTTLE 2! YOUR POINT IS:: " + this.BottlePill);
                    pillsAdded.Add(other.gameObject);
                    other.tag = "addedPill";
                }

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
                if (!this.BootleLock)
                {
                    onPillChange.Invoke();
                    Debug.Log("You have got a point! FOR BOTTLE 3! YOUR POINT IS: " + this.BottlePill);
                    pillsAdded.Add(other.gameObject);
                    other.tag = "addedPill";
                }

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
        if (other.gameObject.tag == "addedPill")
        {
            Debug.Log(this.gameObject.tag);
            if (this.gameObject.tag == "bottle1")
            {
                if (!this.BootleLock)
                {
                    Debug.Log(other.tag);
                    onBottleChange.Invoke();
                    Debug.Log("You lose your point for bottle 1. Your current bottle point:: " + this.BottlePill);
                    pillsAdded.Remove(other.gameObject);
                    other.tag = "pill1";
                }

            }
            else if (this.gameObject.tag == "bottle2")
            {
                Debug.Log(gameObject.name);
                if (!this.BootleLock)
                {
                    Debug.Log(other.tag);
                    onBottleChange.Invoke();
                    Debug.Log("You lose your point for bottle 2. Your current bottle point:: " + this.BottlePill);
                    pillsAdded.Remove(other.gameObject);
                    other.tag = "pill2";
                }


            }
            else if (this.gameObject.tag == "bottle3")
            {
                if (!this.BootleLock)
                {
                    onBottleChange.Invoke();
                    Debug.Log("You lose your point for bottle 3. Your current bottle point:: " + this.BottlePill);
                    pillsAdded.Remove(other.gameObject);
                    other.tag = "pill3";
                }

            }
        }
    }

    //Functions
    public void MakeChildren()
    {
        for(int i = 0; i< pillsAdded.Count; i++)
        {
            pillsAdded[i].gameObject.transform.SetParent(this.gameObject.transform);
            pillsAdded[i].gameObject.transform.position = pillsAdded[i].gameObject.transform.parent.position;
            pillsAdded[i].gameObject.tag = pillsAdded[i].gameObject.transform.parent.tag;
            Rigidbody _pillRigidboy = pillsAdded[i].gameObject.GetComponent<Rigidbody>();
            _pillRigidboy.constraints = RigidbodyConstraints.FreezePosition;
            _pillRigidboy.constraints = RigidbodyConstraints.FreezeRotation;
        }
        _bottleCover.gameObject.transform.SetParent(this.gameObject.transform);
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
        if (onBottleChange == null)
        {
            onBottleChange = new UnityEvent();
        }
        if (onLockChange == null)
        {
            onLockChange = new UnityEvent();
        }
        onPillChange.AddListener(AddPill);
        onBottleChange.AddListener(MinusPill);
        onWrongPill.AddListener(WrongPill);
        onLockChange.AddListener(GameManager.Instance.OnAllLock);
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
            Debug.Log("Bottle locked:" + this.BootleLock);
            _controller.playCoverAnimation();
            //Lock to bottle animation
            GameManager.Instance.NextLevel();
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

}
