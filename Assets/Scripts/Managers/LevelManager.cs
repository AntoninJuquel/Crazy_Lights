using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject pressEnterText;
    public static bool gameHasStarted = false;
    public static bool gameHasEnded = false;
    bool stageClear = false;
    public float offset;
    public float levelLenght;
    public float timer = 0;
    public string timerFormatted;

    public GameObject gameOverUi;
    public GameObject gameStatisticsUi;

    public GameObject player;

    System.TimeSpan t;

    private void Start()
    {
        timer = offset;
        stageClear = false;
        gameHasEnded = false;
        gameHasStarted = false;
        FindObjectOfType<ProgressBar>().SetLevelLenght(levelLenght);
        Time.timeScale = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Restart();
        }

        if (!gameHasStarted)
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Cursor.visible = false;
                gameHasStarted = true;
                pressEnterText.SetActive(false);
                FindObjectOfType<AudioManager>().Play(SceneManager.GetActiveScene().name);
                Time.timeScale = 1f;
            }

        if(timer > levelLenght)
        {
            stageClear = true;
            GameEnded();
        }
        timer += Time.deltaTime;
        FindObjectOfType<ProgressBar>().SetLevelProgress(timer);
        t = System.TimeSpan.FromSeconds(timer);
        timerFormatted = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
    }

    /*private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 250, 100), timerFormatted);
    }*/

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            Cursor.visible = true;
            Time.timeScale = 0f;
            gameHasEnded = true;
            FindObjectOfType<AudioManager>().Stop(SceneManager.GetActiveScene().name);
            gameOverUi.SetActive(true);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        gameHasStarted = false;
        gameHasEnded = false;
        if (timer > levelLenght / 2)
        {
            if (SceneManager.GetActiveScene().name.Contains("_checkpoint") || SceneManager.GetActiveScene().name.Contains("Boss") ||stageClear)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().name + "_checkpoint");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void GameEnded()
    {
        float _score = player.GetComponent<PlayerStatistics>().totalDashCounter * -100 + player.GetComponent<PlayerStatistics>().distanceTravelled * -50 + player.GetComponent<PlayerStatistics>().timeStanding * 10000;
        string _grade = "";
        Cursor.visible = true;
        FindObjectOfType<StatsUI>().SetDashCounter(player.GetComponent<PlayerStatistics>().totalDashCounter);
        FindObjectOfType<StatsUI>().SetDistanceTravelled(player.GetComponent<PlayerStatistics>().distanceTravelled);
        FindObjectOfType<StatsUI>().SetTimeStandingStill(player.GetComponent<PlayerStatistics>().timeStanding);

        FindObjectOfType<StatsUI>().SetScore(_score);

        FindObjectOfType<StatsUI>().SetGrade(_grade);
        Time.timeScale = 0f;
        gameHasStarted = false;
        gameHasEnded = true;
        FindObjectOfType<AudioManager>().Stop(SceneManager.GetActiveScene().name);
        gameStatisticsUi.SetActive(true);
        gameOverUi.SetActive(true);
    }
}
