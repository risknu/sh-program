using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats Settings")]
    public float playerSpeed = 5f;
    public float playerJumpForce = 7f;
    public float checkRadius = 0.2f;
    public string ability = "null";

    [Header("Player Sounds")]
    public AudioSource[] walkSound;
    public AudioSource jumpSound;
    public AudioSource landSound;

    [Header("Player DEBUG")]
    public float moveInput = 0f;
    public bool facingRight = true;
    public bool isGrounded = false;

    [Header("Guns")]
    public GameObject normalGun;
    public GameObject mcGun;
    public GameObject nullGun;

    [Header("Objects/Particles")]
    public GameObject landParticleObject;
    public Transform[] feetPos;
    public LayerMask whatIsGround;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;

    // Other
    private Coroutine flipCoroutine;

    public void Start()
    {
        if (ability == "null")
            ability = AbilitySelectionManager.selectedAbility;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (ability == "ForwardCard")
            normalGun.SetActive(true);
        else if (ability == "McCard")
            mcGun.SetActive(true);
        else if (ability == "NullCard")
            nullGun.SetActive(true);
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
        isGrounded = CheckGroundOn();

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            jumpSound.Play();
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

    public bool CheckGroundOn()
    {
        foreach (var foot in feetPos)
        {
            if (Physics2D.OverlapCircle(foot.position, checkRadius, whatIsGround))
            {
                return true;
            }
        }
        return false;
    }

    public void PlayWalkSound()
    {
        int rand = Random.Range(0, walkSound.Length);
        walkSound[rand].Play();
    }

    public void Flip(float moveInput)
    {
        bool newFacingRight = moveInput > 0;

        if (facingRight != newFacingRight)
        {
            facingRight = newFacingRight;
            float targetAngle = facingRight ? 0f : 180f;

            if (flipCoroutine != null)
                StopCoroutine(flipCoroutine);

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
        landSound.Play();
        Instantiate(landParticleObject, feetPos[0].position, Quaternion.identity);
    }
}
