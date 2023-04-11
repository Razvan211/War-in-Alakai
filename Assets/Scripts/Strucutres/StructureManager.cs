using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RN.WIA.Structure
{
    public class StructureManager : MonoBehaviour
    {
       
            public static StructureManager instance;



            [SerializeField]
            private Structure castle, lumberMill, mageTower, workshop;

            private void Awake()
            {
                // Singleton 
                if (instance != null && instance != this)
                {
                    Destroy(gameObject);
                    return;
                }
                instance = this;
                DontDestroyOnLoad(gameObject);
            }


            public StructureStats.Stats GetStats(string type)
            {
                Structure structure;
                switch (type)
                {
                    case "castle":
                        structure = castle;
                        break;
                    case "lumbermill":
                        structure = lumberMill;
                        break;
                    case "magetower":
                        structure = mageTower;
                        break;
                    case "workshop":
                        structure = workshop;
                        break;
                    default:
                        Debug.Log($"Unit Type: {type} does not exist!");
                        return null;
                }
                return structure.structStats;

            }

        }
    }



