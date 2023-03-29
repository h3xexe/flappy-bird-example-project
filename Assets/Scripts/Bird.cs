using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float velocity = 1f;
    public Rigidbody2D rb2d;
    public int zAngleLimit = 45;
    public Vector2 initialPosition;
    public bool isDead = false;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Dangerous")
        {
            isDead = true;
            gameManager.endGame();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            gameManager.addScore(1);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2d.velocity = Vector2.up * velocity;
            //rb2d.AddTorque(velocity/4);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb2d.position = initialPosition;
        }
    }
}
