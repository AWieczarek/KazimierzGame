using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    public bool isShield = false;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
       if(hit.collider.tag == "obstacle" && isShield == false)
        {
            FindObjectOfType<AudioManager>().Play("Kurwa");
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

       if(isShield)
	    {
            hit.collider.enabled = false;
		}
    }
}
