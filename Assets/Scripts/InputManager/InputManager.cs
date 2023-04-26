using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RN.WIA.Units.Player;
using UnityEngine.EventSystems;

namespace RN.WIA.InputManager
{
    public class InputManager : MonoBehaviour
    {
     


        public static InputManager instance;
        public Transform environment;

        public Camera cam;
        public GameObject pointToMove;
        public LayerMask ground;
        public LayerMask selectableLayer = new LayerMask();

        private RaycastHit hit; //ray target

        //check if we create the rectangle
        private bool drag = false;

        private Vector3 mousePosition;

        private Units.UnitsHealth enemyUnit;

        private float attackCd;
        //stores the selected units
        public List<Transform> selectedUnits = new List<Transform>();
        public Units.UnitsStats.Stats pUnitStats;
        public Transform selectedStrucutre = null;


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
        }

        private void Update()
        {
            LocationOutput();
            attackCd -= Time.deltaTime;
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
                //if we left click and we are over the UI we break from the method
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                mousePosition = Input.mousePosition;
               
                //create ray
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                //check if the unit is hit
                if (Physics.Raycast(ray, out hit, 100, selectableLayer))
                {
                    if (SelectedUnit(hit.transform, Input.GetKey(KeyCode.LeftShift)))
                    {
                        
                    }else if (SelectedStructure(hit.transform))
                    {
                        Debug.Log("Structure selected");
                    }
                }
                else
                {
                    drag = true;
                    DeselectUnit();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                foreach (Transform elements in environment)
                {
                    Debug.Log(elements);
                    //iterates through PlayerUnits 
                    foreach (Transform units in Player.PlayerManager.instance.playerUnits)
                    {
                        //Iterates through the children of PlayerUnits: Warriors/Mages/Catapult
                        foreach (Transform unit in units)
                        {
                            if (isInRectangle(unit))
                            {
                                SelectedUnit(unit, true);
                            }

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
                           foreach(Transform unit in selectedUnits)
                            {
                                PlayerUnits playerUnits = unit.gameObject.GetComponent<PlayerUnits>();
                                playerUnits.SetTarget(hit.collider.gameObject);
                            }
                            break;
                        default:
                           
                            foreach (Transform unit in selectedUnits)
                            {
                                PlayerUnits playerUnits = unit.gameObject.GetComponent<PlayerUnits>();
                                playerUnits.UnitMovement(hit.point);
                                playerUnits.SetTarget(null);
                            }
                            break;
                    }
                }
            }
        }

        private void DeselectUnit()
        {
            if (selectedStrucutre)
            {
                selectedStrucutre.gameObject.GetComponent<Selectables.SelectStructure>().RemoveSelection();
                selectedStrucutre = null;
            }

            for(int i = 0; i < selectedUnits.Count; i++)
            {
                selectedUnits[i].gameObject.GetComponent<Selectables.SelectUnit>().RemoveSelection();
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


        
        private Selectables.SelectUnit SelectedUnit(Transform tr, bool selectMore = false)
        {
            Selectables.SelectUnit sUnit = tr.GetComponent<Selectables.SelectUnit>();
            if (sUnit)
            {
                if (!selectMore)
                {
                    DeselectUnit();
                }
                selectedUnits.Add(sUnit.gameObject.transform);

                sUnit.OnSelect();

                return sUnit;
            }
            else
            {
                return null;
            }
        }

        private Selectables.SelectStructure SelectedStructure(Transform tr)
        {
            
            Selectables.SelectStructure sStructure = tr.GetComponent<Selectables.SelectStructure>();
            if (sStructure)
            {
                DeselectUnit();

                selectedStrucutre = sStructure.gameObject.transform;

                sStructure.OnSelect();

                return sStructure;
            }
            else
            {
                return null;
            }
        }
    }
}

