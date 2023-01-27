using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitsSelection : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 currentPos;
    private bool isSelecting = false;
    private Rect selectBox;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isSelecting = true;
        }

        if (Input.GetMouseButton(0))
        {
            currentPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSelecting = false;
        }
    }

    private void OnGUI()
    {
        if (isSelecting)
        {
            float x = Mathf.Min(startPos.x, currentPos.x);
            float y = Mathf.Min(startPos.y, currentPos.y);
            float width = Mathf.Abs(startPos.x - currentPos.x);
            float height = Mathf.Abs(startPos.y - currentPos.y);
            selectBox = new Rect(x, Screen.height - y - height, width, height);
            GUI.color = Color.cyan;
            GUI.Box(selectBox, "");
          
        }
    }
}