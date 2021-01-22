using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountScoreUI : MonoSingleton<CountScoreUI>
{
    private TextMeshProUGUI scoreText;
    public string ScoreText { get { return scoreText.text; } }

    void Awake()
    {
        InitSingleton();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
