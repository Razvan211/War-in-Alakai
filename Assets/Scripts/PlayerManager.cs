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
        void Start()
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

        
        void Update()
        {
            InputManager.InputManager.instance.ManageUnitsMovement();
        }
    }

}
