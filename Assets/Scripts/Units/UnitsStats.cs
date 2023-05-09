using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RN.WIA.Units
{
    
    //stores the stats for units
    public class UnitsStats : ScriptableObject
    {
        [System.Serializable]
        public class Stats
        {
            public float health, attack, cost, armor, range, sightRange, attkSpeed;
        }
       
    }

}
