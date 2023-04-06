using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField]
    float forcePower = 10f;
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
}
