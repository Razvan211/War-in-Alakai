using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnit : MonoBehaviour
{
    //stores spawnPoint for unit
    [SerializeField]private GameObject spawnPoint;
    [SerializeField] private GameObject offset;

    //stores selection circle
    [SerializeField]private GameObject selectionCircle;

    //stores prefab to spawn
    [SerializeField]private GameObject prefab;

    //stores the spawnUnit button
    public Button spawnButton;

    public Vector3 spawnPosition;


    //check if building is selected
    [SerializeField] private bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        selectionCircle.SetActive(false);
        spawnButton.gameObject.SetActive(false);
        spawnPoint.transform.position = transform.position;
        offset.transform.position = spawnPosition;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            selectionCircle.SetActive(true);
            spawnButton.gameObject.SetActive(true);
        }
        else
        {
            selectionCircle.SetActive(false);
            spawnButton.gameObject.SetActive(false);
        }
        
    }

    public void SpawnUnits()
    {
        Instantiate(prefab, spawnPoint.transform.position + offset.transform.position, Quaternion.identity);
    }
}
