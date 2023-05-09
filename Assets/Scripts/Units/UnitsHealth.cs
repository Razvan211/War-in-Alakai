using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RN.WIA.Units
{
    // class to handle Health, Take Damage and Die methods
    public class UnitsHealth : MonoBehaviour
    {
        public float health, armor, currentHealth;
        [SerializeField] private Image healthAmount;

        private bool isPlayer = false;

        
        public void SetUnitHealth(UnitsStats.Stats stats, bool playerUnit)
        {
            health = stats.health;
            armor = stats.armor;

            isPlayer = playerUnit;
            currentHealth = health;
        }

        public void SetStructureHealth(Structure.StructureStats.Stats stats, bool playerUnit)
        {
            health = stats.health;
            armor = stats.armor;

            isPlayer = playerUnit;
            currentHealth = health;
        }
        // Update is called once per frame
        void Update()
        {
            Health();
        }


        //handles the healthbar
        public void TakeDamage(float damage)
        {
            float takenDamage = damage - armor;
            currentHealth -= takenDamage;
        }

        private void Health()
        {
            Camera cam = Camera.main;
            //rotates healthbars to look at the camera
            gameObject.transform.LookAt(gameObject.transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);

            //handles the healthbar 
            healthAmount.fillAmount = currentHealth / health;
           
            if (currentHealth <= 0)
            {

                Die();
            }
        }

        //handles death
        private void Die()
        {
            if (isPlayer)
            {
                InputManager.InputManager.instance.selectedUnits.Remove(gameObject.transform.parent.gameObject.transform);
                Destroy(gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject.transform.parent.gameObject);
            }

            
        }

    }
}

