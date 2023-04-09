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

        //variables for healthbar
        public GameObject unitHealthbar;

        public Image healthAmout;
        public float currentHealth;

        private void Start()
        {
            currentHealth = pUnitStats.health;
        }
        private void OnEnable()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            Health();
        }
        public void UnitMovement(Vector3 destination)
        {
            agent.SetDestination(destination);
        }

        //handles the healthbar
        private void Health()
        {
            Camera cam = Camera.main;
            //rotates healthbars to look at the camera
            unitHealthbar.transform.LookAt(unitHealthbar.transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);

            healthAmout.fillAmount = currentHealth / pUnitStats.health;

            if(currentHealth <= 0)
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

        public void TakeDamage(float damage)
        {
            float takenDamage = damage + pUnitStats.armor;
            currentHealth -= takenDamage;
        }
    }
}




