using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private Vector3 refPositionObject;
    private Vector3 mOffSet;
    private float mZCoord;



    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffSet = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    void OnMouseDrag()
    {
        refPositionObject = new Vector3(0f, 0f);
        transform.position = new Vector3(GetMouseWorldPos().x + refPositionObject.x, GetMouseWorldPos().y + mOffSet.y, 0);
        transform.localScale = new Vector3(3f, 3f, 3f);
    }
}
