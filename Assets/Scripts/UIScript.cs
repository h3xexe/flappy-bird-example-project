using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;




public class UIScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI playerScore;
    public GameObject restartScreen;

    public static UIScript Instance { get; private set; }

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

    public void showRestart()
    {
        restartScreen.gameObject.SetActive(true);
    }


    public void hideRestart()
    {
        restartScreen.gameObject.SetActive(false);
    }

}
