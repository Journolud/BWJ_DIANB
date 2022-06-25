using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private Dictionary<(int, int), RoomInfo> levelMap;
    public GameObject startRoomPrefab;
    public List<GameObject> roomPrefabs;
    Vector2Int head;
    
    // Start is called before the first frame update
    void Start()
    {
        levelMap = new Dictionary<(int, int), RoomInfo>();
        RoomInfo startRoom = new RoomInfo(new Vector2Int(0, 0));
        levelMap.Add((0, 0), startRoom);
        RoomInfo secondRoom = new RoomInfo(new Vector2Int(0, 0));
        levelMap.Add((0, 1), secondRoom);
        head = new Vector2Int(0, 1);

        int roomsGenerated = 0;
        while(roomsGenerated < 8)
        {
            List<Vector2Int> possibleNeighbours = GetFreeNeighbours(head);
            if (possibleNeighbours.Count == 0)
            {
                head = levelMap[(head.x, head.y)].previousRoomLocation;
            }
            else
            {
                Vector2Int nextRoomPosition = possibleNeighbours[Random.Range(0, possibleNeighbours.Count)];
                levelMap.Add((nextRoomPosition.x, nextRoomPosition.y), new RoomInfo(head));
                head = nextRoomPosition;
                Debug.Log(head);
                roomsGenerated++;
            }
        }
        foreach (KeyValuePair<(int, int), RoomInfo> entry in levelMap)
        {
            float x = entry.Key.Item1 * 20;
            float y = entry.Key.Item2 * 13;
            
            if (x == 0 && y == 0)
            {
                Instantiate(startRoomPrefab, new Vector3(x, y, 0), Quaternion.identity);
            }
            else
            {
                GameObject nextRoom = roomPrefabs[Random.Range(0, roomPrefabs.Count)];
                Instantiate(nextRoom, new Vector3(x, y, 0), Quaternion.identity);
            }
            
        }
    }

    List<Vector2Int> GetNeighbourDirectionsAtPoint(Vector2Int position)
    {
        List<Vector2Int> neighbourDirections = new List<Vector2Int>();
        foreach (Vector2Int direction in DirectionVectors2D.cardinalDirectionVectorsInt)
        {
            Vector2Int currentNeighbour = head + direction;
            if (currentNeighbour.Equals(new Vector2(0, 0))) { continue; }
            if (levelMap.ContainsKey((currentNeighbour.x, currentNeighbour.y)))
            {
                neighbourDirections.Add(direction);
            }
        }
        return neighbourDirections;
    }

    List<Vector2Int> GetFreeNeighbours(Vector2Int currentNeighbours)
    {
        List<Vector2Int> freeNeighbours = new List<Vector2Int>();
        foreach (Vector2Int direction in DirectionVectors2D.cardinalDirectionVectorsInt)
        {
            Vector2Int currentNeighbour = head + direction;
            if (!levelMap.ContainsKey((currentNeighbour.x, currentNeighbour.y))){
                freeNeighbours.Add(currentNeighbour);
            }
        }
        return freeNeighbours;
    }
}

public class RoomInfo
{
    List<Vector2Int> neighbours;
    public Vector2Int previousRoomLocation;

    public RoomInfo(Vector2Int _cameFrom)
    {
        previousRoomLocation = _cameFrom;
    }
}
