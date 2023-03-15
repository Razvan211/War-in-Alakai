using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TextMeshProUGUI goldText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
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
            goldText.text = "Gold: " + playerGold;
        }
    }
}
