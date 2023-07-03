using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
   [SerializeField] private GameObject panel;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.E)) // Following minecraft's control scheme
      {
         ToggleInventory();
      }
   }

   public void ToggleInventory()
   {
      panel.SetActive(!panel.activeInHierarchy);
   }
}


