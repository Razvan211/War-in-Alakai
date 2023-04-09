using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildLumberMill : MonoBehaviour
{
    public Vector3 place;
    public GameObject prefab;
   // public GameManager gm;
    public bool placeNow;

    private RaycastHit hit;
    public int cost = 10;
    
  
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0) && placeNow == true)// && gm.playerGold >= cost)
        {
            //gm.playerGold = gm.playerGold - cost;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
               
                if (hit.transform.tag == "Terrain")
                {
                    place = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    Instantiate(prefab, place, Quaternion.identity);
                    
                    placeNow = false;

                   
                    
                }
            }
        }

    }

    public void PlaceCube()
    {

        placeNow = true;
    }
}
