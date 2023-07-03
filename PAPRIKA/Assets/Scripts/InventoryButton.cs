using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
   [SerializeField] private Image icon;
   [SerializeField] private TextMeshProUGUI text;

   private int myIndex;

   public void SetIndex(int index)
   {
      myIndex = index;
   }

   public void Set(ItemSlot slot)
   {
      icon.gameObject.SetActive(true);
      icon.sprite = slot.item.icon;

      if (slot.item.stackable == true)
      {
         text.gameObject.SetActive(true);
         text.text = slot.count.ToString();
      }
      else
      {
         text.gameObject.SetActive(false);
      }
   }

   public void Clean()
   {
      icon.sprite = null;
      icon.gameObject.SetActive(false);
      
      text.gameObject.SetActive(false);
   }
}
