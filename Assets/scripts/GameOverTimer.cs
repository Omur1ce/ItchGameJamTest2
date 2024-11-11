using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement; 
using TMPro;

public class GameOverTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public bool isGameOver = false;  

    private float timer;  

    void Start()
    {
        timer = 0f;  
        UpdateTimerDisplay(); 
    }

    void Update()
    {
        if (!isGameOver)
        {
            timer += Time.deltaTime; 
            UpdateTimerDisplay(); 
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        isGameOver = true;  
    }

    public void ResetTimer()
    {
        timer = 0f; 
        isGameOver = false;  
        UpdateTimerDisplay(); 
    }
}
