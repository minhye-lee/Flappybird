using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl instance; //static을 붙이면 object갯수만큼 변수가 생기지 않고 공유한다.
    public float scrollSpeed = -1.5f;
    public Text scoreText;
    public GameObject gameOverText;

    public bool gameOver = false;

    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if(gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void BirdScored()
    {
        if(gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score;
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

}
