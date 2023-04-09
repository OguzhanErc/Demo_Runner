using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class CollisionControl : MonoBehaviour
{
    public static CollisionControl Instance;
    Rigidbody _rb; 
    public PlayerController playerController;
    public GameObject startPoint;

   [Serializable] public class Triggers: UnityEvent { }

    public Triggers rotatorStick;
    public Triggers rotatorMain;
    public Triggers rotatorObject;
    public Triggers donutObject;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
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
        if (other.CompareTag("Stick"))
        {

        }
        if (other.CompareTag("RotatorMain"))
        {
            rotatorMain.Invoke();
        }
        if (other.CompareTag("Donut"))
        {

        }
       
    }
    
    public void RollBack()
    {
        this.transform.position = startPoint.transform.position;
    }
   

}
