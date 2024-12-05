using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase playerTile;

    // The game object variable used to get the variables from the MapGen.cs script
    public GameObject tileMapObj;

    // The game object variable used to get the variables from the EnemyScript.cs script
    public GameObject enemyObj;

    // References to different scripts
    MapGen referenceMapGen;
    EnemyScript referenceEnemyScript;

    // The variables that were taken from the MapGen.cs script
    TileBase wallTile;
    TileBase doorTile;
    TileBase chestTile;
    TileBase enemyTile;

    // A vector3Int that is the position of the player
    public Vector3Int playerPosition;

    // A vector3Int that is the new position of that player whenever they move
    Vector3Int newPlayerPosition;

    // A bool that turns true if you took your turn by moving or attacking
    public bool isPlayerTurnOver;

    // Start is called before the first frame update
    void Start()
    {
        referenceMapGen = tileMapObj.GetComponent<MapGen>();
        referenceEnemyScript = enemyObj.GetComponent<EnemyScript>();

        isPlayerTurnOver = false;

        // This function will get references of tha variables in the MapGen.cs
        wallTile = referenceMapGen.wallTile;
        doorTile = referenceMapGen.doorTile;
        chestTile = referenceMapGen.chestTile;


        enemyTile = referenceEnemyScript.enemyTile;

        playerPosition = new Vector3Int(2, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        tilemap.SetTile(playerPosition, playerTile);

        // Checks to see what the status of the isPlayerTurnOver bool is from the EnemyScript.cs file
        isPlayerTurnOver = referenceEnemyScript.isPlayerTurnOver;

        if (isPlayerTurnOver == false)
        {
            // Makes the player go left if they press the A button
            if (Input.GetKeyDown(KeyCode.A))
            {
                tilemap.SetTile(playerPosition, null);
                newPlayerPosition = playerPosition + Vector3Int.left;
                playerPosition = newPlayerPosition;
                new WaitForSeconds(1);

                isPlayerTurnOver = true;
                Debug.Log("Player's turn is over, Enemy's turn starts now");
            }

            // Makes the player go up if they press the W button
            if (Input.GetKeyDown(KeyCode.W))
            {
                tilemap.SetTile(playerPosition, null);
                newPlayerPosition = playerPosition + Vector3Int.up;
                playerPosition = newPlayerPosition;
                new WaitForSeconds(1);

                isPlayerTurnOver = true;
                Debug.Log("Player's turn is over, Enemy's turn starts now");
            }

            // Makes the player go right if they press the D button
            if (Input.GetKeyDown(KeyCode.D))
            {
                tilemap.SetTile(playerPosition, null);
                newPlayerPosition = playerPosition + Vector3Int.right;
                playerPosition = newPlayerPosition;
                new WaitForSeconds(1);

                isPlayerTurnOver = true;
                Debug.Log("Player's turn is over, Enemy's turn starts now");
            }

            // Makes the player go down if they press the S button
            if (Input.GetKeyDown(KeyCode.S))
            {
                tilemap.SetTile(playerPosition, null);
                newPlayerPosition = playerPosition + Vector3Int.down;
                playerPosition = newPlayerPosition;
                new WaitForSeconds(1);

                isPlayerTurnOver = true;
                Debug.Log("Player's turn is over, Enemy's turn starts now");
            }
        }

        // Makes the game restart if they press the R Button
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
