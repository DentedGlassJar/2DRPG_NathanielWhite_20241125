using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Public Variables
    public TextMeshProUGUI healthText;
    
    public GameObject DiedTextObj;

    public GameObject enemyObj;

    // Private Variables
    public int currentHealth = 100;
    private int maxHealth = 100;
    private int minHealth = 0;

    EnemyScript referenceEnemyScript;

    // Start is called before the first frame update
    private void Start()
    {
        referenceEnemyScript = enemyObj.GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthStats();
    }

    private void HealthStats()
    {
        currentHealth = Mathf.Clamp(currentHealth, minHealth, maxHealth);
        Debug.Log($"Current Health is {currentHealth}");

        healthText.text = $"Health: {currentHealth}";

        if (currentHealth == 0)
        {
            DiedTextObj.SetActive(true);
        }
    }

}
