using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnit : MonoBehaviour
{
    //stores spawnPoint for unit
    [SerializeField]private GameObject spawnPoint;


    //stores selection circle
    [SerializeField]private GameObject selectionCircle;

    //stores prefab to spawn
    [SerializeField]private GameObject prefab;

    //stores the spawnUnit canvas
    public Canvas buildingCanvas;

    //check if building is selected
    [SerializeField] private bool isSelected = false;

    //Timer for units spawning
    [SerializeField] private float timer = 2.0f;

    // Start is called before the first frame update
    private void Awake()
    {
        buildingCanvas = GetComponent<Canvas>();
    }
    void Start()
    {

        selectionCircle.SetActive(false);
        buildingCanvas = GameObject.Find("BuildingUI").GetComponent<Canvas>();
        buildingCanvas.gameObject.SetActive(false);
        spawnPoint.transform.position = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            selectionCircle.SetActive(true);
            buildingCanvas.gameObject.SetActive(true);
        }
        else
        {
            selectionCircle.SetActive(false);
            buildingCanvas.gameObject.SetActive(false);
        }
        
    }

    public void SpawnUnits()
    {
        if (timer > 0)
        {
            
            Instantiate(prefab, spawnPoint.transform.position + new Vector3(0, 0, -5), Quaternion.identity);
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 2.0f;
        }
        
    }
}
