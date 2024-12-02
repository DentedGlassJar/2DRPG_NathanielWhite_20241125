using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase playerTile;

    // A vector3Int that is the position of the player
    Vector3Int playerPosition;

    // A vector3Int that is the new position of that player whenever they move
    Vector3Int newPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            tilemap.SetTile(playerPosition, null);
            newPlayerPosition = playerPosition + Vector3Int.left;
            playerPosition = newPlayerPosition; playerPosition = newPlayerPosition;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
                tilemap.SetTile(playerPosition, null);
                newPlayerPosition = playerPosition + Vector3Int.up;
                playerPosition = newPlayerPosition;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            tilemap.SetTile(playerPosition, null);
            newPlayerPosition = playerPosition + Vector3Int.right;
            playerPosition = newPlayerPosition;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            tilemap.SetTile(playerPosition, null);
            newPlayerPosition = playerPosition + Vector3Int.down;
            playerPosition = newPlayerPosition;
        }
    }

}
