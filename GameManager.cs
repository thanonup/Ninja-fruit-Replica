using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Score;
    public GameObject PanelGameOver;
    public GameObject PanelGameOver1;

    [HideInInspector]
    public bool Gameover = false;


    int count;
    private int ScoreUpdate;
    public static GameManager instance;

    [Header("MissUi Setting", order = 0)]

    [Range(0, 3)]
    public int Miss;
    public int numOfMiss;
    public Image[] miss;
    public Sprite FullMiss;
    public Sprite emptyMiss;


    [SerializeField]
    private Stat ScoreOB;

    [SerializeField]
    private Stat ScoreOb2;


    void Awake()
    {
        if (instance == null)
            instance = this;

        ScoreOB.Initialize();
        ScoreOb2.Initialize();
    }

    private void Update()
    {
        if(count >= 3)
        {
            GameOver();
        }

        if(ScoreOB.CurrentValue == ScoreOB.MaxValue)
        {
            GameWinner();
        }

        UIcontrol();
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ScoreOB.CurrentValue += 10;
        }

    }

    public void UpScore(int Scorepoint)
    {
        //ScoreUpdate = ScoreUpdate + Scorepoint;
        //Score.text = ScoreUpdate.ToString("Score: 0");
        ScoreOB.CurrentValue += Scorepoint;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ob")
        {
            if (FuritSpawner.instance.CheckSpawn == true)
            {
                count++;
                Miss++;
            }
            //Debug.Log(count); 
        }
    }
    public void GameOver()
    {
        Gameover = true;
        PanelGameOver.SetActive(true);
        FuritSpawner.instance.CheckSpawn = false;
        Miss = 3;
    }
    public void GameWinner()
    {
        Gameover = true;
        PanelGameOver1.SetActive(true);
        FuritSpawner.instance.CheckSpawn = false;
    }

    public void UIcontrol()
    {
        if(Miss > numOfMiss)
        {
            Miss = numOfMiss;
        }

        for(int i = 0;i < miss.Length; i++)
        {
            if(i < Miss)
            {
                miss[i].sprite = FullMiss;
            }
            else
            {
                miss[i].sprite = emptyMiss;
            }
            if(i < numOfMiss)
            {
                miss[i].enabled = true;
            }
            else
            {
                miss[i].enabled = false;
            }
        }
    }

  
}
