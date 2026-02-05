using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{

    public Sprite shipLeft;
    public Sprite shipStraight;
    public Sprite shipRight;
    public SpriteRenderer shipSprite;
    public Animator animator;

    public Rigidbody2D body;

    public float speed = 5f;

    Rect boundaries;

    void Start()
    {
        float height = Camera.main.orthographicSize - 1;
        float width = height * 2 * Camera.main.aspect - .5f;
        boundaries = new(-width / 2, -height, width, height);

        transform.position = new(0, boundaries.y * .75f);
    }

    Vector3 movement = Vector3.zero;
    // FixedUpdate is called every fixed framerate frame, used for physics operations
    void FixedUpdate()
    {
        animator.SetFloat("horizontal_velocity", movement.x);

        if (movement.x < -0.1f)
            shipSprite.sprite = shipLeft;
        else if (movement.x > 0.1f)
            shipSprite.sprite = shipRight;
        else
            shipSprite.sprite = shipStraight;

        body.linearVelocity = movement * speed;

        //I did not find a way to hook some window resize event so let's compute it every tick!
        float height = Camera.main.orthographicSize - 1;
        float width = height * 2 * Camera.main.aspect;
        boundaries = new(-width / 2, -height, width, height);

        if (!boundaries.Contains(transform.position))
        {
            float clampedX = Mathf.Clamp(transform.position.x, boundaries.xMin, boundaries.xMax);
            float clampedY = Mathf.Clamp(transform.position.y, boundaries.yMin, boundaries.yMax);
            transform.position = new Vector3(clampedX, clampedY);
        }
    }
    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    void OnDestroy()
    {
        GameObject.Find("Canvas").GetComponent<PlayerLivesHandler>().LoseLife();
    }
}
