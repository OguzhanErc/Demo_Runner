using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class CollisionControl : MonoBehaviour
{

    Rigidbody _rb;
    public float forcePower;
    public GameObject startPoint;
    Animator anim;

    [Serializable] public class Triggers : UnityEvent { }

    public Triggers rotatorMain;//Completed.
    public Triggers rotatorStick;//Completed.
    public Triggers finishLine;
 
  
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    //Controlling collisions
    private void OnCollisionEnter(Collision collision)
    {
     
        if (collision.gameObject.CompareTag("RotatorMain"))
        {
          
            rotatorMain.Invoke();
        }
        if (collision.gameObject.CompareTag("Stick"))
        {
            rotatorStick.Invoke();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
          
            finishLine.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Finish"))
        {
            Debug.Log("Triggered Finish");
            finishLine.Invoke();
        }
    }


    /// <summary>
    /// Starts from the beggining.
    /// </summary>
    public void RollBack()
    {
        Debug.Log("RollBack");
        transform.position = startPoint.transform.position;
    }
    /// <summary>
    /// Pushes back when hitting an obstacle
    /// </summary>
    public void PushBack()
    {
        _rb.AddForce(Vector3.back * forcePower);
    }
    public void StopAnimations()
    {
        anim.SetBool("Idle", true);
    }

}
