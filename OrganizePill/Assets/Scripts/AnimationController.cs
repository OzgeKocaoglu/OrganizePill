using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationController : MonoBehaviour
{
    //Variables
    [SerializeField]
    private GameObject _bottleCover;
    private Animator _controller;

    //Events
    UnityEvent onCheck, onFalse;

    //Unity Functions
    private void Start()
    {
        IniliazeEvents();
        _controller = _bottleCover.GetComponent<Animator>();
    }

    //Functions
    public void IniliazeEvents()
    {
        if (onCheck == null)
        {
            onCheck = new UnityEvent();
        }
        if (onFalse == null)
        {
            onFalse = new UnityEvent();
        }

        onCheck.AddListener(On_playCheck);
        onFalse.AddListener(On_playCross);
    }
    #region EVENT FUNCS
    public void On_playCheck()
    {
        if (this.gameObject.tag == "bottle1")
        {
            _controller.Play("Bottle01Correct");
            Debug.Log("Check animation is playing");
        }
        if(this.gameObject.tag == "bottle2")
        {
            _controller.Play("Bottle02Correct");
            Debug.Log("Check animation is playing");
        }
        if(this.gameObject.tag == "bottle3")
        {
            _controller.Play("Bottle03Correct");
            Debug.Log("Check animation is playing");
        }
    }
    public void On_stopCheck()
    {
        if (this.gameObject.tag == "bottle1")
        {
            Debug.Log("Check animation is not playing");
        }
    }

    public void On_playCross()
    {
        if(this.gameObject.tag == "bottle1")
        {
            _controller.Play("Bottle01False");
            Debug.Log("False animation is playing");
        }
        if(this.gameObject.tag == "bottle2")
        {
            _controller.Play("Bottle02False");
            Debug.Log("False animation is playing");
        }
        if(this.gameObject.tag == "bottle3")
        {
            _controller.Play("Bottle03False");
            Debug.Log("False animation is playing");
        }
    }

    #endregion
    public void playCoverAnimation()
    {
        if(this.gameObject.tag == "bottle1")
        {
            _controller.Play("Bottle01Movement02");
            Debug.Log("Cover Animation is playing");
        }
        else if(this.gameObject.tag == "bottle2")
        {
            _controller.Play("Bottle02Movement02");
            Debug.Log("Cover Animation is playing");
        }
        else if(this.gameObject.tag == "bottle3")
        {
            _controller.Play("Bottle03Movement02");
        }
    }
    public void playCheck()
    {
        onCheck.Invoke();
    }
    public void playCross()
    {
        onFalse.Invoke();
    }
}
