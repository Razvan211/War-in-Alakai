using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RN.WIA.Structure
{
    public class StructureStats : ScriptableObject
    {
        //stores strucutres stats
        [System.Serializable]
        public class Stats {
            public float health, armor, attack, resources;
        }

    }
}

