using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SammyMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public bool isLandable;
    private bool wasOnLand;
    private bool wasInWater;


    void Start()
    {
        //wasInWater = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Code for world boundary
        if(transform.position.y >= 2.4) {
            transform.position = new Vector3(transform.position.x, 2.4f, transform.position.z);
        }
        else if(transform.position.y <= -6.06) {
            transform.position = new Vector3(transform.position.x, -6.06f, transform.position.z);
        }
        else if(transform.position.x >= 38.88) {
            transform.position = new Vector3(38.88f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x <= -17.16) {
            transform.position = new Vector3(-17.16f, transform.position.y, transform.position.z);
        }
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if(other.CompareTag("BeachBounds"))
    //     {
    //         Debug.Log(moveSpeed);

    //         if(isLandable) 
    //         {
    //             if(wasInWater) 
    //             {
    //                 moveSpeed += 1;
    //                 wasInWater = false;
    //                 Debug.Log("ON LAND!");
    //             }
    //             else 
    //             {
    //                 moveSpeed = 5;
    //                 wasInWater = true;
    //                 Debug.Log("IN WATER!");

    //             }
    //         }
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BeachBounds")) {
            moveSpeed += 3;
            Debug.Log("Enter!");
            Debug.Log("Test!");
        }

    }

<<<<<<< Updated upstream
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("BeachBounds")) {
        moveSpeed = 5;
        Debug.Log("exit!");
        }
    }
=======
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "SammyTheSeal") {
            moveSpeed += 3;
            Debug.Log("Enter!");
        }

    }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if(other.CompareTag("BeachBounds")) {
    //     moveSpeed = 5;
    //     Debug.Log("exit!");
    //     }
    // }
>>>>>>> Stashed changes
}
