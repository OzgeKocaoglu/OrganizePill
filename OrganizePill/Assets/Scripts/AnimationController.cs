using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationController : MonoBehaviour
{
    //Variables
    [SerializeField]
    private GameObject _bottleCover, mainCamera;
    private Animator _Pillcontroller, _Cameracontroller;

    //Events
    UnityEvent onCheck, onFalse;
    UnityEvent onFinish;

    //Unity Functions
    private void Start()
    {
        IniliazeEvents();
        _Pillcontroller = _bottleCover.GetComponent<Animator>();
        _Cameracontroller = mainCamera.GetComponent<Animator>();
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
        if(onFinish == null)
        {
            onFinish = new UnityEvent();
        }

        onCheck.AddListener(On_playCheck);
        onFalse.AddListener(On_playCross);
        onFinish.AddListener(On_finish);
    }
    #region EVENT FUNCS
    public void On_finish()
    {
        if(this.gameObject.tag == "bottle1")
        {
            _Pillcontroller.Play("Bottle01Movement03");
            Debug.Log("Finish this level");
        }
        if(this.gameObject.tag == "bottle2")
        {
            _Pillcontroller.Play("Bottle02Movement03");
        }
        if(this.gameObject.tag == "bottle3")
        {
            _Pillcontroller.Play("Bottle03Movement03");
        }
        if (GameManager.Instance.IsFirstStepFinish)
        {
            _Cameracontroller.Play("CameraChange");
        }
    }
    public void On_playCheck()
    {
        if (this.gameObject.tag == "bottle1")
        {
            _Pillcontroller.Play("Bottle01Correct");
            Debug.Log("Check animation is playing");
        }
        if(this.gameObject.tag == "bottle2")
        {
            _Pillcontroller.Play("Bottle02Correct");
            Debug.Log("Check animation is playing");
        }
        if(this.gameObject.tag == "bottle3")
        {
            _Pillcontroller.Play("Bottle03Correct");
            Debug.Log("Check animation is playing");
        }
    }
    public void On_playCross()
    {
        if(this.gameObject.tag == "bottle1")
        {
            _Pillcontroller.Play("Bottle01False");
            Debug.Log("False animation is playing");
        }
        if(this.gameObject.tag == "bottle2")
        {
            _Pillcontroller.Play("Bottle02False");
            Debug.Log("False animation is playing");
        }
        if(this.gameObject.tag == "bottle3")
        {
            _Pillcontroller.Play("Bottle03False");
            Debug.Log("False animation is playing");
        }
    }
    #endregion
    public void playCoverAnimation()
    {
        if(this.gameObject.tag == "bottle1")
        {
            _Pillcontroller.Play("Bottle01Movement02");
            Debug.Log("Cover Animation is playing");
        }
        else if(this.gameObject.tag == "bottle2")
        {
            _Pillcontroller.Play("Bottle02Movement02");
            Debug.Log("Cover Animation is playing");
        }
        else if(this.gameObject.tag == "bottle3")
        {
            _Pillcontroller.Play("Bottle03Movement02");
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
    public void playFinish()
    {
        onFinish.Invoke();
    }
}
