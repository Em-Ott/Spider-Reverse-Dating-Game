using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float verticalMoveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool onWeb = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        if (onWeb)
        {
            float moveY = Input.GetAxis("Vertical");
            moveInput = new Vector2(moveX * moveSpeed, moveY * verticalMoveSpeed).normalized;
            moveInput = new Vector2 (moveInput.x, moveInput.y * verticalMoveSpeed);
        } else {
            moveInput = new Vector2(moveX, 0).normalized;
        }
    }

        void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cobweb"))
        {
            onWeb = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cobweb"))
        {
            onWeb = false;
        }
    }
}
