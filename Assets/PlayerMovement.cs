using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
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
        float moveY = Input.GetAxis("Vertical");
        if (onWeb)
        {
            moveInput = new Vector2(moveX * moveSpeed, moveY * verticalMoveSpeed).normalized;
            moveInput = new Vector2 (moveInput.x, moveInput.y * verticalMoveSpeed);
        } else {
            moveInput = new Vector2(moveX, 0f).normalized;
        }
        
        if (moveInput.y != 0f)
        {
            animator.SetFloat("VerticalSpeed", moveY);
            animator.SetFloat("HorizontalSpeed", 0);
        } else
        {
            animator.SetFloat("VerticalSpeed", 0);
            animator.SetFloat("HorizontalSpeed", Mathf.Abs(moveX));

            Vector3 scale = transform.localScale;
            if (moveX > 0)
            {
                scale.x = -2;
            }
            else if (moveX < 0)
            {
                scale.x = 2;
            }
            transform.localScale = scale;
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
        } else if (other.gameObject.CompareTag("Finish"))
        {
            ViolinEnding();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cobweb"))
        {
            onWeb = false;
        }
    }

    void ViolinEnding()
    {
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
        DialogueManager.Instance.endingScript.endingScreen.SetActive(true);
        DialogueManager.Instance.endingScript.endingText.text = "Ending Eight:" + "\n" + "ESCAPED" 
        + "\n" + "The World's Smallest Violin by AJR is a banger.";
    }
}
