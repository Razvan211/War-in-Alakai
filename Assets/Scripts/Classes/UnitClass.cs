using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Create Unit")]
public class UnitClass : ScriptableObject
{
    public bool melee;
    public int damage;
    public int health;
    public int cost;
    public int reward;
    public float speed;
    public float range;
    public GameObject prefab;
    public bool playerOwned;

    public void Attack(UnitClass target)
    {
        if(melee)
        {
            // check distance
            // target.health -= this.damage;
        }
        else
        {

        }
    }
}