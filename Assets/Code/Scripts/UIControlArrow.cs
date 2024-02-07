using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControlArrow : MonoBehaviour
{
    [SerializeField]
    private Sprite sprite = null;
    private GameObject spriteObject = null;
    private Rigidbody2D playerRigidbody = null;
    SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private float distanceInFrontOfPlayer = 1.0f;

    private void Awake()
    {
        GameObject spriteObject = new GameObject("ArrowSprite");

        spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;

        spriteObject.transform.position = transform.position;
        spriteObject.transform.SetParent(transform, true);
        spriteRenderer.transform.localScale = new Vector2(0.2f, 0.2f);

        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the arrow to point in the direction of the player's movement
        if (playerRigidbody.velocity != Vector2.zero)
        {
            // Calculate the angle to rotate towards
            float angle = Mathf.Atan2(playerRigidbody.velocity.y, playerRigidbody.velocity.x) * Mathf.Rad2Deg;

            // Update the rotation of the arrow object
            spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, angle);

            Vector3 directionInFrontOfPlayer = playerRigidbody.velocity.normalized * distanceInFrontOfPlayer;
            spriteRenderer.transform.localPosition = directionInFrontOfPlayer;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
