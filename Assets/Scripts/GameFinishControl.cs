using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishControl : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            GameManager.instance.isGameOver = true;
        }
    }
}
