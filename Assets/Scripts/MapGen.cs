using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGen : MonoBehaviour
{
    //string pathToMapFile = $"{Application.dataPath}/textFile/textFileMap.txt";

    // The sprites used for the mapTiles
    public GameObject playerGameObject;

    public Tilemap tilemap;
    public TileBase playerTile;
    public TileBase wallTile;
    public TileBase doorTile;
    public TileBase chestTile;
    public TileBase enemyTile;

    // The size for the map
    int width = 15;
    int height = 10;

    // Bool for is that specific tile is walkable or not.
    bool isTileWalkable;

    // The characters used that represents different mapTiles
    string wallStr = "#";
    string doorStr = "O";
    string chestStr = "$";

    // A multidimensional string array that outputs the strings of the map
    public string[,] mapOutput;

    // A bool that turns true if a chest has been created in a map
    bool isChestCreated;

    // A int that increases by one for every created door
    int numOfDoors;

    // A bool that returns true if two doors have been created
    bool isDoorsCreated;

    // A bool that returns true if a valid map has been created
    bool isMapPremade = false;

    // A vector3Int that is the position of the player
    Vector3Int playerPosition;

    // A vector3Int that is the position of the enemy
    Vector3Int enemyPosition;

    // A vector3Int that is the new position of that player whenever they move
    Vector3Int newPlayerPosition;

    // A vector3Int that is the new position of that enemy whenever they move
    Vector3Int newEnemyPosition;

    // Start is called before the first frame update
    void Start()
    {
        numOfDoors = 0;
        isDoorsCreated = false;

        if (tilemap == wallTile)
        {
            isTileWalkable = false;
        }

        if (tilemap == chestTile)
        {
            isTileWalkable = false;
        }

        if (tilemap == doorTile)
        {
            isTileWalkable = false;
        }

        playerPosition = new Vector3Int(2, 2, 0);
        enemyPosition = new Vector3Int(7, 6, 0);
        isChestCreated = false;

        //LoadPremadeMap(File.ReadAllLines(pathToMapFile);
        GenerateMapString();

        ConvertMapToTileMap();

    }

    private void Update()
    {
        PlayerMovement();
        EnemyMovement();
    }

    private void PlayerMovement()
    {
        tilemap.SetTile(playerPosition, playerTile);

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (isTileWalkable == false)
            {
                tilemap.SetTile(playerPosition, null);
                newPlayerPosition = playerPosition + Vector3Int.left;
                playerPosition = newPlayerPosition;
            }
            else
            {
                newPlayerPosition = playerPosition;
                playerPosition = newPlayerPosition;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isTileWalkable == false)
            {
                tilemap.SetTile(playerPosition, null);
                newPlayerPosition = playerPosition + Vector3Int.up;
                playerPosition = newPlayerPosition;
            }
            else
            {
                newPlayerPosition = playerPosition;
                playerPosition = newPlayerPosition;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (isTileWalkable == false)
            {
                tilemap.SetTile(playerPosition, null);
                newPlayerPosition = playerPosition + Vector3Int.right;
                playerPosition = newPlayerPosition;
            }
            else
            {
                newPlayerPosition = playerPosition;
                playerPosition = newPlayerPosition;
            }

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isTileWalkable == false)
            {
                tilemap.SetTile(playerPosition, null);
                newPlayerPosition = playerPosition + Vector3Int.down;
                playerPosition = newPlayerPosition;
            }
            else
            {
                newPlayerPosition = playerPosition;
                playerPosition = newPlayerPosition;
            }
        }
    }

    private void EnemyMovement()
    {
        tilemap.SetTile(enemyPosition, enemyTile);
    }

    // Returns a string of a generated map
    public void GenerateMapString()
    {
        string[,] mapString = new string[width, height];
        mapOutput = new string[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                // Generational Rule for the walls
                if (x == 0 || y == 0 || x == 14 || y == 9)
                {
                    mapString[x, y] = wallStr;
                    mapOutput[x, y] += mapString[x, y];
                }

                // Procedural Generation Rule for the chests
                else if (x == 1 || y == 1 || x == 13 || y == 8)
                {
                    if (x == 1 && y == 1)
                    {
                        if (Random.Range(0, 3) == 0)
                        {
                            mapString[x, y] = chestStr;
                            mapOutput[x, y] += mapString[x, y];
                            isChestCreated = true;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    else if (x == 1 && y == 8)
                    {
                        // Generates a random int between 1 and 2, and continues the loop if it's zero
                        if (Random.Range(0, 3) == 0)
                        {
                            if (isChestCreated == false)
                            {
                                mapString[x, y] = chestStr;
                                mapOutput[x, y] += mapString[x, y];
                                isChestCreated = true;
                            }
                            else
                            {
                                mapString[x, y] = null;
                                mapOutput[x, y] += mapString[x, y];
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    else if (x == 13 && y == 1)
                    {
                        // Generates a random int between 1 and 2, and continues the loop if it's zero
                        if (Random.Range(0, 3) == 0)
                        {
                            if (isChestCreated == false)
                            {
                                mapString[x, y] = chestStr;
                                mapOutput[x, y] += mapString[x, y];
                                isChestCreated = true;
                            }
                            else
                            {
                                mapString[x, y] = null;
                                mapOutput[x, y] += mapString[x, y];
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    else if (x == 13 && y == 8)
                    {
                        if (isChestCreated == false)
                        {
                            mapString[x, y] = chestStr;
                            mapOutput[x, y] += mapString[x, y];
                            isChestCreated = true;
                            continue;
                        }
                    }

                    // Procedural Generation Rule for the doors
                    if (Random.Range(0, 6) == 0)
                    {
                        if (numOfDoors == 2)
                        {
                            isDoorsCreated = true;
                        }

                        if (isDoorsCreated == true)
                        {
                            continue;
                        }

                        if (mapOutput[x, y] == chestStr)
                        {
                            continue;
                        }
                        else
                        {
                            mapString[x, y] = doorStr;
                            mapOutput[x, y] += mapString[x, y];
                            numOfDoors++;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }

    // Converts the map string into a unity tilemap
    void ConvertMapToTileMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (mapOutput[x, y] == wallStr)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), wallTile);
                }

                if (mapOutput[x, y] == chestStr)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), chestTile);
                }

                if (mapOutput[x, y] == doorStr)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), doorTile);
                }
            }
        }
    }

    // Loads a pre-made map from a text assets
    void LoadPremadeMap(string mapFilePath)
    {
    }
}
