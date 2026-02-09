using UnityEngine;

public class RandomShoot : MonoBehaviour
{
    Vector2 range;
    Rigidbody2D gridrb;

    private void Start()
    {
        gridrb = GameObject.Find("Grid").GetComponent<Rigidbody2D>();
        range = new(Mathf.Max(1 - ((-gridrb.linearVelocity.y - 1) / 10), .1f), Mathf.Max(3 - ((-gridrb.linearVelocity.y - 1) / 3), .3f));
        Invoke(nameof(Shoot), Random.Range(range.x, range.y));
    }

    private void Shoot()
    {
        gameObject.SendMessage("OnFire");
        Invoke(nameof(Shoot), Random.Range(range.x, range.y));
    }
}
