using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RN.WIA.Structure
{
    public class StructureStats : ScriptableObject
    {
        [System.Serializable]
        public class StrucutreStats {
            public float health, armor, attack, resources;
        }

    }
}

