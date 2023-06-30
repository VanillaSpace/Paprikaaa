using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField] private GameObject closedChest;
    [SerializeField] private GameObject openedChest;
    [SerializeField] private bool isOpen;
    
    public override void Interact(Character character)
    {
        if (isOpen == false)
        {
            isOpen = true;
            closedChest.SetActive(false);
            openedChest.SetActive(true);
        }
    }
}
