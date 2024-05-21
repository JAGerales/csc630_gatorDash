using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    //public Transform platform;
    public Transform pointA, pointB;
    public float speed;
    Vector3 targetPos;

    playerMovementFix movementController;
    Rigidbody2D rb;
    Vector3 moveDirection;

    Rigidbody2D playerRb;

    private void Awake()
    {
        movementController = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovementFix>();
        rb = GetComponent<Rigidbody2D>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        targetPos = pointB.position;
        calculateDirection();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, pointA.position) < 0.05f)
        {
            targetPos = pointB.position;
            calculateDirection();
        }

        if (Vector2.Distance(transform.position, pointB.position) < 0.05f)
        {
            targetPos = pointA.position;
            calculateDirection();
        }

       // transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * speed;
    }

    void calculateDirection()
    {
        moveDirection = (targetPos - transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movementController.isOnPlatform = true;
            movementController.platformRb = rb;
            //playerRb.gravityScale = playerRb.gravityScale * 15;
            //collision.transform.parent = this.transform;
        }
        //collision.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movementController.isOnPlatform = false;
            //playerRb.gravityScale = playerRb.gravityScale / 15;
            //collision.transform.parent = null;
        }
        //collision.transform.parent(null);
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    */
}
