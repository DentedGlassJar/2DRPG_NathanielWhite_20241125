using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyScript : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase enemyTile;

    public GameObject playerObj;

    PlayerMovement referencePlayerMovement;

    // A vector3Int that is the position of the enemy
    Vector3Int enemyPosition;

    // A vector3Int that is the new position of that enemy whenever they move
    Vector3Int newEnemyPosition;

    // A bool that turns true if the player took their turn by moving or attacking
    public bool isPlayerTurnOver;

    // Start is called before the first frame update
    void Start()
    {
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

        if (isPlayerTurnOver == true)
        {
            Debug.Log("Player's turn is over, Enemy's turn starts now");
            tilemap.SetTile(enemyPosition, null);
            newEnemyPosition = enemyPosition + Vector3Int.up;
            enemyPosition = newEnemyPosition;

            isPlayerTurnOver = false;
            Debug.Log("Enemy's turn is over, Player's turn starts now");
        }
    }
}
