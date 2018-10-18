using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Deals with moving the camera on the perspective camera view
 * based on keypress
 * WASD to move forward / back, Q and E to move up/down, and R / arrow keys to rotate
 */

public class Move : MonoBehaviour
{
    const float MOVE_AMOUNT = 10.0f;
    
    // Use this for initialization
    void Start()
    {
       
    }

    // Write the position and rotation of the object it is attached to  (camera rig)
    void Update()
    {
    }

    // Fixed Update is different from regular update. It runs before update
    void FixedUpdate()
    {
        move();
    }
    
    // Move according to the keyboard
    void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Transform>().Translate(GetComponent<Transform>().forward / 10, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().Translate(GetComponent<Transform>().right / -10, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Transform>().Translate(GetComponent<Transform>().forward / -10, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().Translate(GetComponent<Transform>().right / 10, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Transform>().RotateAround(GetComponent<Transform>().transform.position, Vector3.up, -MOVE_AMOUNT);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Transform>().RotateAround(GetComponent<Transform>().transform.position, Vector3.up, MOVE_AMOUNT);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            GetComponent<Transform>().Translate(Vector3.up / 10);
        }
        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<Transform>().Translate(Vector3.down / 10);
        }
        if (Input.GetKey(KeyCode.R))
        {
            GetComponent<Transform>().Rotate(new Vector3(0, 10, 0), Space.Self);
        }
    }
}
