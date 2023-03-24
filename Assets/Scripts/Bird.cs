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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAir = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isAir = true;
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
