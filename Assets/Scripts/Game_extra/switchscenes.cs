using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchscenes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "2")
        {
            SceneManager.LoadScene(2);
        }

        if (collision.tag == "1")
        {
            SceneManager.LoadScene(1);
        }

        if (collision.tag == "0")
        {
            SceneManager.LoadScene(0);
        }

    }
}

  