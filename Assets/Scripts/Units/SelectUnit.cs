using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnit : MonoBehaviour
{
    public List<GameObject> units = new List<GameObject>();
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

    }

    public void DragSelect(GameObject coveredUnits)
    {

    }
    
    public void ShiftClickSelect(GameObject coveredUnits)
    {

    }

    public void DeselectAll()
    {

    }

    public void Deselect(GameObject unitsToUncover)
    {
       
    }
}
