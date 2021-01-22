using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public static float speed = 2f;

    private float lowerBound = -30f;

    private void OnLevelWasLoaded(int level)
    {
        speed = 2f;
    }

    void Update()
    {
        if (!GameMaster.Instance.GameOver)
        {
            speed += Time.deltaTime / Mathf.Pow(speed, 2);
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < lowerBound)
        {
            gameObject.SetActive(false);
        }
    }
}
