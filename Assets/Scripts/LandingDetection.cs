using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingDetection : MonoBehaviour
{
    PlayerControl player;

    private void Start()
    {
        player = transform.parent.gameObject.GetComponent<PlayerControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            player.SetJumpCount(2);
        }
    }
}
