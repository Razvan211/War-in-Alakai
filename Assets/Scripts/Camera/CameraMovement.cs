using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float zoomSpeed = 200f;

    [SerializeField] private float minZoom = 3f;
    [SerializeField] private float maxZoom = 12f;
    

    private Vector3 dragStartPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(x, 0f, z);

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetMouseButtonDown(2))
        {
            dragStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 dragCurrentPosition = Input.mousePosition;
            Vector3 difference = dragStartPosition - dragCurrentPosition;
            transform.position += difference * moveSpeed * Time.deltaTime;
            dragStartPosition = dragCurrentPosition;
        }
    }

    private void HandleZoom()
    {
        
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * 100 * Time.deltaTime;

        Vector3 zoomDirection = transform.forward * zoomAmount;
        transform.position += zoomDirection;
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
