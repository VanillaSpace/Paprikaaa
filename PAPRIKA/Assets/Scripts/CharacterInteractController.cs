using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
   private CharacterController2D characterController;
   private Rigidbody2D rgbd2d;
   [SerializeField] public float offsetDistance = 1.0f;
   [SerializeField] public float sizeOfInteractableArea = 1.2f;
   private Character character;

   [SerializeReference] HighlightController highlightController;
   
   private void Awake()
   {
      characterController = GetComponent<CharacterController2D>();
      rgbd2d = GetComponent<Rigidbody2D>();
      character = GetComponent<Character>();
   }
   
   private void Update()
   {
      Check();
      
      if (Input.GetMouseButton(1))
      {
         Interact();
      }
   }


   private void Check()
   {
      Vector2 position = rgbd2d.position + characterController.lastMotionVector * offsetDistance;

      Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
      
      foreach (Collider2D c in colliders)
      {
         Interactable hit = c.GetComponent<Interactable>();
         if (hit != null)
         {
            highlightController.Highlight(hit.gameObject);
            break;
         }
      }
   }
   private void Interact()
   {
      Vector2 position = rgbd2d.position + characterController.lastMotionVector * offsetDistance;

      Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

      foreach (Collider2D c in colliders)
      {
         Interactable hit = c.GetComponent<Interactable>();
         if (hit != null)
         {
            hit.Interact(character);
            break;
         }
      }
   }
}
