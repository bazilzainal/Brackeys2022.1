using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [SerializeField] AudioSource gameMusic;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] float pausePitch = 0.8f;

    private void Awake()
    {
        gameMusic = GetComponent<AudioSource>();
    }
    private void Start()
    {
        Resume();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        gameMusic.pitch = 1f;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        gameMusic.pitch = pausePitch;
    }

    public void GoToMenu()
    {
        FindObjectOfType<GameManager>().ExitToMenu();
    }
}

