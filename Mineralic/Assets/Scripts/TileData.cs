using UnityEngine;
using System.Collections;

public class TileData : MonoBehaviour
{
    [Tooltip("0 = stone, 1 = dirt, 2 = grass, 3 = coal, 4 = diamond, 5 = gold, 6 = iron, 7 = glass, 8 = stone bricks,")]
    public int TileType;

    public int hardness;

    void Update()
    {
    }
}