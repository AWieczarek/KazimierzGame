using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Transform tf;
    [SerializeField]
    public float speed = 5.0f;
    int x = 2;
    int y = 0;
    public bool canMove = true;

    public Animator animator;
        
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        tf = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = new Vector3(0, 0, 1);
        Vector3 velocity = new Vector3(0, 0, direction.z * speed);
        controller.Move(velocity * Time.deltaTime);

        ResetTriggers();

        if (canMove)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (x < 3)
                {
                    x++;
                    animator.SetTrigger("Right");
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (x > 1)
                {
                    x--;
                    animator.SetTrigger("Left");
                }
            }



            switch (x)
            {
                case 1:
                    tf.position = new Vector3(-2.5f, tf.position.y, tf.position.z);
                    break;
                case 2:
                    tf.position = new Vector3(0f, tf.position.y, tf.position.z);
                    break;
                case 3:
                    tf.position = new Vector3(2.5f, tf.position.y, tf.position.z);
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
