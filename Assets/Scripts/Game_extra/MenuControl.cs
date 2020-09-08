using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    public GameObject OptionsPanel;
    public GameObject Neusaap;
    public GameObject ControlPanel;

    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Startscherm");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadOptionsPanel()
    {
        OptionsPanel.gameObject.SetActive(true);
    }

    public void CloseOptionsPanel()
    {
        OptionsPanel.gameObject.SetActive(false);
    }

    public void LoadControlPanel()
    {
        ControlPanel.gameObject.SetActive(true);
    }

    public void CloseControlPanel()
    {
        ControlPanel.gameObject.SetActive(false);
    }

    public void LoadNeusaap()
    {
        Neusaap.gameObject.SetActive(true);
    }

    public void CloseNeusaap()
    {
        Neusaap.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(3);
    }

}
