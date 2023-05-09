using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RN.WIA.Player;


namespace RN.WIA.Units
{
    public class UnitManager : MonoBehaviour
    {
        public static UnitManager instance;

        public LayerMask playerUnitLayer, enemyUnitLayer;

        [SerializeField]
        private Unit warrior, mage, catapult;

        private void Awake()
        {
            // Singleton 
            if(instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //gets the stats based on the unit type
        public UnitsStats.Stats GetStats(string unitType)
        {
            Unit unit;
            switch (unitType)
            {
                case "warrior":
                    unit = warrior;
                    break;
                case "mage":
                    unit = mage;
                    break;
                case "catapult":
                    unit = catapult;
                    break;
                default:
                    Debug.Log($"Unit Type: {unitType} does not exist!");
                    return null;
            }
            return unit.stats;
                
        }

       

    }

}
