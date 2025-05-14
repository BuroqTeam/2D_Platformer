using ScriptableObjectArchitecture;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed, jumpForce;
    private Rigidbody2D playerRb;
    private SpriteRenderer playerSp;
    private Animator playerAn;
    private AudioSource playerAudio;

    public bool isGrounded;
    public GameEvent JumpEvent;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSp = GetComponent<SpriteRenderer>();
        playerAn = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    public void Move(float horizontalInput)
    {
        playerRb.linearVelocity = new Vector2(horizontalInput * moveSpeed, playerRb.linearVelocity.y);
        playerAn.SetBool("Run", horizontalInput != 0);

        if (horizontalInput > 0)
        {
            playerSp.flipX = false;                  
        }
        else if (horizontalInput < 0)
        {
            playerSp.flipX = true;          
        }

        // Handle audio
        if (Mathf.Abs(horizontalInput) > 0.01f && isGrounded)
        {
            if (!playerAudio.isPlaying)
            {
                playerAudio.Play();
            }
        }
        else
        {
            if (playerAudio.isPlaying)
            {
                playerAudio.Stop();
            }
        }
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;            
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            //playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpForce);
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            JumpEvent.Raise();
        }
    }

    private void Update()
    {
        playerAn.SetBool("Grounded", isGrounded);
    }

}
