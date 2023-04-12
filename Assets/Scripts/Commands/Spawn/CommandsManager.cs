using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RN.WIA.Commands.Spawn
{
    public class CommandsManager : MonoBehaviour
    {
        public static CommandsManager instance = null;

        [SerializeField] private Button commandBtn = null;
        [SerializeField] private Transform commandGroup = null;

        private List<Button> buttons = new List<Button>();

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

        //Sets the Buttons for spawning
        public void SetButtons(PlayerCommands commands)
        {
            //checks if there are any units in the list
            if (commands.units.Length > 0)
            {//iterates thorugh all the units in the list 
                foreach (Units.Unit unit in commands.units)
                {
                    //sets the buttons for each unit, in the parent (commandGroup)
                    Button btn = Instantiate(commandBtn, commandGroup);
                    btn.name = unit.name;
                    buttons.Add(btn);
                }
            }

            //checks if there are any structures in the list
            if (commands.structures.Length > 0)
            {//iterates through all the structures in the list
                foreach (Structure.Structure structure in commands.structures)
                {
                    //sets the buttons for each structure, in the parent(commandGroup)
                    Button btn = Instantiate(commandBtn, commandGroup);
                    btn.name = structure.name;
                    buttons.Add(btn);
                }
            }
        }
            //emptyes the pannel (commandGroup)
            public void EmptyCommands()
            {
                foreach (Button btn in buttons)
                {
                   
                    Destroy(btn.gameObject);
                }
            buttons.Clear();
            }
    }
}

