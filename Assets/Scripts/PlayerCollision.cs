using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
       if(hit.collider.tag == "obstacle")
        {
            FindObjectOfType<AudioManager>().Play("Kurwa");
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
