using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RN.WIA.Units
{
    

    public class UnitsStats : ScriptableObject
    {
        [System.Serializable]
        public class Stats
        {
            public float health, attack, cost, armor, range, sightRange, attkSpeed;
        }
       
    }

}
