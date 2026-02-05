using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Vector2 velocity = Vector2.up * 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity += velocity;
    }
}
