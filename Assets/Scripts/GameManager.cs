using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private InGameRankings igr;

    private GameObject[] runners;

    List<RankingSystem> sortArray = new List<RankingSystem>();

    public bool isGameOver = false;

    public Camera mainCam;
    public GameObject paintingCam;
    private void Awake()
    {
        instance = this;

        runners = GameObject.FindGameObjectsWithTag("Runner");
        igr = FindObjectOfType<InGameRankings>();
    }
    private void Start()
    {
        for (int i = 0; i < runners.Length; i++)
        {
            sortArray.Add(runners[i].GetComponent<RankingSystem>());
        }
    }
  
    void Update()
    {
        CalculateRanking();
    }
    void CalculateRanking()
    {
        sortArray = sortArray.OrderBy(x => x.distance).ToList();
        sortArray[0].rank = 1;
        sortArray[1].rank = 2;
        sortArray[2].rank = 3;
        sortArray[3].rank = 4;
        sortArray[4].rank = 5;
        sortArray[5].rank = 6;
        sortArray[6].rank = 7;
        sortArray[7].rank = 8;
        sortArray[8].rank = 9;
        sortArray[9].rank = 10;
        sortArray[10].rank = 11;


        igr.a = sortArray[10].name;
        igr.b = sortArray[9].name;
        igr.c = sortArray[8].name;
        igr.d = sortArray[7].name;
        igr.e = sortArray[6].name;
        igr.f = sortArray[5].name;
        igr.g = sortArray[4].name;
        igr.h = sortArray[3].name;
        igr.i = sortArray[2].name;
        igr.j = sortArray[1].name;
        igr.k = sortArray[0].name;
    }
    public void ActiveCam()
    {
        if (isGameOver==true)
        {
            mainCam.transform.position = paintingCam.transform.position;
        }
    }
}
