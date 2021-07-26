using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR

using UnityEditor;

#endif

public class GameManager : MonoBehaviour //inheritance from MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreText;
    private bool paused; //encapsulation
    public bool gameOver;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused(); //Abstraction
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    private void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
            Quit();
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverScreen.SetActive(true);
        if (Input.GetKey(KeyCode.Space))
        {
            RestartGame();
        }
        else
        {
            Quit();
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        }

    }
}
