using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenuInventory : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public static bool IsInventoryOpen = false;
    public GameObject InventoryUI;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (IsInventoryOpen)
            {
                Closed();
            }
            else
            {
                Open();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Closed()
    {
        InventoryUI.SetActive(false);
        Time.timeScale = 1f;
        IsInventoryOpen = false;
    }

    public void Open()
    {
        InventoryUI.SetActive(true);
        Time.timeScale = 0f;
        IsInventoryOpen = true;
    }
}
