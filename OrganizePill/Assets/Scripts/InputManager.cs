using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Threading.Tasks;


public class InputManager : MonoBehaviour, IEventSystemHandler
{
    //Variables
    Vector3 distance;
    Rigidbody _myRigidboy;
    float posX, posY;
    float waitforsecond = 2.0f;
   
    //Unity Functions
    private void Start()
    {
        _myRigidboy = GetComponent<Rigidbody>();
    }
    private void OnMouseDown()
    {
        distance = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - distance.x;
        posY = Input.mousePosition.y - distance.y;
    }
    private void OnMouseDrag()
    {
        _myRigidboy.constraints = RigidbodyConstraints.FreezeRotation;

        if(this.gameObject.tag == "pill1")
        {
            Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, 1.7f);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
            transform.position = worldPos;
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else if(this.gameObject.tag == "pill2")
        {
            Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, 1.7f);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
            transform.position = worldPos;
            transform.localScale = new Vector3(6f, 6f, 6f);
        }
        else if(this.gameObject.tag == "pill3")
        {
            Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, 1.7f);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
            transform.position = worldPos;
            transform.localScale = new Vector3(10f, 10f, 10f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        #region Dead Part
        if (other.tag == "Dead")
        {
            Debug.Log("Dead Zone!");
            if(gameObject.tag == "pill1"){ ReTransformPillObjects("pill1"); }
            else if(gameObject.tag == "pill2") { ReTransformPillObjects("pill2"); }
            else if (gameObject.tag == "pill3"){ ReTransformPillObjects("pill3"); }
        }
        #endregion

    }

    //Functions
    IEnumerator ReSpawnObject()
    {
        Debug.Log("Waiting for respawn");
        yield return new WaitForSeconds(waitforsecond);
    }
    public void ReTransformPillObjects(string pillTag)
    {
        if(pillTag == "pill1")
        {
            Debug.Log("Creating new pill 1");
            StartCoroutine("ReSpawnObject");
            this.gameObject.transform.position = new Vector3(-0.07f, 5.4f, 6.53f);
            this.gameObject.transform.localScale = new Vector3(15f, 15f, 15f);
        }

        else if(pillTag == "pill2")
        {
            Debug.Log("Creating new pill 2");
            StartCoroutine("ReSpawnObject");
            this.gameObject.transform.position = new Vector3(-0.07f, 5.4f, 6.53f);
            this.gameObject.transform.localScale = new Vector3(30f, 30f, 30f);
        }

        else if(pillTag == "pill3")
        {
            Debug.Log("Creating new pill 3");
            StartCoroutine("ReSpawnObject");
            this.gameObject.transform.position = new Vector3(-0.07f, 5.4f, 6.53f);
            this.gameObject.transform.localScale = new Vector3(40f, 40f, 40f);
        }

    }

}
