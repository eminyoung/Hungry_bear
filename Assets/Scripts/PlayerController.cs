using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int openMouth;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            openMouth = 1;
            Debug.Log("mouth open");
        } else {
            openMouth = 0;
        }
        spriteRenderer.sprite = sprites[openMouth];

    }

    public int getMouth() {
        return openMouth;
    }
}
