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

        private Player.PlayerUnits playerUnit;

        private bool hasAggro = false;

        private float distance;

        //variables for healthbar
        public GameObject unitHealthbar;
        public Image healthAmout;
        public float currentHealth;


        private float attackCd;

        private void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            currentHealth = eUnitStats.health;
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

        private void LateUpdate()
        {
            Health();
        }
        private void SearchEnemy()
        {
            rangeCollider = Physics.OverlapSphere(transform.position, eUnitStats.sightRange);
            //checks if an object enters our collider and if the object is a playerunit
            for(int i = 0; i < rangeCollider.Length; i++)
            {
                if(rangeCollider[i].gameObject.layer == UnitManager.instance.playerUnitLayer)
                {
                    target = rangeCollider[i].gameObject.transform;
                    playerUnit = target.gameObject.GetComponent<Player.PlayerUnits>();
                    hasAggro = true;
                    break;
                }
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


        private void Health()
        {
            Camera cam = Camera.main;
            //rotates healthbars to look at the camera
            unitHealthbar.transform.LookAt(unitHealthbar.transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);

            healthAmout.fillAmount = currentHealth / eUnitStats.health;

            if (currentHealth <= 0)
            {
                
                Die();
            }
        }

        //handles death
        private void Die()
        {
            InputManager.InputManager.instance.selectedUnits.Remove(gameObject.transform);
            Destroy(gameObject);
        }

        private void TakeDamage(float damage)
        {
            float takenDamage = damage + eUnitStats.armor;
            currentHealth -= takenDamage;
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
