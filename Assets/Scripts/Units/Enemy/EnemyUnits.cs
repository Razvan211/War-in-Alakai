using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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

        private UnitsHealth playerUnit;

        private bool hasAggro = false;

        private float distance;

        private float attackCd;

        private void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
        
        }

        private void Update()
        {
            attackCd -= Time.deltaTime;
            if (!hasAggro)
            {
                SearchEnemy();
            }
            else
            {
                MoveToEnemy();
                Attack();
            }
        }

     
        private void SearchEnemy()
        {
            rangeCollider = Physics.OverlapSphere(transform.position, eUnitStats.sightRange, UnitManager.instance.playerUnitLayer);
            //checks if an object enters our collider and if the object is a playerunit
            for(int i = 0; i < rangeCollider.Length;)
            {
                target = rangeCollider[i].gameObject.transform;
                playerUnit = target.gameObject.GetComponentInChildren<UnitsHealth>();
                hasAggro = true;
                break;
            }
        }

        private void MoveToEnemy()
        {
            if (target == null)
            {
                agent.SetDestination(transform.position);
                hasAggro = false;
            }
            else
            {
                distance = Vector3.Distance(target.position, transform.position);
                agent.stoppingDistance = (eUnitStats.range + 1);

                if (distance <= eUnitStats.sightRange)
                {
                    agent.SetDestination(target.position);
                }
            }

        }


        private void Attack()
        {
            if(attackCd <= 0 && distance <= eUnitStats.range + 1)
            {
                playerUnit.TakeDamage(eUnitStats.attack);
                attackCd = eUnitStats.attkSpeed;
            }
        }
    }

}
