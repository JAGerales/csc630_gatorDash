using UnityEngine;

public class playerMovementFix : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private Vector3 respawnPoint;
    public GameObject fallDetector;
    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        // Reference Rigidbody2D Component and animator Component
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    private void Update()
    {
        if (body != null)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            bool isPressingS = Input.GetAxis("Vertical") < -0.1f;
            bool isMoving = horizontalInput > 0.1f || horizontalInput < 0.1f; // Check if moving left / right
            bool isSliding = isMoving && isPressingS;

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            // flips player when moving right or left
            if (horizontalInput > 0.01f)
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            else if (horizontalInput < -0.01f)
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);

            if (Input.GetKey(KeyCode.Space) && grounded)
                Jump();

            if (isSliding && grounded)
                Slide();

            // Set animator parameters
            anim.SetBool("isRun", horizontalInput != 0); // checks to see if horizontal input is zero or not
            anim.SetBool("isGrounded", grounded);
            anim.SetBool("isSliding", isSliding);

            fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed / 1.25f); // Transforms on Y axis
        soundManager.instance.PlaySound(jumpSound);
        anim.SetTrigger("Jump");
        grounded = false;
    }

    private void Slide()
    {
        body.velocity = new Vector2(body.velocity.x * 1.25f, body.velocity.y);
        anim.SetTrigger("slide");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "fallDetector")
        {
            transform.position = respawnPoint;
        }
    }
}
