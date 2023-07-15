using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Transform player;
    [SerializeField] public float speed = 5.0f;
    [SerializeField] public float pickUpDistance = 1.5f;
    [SerializeField] public float ttl = 10.0f;

    [Category("Items")]
    public Item item;
    public int count = 1;
    
    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
    }
    
    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0)
        {
            Destroy(gameObject);
        }
        
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime);

        if (distance < 0.1f)
        {
            // TODO: Move into specified controller not in here!
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
            }
            else
            {
                Debug.LogWarning("no inventory set up, please implement the data asset in the GM!");
            }
            Destroy(gameObject);
        }
    }
}
