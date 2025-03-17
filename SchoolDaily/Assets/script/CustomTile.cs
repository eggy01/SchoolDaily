using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(fileName = "New Custom Tile", menuName = "Tilemap/Custom Tile")]
public class CustomTile : Tile
{
    public new Sprite sprite;
    public Vector3Int[] coveredCells;

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = sprite;
        tileData.flags = TileFlags.LockTransform;
        tileData.transform = Matrix4x4.identity;
    }
}
