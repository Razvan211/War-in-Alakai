using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName ="Create Building")]
public class BuildingClass : ScriptableObject
{
    public int cost;
    public int health;
    public GameObject prefab;
    public Unit unitToSpawn;

    public void Spawn(Vector3 position)
    {
        Instantiate(unitToSpawn, position, Quaternion.identity);
    }
}