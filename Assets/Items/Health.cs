using UnityEngine;

public class Health : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity += GameObject.Find("Grid").GetComponent<Rigidbody2D>().linearVelocity + Vector2.down;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Life>().LifePoints += 10;
        Destroy(gameObject);
    }
}
