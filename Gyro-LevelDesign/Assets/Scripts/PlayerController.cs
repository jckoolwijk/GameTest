using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] int rotationSpeed = 50;
    [SerializeField] float jumpingHeight;
    private float movementX;
    private float vertical;
    private Rigidbody body;
    [SerializeField] bool dubleJump;


    void Start()
    {
        body = GetComponent<Rigidbody>();
        Application.targetFrameRate = 120;
    }

    void OnJump(InputValue movementValue)
    {
        Debug.Log("jump");

                Vector3 movement = new Vector3( 0, jumpingHeight, 0.0f);
                body.AddRelativeForce(movement);

    }

    void OnMove(InputValue movementValue)
    {
        Debug.Log("move");
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.y;
        vertical = movementVector.x;
    }

    void rotate()
    {
        float rotationValue = vertical * rotationSpeed;
        if (rotationValue > 0.1 || rotationValue < -0.1)
        {
           Quaternion deltaRotation = Quaternion.Euler(new Vector3(0,rotationValue* Time.fixedDeltaTime,0) );
                   body.MoveRotation(body.rotation * deltaRotation); 
        }
        else
        {
            var angles = transform.eulerAngles;
            angles.x = 0;
            angles.z = 0;
            transform.eulerAngles = angles;
        }
    }

    void move()
    {
            Vector3 movement = new Vector3( movementSpeed * movementX * Time.deltaTime, 0.0f, 0.0f);
            body.AddRelativeForce(movement);
    }

    void FixedUpdate()
    {
        // var position = transform.position;
        //
        //     position.y = 4;
        //
        //
        // transform.position = position;
        rotate();
        move();
    }
}