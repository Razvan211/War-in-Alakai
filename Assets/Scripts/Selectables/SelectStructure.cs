using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RN.WIA.Selectables
{
    public class SelectStructure : Selectables
    {
        public Commands.Spawn.PlayerCommands commands;
        public GameObject spawnLocation = null;
        
        public override void OnSelect()
        {
            Commands.Spawn.CommandsManager.instance.SetButtons(commands, gameObject);
            base.OnSelect();
           
        }

        public override void RemoveSelection()
        {
            Commands.Spawn.CommandsManager.instance.EmptyCommands();
            base.RemoveSelection();
          
        }

     
    }
}

