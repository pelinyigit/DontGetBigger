using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Space]
    [SerializeField] DynamicJoystick dynamicJoystick;

    [Space]
    [SerializeField] float playerSpeed = 10f;

    Rigidbody rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();        
    }

    void HandlePlayerMovement()
    {
        rb.velocity = new Vector3(dynamicJoystick.Horizontal * playerSpeed * 0.5f, 0, playerSpeed);
    }
  
}
