using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RN.WIA.Units.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyUnits : MonoBehaviour
    {
        public UnitsStats.Stats eUnitStats;

        private Collider[] rangeCollider;

        NavMeshAgent agent;

        //target for aggro
        private Transform target;

        private bool hasAggro = false;

        private float distance;

        private void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (!hasAggro)
            {
                SearchEnemy();
            }
            else
            {
                MoveToEnemy();
            }
        }
        private void SearchEnemy()
        {
            rangeCollider = Physics.OverlapSphere(transform.position, eUnitStats.range);
            //checks if an object enters our collider and if the object is a playerunit
            for(int i = 0; i < rangeCollider.Length; i++)
            {
                if(rangeCollider[i].gameObject.layer == UnitManager.instance.playerUnitLayer)
                {
                    target = rangeCollider[i].gameObject.transform;
                    hasAggro = true;
                    break;
                }
            }
        }

        private void MoveToEnemy()
        {
            distance = Vector3.Distance(target.position, transform.position);
            agent.stoppingDistance = (eUnitStats.range + 1);

            if(distance <= eUnitStats.range + 10)
            {
                agent.SetDestination(target.position);
            }
        }
    }

}
