using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehavior : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    bool canMove = true;
    int directionOffset = 1;
    public bool Canmove { get { return canMove; } set { canMove = value; } }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (canMove)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * directionOffset);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            directionOffset *= -1;
        }  
    }
}
