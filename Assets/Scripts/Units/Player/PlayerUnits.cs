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

        private GameObject target;
        private float lastAttackTime;
        

        private void Start()
        {
            pUnitStats = unitType.stats;
            unitHealth.SetUnitHealth(pUnitStats, true);
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            //handles the attack logic
            if (target != null && Vector3.Distance(transform.position, target.transform.position) <= pUnitStats.range)
            {
                if (Time.time - lastAttackTime > pUnitStats.attkSpeed)
                {
                    RN.WIA.Structure.Enemy.EnemyStructure structure = target.GetComponent<RN.WIA.Structure.Enemy.EnemyStructure>();
                    RN.WIA.Units.Enemy.EnemyUnits unit = target.GetComponent<RN.WIA.Units.Enemy.EnemyUnits>();
                    if (structure) structure.structHealth.TakeDamage(pUnitStats.attack);
                    if (unit) unit.unitHealth.TakeDamage(pUnitStats.attack);
                    lastAttackTime = Time.time;
                }
                agent.isStopped = true;
            }
            else if( target != null)
            {
                agent.isStopped = false;
                agent.SetDestination(target.transform.position);
            }
            else
            {
                agent.isStopped = false;
            }

        }

        //sets the target to attack
        public void SetTarget(GameObject newTarget)
        {
            if (target == null && newTarget == null) return;
            if (newTarget == null)
            {
                target = null;
                return;
            }
            target = newTarget;
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if(distance > pUnitStats.range)
            {
                float adjustedDistance = distance - pUnitStats.range;
                Vector3 direction = (target.transform.position - transform.position).normalized;
                Vector3 destination = target.transform.position - direction * adjustedDistance;
                agent.SetDestination(destination);
            }
            transform.LookAt(target.transform.position);
        }

        //handles movement
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




