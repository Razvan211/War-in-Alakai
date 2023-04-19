using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RN.WIA.Commands.Spawn
{
    public class Timer : MonoBehaviour
    {
        public static Timer instance = null;

        private void Awake()
        {
            // Singleton 
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

        }

        public IEnumerator SpawnTime()
        {
            if(CommandsManager.instance.spawnCount.Count > 0)
            {
                Debug.Log($"Waiting for {CommandsManager.instance.spawnCount[0]}");

                yield return new WaitForSeconds(CommandsManager.instance.spawnCount[0]);

                CommandsManager.instance.SpawnObj();

                CommandsManager.instance.spawnCount.Remove(CommandsManager.instance.spawnCount[0]);

                //it starts over if the spawnCount is bigger than 0
                if(CommandsManager.instance.spawnCount.Count > 0)
                {
                    StartCoroutine(SpawnTime());
                }
            }
        }
    }

}
