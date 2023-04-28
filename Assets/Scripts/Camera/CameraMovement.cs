using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //variables to store camera speed and zoom speed
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float zoomSpeed = 100f;

    //variables to store the zoom constraints
    [SerializeField] private float minZoom = 8f;
    [SerializeField] private float maxZoom = 20f;

    //variables to store the movement constraints
    [SerializeField] private float xMargin = 37f;
    [SerializeField] private float zTopMargin = 40f;
    [SerializeField] private float zBotMargin = -49f;
    

    private Vector3 dragStartPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //HandleMovement();
        //HandleZoom();
    }

    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(x, 0f, z);

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetMouseButton(2))
        {
            Vector3 dragCurrentPosition = Input.mousePosition;
            Vector3 difference = dragStartPosition - dragCurrentPosition;
            transform.position += difference * moveSpeed * Time.deltaTime;
            dragStartPosition = dragCurrentPosition;
        }
            if(transform.position.x > xMargin )
            {
                transform.position = new Vector3(xMargin, transform.position.y, transform.position.z);
            }
            else if(transform.position.x < -xMargin)
            {
                transform.position = new Vector3(-xMargin, transform.position.y, transform.position.z);
            }

            if (transform.position.z > zTopMargin)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zTopMargin);
            }
            else if (transform.position.z < zBotMargin)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zBotMargin);
            }
        
    }


    //handles zoom
    private void HandleZoom()
    {
        
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * 100 * Time.deltaTime;

        Vector3 zoomDirection = transform.forward * zoomAmount;
        transform.position += zoomDirection;

        //checks how far from the zoom limit is the camera
        if (transform.position.y <= minZoom)
        {
            transform.position = new Vector3(transform.position.x, minZoom, transform.position.z);
        }
        else if (transform.position.y >= maxZoom)
        {
            transform.position = new Vector3(transform.position.x, maxZoom, transform.position.z);
            
        }
        
    }
}
