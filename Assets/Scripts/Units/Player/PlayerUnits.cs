using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


namespace RN.WIA.Units.Player {
    //Adds navMeshAgent to all objects on which the script is attached to
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerUnits : MonoBehaviour
    {
        private NavMeshAgent agent;

        public UnitsStats.Stats pUnitStats;

        public Unit unitType;
        public UnitsHealth unitHealth;
        private void OnEnable()
        {
            pUnitStats = unitType.stats;
            unitHealth.SetUnitHealth(pUnitStats, true);
            agent = GetComponent<NavMeshAgent>();
        }

       
        public void UnitMovement(Vector3 destination)
        {
            if(agent == null)
            {//in case of bugs we get the navmesh if for some reason is not gotten in the OnEnable method
                agent = GetComponent<NavMeshAgent>();
                agent.SetDestination(destination);
            }
            else
            {
                agent.SetDestination(destination);
            }
       
        }

       

       

    }
}




