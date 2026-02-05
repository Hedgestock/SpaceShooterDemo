using UnityEngine;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{

    public GameObject projectile;

    public Vector3 barrelPosition = Vector3.zero;

    void OnFire()
    {
        var projo = Instantiate(projectile, transform.position + barrelPosition, Quaternion.identity);
        projo.GetComponent<Rigidbody2D>().linearVelocity += GetComponent<Rigidbody2D>().linearVelocity;
        Physics2D.IgnoreCollision(projo.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }
}
