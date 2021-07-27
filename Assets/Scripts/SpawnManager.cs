using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> targetPrefab;
    private float spawnRate;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(0.1f, 1);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (!gameManager.gameOver)
        {
            InvokeRepeating("SpawnTarget", spawnRate, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnTarget()
    {
        int index = Random.Range(0, targetPrefab.Count);
        Vector3 rotation = new Vector3(0, 0, 0);
        Instantiate(targetPrefab[index], RandomSpawnPos(), Quaternion.Euler(rotation));
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(47, 2200), Random.Range(40, 870));
    }
}
