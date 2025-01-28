using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int openMouth;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public GameObject Bear;

    private void Start() {
        SpriteRenderer spriteRenderer = Bear.GetComponent<SpriteRenderer>();
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
    void OnDisable(){ Debug.Log("disabled");}
}
