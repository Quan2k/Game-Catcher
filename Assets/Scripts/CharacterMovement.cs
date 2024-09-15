using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CharacterMovement : MonoBehaviour
{
    public static int speed = 5;
    public float jumpForce = 2;
    public float jumpMaxStep = 2;
    public static int maxSpeed = 20;
    private Animator animator;
    private Rigidbody2D rb;
    bool isGrounded = false;
    int jumpCount = 0;
    public static void AddSpeed(int amount)
    {
        speed += amount;
        if (speed > maxSpeed) 
        { speed = maxSpeed; }
    }

    void Start()
    {
        animator = GetComponent<Animator>(); //bắt đầu animation khép mở chân
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
    }


    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        bool isMoving = moveHorizontal != 0; // khai báo biến isMoving
        animator.SetBool("isMoving", isMoving);

        if (isMoving) // nếu nhân vật đang di chuyển
        {
            transform.position += new Vector3(moveHorizontal * speed * Time.deltaTime, 0f, 0f);
        }

        // xu ly nhay
        if (Input.GetButtonDown("Jump") && jumpCount < jumpMaxStep)
        {
            // Apply jump force
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount += 1; 
        }
        Debug.Log(" speed: " + speed);
    }

    private void OnCollisionEnter2D(Collision2D collision) // 2 vat the cham vao nhau, ktra xem co phai mat dat hay khong
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // neu phai undate isGr = T
            UnityEngine.Debug.Log(isGrounded);
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) // 2 vat tach ra khoi mot vat the dang va cham, ktra xem co phai mat dat hay khong
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // neu phai thi set isGr = F
            UnityEngine.Debug.Log(isGrounded);
        }
    }
}