using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Unit", menuName = "Create New Unit")]
public class PlayerMovement : ScriptableObject
{
   

    public enum unitType
    {
        Warrior,
        Mage,
        Catapult
    }

    public unitType type;
    public bool isPlayerunit;

    public GameObject unit;

    public int cost;
    public int attack;
    public int health;
    public int armor;
   

}

