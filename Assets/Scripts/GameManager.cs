using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // [SerializeField] int playerLives = 3;
    [SerializeField] int playerDeaths = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finishText;

    [SerializeField] int score = 0;

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
        // livesText.text = playerLives.ToString();
        livesText.text = playerDeaths.ToString();
        scoreText.text = padStringWithZeros(3, "0");
        finishText.gameObject.SetActive(false);
    }

    public IEnumerator ProcessPlayerDeath(float delay)
    {
        yield return new WaitForSeconds(delay);

        AddDeath();
        //if (playerLives > 1)
        //{
        //    // TakeLife();
        //}
        //else
        //{
        //    ResetGameSession();
        //}

    }

    // Restart this level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //void TakeLife()
    //{
    //    this.playerLives--;
    //    livesText.text = playerLives.ToString();

    //    score = 0;
    //    scoreText.text = padStringWithZeros(3, score.ToString());
    //    Debug.Log("Remove life");
    //    Restart();

    //}

    void AddDeath()
    {
        this.playerDeaths++;
        livesText.text = playerDeaths.ToString();

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

    //public int GetPlayerLives()
    //{
    //    return playerLives;
    //}

    public int getScore()
    {
        return score;
    }

    public void addScore(int toAdd)
    {
        this.score += toAdd;
        this.scoreText.text = padStringWithZeros(3, score.ToString());
    }

    private string padStringWithZeros(int targetedStringLength, string s)
    {
        while (s.Length < targetedStringLength)
        {
            s = "0" + s;
        }
        return s;
    }

    public IEnumerator FinishLevel(float delay)
    {
        finishText.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        finishText.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
