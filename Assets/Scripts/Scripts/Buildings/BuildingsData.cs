using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsData : MonoBehaviour
{
    // Will store the building type
    private string _buildingType;

    // Will store the hp of the building
    private int _healthPoints;

    //assigns the values to the private variables
    public BuildingsData(string buildingType, int healthPoints)
    {
        _buildingType = buildingType;
        _healthPoints = healthPoints;
    }

    // Gets building type
    public string Type { get => _buildingType; }

    // Gets building health
    public int Health { get => _healthPoints; }
}
