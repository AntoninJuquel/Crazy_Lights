using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public bool GameIsPaused = false;

    public GameObject pauseMenuUi;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && LevelManager.gameHasEnded == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;

        FindObjectOfType<AudioManager>().Play(SceneManager.GetActiveScene().name);
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Cursor.visible = true;
        FindObjectOfType<AudioManager>().Pause(SceneManager.GetActiveScene().name);

        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Stop(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
