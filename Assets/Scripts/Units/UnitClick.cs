using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera Cam;
    public GameObject pointToMove;

    public LayerMask selectable;
    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, selectable))
            {
                //if we press over a selectable object


                //checks if the Shift key is pressed while selecting units
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    //click + shift
                    SelectUnit.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                    //click
                    SelectUnit.Instance.ClickSelection(hit.collider.gameObject);
                }
            }
            else
            {
                
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    SelectUnit.Instance.DeselectAll();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                pointToMove.transform.position = hit.point;
                pointToMove.SetActive(false);
                pointToMove.SetActive(true);
            }
        }
        else if(Input.GetMouseButtonUp(1))
        {
            pointToMove.SetActive(false);
        }
    }
}
