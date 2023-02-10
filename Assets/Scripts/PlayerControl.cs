using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    [SerializeField] Sprite deadSprite;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] Collider2D bodyCollider;
    bool isAlive = true;

    bool canMoveHorizontally = true;
    int jumpCount = 2;
    public bool CanMoveHorizontally { get { return canMoveHorizontally; } set { canMoveHorizontally = value; } }

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlPlayer();
    }

    void ControlPlayer()
    {
        if (!isAlive) { return; }
        ControlHorizontalMove();
        ControlJump();
        DetectDeath();
    }

    void ControlHorizontalMove()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(1, 1);
            if (canMoveHorizontally)
            {
                //playerRB.AddForce(new Vector2(moveSpeed, 0));
                transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0));
                playerAnimator.SetBool("Running", true);
            }
            else { playerAnimator.SetBool("Running", false); }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector2(-1, 1);
            if (canMoveHorizontally)
            {
                //playerRB.AddForce(new Vector2(-moveSpeed, 0));
                transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0));
                playerAnimator.SetBool("Running", true);
            }
            else { playerAnimator.SetBool("Running", false); }
        }
        else { playerAnimator.SetBool("Running", false); }
    }
    
    void ControlJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            jumpCount--;
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            playerRB.AddForce(new Vector2(0, jumpForce));
        }
    }

    void DetectDeath()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")) && isAlive)
        {
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = deadSprite;
            playerRB.AddForce(new Vector2(Random.Range(-300f, 300f), Random.Range(.7f*jumpForce, jumpForce)));
            isAlive = false;
        }
    }

    public void SetJumpCount(int count)
    {
        jumpCount = count;
    }

}
