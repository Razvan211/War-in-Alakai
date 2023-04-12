using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RN.WIA.Commands.Spawn
{
    [CreateAssetMenu(fileName = "New Command", menuName = "Command")]
    public class PlayerCommands : ScriptableObject
    {

        public Units.Unit[] units = new Units.Unit[0];
        public Structure.Structure[] structures = new Structure.Structure[0];

    }

}
