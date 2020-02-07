using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int playercurrentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            scoreText.text = playercurrentScore.ToString();
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public int getScore()
    {
        return playercurrentScore;
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = playercurrentScore.ToString();
    }

    public void addScore(int scoreToAdd)
    {
        playercurrentScore += scoreToAdd;
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }
}
