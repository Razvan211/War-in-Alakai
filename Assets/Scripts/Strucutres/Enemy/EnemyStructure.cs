using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RN.WIA.Structure.Enemy
{
    public class EnemyStructure : MonoBehaviour
    {

        public StructureStats.Stats stats;

        public Structure structureType;

        public Units.UnitsHealth structHealth;

        private void Start()
        {
            stats = structureType.structStats;
            structHealth.SetStructureHealth(stats, false);
        }
       
    }
}

