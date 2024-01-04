using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpreadTilemap : MonoBehaviour
{
    [SerializeField]
    private Tilemap floor; //타일맵 오브젝트
    [SerializeField]
    private Tilemap wall; //타일맵 오브젝트
    [SerializeField]
    private TileBase floorTile; //사용할 타일 에셋
    [SerializeField]
    private TileBase wallTile;  //사용할 타일 에셋

    public void SpreadFloorTilemap (HashSet<Vector2Int> positions)
    {
        SpreadTile(positions, floor, floorTile);
    }

    public void SpreadWallTilemap(HashSet<Vector2Int> positions)
    {
        SpreadTile(positions, wall, wallTile);
    }

    public void SpreadTile(HashSet<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            tilemap.SetTile((Vector3Int) position, tile);
        }
    }

    public void ClearAllTiles()
    {
        floor.ClearAllTiles();
        wall.ClearAllTiles();
    }
}
