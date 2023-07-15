using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChoppable : ToolHit
{
    [SerializeField] public GameObject pickUpDrop;
    [SerializeField] public float spread = 0.7f;

    [SerializeField] public Item item;
    [SerializeField] public int itemCountInOneDrop = 1;
    [SerializeField] public int dropCount = 5;
    
    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            
            ItemSpawnManager.instance.SpawnItem(position, item, itemCountInOneDrop);
        }
        Destroy(gameObject);
    }
}
