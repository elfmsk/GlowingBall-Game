using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler: MonoBehaviour
{
    // _______ Controllers _______
    [Header("Controllers")]

    [Range(1f, 100f)] [SerializeField] private float spawnTime;

    // _______ Other components _______
    [Header("Other components")]

    public GameObject[] PlatformsPool;
    private int indexPlatform;
    private float countTime;
    private float sizePlatform;
    private Vector3 posPlatform;

    void Start()
    {
        countTime = spawnTime;
        indexPlatform = 3;
    }

    void Update()
    {
        if (!GameMaster.Instance.GameOver)
        {
            countTime -= Time.deltaTime;

            if (countTime <= 0)
            {
                ActivatePlatform();
            }
        }
    }
    
    private void ActivatePlatform()
    {
        countTime = Random.Range(spawnTime - 0.8f, spawnTime);
        sizePlatform = Random.Range(0.7f, 1.1f);
        posPlatform = new Vector3(transform.position.x, PlatformsPool[indexPlatform].transform.position.y, transform.position.z);
        PlatformsPool[indexPlatform].transform.position = posPlatform;
        PlatformsPool[indexPlatform].transform.localScale = new Vector3(sizePlatform, 1, 1);
        PlatformsPool[indexPlatform].SetActive(true);
        indexPlatform += 1;
        if (indexPlatform >= PlatformsPool.Length)
        {
            indexPlatform = 0;
        }
    }
}
