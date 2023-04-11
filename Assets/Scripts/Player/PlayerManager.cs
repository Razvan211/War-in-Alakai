using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RN.WIA.InputManager;

namespace RN.WIA.Player
{
    public class PlayerManager : MonoBehaviour
    {
        
        public static PlayerManager instance;

        public Transform playerUnits;
        public Transform enemyUnits;

        public Transform playerStructures;
        public Transform enemyStructures;
        void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
            SetStats(playerUnits);
            SetStats(enemyUnits);
            SetStats(playerStructures);
            SetStats(enemyStructures);
        }

       

        private void Update()
        {
            InputManager.InputManager.instance.ManageUnitsMovement();
        }


        //this method sets the stats for all units and structures in the game
        //all of them are stored in designated empty objects in the scene
        public void SetStats(Transform type)
        {
         
            //iterates thorugh the childs of the empty objects
            foreach (Transform child in type)
            {
                //iterates thorugh the objects stored in the childs of the empty objects
                foreach (Transform obj in child)
                {
                    // remove the last letter and make the string lower case
                    string name = child.name.Substring(0, child.name.Length - 1).ToLower();

                   // var stats = Units.UnitManager.instance.GetStats(name);


                    if (type == playerUnits)
                    {
                        Units.Player.PlayerUnits playerUnit = obj.GetComponent<Units.Player.PlayerUnits>();
                        //set stats for all player units
                        playerUnit.pUnitStats = Units.UnitManager.instance.GetStats(name);

                    }
                    else if (type == enemyUnits)
                    {
                        Units.Enemy.EnemyUnits enemyUnit = obj.GetComponent<Units.Enemy.EnemyUnits>();
                        //set stats for all enemy units
                        enemyUnit.eUnitStats = Units.UnitManager.instance.GetStats(name);
                    }
                    else if (type == playerStructures)
                    {
                        Structure.Player.PlayerStructure playerStrcture = obj.GetComponent<Structure.Player.PlayerStructure>();
                        //sets stats for all player structures
                        playerStrcture.stats = Structure.StructureManager.instance.GetStats(name);
                    }
                    else if(type == enemyStructures)
                    {
                        Structure.Enemy.EnemyStructure enemyStrcture = obj.GetComponent<Structure.Enemy.EnemyStructure>();
                        //sets stats for all enemy structures
                        enemyStrcture.stats = Structure.StructureManager.instance.GetStats(name);
                    }

                }
            }
        }
    }

}
