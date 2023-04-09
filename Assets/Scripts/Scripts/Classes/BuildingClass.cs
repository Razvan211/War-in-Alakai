using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName ="Create Building")]
public class BuildingClass : ScriptableObject
{
    public int cost;
    public int health;
    public GameObject prefab;


   
}