using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
   [SerializeField] private GameObject panel;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.I))
      {
         ToggleInventory();
      }
   }

   public void ToggleInventory()
   {
      panel.SetActive(!panel.activeInHierarchy);
   }
}


