using System;
using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    Rigidbody2D rb;
    Spawner spawner;
    DateTime startTime;
    private bool _isRunning = false;
    public bool IsRunning
    {
        set
        {
            _isRunning = value;
            if (value)
                startTime = DateTime.Now;
            else
            {
                rb.linearVelocity = Vector2.down;
                spawner.range = new(1, 3);

            }
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    void FixedUpdate()
    {
        if (!_isRunning) return;

        var gameSpeed = 1 + (int)((DateTime.Now - startTime).TotalSeconds / 6) * 0.1f;

        if (-rb.linearVelocity.y < gameSpeed)
        {
            rb.linearVelocity = Vector2.down * gameSpeed;
            spawner.range = new(Mathf.Max(1 - ((gameSpeed - 1) / 10), .1f), Mathf.Max(3 - ((gameSpeed - 1) / 3), .3f));
        }

        Debug.Log($"{rb.linearVelocity} {gameSpeed} {(DateTime.Now - startTime).TotalSeconds}");
    }
}
