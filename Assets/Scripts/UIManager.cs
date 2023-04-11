using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public int deathCount;
    public Text deathCountText;

    public GameObject painter;
    

    public GameObject paintingPannel;
    public GameObject inGameRankings;
    public GameObject deathCountPannel;

    private void Awake()
    {
        if (Instance != null && Instance !=this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
       

        deathCount = 0;

        paintingPannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        deathCountText.text = deathCount.ToString();
        PaintingStage();
        
    }

    public void PaintingRed()
    {
        painter.GetComponent<PaintIn3D.P3dPaintDecal>().Color = Color.red;
    }

    public void PaintingYellow()
    {
        painter.GetComponent<PaintIn3D.P3dPaintDecal>().Color = Color.yellow;
    }

    public void PaintingBlue()
    {
        painter.GetComponent<PaintIn3D.P3dPaintDecal>().Color = Color.blue;
    }

  public void PaintingStage()
    {
        if (GameManager.instance.isGameOver)
        {
            paintingPannel.SetActive(true);
            inGameRankings.SetActive(false);
            deathCountPannel.SetActive(false);
        }
        
    }
}
