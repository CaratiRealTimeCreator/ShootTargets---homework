using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    private GameManager gameManager;
    private SpawnManager spawnManager;
    private int selfDestroyTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyAfterTime();
    }

    public virtual void OnMouseDown()
    {
        if (!gameManager.gameOver)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(1);
        }
    }

    void DestroyAfterTime()
    {
            Destroy(gameObject, selfDestroyTime);
    }
}
