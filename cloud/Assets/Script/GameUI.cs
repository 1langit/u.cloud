using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject pause, menu, finish;
    private bool isPaused = false;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference
        playerController = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            // Resume button
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ResumeGame();
            }
            // Restart button
            else if (Input.GetKeyDown(KeyCode.R))
            {
                ResumeGame();
                playerController.Respawn();
            }
            // Quit button
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
        else
        {
            // Pause button
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        pause.SetActive(false);
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        pause.SetActive(true);
        finish.SetActive(false);
        isPaused = false;
    }

    public void LevelComplete()
    {
        Time.timeScale = 0;
        menu.SetActive(false);
        pause.SetActive(false);
        finish.SetActive(true);
        isPaused = true;
    }
}
