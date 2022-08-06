using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenu;

    [SerializeField]
    public GameObject gameOver;

    public static bool isGamePaused = false;
    public static bool isGameOver;

    public void Start(){
        pauseMenu.SetActive(false);
        Resume();
    }
    
    void Awake(){
        isGameOver = false;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if (isGameOver)
        {
            gameOver.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isGamePaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }
}