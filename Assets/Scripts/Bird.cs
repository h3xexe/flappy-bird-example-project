using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float velocity = 1f;
    public Rigidbody2D rb2d;
    private bool isAir = true;
    public int zAngleLimit = 45;
    public Vector2 initialPosition;
    public bool isDead = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Dangerous")
        {
            isDead = true;
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
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
