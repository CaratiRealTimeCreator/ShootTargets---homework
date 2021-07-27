using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongTargets : Targets  //inheritance
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public override void OnMouseDown()
    {
        //base.OnMouseDown();
        if (!gameManager.gameOver)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(-10);  //polymorphism
        }
    }
}
