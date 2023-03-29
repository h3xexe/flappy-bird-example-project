using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Bird bird;
    private UIScript canvas;

    void Start()
    {
        canvas = GameObject.Find("UI").GetComponent<UIScript>();
        setScore(0);
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        canvas.playerScore.text = score.ToString();
    }

    public void setScore(int scoreToSet)
    {
        score = scoreToSet;
        canvas.playerScore.text = score.ToString();
    }

    public void startGame()
    {
        SceneManager.LoadScene(0);
        bird.isDead = false;
        score = 0;
        Time.timeScale = 1f;
    }

    public void endGame()
    {
        canvas.restartScreen.SetActive(true);
        /**GameObject myGameObject = GameObject.Find("MyGameObject");

        // Set the timescale for the GameObject
        myGameObject.GetComponent<Time>().timeScale = 0.5f;**/
    }
}
