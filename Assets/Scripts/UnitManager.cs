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

        public (float health, float attack, float cost, float armor, float range) GetUnitStats(string type)
        {
            Unit unit;
            switch (type)
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
                    Debug.Log($"Unit Type: {type} does not exist!");
                    return (0, 0, 0, 0, 0);
            }
            return (unit.stats.health, unit.stats.attack, unit.stats.cost, unit.stats.armor, unit.stats.range);
                
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

                    var stats = GetUnitStats(unitName);
                    

                   if (type == playerUnits)
                    {
                        Player.PlayerUnits playerUnit = unit.GetComponent<Player.PlayerUnits>();
                        //set stats for all player units
                        playerUnit.pUnitStats.health = stats.health;
                        playerUnit.pUnitStats.attack = stats.attack;
                        playerUnit.pUnitStats.cost = stats.cost;
                        playerUnit.pUnitStats.armor = stats.armor;
                        playerUnit.pUnitStats.range = stats.range;

                    }
                    else if(type == enemyUnits)
                    {
                        Enemy.EnemyUnits enemyUnit = unit.GetComponent<Enemy.EnemyUnits>();
                        //set stats for all enemy units
                        enemyUnit.eUnitStats.health = stats.health;
                        enemyUnit.eUnitStats.attack = stats.attack;
                        enemyUnit.eUnitStats.cost = stats.cost;
                        enemyUnit.eUnitStats.armor = stats.armor;
                        enemyUnit.eUnitStats.range = stats.range;
                    }

                    
                }
            }
        }

    }

}
