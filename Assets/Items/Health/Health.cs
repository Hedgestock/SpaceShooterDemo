using UnityEngine;

public class Health : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Life>().LifePoints += 10;
        Destroy(gameObject);
    }
}
