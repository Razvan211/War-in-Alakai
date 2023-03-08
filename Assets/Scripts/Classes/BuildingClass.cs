using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName ="Create Building")]
public class BuildingClass : ScriptableObject
{
    public int cost;
    public GameObject prefab;
    public UnitClass unitToSpawn;

    public void Spawn(Vector3 position)
    {
        Instantiate(unitToSpawn.prefab, position, Quaternion.identity);
    }
}