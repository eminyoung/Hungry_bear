using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int spriteIndex;
    public Sprite[] fishSprites;

    public Rigidbody2D rb;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float jumpStrength;
    public float swimSpeed = 10.0f;
    public bool jumping;
    public float maxHeight = 10.0f;
    public float swimHeight = -1.5f;

    public Transform bear;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumping = false;
        jumpStrength = Random.Range(2.5f, 7.5f);
        rb.gravityScale = 0.0f;
        InvokeRepeating(nameof(Animate), 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToBear = transform.position.x - bear.position.x;
        transform.position += Vector3.left * (swimSpeed * Time.deltaTime);

        if (distanceToBear <= 5.0f && !jumping)
        {
            jumping = true;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            rb.gravityScale = 1.0f;
        }
        
        if (jumping && rb.position.y <= swimHeight)
        {
            rb.gravityScale = 0;
            jumping = false;
        }
    }

    private void Animate()
    {
        spriteIndex++;
        if (spriteIndex >= fishSprites.Length)
        {
            spriteIndex = 0;
        }
        
        spriteRenderer.sprite = fishSprites[spriteIndex];
    }
}