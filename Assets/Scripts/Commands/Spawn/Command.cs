using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RN.WIA.Commands.Spawn
{
    public class Command : MonoBehaviour
    {
        public void OnClick()
        {
            CommandsManager.instance.BeginSpawnTimer(name);
            
        }
    }
}

