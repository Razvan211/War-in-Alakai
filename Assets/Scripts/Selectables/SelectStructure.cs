using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RN.WIA.Selectables
{
    public class SelectStructure : Selectables
    {
        public Commands.Spawn.PlayerCommands commands;
   
        
        //Adds selection and sets the buttons
        public override void OnSelect()
        {
            Commands.Spawn.CommandsManager.instance.SetButtons(commands, gameObject);
            base.OnSelect();
           
        }

        //Removes selection and empties commands grid
        public override void RemoveSelection()
        {
            Commands.Spawn.CommandsManager.instance.EmptyCommands();
            base.RemoveSelection();
          
        }

     
    }
}

