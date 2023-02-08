using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCollisionDetector : MonoBehaviour
{
    PlayerControl player;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            player.CanMoveHorizontally = false;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Terrain")
        {
            player.CanMoveHorizontally = true;
        }
    }
}
