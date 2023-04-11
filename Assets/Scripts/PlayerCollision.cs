using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject startPoint;
    Animator anim;
    Rigidbody rb;
    public float forcePower;

    private void Start()
    {
        anim =GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RotatorMain"))
        {
            transform.position = startPoint.transform.position;
            UIManager.Instance.deathCount ++;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            anim.SetBool("Idle", true);
        }
        if (collision.gameObject.CompareTag("Stick"))
        {
            rb.AddForce(Vector3.back * forcePower);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("RotationPlatform"))
        {
            rb.AddForce(Vector3.left, ForceMode.VelocityChange);
        }
    }
}
