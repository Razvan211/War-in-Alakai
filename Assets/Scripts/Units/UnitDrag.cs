using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    Camera Cam;

    [SerializeField]
    RectTransform box;

    Rect selectionBox;

    //used to store the first and last values of the mouse position
    Vector2 firstPos;
    Vector2 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        firstPos = Vector2.zero;
        lastPos = Vector2.zero;
        DrawBox();
    }

    // Update is called once per frame
    void Update()
    {
        //click
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
            selectionBox = new Rect();
        }
        //drag
        if (Input.GetMouseButton(0))
        {
            lastPos = Input.mousePosition;
            DrawBox();
            DrawBoxSelection();
        }
        //release
        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
            firstPos = Vector2.zero;
            lastPos = Vector2.zero;
            DrawBox();
        }
    }

    void DrawBox()
    {
        Vector2 rectangleStart = firstPos;
        Vector2 rectangleEnd = lastPos;

        Vector2 rectangleCenter = (rectangleStart + rectangleEnd) / 2;
        box.position = rectangleCenter;

        Vector2 rectangleSize = new Vector2(Mathf.Abs(rectangleStart.x - rectangleEnd.x), Mathf.Abs(rectangleStart.y - rectangleEnd.y));
        box.sizeDelta = rectangleSize;

    }

    //calculates where the selection box starts and where it ends.
    void DrawBoxSelection() 
    {
        // X calculations
        if(Input.mousePosition.x < firstPos.x)
        { //drag to the left
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = firstPos.x;
        }
        else
        { //drag to the right
            selectionBox.xMin = firstPos.x;
            selectionBox.xMax = Input.mousePosition.x;
        }


        // Y calculations
        if(Input.mousePosition.y < firstPos.y)
        { //drag down
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = firstPos.y;
        }
        else
        {//drag up
            selectionBox.yMin = firstPos.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }

    void SelectUnits()
    {
        foreach(var unit in SelectUnit.Instance.units)
        {
            if (selectionBox.Contains(Cam.WorldToScreenPoint(unit.transform.position)))
            {
                SelectUnit.Instance.DragSelect(unit);
            }
        }

    }
}
