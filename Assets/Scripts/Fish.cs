using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int spriteIndex;
    public Sprite[] fishSprites;

    private Rigidbody2D rb;
    public float jumpStrength;
    public float swimSpeed = 10.0f;
    public bool jumping;
    public float deadZone = -45;
    public bool hasJumped;
    public float swimHeight;

    private Transform bear;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumping = false;
        hasJumped = false;
        jumpStrength = Random.Range(7.5f, 11.5f);
        swimHeight = transform.position.y;
        rb.gravityScale = 0.0f;
        InvokeRepeating(nameof(Animate), 0.3f, 0.3f);
        bear = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToBear = transform.position.x - bear.position.x;
        transform.position += Vector3.left * (swimSpeed * Time.deltaTime);

        if (distanceToBear <= 5.0f && !jumping && !hasJumped)
        {
            jumping = true;
            hasJumped = true;
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            rb.gravityScale = 1.0f;
        } else if (rb.position.y <= swimHeight)
        {
            transform.position = new Vector3(transform.position.x, swimHeight, transform.position.z);
            jumping = false;
        }
        if (transform.position.x <= deadZone) {
            Destroy(gameObject);
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

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if(player != null && player.getMouth() == 1) {
                Destroy(gameObject);
                Debug.Log("collided");
            }
        }
    }
}