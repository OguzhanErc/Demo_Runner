using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ShiningObstacleAnim : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;

    [SerializeField]
    float range = 14.5f;

    float randomOffset;

    ParticleSystem particleSystem;
    [Serializable] public class Trigger : UnityEvent { }

    public Trigger Racers;
    void Start()
    {
        randomOffset = UnityEngine.Random.Range(-6, 6);
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Triggered");
        Racers.Invoke();
    }
    void Update()
    {
        transform.Rotate(0, 1, 0);
        Vector3 pos = transform.position;
        pos.x = Mathf.Sin(Time.time * speed + randomOffset) * range;
        transform.position = pos;
    }

    public void ChangeColor()
    {
        particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        var main = particleSystem.main;
        main.startColor = new Color(.15f, 1, 0, 1);
    }
}
