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
        spawnPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + spawnPoint.transform.position.z);
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
