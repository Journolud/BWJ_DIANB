using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomManager : MonoBehaviour
{
    // Tilemap variables - Cell size of tilemap must be set to 1 
    Tilemap mainTileMap;

    public TileBase doorTopLeft, doorTopRight, doorBottomLeft, doorBottomRight, doorRightTop, doorRightBottom, doorLeftTop, doorLeftBottom;
    public GameObject doorTop, doorBottom, doorLeft, doorRight;

    public void Start()
    {
        mainTileMap = transform.Find("Grid/MainTileMap").gameObject.GetComponent<Tilemap>();
        List<Vector2Int> neighbourDirections = new List<Vector2Int>();
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
                Debug.Log("Neighbour above");
                mainTileMap.SetTile(new Vector3Int(-1, 4, 0), doorTopLeft);
                mainTileMap.SetTile(new Vector3Int(0, 4, 0), doorTopRight);
                Instantiate(doorTop, transform.position, Quaternion.identity);
            }
            if (direction.Equals(new Vector2Int(0, -1)))
            {
                Debug.Log("Neighbour below");
                mainTileMap.SetTile(new Vector3Int(-1, -5, 0), doorBottomLeft);
                mainTileMap.SetTile(new Vector3Int(0, -5, 0), doorBottomRight);
                Instantiate(doorBottom, transform.position, Quaternion.identity);
            }
            if (direction.Equals(new Vector2Int(1, 0)))
            {
                mainTileMap.SetTile(new Vector3Int(8, 0, 0), doorRightTop);
                mainTileMap.SetTile(new Vector3Int(8, -1, 0), doorRightBottom);
                Instantiate(doorRight, transform.position, Quaternion.identity);
                Debug.Log("Neighbour right");
            }

            if (direction.Equals(new Vector2Int(-1, 0)))
            {
                mainTileMap.SetTile(new Vector3Int(-9, 0, 0), doorLeftTop);
                mainTileMap.SetTile(new Vector3Int(-9, -1, 0), doorLeftBottom);
                Instantiate(doorLeft, transform.position, Quaternion.identity);
                Debug.Log("Neighbour right");
                Debug.Log("Neighbour left");
            }
        }
    }

    public void SetNeighbours(List<Vector2Int> _neighbourDirections)
    {
        mainTileMap = transform.Find("Grid/MainTileMap").gameObject.GetComponent<Tilemap>();
        foreach (Vector2Int direction in _neighbourDirections)
        {
            Debug.Log("Neighbour at");
            Debug.Log(direction);
            Debug.Log("Tilemap size");
            Debug.Log(mainTileMap.size);
            
            if (direction.Equals(new Vector2Int(0, 1)))
            {
                Debug.Log("Neighbour above");
                mainTileMap.SetTile(new Vector3Int(-1, 4, 0), doorTopLeft);
                mainTileMap.SetTile(new Vector3Int(0, 4, 0), doorTopRight);
            }
            if (direction.Equals(new Vector2Int(0, -1)))
            {
                Debug.Log("Neighbour below");
                mainTileMap.SetTile(new Vector3Int(-1, -4, 0), doorTopLeft);
                mainTileMap.SetTile(new Vector3Int(0, -4, 0), doorTopRight);
            }
            if (direction.Equals(new Vector2Int(1, 0)))
            {
                Debug.Log("Neighbour right");
            }

            if (direction.Equals(new Vector2Int(-1, 0)))
            {
                Debug.Log("Neighbour left");
            }
        }
    }

}


