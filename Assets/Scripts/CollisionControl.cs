using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    Rigidbody _rb;
   
    

    public PlayerController playerController;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    //Controlling collisions
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with an obstacle");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            playerController.runningSpeed = 0;
        }
    }
}
