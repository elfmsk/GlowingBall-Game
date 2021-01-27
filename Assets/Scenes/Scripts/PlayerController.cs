using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int score;

    private AudioSource AudioBG;
    private float forceGravity = 9.8F;
    private int border = 4;
    private bool canChangeGravity;
    private Rigidbody RB;

    private void Awake()
    {
        AudioBG = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
    }
    
    void Start()
    {
        score = 0;
        AudioBG.Play();
        canChangeGravity = false;
        CountScoreUI.Instance.ChangeScore(score);
        Physics.gravity = new Vector3(0, forceGravity * (-1), 0);
        RB = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!GameMaster.Instance.GameOver)
        {
            RB.isKinematic = false;
            ChangeGravity();
            FollowEnd();
            ChangeVolume();
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        canChangeGravity = true;
    }

    private void ChangeGravity()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space)) && canChangeGravity && !GameMaster.Instance.GameOver)
        {
            score += 1;
            CountScoreUI.Instance.ChangeScore(score);
            canChangeGravity = false;

            if (Physics.gravity.y > 0) // Change gravity on mouse click
            {
                Physics.gravity = new Vector3(0, forceGravity * (-1), 0); // Normal gravity so downward force of -9.8
            }
            else
            {
                Physics.gravity = new Vector3(0, forceGravity, 0); // Inverse gravity
            }
        }
    }

    private void FollowEnd()
    {
        if (transform.position.y < -border || transform.position.y > border)
        {
            GameMaster.Instance.EndGame();
            if (score > PanelMenuUI.Instance.BestScore)
            {
                PanelMenuUI.Instance.BestScore = score;
            }
        }
    }

    private void ChangeVolume()
    {
        if (!GameMaster.Instance.GameOver)
        {
            AudioBG.minDistance += Time.deltaTime;
        }
        else if (GameMaster.Instance.GameOver)
        {
            AudioBG.minDistance -= Time.deltaTime * 6;
        }
    }
}
