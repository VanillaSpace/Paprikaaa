using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField] private GameObject closedChest;
    [SerializeField] private GameObject openedChest;
    [SerializeField] private bool isOpen = false;
    
    void ToggleChestState(bool newState)
    {
        closedChest.SetActive(!newState);
        openedChest.SetActive(newState);
        isOpen = newState;
    }
    
    public override void Interact(Character character)
    {
        if (isOpen = !isOpen)
        {
            ToggleChestState(true);
        }
        else
        {
            ToggleChestState(false);
        }
    }
}
