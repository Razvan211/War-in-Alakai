using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RN.WIA.Units
{
    public class UnitManager : MonoBehaviour
    {
        public static UnitManager instance;

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

        public (int health, int attack, int cost, int armor, int range) GetUnitStats(string type)
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
            return (unit.health, unit.attack, unit.cost, unit.armor, unit.range);
                
        }

        public void SetUnitStats(Transform type)
        {
            
            foreach(Transform units in type)
            {
                foreach(Transform unit in units)
                {
                    // remove the last letter and make the string lower case
                    string unitName = units.name.Substring(0, units.name.Length - 1).ToLower();

                    var stats = GetUnitStats(unitName);
                    Player.PlayerUnits playerUnit;

                   if (type == WIA.Player.PlayerManager.instance.playerUnits)
                    {
                        playerUnit = unit.GetComponent<Player.PlayerUnits>();
                        //set stats for all units
                        playerUnit.health = stats.health;
                        playerUnit.attack = stats.attack;
                        playerUnit.cost = stats.cost;
                        playerUnit.armor = stats.armor;
                        playerUnit.range = stats.range;

                    }
                    else if(type == WIA.Player.PlayerManager.instance.enemyUnits)
                    {

                    }

                    
                }
            }
        }

    }

}
