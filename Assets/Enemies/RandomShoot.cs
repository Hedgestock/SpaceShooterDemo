using UnityEngine;

public class RandomShoot : MonoBehaviour
{
    Vector2 range = new(1, 3);

    private void Start()
    {
        Invoke(nameof(Shoot), Random.Range(range.x, range.y));
    }

    private void Shoot()
    {
        gameObject.SendMessage("OnFire");
        Invoke(nameof(Shoot), Random.Range(range.x, range.y));
    }
}
