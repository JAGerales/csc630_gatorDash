using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;

    private void Awake()
    {
        // Reference Rigidbody2D Component
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (body != null)
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y); // Transforms on X axis

            if (Input.GetKey(KeyCode.Space))
                body.velocity = new Vector2(body.velocity.x, speed); // Transforms on Y axis
        }
    }
}
