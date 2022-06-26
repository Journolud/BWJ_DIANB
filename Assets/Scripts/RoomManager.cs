using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomManager : MonoBehaviour
{
    // Tilemap variables - Cell size of tilemap must be set to 1 
    Tilemap mainTileMap;

    public TileBase doorTopLeft, doorTopRight, doorBottomLeft, doorBottomRight, doorRightTop, doorRightBottom, doorLeftTop, doorLeftBottom;
    public TileBase doorTopLeftOpen, doorTopRightOpen, doorBottomLeftOpen, doorBottomRightOpen, doorRightTopOpen, doorRightBottomOpen, doorLeftTopOpen, doorLeftBottomOpen;
    public GameObject doorTop, doorBottom, doorLeft, doorRight;
    List<Vector2Int> neighbourDirections;

    public int enemies = 0;
    public List<Door> doors;

    public void Start()
    {
        doors = new List<Door>();

        mainTileMap = transform.Find("Grid/MainTileMap").gameObject.GetComponent<Tilemap>();
        neighbourDirections = new List<Vector2Int>();
        int layer_mask = LayerMask.GetMask("RoomDetection");

        foreach (Vector2Int direction in DirectionVectors2D.cardinalDirectionVectorsInt)
        {
            RaycastHit2D[] hits;
            if (direction.x == 0)
            {
                hits = Physics2D.RaycastAll(transform.position, direction, 20, layer_mask);
            }
            else
            {
                hits = Physics2D.RaycastAll(transform.position, direction, 20, layer_mask);
            }
            

            if (hits.Length > 1)
            {
                neighbourDirections.Add(direction);
            }
        }

        foreach (Vector2Int direction in neighbourDirections)
        {
            if (direction.Equals(new Vector2Int(0, 1)))
            {
                mainTileMap.SetTile(new Vector3Int(-1, 4, 0), doorTopLeft);
                mainTileMap.SetTile(new Vector3Int(0, 4, 0), doorTopRight);
            }
            if (direction.Equals(new Vector2Int(0, -1)))
            {
                mainTileMap.SetTile(new Vector3Int(-1, -5, 0), doorBottomLeft);
                mainTileMap.SetTile(new Vector3Int(0, -5, 0), doorBottomRight);
            }
            if (direction.Equals(new Vector2Int(1, 0)))
            {
                mainTileMap.SetTile(new Vector3Int(8, 0, 0), doorRightTop);
                mainTileMap.SetTile(new Vector3Int(8, -1, 0), doorRightBottom);
            }

            if (direction.Equals(new Vector2Int(-1, 0)))
            {
                mainTileMap.SetTile(new Vector3Int(-9, 0, 0), doorLeftTop);
                mainTileMap.SetTile(new Vector3Int(-9, -1, 0), doorLeftBottom);
            }
        }

        if (enemies == 0)
        {
            OpenDoors();
        }
    }

    private void OpenDoors()
    {
        foreach (Vector2Int direction in neighbourDirections)
        {
            if (direction.Equals(new Vector2Int(0, 1)))
            {
                mainTileMap.SetTile(new Vector3Int(-1, 4, 0), doorTopLeftOpen);
                mainTileMap.SetTile(new Vector3Int(0, 4, 0), doorTopRightOpen);
                Instantiate(doorTop, transform.position, Quaternion.identity);
            }
            if (direction.Equals(new Vector2Int(0, -1)))
            {
                mainTileMap.SetTile(new Vector3Int(-1, -5, 0), doorBottomLeftOpen);
                mainTileMap.SetTile(new Vector3Int(0, -5, 0), doorBottomRightOpen);
                Instantiate(doorBottom, transform.position, Quaternion.identity);
            }
            if (direction.Equals(new Vector2Int(1, 0)))
            {
                mainTileMap.SetTile(new Vector3Int(8, 0, 0), doorRightTopOpen);
                mainTileMap.SetTile(new Vector3Int(8, -1, 0), doorRightBottomOpen);
                Instantiate(doorRight, transform.position, Quaternion.identity);
            }

            if (direction.Equals(new Vector2Int(-1, 0)))
            {
                mainTileMap.SetTile(new Vector3Int(-9, 0, 0), doorLeftTopOpen);
                mainTileMap.SetTile(new Vector3Int(-9, -1, 0), doorLeftBottomOpen);
                Instantiate(doorLeft, transform.position, Quaternion.identity);
            }
        }
    }

    public void EnemyKilled()
    {
        enemies -= 1;
        if (enemies == 0)
        {
            OpenDoors();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player") { return; }
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.tag == "Enemy")
            {
                if (transform.GetChild(i).gameObject.GetComponent<Enemy>())
                {
                    transform.GetChild(i).gameObject.GetComponent<Enemy>().active = true;
                }
            }

        }
    }

}


