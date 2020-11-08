using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Transform playerPosition;
    [SerializeField]
    public float speed = 5.0f;
    private int positionID = 2;
    private bool canMove = true;
    public Animator animator;
    public SwipeInput input;

    public float bonus = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerPosition = GetComponent<Transform>();
        input = gameObject.GetComponent<SwipeInput>();
        bonus = PlayerPrefs.GetFloat("bonus");
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = new Vector3(0, 0, 1);
        Vector3 velocity = new Vector3(0, 0, direction.z * speed * bonus);
        controller.Move(velocity * Time.deltaTime);

        ResetTriggers();

        if (canMove)
        {

            if ((Input.GetKeyDown(KeyCode.RightArrow) || input.SwipeRight) && positionID < 3)
            {
                positionID++;
                FindObjectOfType<AudioManager>().Play("Ziu");
                animator.SetTrigger("Right");
            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow) || input.SwipeLeft) && positionID > 1)
            {
                positionID--;
                FindObjectOfType<AudioManager>().Play("Ziu");
                animator.SetTrigger("Left");
            }

            switch (positionID)
            {
                case 1:
                    playerPosition.position = new Vector3(-2.5f, playerPosition.position.y, playerPosition.position.z);
                    break;
                case 2:
                    playerPosition.position = new Vector3(0f, playerPosition.position.y, playerPosition.position.z);
                    break;
                case 3:
                    playerPosition.position = new Vector3(2.5f, playerPosition.position.y, playerPosition.position.z);
                    break;
            }

        }

    }

    public void ResetTriggers()
    {
        animator.ResetTrigger("Right");
        animator.ResetTrigger("Left");
    }

    public void AdjustSpeed (float newSpeed)
    {
        speed = newSpeed;
    }
}
