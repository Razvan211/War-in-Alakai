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

        [Header("Unit Properties")]
        public unitType type;
        public string unitName;
        public int cost;
        public float timeToSpawn;
        public GameObject bluePrefab;
        public GameObject redPrefab;
        public GameObject spawnImg;
        

        [Header("Units Stats")]
        public UnitsStats.Stats stats;
    }

}
