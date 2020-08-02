using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BottleInputManager : MonoBehaviour, IEventSystemHandler
{
    //Variables
    GameObject getTarget;
     bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;

    //Unity Funcs
    void Update()
    {

        //Mouse Button Press Down
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            getTarget = ReturnClickedObject(out hitInfo);
            if (getTarget != null && GameManager.Instance.IsFirstStepFinish)
            {
                if(getTarget.gameObject.tag == "bottle1" || getTarget.gameObject.tag == "bottle2" || getTarget.gameObject.tag == "bottle3")
                {
                    isMouseDragging = true;
                    //Converting world position to screen position.
                    positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
                    offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
                }
               ;
            }
        }

        //Mouse Button Up
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
        }

        //Is mouse Moving
        if (isMouseDragging)
        {
            //tracking mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3.4f);

            //converting screen position to world position with offset changes.
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

            //It will update target gameobject's current postion.
            getTarget.transform.position = currentPosition;
            if(getTarget.gameObject.tag == "bottle3")
            {
                getTarget.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
       
        }


    }

    //Method to Return Clicked Object
    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }



}
