using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionVectors2D : MonoBehaviour
{
    public static readonly Vector2Int northInt = new Vector2Int(0, 1);
    public static readonly Vector2Int southInt = new Vector2Int(0, -1);
    public static readonly Vector2Int eastInt = new Vector2Int(1, 0);
    public static readonly Vector2Int westInt = new Vector2Int(-1, 0);
    public static readonly Vector2Int zeroInt = new Vector2Int(0, 0);
    public static readonly Vector2 northEast = new Vector2(1, 1).normalized;
    public static readonly Vector2 northwest = new Vector2(-1, 1).normalized;
    public static readonly Vector2 southEast = new Vector2(1, -1).normalized;
    public static readonly Vector2 southWest = new Vector2(-1, -1).normalized;
    public static readonly Vector2Int northEastGrid = new Vector2Int(1, 1);
    public static readonly Vector2Int northwestGrid = new Vector2Int(-1, 1);
    public static readonly Vector2Int southEastGrid = new Vector2Int(1, -1);
    public static readonly Vector2Int southWestGrid = new Vector2Int(-1, -1);

    public static readonly List<Vector2Int> cardinalDirectionVectorsInt = new List<Vector2Int>
    {
        northInt,
        southInt,
        eastInt,
        westInt
    };

    public static readonly List<Vector2Int> directionVectorsInt = new List<Vector2Int>
    {
        northInt,
        southInt,
        eastInt,
        westInt,
        northEastGrid,
        northwestGrid,
        southEastGrid,
        southWestGrid
    };

    public static readonly List<Vector2Int> cardinalDirectionVectorsIntIncZero = new List<Vector2Int>
    {
        northInt,
        southInt,
        eastInt,
        westInt,
        zeroInt
    };

    public static string GetVectorIntAbbreviation(Vector2Int direction)
    {
        if (direction == northInt) return "N";
        if (direction == southInt) return "S";
        if (direction == westInt) return "W";
        if (direction == eastInt) return "E";
        if (direction == zeroInt) return "0";
        return "void";
    }
}
