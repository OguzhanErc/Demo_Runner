using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runningSpeed;

    Rigidbody _rb;
    float touchXDelta = 0;
    float newX = 0;

    [SerializeField]
    float xSpeed;

    [SerializeField]
    float limitX;

   
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
     //   transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
    }
    void Update()
    {
        Movement();
    }


    /// <summary>
    /// Player Movement Fanction
    /// </summary>
    void Movement()
    {
        //Control character with touching
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }

        //Control character with mouse
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
