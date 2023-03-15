using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMageTower : MonoBehaviour
{
    public Vector3 place;
    public GameObject prefab;

    private RaycastHit hit;

    public bool placeNow;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && placeNow == true)
        {



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
