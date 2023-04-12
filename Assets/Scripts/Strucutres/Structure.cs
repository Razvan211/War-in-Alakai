using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RN.WIA.Structure
{
    [CreateAssetMenu(fileName = "Structure", menuName = "Strucures/New Strucure")]
    public class Structure : ScriptableObject
    {
        public enum structureType
        {
            Castle,
            LumberMill,
            MageTower,
            Workshop
        }

        public enum structureResources
        {
            Gold
        }

        [Header("Structure Properties")]
        public structureType type;
        public structureResources resources;
        public string structureName;
        public int cost;
        public float timeToSpawn;
        public GameObject bluePrefab;
        public GameObject redPrefab;
        public GameObject spawnImg;


        [Header("Structure Stats")]
        public StructureStats.Stats structStats;
    }
}

