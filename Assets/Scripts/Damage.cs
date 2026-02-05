using UnityEngine;

public class Damage : MonoBehaviour
{
    [field: SerializeField]
    int damage = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Life>().LifePoints -= damage;
    }
}
