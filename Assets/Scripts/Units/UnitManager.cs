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

        private void Start()
        {
            playerUnitLayer = LayerMask.NameToLayer("PlayerUnits");
            enemyUnitLayer = LayerMask.NameToLayer("EnemyUnits");
        }

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

        public void SetUnitStats(Transform type)
        {
            Transform playerUnits = PlayerManager.instance.playerUnits;
            Transform enemyUnits = PlayerManager.instance.enemyUnits;
            
            foreach(Transform units in type)
            {
                foreach(Transform unit in units)
                {
                    // remove the last letter and make the string lower case
                    string unitName = units.name.Substring(0, units.name.Length - 1).ToLower();

                    var stats = GetStats(unitName);
                    

                   if (type == playerUnits)
                    {
                        Player.PlayerUnits playerUnit = unit.GetComponent<Player.PlayerUnits>();
                        //set stats for all player units
                        playerUnit.pUnitStats = GetStats(unitName);

                    }
                    else if(type == enemyUnits)
                    {
                        Enemy.EnemyUnits enemyUnit = unit.GetComponent<Enemy.EnemyUnits>();
                        //set stats for all enemy units
                        enemyUnit.eUnitStats = GetStats(unitName);
                    }

                    
                }
            }
        }

    }

}
