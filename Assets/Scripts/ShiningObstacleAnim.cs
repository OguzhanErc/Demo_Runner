using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiningObstacleAnim : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;

    [SerializeField]
    float strenght = 14.5f;

    float randomOffset;
    // Start is called before the first frame update
    void Start()
    {
        randomOffset = Random.Range(-6, 6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1, 0);
        Vector3 pos = transform.position;
        pos.x = Mathf.Sin(Time.time * speed + randomOffset) * strenght;
        transform.position = pos;
    }
}
