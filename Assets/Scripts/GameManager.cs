using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Bird bird;

    public static GameManager Instance { get; private set; }
    
    // This is a singleton class
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        setScore(0);
    }

    private void Update()
    {
        //Debug.Log(bird.isDead());
        if (bird.isDead() && Input.GetKeyDown(KeyCode.Space))
        {
            startGame();
        }
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UIScript.Instance.playerScore.text = score.ToString();
    }

    public void setScore(int scoreToSet)
    {
        score = scoreToSet;
        UIScript.Instance.playerScore.text = score.ToString();
    }

    public void startGame()
    {
        UIScript.Instance.hideRestart();
        UIScript.Instance.showScore();
        SceneManager.LoadScene(0);
        bird.setBirdDeath(false);
        setScore(0);
        Time.timeScale = 1f;
    }

    public void endGame()
    {
        bird.setBirdDeath(true);
        UIScript.Instance.showRestart();
        UIScript.Instance.hideScore();
        Time.timeScale = 0;
        /**GameObject myGameObject = GameObject.Find("MyGameObject");

        // Set the timescale for the GameObject
        myGameObject.GetComponent<Time>().timeScale = 0.5f;**/
    }

    public void startButton()
    {
        if (CountdownController.Instance && CountdownController.Instance.gameObject.activeSelf)
        {
            CountdownController.Instance.startCounter();
        } else if(TapToStartController.Instance) {
            SceneManager.LoadScene(0);
            UIScript.Instance.hideRestart();
            TapToStartController.Instance.gameObject.SetActive(true);
        }
    }
}
