using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class MapGeneration : MonoBehaviour
{
    // Tilemap variables - Cell size of tilemap must be set to 1
    Tilemap groundTileMap; // tilemap containing ground tiles such as grass and mud - tilemap must be component of "GroundTileMapObject"
    Tilemap mainTileMap; // tilemap containing main tiles such as walls and placeable items - tilemap must be component of "MainTileMapObject"
    public TileBase sandTile, groundTile, waterTile, rockTile, snowTile, rockSmall;

    public int sizeX, sizeY;
    public Vector2Int origin;
    public bool generateAutomatically;
    private float seedX, seedY;
    public float scale = 10f;

    private void Awake()
    {
        groundTileMap = GameObject.Find("GroundTileMap").GetComponent<Tilemap>(); // assign ground tilemap variable
        mainTileMap = GameObject.Find("MainTileMap").GetComponent<Tilemap>(); // assign main tile map variable
    }

    public void GenerateMap()
    {
        GenerateSeed();
        for (int x = origin.x; x < (sizeX + origin.x); x++)
        {
            for (int y = origin.y; y < (sizeY + origin.y); y++)
            {
                groundTileMap.SetTile(new Vector3Int(x, y, 0), waterTile);
                float perlinValue = GetPerlinValue(x, y);
                 if (perlinValue > 0.75f)
                 {
                    groundTileMap.SetTile(new Vector3Int(x, y, 0), sandTile);
                 }
                 if (perlinValue > 0.80f)
                 {
                    groundTileMap.SetTile(new Vector3Int(x, y, 0), groundTile);
                 }
                 if (perlinValue > 0.88f)
                 {
                    groundTileMap.SetTile(new Vector3Int(x, y, 0), rockTile);
                 }
                 if (perlinValue > 0.96f)
                 {
                     groundTileMap.SetTile(new Vector3Int(x, y, 0), snowTile);
                 }
                
            }
        }
    }

    public void DetailMap()
    {
        for (int x = origin.x; x < (sizeX + origin.x); x++)
        {
            for (int y = origin.y; y < (sizeY + origin.y); y++)
            {
                TileBase currentTile = groundTileMap.GetTile(new Vector3Int(x, y, 0));
                if (currentTile == groundTile)
                {
                    Debug.Log("Placed tile");
                    Debug.Log(Random.Range(0, 1f));
                    if (Random.Range(0, 1f) < 0.05f)
                    {
                        mainTileMap.SetTile(new Vector3Int(x, y, 0), rockSmall);
                    }
                }
            }
        }
    }

    private void GenerateSeed()
    {
        seedX = Random.Range(0, 3000f);
        seedY = Random.Range(0, 3000f);
    }

    private float GetPerlinValue(int x, int y)
    {
        int xGridCord = x - origin.x;
        int yGridCord = y - origin.y;
        float xPerlinCoord = (float)xGridCord / sizeX * scale + seedX;
        float yPerlinCoord = (float)yGridCord / sizeY * scale + seedY;
        return Mathf.PerlinNoise(xPerlinCoord, yPerlinCoord);
    }
}
