using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    Vector3 distance;
    Rigidbody _myRigidboy;
    float posX, posY;
    float waitforsecond = 2.0f;
    private int PL1 = 0, PL2 = 0, PL3 = 0; //pill1 bottle count, pill2 bottle count, pill3 bottle count

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

        #region Point

        if (other.tag == "bottle1")
        {
            if (this.gameObject.tag == "pill1")
            {

                AddPoint(1);
                Debug.Log("You have got a point! FOR BOTTLE 1! YOUR POINT IS:: " + PL1);
            }
            else if(this.gameObject.tag =="pill2")
            {
                //Create new pill for this
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
            else if(this.gameObject.tag == "pill3")
            {
                //Create new pill for this
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
        }

        if(other.tag == "bottle2")
        {
            if (this.gameObject.tag == "pill2")
            {

                AddPoint(2);
                Debug.Log("You have got a point! FOR BOTTLE 2! YOUR POINT IS:: " + PL2);
            }
            else if (this.gameObject.tag == "pill1")
            {
                //Create new pill for this
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
            else if (this.gameObject.tag == "pill3")
            {
                //Create new pill for this
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
        }

        if(other.tag == "bottle3")
        {
            if (this.gameObject.tag == "pill3")
            {
                AddPoint(3);
                Debug.Log("You have got a point! FOR BOTTLE 3! YOUR POINT IS: " + PL3);
            }
            else if (this.gameObject.tag == "pill2")
            {
                //Create new pill for this
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
            else if (this.gameObject.tag == "pill3")
            {
                //Create new pill for this
                Debug.Log("WRONG PILL:: " + this.gameObject.tag);
                //TO DO:: ADD CROSS SIGN
            }
        }

        #endregion

    }

    IEnumerator ReSpawnObject()
    {
        Debug.Log("Waiting for respawn");
        yield return new WaitForSeconds(waitforsecond);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "bottle1")
        {
            if(this.gameObject.tag == "pill1")
            {
                PL1--;
                Debug.Log("You lose your point");
            }
        }
        if(other.tag == "bottle2")
        {
            if(this.gameObject.tag == "pill2")
            {
                PL2--;
                Debug.Log("You lose your point");
            }
        }

        if(other.tag == "bottle3")
        {
            if(this.gameObject.tag == "pill3")
            {
                PL3--;
                Debug.Log("You lose your point");
            }
        }
    }


    void ReTransformPillObjects(string pillTag)
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

    public void AddPoint(int pillScoreName)
    {
        if(pillScoreName == 1)
        {
            PL1++;
        }
        else if(pillScoreName == 2)
        {
            PL2++;
        }
        else if(pillScoreName == 3)
        {
            PL3++;
        }
    }

}
