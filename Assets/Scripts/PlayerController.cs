using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    public float jump = 1;

    private int openMouth;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public Vector3 direction;
    bool isGrounded = true;


    public GameObject Bear;

    public float gravity = -9.8f;

    private void Start() {
        SpriteRenderer spriteRenderer = Bear.GetComponent<SpriteRenderer>();
        Rigidbody2D body = Bear.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            openMouth = 1;
            Debug.Log("mouth open");
        } else {
            openMouth = 0;
        }
        spriteRenderer.sprite = sprites[openMouth];

        //jump

        if (body.position.y <= 0.06) {
            direction.y = 0;
        }

        if (Input.GetKey(KeyCode.Space) && body.position.y <= 0.06) {
            direction.y += 7;
        }
        transform.position += direction * Time.deltaTime;
    }

    public int getMouth() {
        return openMouth;
     }
//     void OnCollisionEnter(Collision collision)
// {
//     if (collision.gameObject.CompareTag("Ground"))
//     {
//         isGrounded = true;
//     }
// }
// void OnCollisionExit(Collision collision)
// {
//     if (collision.gameObject.CompareTag("Ground"))
//     {
//         isGrounded = false;
//     }
// }

//         void OnDisable(){ Debug.Log("disabled");}
 }
