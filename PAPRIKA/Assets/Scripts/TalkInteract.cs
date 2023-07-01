using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteract : Interactable
{
    public override void Interact(Character character)
    {
        Debug.Log("I'm a mushroom bro!");
    }
}
