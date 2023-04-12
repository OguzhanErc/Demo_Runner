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

    public GameObject PaintingArea;
    bool isOnRotatingGround;
    public float forcePower;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
       
    }
    void Update()
    {
        if (isOnRotatingGround)
        {
            _rb.AddForce(Vector3.left * forcePower, ForceMode.Impulse);
        }
        if (GameManager.instance.isGameOver==false)
        {
            Movement();
        }
        else
        {
            PaintingStage();
        }
        
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

    private void PaintingStage()
    {       
            runningSpeed = 0;
            gameObject.transform.position = PaintingArea.transform.position;        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("RotationPlatform"))
        {
            isOnRotatingGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isOnRotatingGround = false;
    }

}
