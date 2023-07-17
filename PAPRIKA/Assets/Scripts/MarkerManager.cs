using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Tilemap targetTilemap;
    [SerializeField] public TileBase tile;

    public Vector3Int markedCellPosition;
    public Vector3Int oldCellPosition;

    private void Update()
    {
        targetTilemap.SetTile(oldCellPosition, null);
        targetTilemap.SetTile(markedCellPosition, tile);
        oldCellPosition = markedCellPosition;
    }
}
