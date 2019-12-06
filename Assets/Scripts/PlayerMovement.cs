using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Transform tf;
    [SerializeField]
    private float speed = 5.0f;
    int x = 2;
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
        Vector3 velocity = direction * speed;
        controller.Move(velocity * Time.deltaTime);
        

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x--;
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
