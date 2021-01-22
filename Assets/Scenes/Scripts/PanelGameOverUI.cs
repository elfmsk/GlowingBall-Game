using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelGameOverUI : MonoBehaviour
{
    Text resultScore;
    private void Awake()
    {
        resultScore = transform.Find("GameOverText").GetComponent<Text>();
    }

    private void OnEnable()
    {
        resultScore.text = CountScoreUI.Instance.ScoreText;
    }

    public void RestartGame()
    {
        LevelLoader.Instance.LoadLevel();
    }
}
