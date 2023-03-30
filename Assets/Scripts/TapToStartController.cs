using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStartController : MonoBehaviour
{
    public static TapToStartController Instance { get; private set; }

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

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            GameManager.Instance.startGame();
        }
    }
}
