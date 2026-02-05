using UnityEngine;

public class GridMovement : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down;
    }

    void FixedUpdate()
    {
        if (transform.position.y < -4)
            transform.position = Vector3.zero;
    }
}
