using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveSpeed = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    public bool isGrounded;
    public Animator anim;

    public AudioSource audioSource2;
    [SerializeField] AudioClip Jump;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput < 0 )
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            
            audioSource2 = GetComponent<AudioSource>();
            audioSource2.clip = Jump;
            if (audioSource2 == null)
            {
                Debug.LogError("Could not play audio");
            }
            else
            {
                
                audioSource2.Play();
            }
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        if (moveInput == 0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

}
