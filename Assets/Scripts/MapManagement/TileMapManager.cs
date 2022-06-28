using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileMapManager : MonoBehaviour
{
    #region variables
    // Testing variables
    public bool drawGizmos;

    // Tilemap variables - Cell size of tilemap must be set to 1
    public Tilemap baseTileMap; // tilemap containing ground tiles such as grass and mud - tilemap must be component of "GroundTileMapObject"

    public Object[] pathTiles; // array holding all tiles prefabs considered as path tiles

    public TileMapNode[,] tileMapArray; // array of nodes with key (gridLocation.x, gridLocation.y)
    public  int sizeX, sizeY; // size of tilemap grid
    Vector2Int mapOrigin; // co-ordinates of bottom left tile in ground tile map

    //Map generation
    public bool generateMap;
    MapGeneration mapGenerator;
    #endregion

    #region grid set up
    void Awake()
    {

        if (generateMap)
        {
            mapGenerator = GetComponent<MapGeneration>();
            mapGenerator.GenerateMap();
            mapGenerator.DetailMap();
        }

        InitialiseTileMapGrid();
        PopulateTileMapGrid();
        GetClearNodes();
    }

    private void InitialiseTileMapGrid()
    {
        // set size of tilemap grid to match the size of the ground tile map
        sizeX = baseTileMap.size.x;
        sizeY = baseTileMap.size.y;
        // set map origin
        mapOrigin = new Vector2Int(baseTileMap.origin.x, baseTileMap.origin.y);
        tileMapArray = new TileMapNode[sizeX, sizeY];

        if (drawGizmos)
        {
            Debug.Log("Map Origin");
            Debug.Log(mapOrigin);
        }
    }

    private void PopulateTileMapGrid()
    {
        // Loop through each node in the tile map array
        Vector2 worldPosition = transform.position;
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                TileBase baseTile = baseTileMap.GetTile(new Vector3Int(x, y, 0) + baseTileMap.origin);
                /*
                if (mainTile != null)
                {
                    if (System.Array.Exists(pathTiles, element => element == mainTile)) // if current tile is a path tile
                    {
                        tileMapArray[x, y] = new TileMapNode("path", x, y, mapOrigin);
                        continue;
                    }
                    else // Tile in main map must be an obstruction
                    {
                        tileMapArray[x, y] = new TileMapNode("obstructed", x, y, mapOrigin);
                        continue;
                    }
                }
                else if (baseTile != null) // If there is no tile in main map but is in ground map
                {
                    tileMapArray[x, y] = new TileMapNode("clear", x, y, mapOrigin);
                    continue;
                }
                else
                {
                    tileMapArray[x, y] = new TileMapNode("obstructed", x, y, mapOrigin);
                    Debug.Log(tileMapArray[x, y].GetPath());
                    continue;
                }
                */

                if (baseTile != null) // If there is no tile in main map but is in ground map
                {
                    tileMapArray[x, y] = new TileMapNode("obstructed", x, y, mapOrigin, worldPosition);
                    continue;
                }
                else
                {
                    tileMapArray[x, y] = new TileMapNode("clear", x, y, mapOrigin, worldPosition);
                    continue;
                }
            }
        }
    }
    #endregion

    #region Grid Utility Methods

    public List<TileMapNode> GetClearNodes()
    {
        List<TileMapNode> clearNodes = new List<TileMapNode>();

        // Loop through each node in the tile map array
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                if (tileMapArray[x, y].GetClear())
                {
                    clearNodes.Add(tileMapArray[x, y]);
                }
            }
        }
        return clearNodes;
    }

    public TileMapNode GetClearNode()
    {
        List<TileMapNode> clearNodes = GetClearNodes();
        TileMapNode clearNode = clearNodes[Random.Range(0, clearNodes.Count)];
        clearNode.SetTileType("path");
        return clearNode;
    }

    public Vector2Int GetGridPosFromWorldPos(Vector2 _worldPos)
    {
        int _gridPosX = Mathf.FloorToInt(_worldPos.x - mapOrigin.x - transform.position.x);
        int _gridPosY = Mathf.FloorToInt(_worldPos.y - mapOrigin.y - transform.position.y);
        return new Vector2Int(_gridPosX, _gridPosY);
    }

    public Vector2Int GetGridPosFromWorldPos(Vector3 _worldPos)
    {
        int _gridPosX = Mathf.FloorToInt(_worldPos.x - mapOrigin.x - transform.position.x);
        int _gridPosY = Mathf.FloorToInt(_worldPos.y - mapOrigin.y - transform.position.y);
        return new Vector2Int(_gridPosX, _gridPosY);
    }

    #endregion

    #region Testing
    private void OnDrawGizmos()
    {
        if (!drawGizmos || tileMapArray == null) return;
        // Set handles color
        Handles.color = Color.magenta;

        for (int x = 0; x < tileMapArray.GetLength(0); x++)
        {
            for (int y = 0; y < tileMapArray.GetLength(1); y++)
            {
                if (tileMapArray[x, y] == null) continue; // If theres no tile in this location continue to next tile
                TileMapNode currentNode = tileMapArray[x, y];
                if (currentNode.GetObstructed())
                {
                    Gizmos.color = Color.red;
                }
                else if (currentNode.GetRoughTerrain())
                {
                    Gizmos.color = Color.yellow;
                }
                else if (currentNode.GetPath())
                {
                    Gizmos.color = Color.white;
                }
                else
                {
                    Gizmos.color = Color.green;
                }
                //Debug.Log(currentNode.worldPosition);
                Gizmos.DrawWireCube(currentNode.worldPosition, new Vector3(0.9f, 0.9f, 0));
                Handles.Label(currentNode.handlePosition, currentNode.gridPosition.ToString());
            }
        }
    }
    #endregion
}
