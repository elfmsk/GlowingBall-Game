using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoSingleton<GameMaster>
{
    private bool gameOver;
    private PanelGameOverUI PanelGameOver;

    public bool GameOver { get { return gameOver; } }

    private void Awake()
    {
        InitSingleton();
        PanelGameOver = GameObject.Find("Canvas").transform.Find("PanelGameOver").GetComponent<PanelGameOverUI>();
    }

    void Start()
    {
        gameOver = true;
    }

    internal void EndGame()
    {
        gameOver = true;
        StartCoroutine(CallGameOverMenu());
    }

    internal void StartGame()
    {
        gameOver = false;
    }

    IEnumerator CallGameOverMenu()
    {
        yield return new WaitForSeconds(1f);
        PanelGameOver.gameObject.SetActive(true);
    }
}
