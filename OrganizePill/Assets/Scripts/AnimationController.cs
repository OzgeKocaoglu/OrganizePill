using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private GameObject _bottleCover;
    private Animator _controller;


    private void Start()
    {
        _controller = _bottleCover.GetComponent<Animator>();
    }

    public void playCoverAnimation()
    {
        if(this.gameObject.tag == "bottle1")
        {
            _controller.Play("Bottle01Movement02");
            Debug.Log("Cover Animation is playing");
        }
        
    }
}
