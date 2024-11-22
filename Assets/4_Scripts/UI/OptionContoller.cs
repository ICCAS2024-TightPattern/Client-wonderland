using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionContoller : MonoBehaviour
{
    // 다른 스크립트에서 쉽게 접근이 가능하도록 static
    public static bool GameIsPaused = false;
    public GameObject optionPanel;
    public GameObject optionMenu;
    public GameObject soundMenu;
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (GameIsPaused && pauseMenuCanvas.activeSelf)
        //    {
        //        Resume();
        //    }
        //    else if (!GameIsPaused)
        //    {
        //        Pause();
        //    }
        //}
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        optionMenu.SetActive(true);
        soundMenu.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OnClickSoundButton()
    {
        soundMenu.SetActive(true);
        optionMenu.SetActive(false);
    }
    public void OnClickBackButton()
    {
        soundMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void GoToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
