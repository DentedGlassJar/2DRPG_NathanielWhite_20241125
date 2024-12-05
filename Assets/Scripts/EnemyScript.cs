using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyScript : MonoBehaviour
{
    // The variable that's used to store sprites in a grid
    public Tilemap tilemap;

    // The TileBase used for the enemy
    public TileBase enemyTile;

    // The gameobject of the playerPosition
    public GameObject playerObj;

    public GameObject winTextObj;

    // The referenced script of PlayerMovement.cs
    PlayerMovement referencePlayerMovement;

    // The referenced script of HealthSystem.cs
    HealthSystem referenceHealthSystem;

    int enemyHealth;

    // A vector3Int that is the position of the enemy
    Vector3Int enemyPosition;

    // A vector3Int that is the new position of that enemy whenever they move
    Vector3Int newEnemyPosition;

    // A vector3Int that is the position of the player
    Vector3Int playerPosition;

    public int currentHealth;

    // A bool that turns true if the player took their turn by moving or attacking
    public bool isPlayerTurnOver;

    private int enemyDamage = 100;
    private int maxHealth = 100;
    private int minHealth = 0;

    private int playerDamage;



    // Start is called before the first frame update
    void Start()
    {
        // This function gets the components of the PlayerMovement script
        referenceHealthSystem = playerObj.GetComponent<HealthSystem>();

        // This function gets the components of the HealthSystem script
        referencePlayerMovement = playerObj.GetComponent<PlayerMovement>();

        enemyPosition = new Vector3Int(7, 6, 0);
    }

    private void LateUpdate()
    {
        Attack();
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        tilemap.SetTile(enemyPosition, enemyTile);

        isPlayerTurnOver = referencePlayerMovement.isPlayerTurnOver;

        playerPosition = referencePlayerMovement.playerPosition;

        if (isPlayerTurnOver == true)
        {
            tilemap.SetTile(enemyPosition, null);

            // If the enemy is to the left of the player, the enemy moves right
            if(enemyPosition.x < playerPosition.x)
            {
                newEnemyPosition = enemyPosition + Vector3Int.right;
                enemyPosition = newEnemyPosition;
                new WaitForSeconds(1);
                isPlayerTurnOver = false;
            }

            // If the enemy is to the right of the player, the enemy moves left
            if (enemyPosition.x > playerPosition.x)
            {
                newEnemyPosition = enemyPosition + Vector3Int.left;
                enemyPosition = newEnemyPosition;
                new WaitForSeconds(1);
                isPlayerTurnOver = false;
            }

            // If the enemy is to the top of the player, the enemy moves down
            if (enemyPosition.y > playerPosition.y)
            {
                newEnemyPosition = enemyPosition + Vector3Int.down;
                enemyPosition = newEnemyPosition;
                new WaitForSeconds(1);
                isPlayerTurnOver = false;
            }

            // If the enemy is to the bottom of the player, the enemy moves up
            if (enemyPosition.y < playerPosition.y)
            {
                newEnemyPosition = enemyPosition + Vector3Int.up;
                enemyPosition = newEnemyPosition;
                new WaitForSeconds(1);

                isPlayerTurnOver = false;
            }
            Debug.Log("Enemy's turn is over, Player's turn starts now");
        }
    }

    private void Attack()
    {
        currentHealth = referenceHealthSystem.currentHealth;

        if (enemyPosition == playerPosition)
        {
            Debug.Log($"{enemyPosition} is equal to {playerPosition}");
            if(isPlayerTurnOver == true)
            {
                Debug.Log("Player turn over is true");
                enemyDamage = Random.Range(1, 16);

                currentHealth = currentHealth - enemyDamage;
                referenceHealthSystem.currentHealth = currentHealth;

                new WaitForSeconds(1);

                isPlayerTurnOver = false;
            }
            else
            {
                enemyHealth = Mathf.Clamp(enemyHealth, minHealth, maxHealth);
                Debug.Log("Player turn over is false");
                playerDamage = Random.Range(1, 21);

                enemyHealth = enemyHealth - playerDamage;
                Debug.Log($"Enemy Health is {enemyHealth}");

                if(enemyHealth <= 0)
                {
                    winTextObj.SetActive(true);
                    return;
                }

                new WaitForSeconds(1);

                isPlayerTurnOver = true;
            }
        }
    }
}
