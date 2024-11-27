using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Public Variables
    public TextMeshProUGUI healthText;

    // Private Variables
    private int currentHealth = 100;
    private int maxHealth = 100;
    private int minHealth = 0;

    // Update is called once per frame
    void LateUpdate()
    {
        currentHealth = Mathf.Clamp(currentHealth, minHealth, maxHealth);
        
    }
}
