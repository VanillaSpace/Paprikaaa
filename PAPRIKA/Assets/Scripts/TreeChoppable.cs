using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChoppable : ToolHit
{
    [SerializeField] public GameObject pickUpDrop;
    [SerializeField] public int dropCount = 5;
    [SerializeField] public float spread = 0.7f;
    
    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop);
            go.transform.position = position;
        }
        Destroy(gameObject);
    }
}
