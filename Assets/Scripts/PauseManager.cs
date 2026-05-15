using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseText;
    public AudioSource gameMusic;

    bool isPaused = false;

    void Start()
    {
        pauseText.SetActive(false);
    }

    void Update()
    {
        if (!CountdownManager.countdownFinished)
            return;

        if (Input.GetKeyDown(KeyCode.Escape) ||
            Input.GetKeyDown(KeyCode.Return) ||
            Input.GetMouseButtonDown(1))
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

    void PauseGame()
    {
        isPaused = true;

        pauseText.SetActive(true);

        Time.timeScale = 0f;

        if (gameMusic != null)
        {
            gameMusic.Pause();
        }
    }

    void ResumeGame()
    {
        isPaused = false;

        pauseText.SetActive(false);

        Time.timeScale = 1f;

        if (gameMusic != null)
        {
            gameMusic.UnPause();
        }
    }
}