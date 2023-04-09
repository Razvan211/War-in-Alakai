using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RN.WIA.Units.Player;

namespace RN.WIA.InputManager
{
    public class InputManager : MonoBehaviour
    {
     


        public static InputManager instance;

        public Camera cam;
        public GameObject pointToMove;
        public LayerMask ground;

        private RaycastHit hit; //ray target

        //check if we create the rectangle
        private bool drag = false;

        private Vector3 mousePosition;

       

        //stores the selected units
        public List<Transform> selectedUnits = new List<Transform>();


        private void Awake()
        {
            // Singleton 
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

        }

        private void Start()
        {
            pointToMove.SetActive(false);
            ground = LayerMask.GetMask("Ground");
        }

        private void Update()
        {
            LocationOutput();
        }

        //draw
        private void OnGUI()
        {
            if (drag)
            {
                Rect rect = MultipleSelection.GetSelectionRectangle(mousePosition, Input.mousePosition);
                MultipleSelection.DrawSelectionRectangle(rect, new Color(0f, 0.2f, 0f, 0.3f));
                
            }
        }

        public void ManageUnitsMovement()
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePosition = Input.mousePosition;
               
                //create ray
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                //check if the unit is hit
                if(Physics.Raycast(ray, out hit))
                {
                    LayerMask targetedLayer = hit.transform.gameObject.layer;

                    switch (targetedLayer.value)
                    {
                        case 6: //Layer for units
                            SelectUnit(hit.transform, Input.GetKey(KeyCode.LeftShift));
                            break;
                        default:
                            drag = true;
                            DeselectUnit();
                            break;
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                //iterates through PlayerUnits 
                foreach(Transform units in Player.PlayerManager.instance.playerUnits)
                {
                    //Iterates through the children of PlayerUnits: Warriors/Mages/Catapult
                    foreach (Transform unit in units)
                    {
                        if (isInRectangle(unit))
                        {
                            SelectUnit(unit, true);
                        }
                        
                    }
                }
                drag = false;
            }

            if (Input.GetMouseButtonDown(1) && AreUnitsSelected())
            {
                //create ray
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                //check if the unit is hit
                if (Physics.Raycast(ray, out hit))
                {
                    LayerMask targetedLayer = hit.transform.gameObject.layer;

                    switch (targetedLayer.value)
                    {
                        case 6: //Layer for player units
                            
                            break;
                        case 7: //Layer for enemy units
                        default:
                           
                            foreach (Transform units in selectedUnits)
                            {
                                PlayerUnits playerUnits = units.gameObject.GetComponent<PlayerUnits>();
                                playerUnits.UnitMovement(hit.point);
                            }
                            break;
                    }
                }
            }
        }

        private void SelectUnit(Transform unit, bool selectMore = false)
        {
            if(!selectMore)
            {
                DeselectUnit();
            }
          
            selectedUnits.Add(unit);
            unit.Find("SelectionCircle").gameObject.SetActive(true);
        }

        private void DeselectUnit()
        {
            for(int i = 0; i < selectedUnits.Count; i++)
            {
                selectedUnits[i].Find("SelectionCircle").gameObject.SetActive(false);
            }
            selectedUnits.Clear();
        }

        private bool isInRectangle(Transform tr)
        {
            if (!drag)
            {
                return false;
            }


            Camera cam = Camera.main;
            Bounds viewBounds = MultipleSelection.GetBounds(cam, mousePosition, Input.mousePosition);
            return viewBounds.Contains(cam.WorldToViewportPoint(tr.position));
        }

        //Checks if there are units in the selectedUnits list
        private bool AreUnitsSelected()
        {
            if(selectedUnits.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void LocationOutput()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                    pointToMove.transform.position = hit.point;
                    pointToMove.SetActive(false);
                    pointToMove.SetActive(true);
                }
            }
            else if (Input.GetMouseButtonUp(1))
            {
                pointToMove.SetActive(false);
            }

        }
    }
}

