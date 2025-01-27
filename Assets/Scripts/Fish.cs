using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int spriteIndex;
    public Sprite[] fishSprites;

    private Vector3 horizontalVec;
    private Vector3 verticalVec;
    public float gravity = -9.8f;
    public float jumpStrength;
    public float swimSpeed = 10.0f;
    public bool hasJumped = false;
    public Transform bear;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horizontalVec = Vector3.left * swimSpeed;
        verticalVec = Vector3.zero;
        InvokeRepeating(nameof(Animate), 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
        float distanceToBear = Mathf.Abs(transform.position.x - bear.position.x);
        transform.position += horizontalVec * Time.deltaTime;
        if (distanceToBear <= 0.5f && !hasJumped)
        {
            jumpStrength = Random.Range(15.0f, 20.0f);
            verticalVec = Vector3.up * jumpStrength;
            hasJumped = true;
        } else if (hasJumped && transform.position.y > -1.5f)
        {
            verticalVec.y += gravity * Time.deltaTime;
            transform.position += verticalVec * Time.deltaTime;
        } else
        {
            transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);
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