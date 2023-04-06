using UnityEngine;


namespace RN.WIA.Units
{
    [CreateAssetMenu(fileName = "New Unit", menuName = "Create Spawnables/Create Unit")]
    public class Unit : ScriptableObject
    {
        public enum unitType
        {
            Warrior,
            Mage,
            Catapult
        };

        public bool isPlayerUnit;

        public unitType type;

        public string unitName;

        public GameObject bluePrefab;
        public GameObject redPrefab;

        public int cost;
        public int attack;
        public int health;
        public int armor;
        public float range;
        
    }

}
