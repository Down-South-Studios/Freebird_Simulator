using System;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static event Action<int> OnCollected;

    [SerializeField]
    protected int value = 1;

    //In case we want to do anything with modifying the sprite during gameplay...?
    protected SpriteRenderer spriteRenderer;
    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Collect()
    {
        //Announce the item was collected.
        OnCollected?.Invoke(value);

        //Destroy the item when collected.
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
}
