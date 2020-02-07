using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delaySeconds = 2f;
    // Start is called before the first frame update
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void LoadLevel()
    {
        FindObjectOfType<GameStatus>().resetGame();
        SceneManager.LoadScene("Level");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
