using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    public SoundtrackManager soundtrackManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame()
    {
        // Load the next scene in the build order or specify by name
        SceneManager.LoadScene("LevelScene");  // Replace "GameScene" with your game scene name
        soundtrackManager.PlayGameplayMusic();
    }

    public void QuitGame()
    {
        // Quit the game
        Debug.Log("Game is quitting.");
        Application.Quit();
    }
}
