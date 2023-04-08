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
        }

        private void Start()
        {
            Units.UnitManager.instance.SetUnitStats(playerUnits);
            Units.UnitManager.instance.SetUnitStats(enemyUnits);
        }


        void Update()
        {
            InputManager.InputManager.instance.ManageUnitsMovement();
        }
    }

}
