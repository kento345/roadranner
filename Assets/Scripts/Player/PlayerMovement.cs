using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Vector2 inputVer;

    private SpriteRenderer sprite;

    private bool isUpDown = false;

    private Rigidbody2D rb;

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVer = context.ReadValue<Vector2>();
    }

    public void OnUpDown(InputAction.CallbackContext context)
    {
        if (isUpDown)
        {
            inputVer = context.ReadValue<Vector2>();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //à⁄ìÆ
        Vector3 move = new Vector3(inputVer.x, inputVer.y,0f) * Speed * Time.deltaTime;
        transform.position += move;
        //âÒì]Çò
        if (inputVer.x > 0f)
        {
            //ç∂
           sprite.flipX = false;
        }
        else if (inputVer.x < 0f)
        {
            //âE
            sprite.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            isUpDown = true;
            rb.gravityScale = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            isUpDown = false;
            rb.gravityScale = 1;
        }
    }
}
