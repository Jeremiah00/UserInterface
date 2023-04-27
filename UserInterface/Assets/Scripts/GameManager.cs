using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    public int lives = 3;
    void Start()
    {
        
        
    }
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score =  0;
        StartCoroutine(SpawnTarget());
        spawnRate /= difficulty;
        UpdateScore(0);
        UpdateLives();
        titleScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    IEnumerator SpawnTarget()
    {
        
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Length);
            Instantiate(targets[index]);
           
            
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void UpdateLives()
    {
        Debug.Log("y");
        livesText.text = "Lives: " + lives;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Update()
    {
        
    }
}
