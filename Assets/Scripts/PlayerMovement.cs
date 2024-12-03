using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase playerTile;

    // The game object variable used to get the variables from the MapGen.cs script
    public GameObject tileMapObj;

    // The variables that were taken from the MapGen.cs script
    MapGen wallTile;
    MapGen doorTile;
    MapGen chestTile;
    MapGen enemyTile;

    // A vector3Int that is the position of the player
    Vector3Int playerPosition;

    // A vector3Int that is the new position of that player whenever they move
    Vector3Int newPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        // This function will get the MapGen.cs script of the TileMap GameObject
        wallTile = tileMapObj.GetComponent<MapGen>();
        doorTile = tileMapObj.GetComponent<MapGen>();
        chestTile = tileMapObj.GetComponent<MapGen>();
        enemyTile = tileMapObj.GetComponent<MapGen>();

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

        // Makes the player go left if they press the A button
        if (Input.GetKeyDown(KeyCode.A))
        {
            tilemap.SetTile(playerPosition, null);
            newPlayerPosition = playerPosition + Vector3Int.left;
            playerPosition = newPlayerPosition;

            if (playerTile.Equals(wallTile || doorTile || chestTile))
            {
                playerPosition += Vector3Int.right;
            }
        }

        // Makes the player go up if they press the W button
        if (Input.GetKeyDown(KeyCode.W))
        {
                tilemap.SetTile(playerPosition, null);
                newPlayerPosition = playerPosition + Vector3Int.up;
                playerPosition = newPlayerPosition;

            if (playerTile.Equals(wallTile || doorTile || chestTile))
            {
                playerPosition += Vector3Int.down;
            }
        }

        // Makes the player go right if they press the D button
        if (Input.GetKeyDown(KeyCode.D))
        {
            tilemap.SetTile(playerPosition, null);
            newPlayerPosition = playerPosition + Vector3Int.right;
            playerPosition = newPlayerPosition;

            if (playerTile.Equals(wallTile || doorTile || chestTile))
            {
                playerPosition += Vector3Int.left;
            }
        }

        // Makes the player go down if they press the S button
        if (Input.GetKeyDown(KeyCode.S))
        {
            tilemap.SetTile(playerPosition, null);
            newPlayerPosition = playerPosition + Vector3Int.down;
            playerPosition = newPlayerPosition;

            if (playerTile.Equals(wallTile || doorTile || chestTile))
            {
                playerPosition += Vector3Int.up;
            }
        }
    }

}
