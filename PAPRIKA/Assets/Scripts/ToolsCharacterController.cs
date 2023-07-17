using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class ToolsCharacterController : MonoBehaviour
{
   private CharacterController2D character;
   private Rigidbody2D rgbd2d;
   [SerializeField] public float offsetDistance = 1.0f;
   [SerializeField] public float sizeOfInteractableArea = 1.2f;
   [SerializeField] public MarkerManager markerManager;
   [SerializeField] public TileMapReaderController tileMapReaderController;

   private void Awake()
   {
      character = GetComponent<CharacterController2D>();
      rgbd2d = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      Marker();
      if (Input.GetMouseButton(0))
      {
         UseTool();
      }
   }

   private void Marker()
   {
      Vector3Int gridPosition = tileMapReaderController.GetGridPosition(Input.mousePosition, true);
      markerManager.markedCellPosition = gridPosition;
   }

   private void UseTool()
   {
      Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;

      Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

      foreach (Collider2D c in colliders)
      {
         ToolHit hit = c.GetComponent<ToolHit>();
         if (hit != null)
         {
            hit.Hit();
            break;
         }
      }
   }
}
