using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Vector2 inputVec;
    private float speed = 8.0f;
    private float jumpPower = 11.5f;

    private bool isGrounded = false;

    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(inputVec.x * speed, rigid.velocity.y);
    }

    private void LateUpdate()
    {
        if (inputVec.x != 0) {
            spriteRenderer.flipX = inputVec.x > 0;
        }

        animator.SetFloat("Speed", inputVec.magnitude);
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void Jump()
    {
        if (isGrounded) {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                isGrounded = false;
                animator.SetBool("Jumping", true);
            }
        }
        else {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
            return;
        isGrounded = true;
        animator.SetBool("Jumping", false);
    }
}
