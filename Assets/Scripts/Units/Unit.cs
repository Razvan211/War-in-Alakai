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
        public GameObject bluePrefab;
        public GameObject redPrefab;

        [Header("Units Stats")]


        public UnitsStats.Stats stats;
    }

}
