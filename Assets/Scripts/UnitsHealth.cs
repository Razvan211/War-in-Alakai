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

        
        // Start is called before the first frame update
        void Start()
        {
            try
            {//gets stats from playerunit script
                health = gameObject.GetComponentInParent<Player.PlayerUnits>().pUnitStats.health;
                armor = gameObject.GetComponentInParent<Player.PlayerUnits>().pUnitStats.armor;
                isPlayer = true;
            }
            catch (Exception)
            {
                Debug.Log("No player");
                try
                {  //gets stats from enemyunit script
                    health = gameObject.GetComponentInParent<Enemy.EnemyUnits>().eUnitStats.health;
                    armor = gameObject.GetComponentInParent<Enemy.EnemyUnits>().eUnitStats.armor;
                    isPlayer = false;
                }
                catch (Exception)
                {
                Debug.Log("No stats found");
                }

            }
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
                Destroy(gameObject.transform.parent.gameObject.transform);
            }

            
        }

    }
}

