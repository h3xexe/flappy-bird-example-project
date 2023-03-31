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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Dangerous")
        {
            GameManager.Instance.endGame();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            GameManager.Instance.addScore(1);
        }
    }

    private bool birdIsDead = false;

    public void setBirdDeath(Boolean value)
    {
        birdIsDead = value;
    }

    public bool isDead()
    {
        return birdIsDead;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * velocity;
            // rb2d.AddTorque(velocity/4);           
        }
        //Debug.Log(rb2d.velocity.y);
        transform.eulerAngles = new Vector3(0, 0, rb2d.velocity.y * 10f);
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.endGame();
            //rb2d.position = initialPosition;
        }
    }
}
