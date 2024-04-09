using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private void Awake()
    {
        // Reference Rigidbody2D Component and animator Component
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (body != null)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y); // Transforms on X axis

            // flips player when moving right or left
            if (horizontalInput > 0.01f)
                transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
            else if (horizontalInput < -0.01f)
                transform.localScale = new Vector3(-0.65f, 0.65f, 0.65f);

            if (Input.GetKey(KeyCode.Space) && grounded)
                Jump();

            // Set animator parameters
            anim.SetBool("isRun", horizontalInput != 0); // checks to see if horizontal input is zero or not
            anim.SetBool("isGrounded", grounded);
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed / 2); // Transforms on Y axis
        anim.SetTrigger("Jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
