using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class UnitMovement : MonoBehaviour
{

    Camera Cam;
    NavMeshAgent agent;
    public LayerMask ground;
    public GameObject selectionPoint;

    public GameObject unitPrefab;

    


    

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        selectionPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UnitsMovement();
    }

    private void UnitsMovement()
    {
        
            if (Input.GetMouseButtonDown(1) && selectionPoint.activeInHierarchy)
            {
                RaycastHit hit;
                Ray ray = Cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                {
                    agent.SetDestination(hit.point);
                }
            }
        
        
    }
}
