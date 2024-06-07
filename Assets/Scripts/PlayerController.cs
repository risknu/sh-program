using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats Settings")]
    public float playerSpeed = 5f;
    public float playerJumpForce = 7f;
    public float checkRadius = 0.2f;

    [Header("Player DEBUG")]
    public float moveInput = 0f;
    public bool facingRight = true;
    public bool isGrounded = false;

    [Header("Objects/Particles")]
    public GameObject landParticleObject;
    public Transform feetPos;
    public LayerMask whatIsGround;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;

    // Other
    private Coroutine flipCoroutine;

    public void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * playerSpeed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip(moveInput);
        } 
        else if(facingRight == true && moveInput < 0)
        {
            Flip(moveInput);
        }

        if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        } 
        else
        {
            animator.SetBool("isRunning", true);
        }
     }

    public void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * playerJumpForce;
            animator.SetTrigger("takeOf");
        }

        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }
    }

    public void Flip(float moveInput)
    {
        bool newFacingRight = moveInput > 0;

        if (facingRight != newFacingRight)
        {
            facingRight = newFacingRight;
            float targetAngle = facingRight ? 0f : 180f;

            if (flipCoroutine != null)
            {
                StopCoroutine(flipCoroutine);
            }

            flipCoroutine = StartCoroutine(RotateSmoothly(targetAngle));
        }
    }

    private IEnumerator RotateSmoothly(float targetAngle)
    {
        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.01f)
        {
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * 15f);
            transform.eulerAngles = new Vector3(0, angle, 0);
            yield return null;
        }
        transform.eulerAngles = new Vector3(0, targetAngle, 0);
    }

    public void landParticle()
    {
        Instantiate(landParticleObject, feetPos.position, Quaternion.identity);
    }
}
