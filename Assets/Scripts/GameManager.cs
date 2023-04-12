using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace RN.WIA.GameManager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance { get; private set; }
        public TextMeshProUGUI goldText;

        private void Awake()
        {
            // Singleton 
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private float timer = 2f;

        public int aiGold = 0;
        public int playerGold = 0;

        private void FixedUpdate()
        {
            if (timer > 0) timer -= Time.deltaTime;
            else
            {
                aiGold += 10;
                playerGold += 10;
                timer = 2f;

            }
            goldText.text = "Gold: " + playerGold;
        }
    }

}
