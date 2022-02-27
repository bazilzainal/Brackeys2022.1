using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;

    [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;

    private void Awake()
    {
        // Singleton pattern. Make sure only 1 GameManager is ever instantiated.

        int numGameSessions = FindObjectsOfType<GameManager>().Length;

        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = padStringWithZeros(3, "0");
    }

    public IEnumerator ProcessPlayerDeath(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }

    }

    // Restart this level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void TakeLife()
    {
        this.playerLives--;
        livesText.text = playerLives.ToString();
        score = 0;
        scoreText.text = padStringWithZeros(3, score.ToString());
        Debug.Log("Remove life");
        Restart();

    }

    // TODO Change the way index is gotten
    void ResetGameSession()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    }

    public void ExitToMenu()
    {
        // Hardcode for now
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public int GetPlayerLives()
    {
        return playerLives;
    }

    public int getScore()
    {
        return score;
    }

    public void addScore(int toAdd)
    {
        activeManager.score += toAdd;
        activeManager.scoreText.text = padStringWithZeros(3, score.ToString());
    }

    private string padStringWithZeros(int targetedStringLength, string s)
    {
        while (s.Length < targetedStringLength)
        {
            s = "0" + s;
        }
        return s;
    }

    public void FinishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
