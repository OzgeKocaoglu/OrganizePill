using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    Vector3 distance;
    float posX, posY;

    private void OnMouseDown()
    {
        distance = Camera.main.WorldToScreenPoint(transform.position);
        posX = Input.mousePosition.x - distance.x;
        posY = Input.mousePosition.y - distance.y;
    }

    private void OnMouseDrag()
    {
       
        
        if(this.gameObject.tag == "pill1")
        {
            Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, 1.6f);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
            transform.position = worldPos;
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else if(this.gameObject.tag == "pill2")
        {
            Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, 1.6f);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
            transform.position = worldPos;
            transform.localScale = new Vector3(6f, 6f, 6f);
        }
        else if(this.gameObject.tag == "pill3")
        {
            Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, 1.6f);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
            transform.position = worldPos;
            transform.localScale = new Vector3(10f, 10f, 10f);
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bottle1" || other.tag == "bottle2" || other.tag == "bottle3")
        {
            Debug.Log("Ben: " + gameObject.name + "Şu Bottle'a dokunuyorum! ::: " + other.tag);
        }
    }
}
