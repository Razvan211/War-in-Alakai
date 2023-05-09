using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RN.WIA.Commands.Spawn
{
    [CreateAssetMenu(fileName = "New Command", menuName = "Command")]
    public class PlayerCommands : ScriptableObject
    {
        //store units, structures commands
        public List<Units.Unit> units = new List<Units.Unit>();
        public List<Structure.Structure> structures = new List<Structure.Structure>();

    }

}
