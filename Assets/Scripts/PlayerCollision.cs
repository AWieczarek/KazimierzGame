using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    bool dieing = true;
    public Developer developer;


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
       if(hit.collider.tag == "obstacle")
        {
            if(dieing)
            {
                if(developer.enabled == false)
                {
                    movement.enabled = false;
                    FindObjectOfType<GameManager>().EndGame();
                }
                else
                {
                    movement.enabled = false;
                    FindObjectOfType<GameManager>().EndGameDevelopers();
                }
            }
        }
    }

    public void DieOff()
    {
        if (dieing)
        {
            dieing = false;
        }
        else
        {
            dieing = true;
        }
    }
}
