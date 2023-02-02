using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : MonoBehaviour
{
    //list to store all units
    public List<GameObject> units = new List<GameObject>();

    //list to store selected units
    public List<GameObject> selectedUnits = new List<GameObject>();


    private static SelectUnit instance;
    public static SelectUnit Instance { get { return instance; }}

    private void Awake()
    {
        //checks if an instance of this exists and if it is not this one
        if(instance != null && instance != this)
        {
            //we are destroying the instance
            Destroy(this.gameObject);
        }
        else
        {
            //we make this the instance
            instance = this;
        }
    }

    public void ClickSelection (GameObject coveredUnits)
    {
        DeselectAll();
        selectedUnits.Add(coveredUnits);
    }

    public void DragSelect(GameObject coveredUnits)
    {

    }
    
    public void ShiftClickSelect(GameObject coveredUnits)
    {
        if (!selectedUnits.Contains(coveredUnits))
        {
            selectedUnits.Add(coveredUnits);
        }else
        {
            selectedUnits.Remove(coveredUnits);
        }
    }

    public void DeselectAll()
    {
        selectedUnits.Clear();
    }

    public void Deselect(GameObject unitsToUncover)
    {
       
    }
}
