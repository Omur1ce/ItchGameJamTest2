using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Drag your PauseMenu Canvas here

    private bool isPaused = false;

    void Update()
    {
        // Check for the Escape key to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);          // Hide the pause menu
        Time.timeScale = 1f;                   // Resume game time
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);           
        Time.timeScale = 0f;                   
        isPaused = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;                  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;                   
        SceneManager.LoadScene("MainMenu");    
    }

    public void QuitGame()
    {
        Application.Quit();                    // Quit application
        Debug.Log("Game is quitting.");
    }
}
