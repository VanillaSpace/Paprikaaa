using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapReaderController : MonoBehaviour
{
    [SerializeField] public Tilemap tilemap;
    [SerializeField] public List<TileData> tileDatas;
    public Dictionary<TileBase, TileData> dataFromTiles;

    private void Start()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();
        
        foreach (TileData tileData in tileDatas)
        {
            foreach (TileBase tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }
    
    public Vector3Int GetGridPosition(Vector2 position, bool mousePosition)
    {
        Vector3 worldPosition;

        if (mousePosition)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(position);
        }
        else
        {
            worldPosition = position;
        }
        
        Vector3Int gridPosition = tilemap.WorldToCell(worldPosition);
        
        return gridPosition;
    }
    
    public TileBase GetTileBase(Vector3Int gridPosition, bool mousePosition = false)
    {
        TileBase tile = tilemap.GetTile(gridPosition);

        return null;
    }

    public TileData GetTileData(TileBase tilebase)
    {
        return dataFromTiles[tilebase];
    }
}
