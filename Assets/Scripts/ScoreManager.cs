using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0; // static bien nay la bien ton tai duy nhat trong noi bo nay
    public float remainingTime = 15;
    public static int Timeboost;
    public GameObject gameOverPanel;// khai bao bien
    public TextMeshProUGUI gameOverText; // kieu du lieu
    

    public TextMeshProUGUI scoreText;

    public static void AddScore(int amount)
    {
        score += amount;
    }

    public static void AddTime(int amount)
    { 
        Timeboost += amount;
        
    }

    void Start() // đếm giờ khi trò chơi bắt đầu
    {
        // remainingTime = 10f; //thời gian còn lại tại thời điểm bắt đầu bằng 30s (thời lượng của trò chơi)
        StartCoroutine(CountdownTimer());
        // là một phương thức nâng cao để gọi hàm CountdownTimer
        // nhằm cho phép đồng hồ chạy song song, tiếp tục đếm khi chuyển qua frame mới và kết thúc ở frame mới khi đạt đúng thời gian
    }

    void Update()
    {
        scoreText.text = "Score: " + score + " | Time: " + Mathf.CeilToInt(remainingTime); //Mathf.CeilToInt(remainingTime) làm tròn số nguyên dương
        if (Timeboost > 0) 
        {
            remainingTime += Timeboost;
            Timeboost = 0;
        }
    }
    

    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        if (remainingTime <= 0)
        {
            GameOver();
            Time.timeScale = 0f;
        }
    }
    private void GameOver()
    {
        gameOverText.text = "Game Over!\nScore: " + score;
        gameOverPanel.SetActive(true);
    }
    // ...rest of the script...
    public void Replay()
    {
        score = 0;
        Time.timeScale = 1f;
        // Get the current active scene

        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current scene

        SceneManager.LoadScene(currentScene.name);
    }
}