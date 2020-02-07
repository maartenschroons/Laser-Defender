using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    TextMeshProUGUI healthText;
    Player player;
    int health;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        health = player.getHealth();
        if (health < 0) { health = 0; }
        healthText.text = health.ToString();
    }
}
