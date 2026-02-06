using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Shoot : MonoBehaviour
{

    public GameObject Projectile;

    public bool nonRelative = false;

    public Vector3 barrelPosition = Vector3.zero;
    public Vector2 barrelDirection = Vector2.up;

    void OnFire()
    {
        var projo = Instantiate(Projectile, transform.position + barrelPosition, Quaternion.identity);
        projo.GetComponent<Rigidbody2D>().linearVelocity = barrelDirection.normalized * projo.GetComponent<Projectile>().speed + (nonRelative ? Vector2.zero : GetComponent<Rigidbody2D>().linearVelocity);
        Physics2D.IgnoreCollision(projo.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Move performed");
            OnFire();
        }
        if (context.canceled)
        {
            Debug.Log("Move canceled");
            //OnFire(Projectile.Ch);
        }
    }

    void FireCharged(GameObject projectile = null)
    {
        projectile = projectile ?? Projectile;
        var projo = Instantiate(projectile, transform.position + barrelPosition, Quaternion.identity);
        projo.GetComponent<Rigidbody2D>().linearVelocity = barrelDirection.normalized * projo.GetComponent<Projectile>().speed + (nonRelative ? Vector2.zero : GetComponent<Rigidbody2D>().linearVelocity);
        Physics2D.IgnoreCollision(projo.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }
}
