using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpreadTilemap : MonoBehaviour
{
    [SerializeField]
    private Tilemap floor; //Ÿ�ϸ� ������Ʈ
    [SerializeField]
    private Tilemap wall; //Ÿ�ϸ� ������Ʈ
    [SerializeField]
    private TileBase floorTile; //����� Ÿ�� ����
    [SerializeField]
    private TileBase wallTile;  //����� Ÿ�� ����

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
