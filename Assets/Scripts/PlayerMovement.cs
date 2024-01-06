using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 0f;
    private float runSpeed = 7.0f;
    private float crouchSpeed = 3.0f;
    private float jumpForce = 1000f;
    private float moveSpeed;
    private Rigidbody2D rb;

    private bool m_Grounded;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private Transform m_CeilingCheck;
    [SerializeField] private Collider2D colliderToDisable;
    const float k_GroundedRadius = .2f;


    private bool m_FacingRight = true;
    private bool jumpingAllowed = true;
    private bool sWasClicked = false;
    private bool isAlive = true;
    public bool notTutorial = false;

    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, moveSpeed * Time.deltaTime);

        if (moveSpeed > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (moveSpeed < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius);
        if (colliders.Length >= 2)
        {
            m_Grounded = true;
        }

        anim.SetFloat("Speed", Mathf.Abs(moveSpeed));
    }

    private void Update()
    {

            if (Input.GetKey(KeyCode.LeftShift) && isAlive && notTutorial)
            {
                sWasClicked = true;
                anim.SetBool("IsCrouching", true);
                colliderToDisable.enabled = false;
                jumpingAllowed = false;
                speed = crouchSpeed;
            }
            else
            {
                if (!sWasClicked || StandingAllowed(m_CeilingCheck))
                {
                    speed = runSpeed;
                    colliderToDisable.enabled = true;
                    jumpingAllowed = true;
                    anim.SetBool("IsCrouching", false);
                }

            }

            if (Input.GetKey(KeyCode.A) && isAlive && notTutorial)
            {
                moveSpeed = -speed;
            }
            else if (Input.GetKey(KeyCode.D) && isAlive && notTutorial)
            {
                moveSpeed = speed;
            }
            else
            {
                moveSpeed = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isAlive && notTutorial)
            {
                StartCoroutine(Jump());
            }
        

    }

    IEnumerator Jump()
    {
        if (m_Grounded && jumpingAllowed)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            anim.SetBool("IsJumping", true);
            yield return new WaitForSeconds(0.1f);
            anim.SetBool("IsJumping", false);
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private bool StandingAllowed(Transform m_CeilingCheck)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_CeilingCheck.position, k_GroundedRadius);
        if (colliders.Length <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void NotTutorial()
    {
        notTutorial = true;
    }

    public void Tutorial()
    {
        notTutorial = false;
    }


    public bool GetNotTutorial()
    {
        return notTutorial;
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }

    public void Die()
    {
        isAlive = false;
        StartCoroutine(Dieing());
    }

    IEnumerator Dieing()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(3);
    }
}
