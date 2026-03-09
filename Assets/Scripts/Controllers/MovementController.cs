using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Vector2 ballPosition;
    public Vector2 ballVelocity;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ballVelocity = rb.linearVelocity;
        ballPosition = gameObject.transform.position;

        Console.Write(ballVelocity);
    }
}
