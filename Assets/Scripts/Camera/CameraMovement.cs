using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float zoomSpeed = 10f;
    

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
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;

        Vector3 zoomDirection = transform.forward * zoomAmount;

        transform.position += zoomDirection;
    }
}
