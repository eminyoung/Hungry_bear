using UnityEngine;

public class Water : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int spriteIndex;
    public Sprite[] waterSprites;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Animate), 0.5f, 0.5f);
    }

    private void Animate()
    {
        spriteIndex++;
        if (spriteIndex >= waterSprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = waterSprites[spriteIndex];
    }
}
