using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapNode
{
    string tileType, baseType;
    public readonly Vector2Int gridPosition;
    public readonly Vector2 worldPosition, handlePosition;
    int gridPosX, gridPosY;

    public TileMapNode(string _tileType, int _gridPosX, int _gridPosY, Vector2Int mapOrigin, Vector2 _worldPosition)
    {
        tileType = _tileType;
        baseType = _tileType;
        gridPosX = _gridPosX;
        gridPosY = _gridPosY;
        gridPosition = new Vector2Int(gridPosX, gridPosY);
        worldPosition = new Vector2(gridPosX + 0.5f + mapOrigin.x + _worldPosition.x, gridPosY + 0.5f + mapOrigin.y + _worldPosition.y);
        handlePosition = new Vector2(gridPosX + mapOrigin.x, gridPosY + 0.5f + mapOrigin.y);
    }

    // Get methods
    public string GetTileType()
    {
        return tileType;
    }
    public bool GetObstructed() {
        if (tileType == "obstructed")
        {
            return true;
        }
        return false;
    }
    public bool GetRoughTerrain() {
        if (tileType == "roughTerrain")
        {
            return true;
        }
        return false;
    }
    public bool GetPath() {
        if (tileType == "path")
        {
            return true;
        }
        return false;
    }
    public bool GetClear()
    {
        if (tileType == "clear")
        {
            return true;
        }
        return false;
    }

    // Set Methods
    public void SetTileType(string _tileType)
    {
        tileType = _tileType;
    }

    public void SetTileTypeToBase()
    {
        tileType = baseType;
    }

}
