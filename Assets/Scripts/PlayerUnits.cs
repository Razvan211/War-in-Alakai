using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace RN.WIA.Units.Player {
    //Adds navMeshAgent to all objects on which the script is attached to
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerUnits : MonoBehaviour
    {
        private NavMeshAgent agent;

        public UnitsStats.Stats pUnitStats;

        private void OnEnable()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public void UnitMovement(Vector3 destination)
        {
            agent.SetDestination(destination);
        }
    }
}




