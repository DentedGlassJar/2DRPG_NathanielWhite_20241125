using System.Collections;
using System.Collections.Generic;
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

    // The referenced script of PlayerMovement.cs
    PlayerMovement referencePlayerMovement;

    // A vector3Int that is the position of the enemy
    Vector3Int enemyPosition;

    // A vector3Int that is the new position of that enemy whenever they move
    Vector3Int newEnemyPosition;

    // A vector3Int that is the position of the player
    Vector3Int playerPosition;

    // A bool that turns true if the player took their turn by moving or attacking
    public bool isPlayerTurnOver;



    // Start is called before the first frame update
    void Start()
    {
        // This function gets the components of the PlayerMovement script.
        referencePlayerMovement = playerObj.GetComponent<PlayerMovement>();

        enemyPosition = new Vector3Int(7, 6, 0);
    }

    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        tilemap.SetTile(enemyPosition, enemyTile);

        isPlayerTurnOver = referencePlayerMovement.isPlayerTurnOver;

        playerPosition = referencePlayerMovement.playerPosition;

        if (isPlayerTurnOver == true)
        {
            Debug.Log("Player's turn is over, Enemy's turn starts now");
            tilemap.SetTile(enemyPosition, null);

            // If the enemy is to the left of the player, the enemy moves right
            if(enemyPosition.x < playerPosition.x)
            {
                newEnemyPosition = enemyPosition + Vector3Int.right;
                enemyPosition = newEnemyPosition;
            }

            // If the enemy is to the right of the player, the enemy moves left
            if (enemyPosition.x > playerPosition.x)
            {
                newEnemyPosition = enemyPosition + Vector3Int.left;
                enemyPosition = newEnemyPosition;
            }

            // If the enemy is to the top of the player, the enemy moves down
            if (enemyPosition.y > playerPosition.y)
            {
                newEnemyPosition = enemyPosition + Vector3Int.down;
                enemyPosition = newEnemyPosition;
            }

            // If the enemy is to the bottom of the player, the enemy moves up
            if (enemyPosition.y < playerPosition.y)
            {
                newEnemyPosition = enemyPosition + Vector3Int.up;
                enemyPosition = newEnemyPosition;
            }

            isPlayerTurnOver = false;
            Debug.Log("Enemy's turn is over, Player's turn starts now");
        }
    }
}
