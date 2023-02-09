using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 10f;
    bool canMoveHorizontally = true;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            playerRB.AddForce(new Vector2(0, jumpForce));
        }
    }
}
