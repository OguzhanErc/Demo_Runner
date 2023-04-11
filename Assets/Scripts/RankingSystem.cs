using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    public float distance;
    public GameObject target;
    public int rank;


    public void DistanceCalculate()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
    }
    void Update()
    {
        DistanceCalculate();
    }
}
