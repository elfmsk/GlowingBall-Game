using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMenuUI : MonoSingleton<PanelMenuUI>
{
    Text bestScoreText;
    private int bestScore;
    public int BestScore
    {
        get
        {
            return bestScore;
        }
        set
        {
            if (value > bestScore)
            {
                bestScore = value;
                PlayerPrefs.SetInt("HighScore", bestScore);
            }
        }
    }

    private void Awake()
    {
        InitSingleton();
        bestScoreText = transform.Find("BestScoreText").GetComponent<Text>();
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("HighScore", 0);
        bestScoreText.text += bestScore;
    }
    
    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.Return) || Input.GetKey("enter"))
    //    {
    //        StartGame();
    //    }
    //}
    public void StartGame()
    {
        GameMaster.Instance.StartGame();
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
