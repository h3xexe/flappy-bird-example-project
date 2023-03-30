using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public int countDownTime = 3;
    private Text countDownText;

    public static CountdownController Instance { get; private set; }

    // This is a singleton class
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        Time.timeScale = 0;
        countDownText = GetComponent<Text>();
        StartCoroutine(CountDownTimer());
    }

    public void startCounter()
    {
        countDownText.gameObject.SetActive(true);
        UIScript.Instance.hideRestart();
        StartCoroutine(CountDownTimer());
    }
    IEnumerator CountDownTimer()
    {
        int ctime = countDownTime;
        while (ctime > 0)
        {
            countDownText.text = ctime.ToString();
            yield return new WaitForSecondsRealtime(1f);
            ctime--;
        }

        countDownText.text = "0";

        GameManager.Instance.startGame();

        yield return new WaitForSecondsRealtime(.5f);

        countDownText.gameObject.SetActive(false);
    }
}
