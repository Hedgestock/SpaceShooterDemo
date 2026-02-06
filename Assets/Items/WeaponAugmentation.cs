using System.Linq;
using UnityEngine;

public class WeaponAugmentation : MonoBehaviour
{
    [SerializeField]
    private bool both = false;

    public GameObject Projectile;

    void OnTriggerEnter2D(Collider2D other)
    {
        Shoot[] weapons = null;
        if (both)
            weapons = other.GetComponents<Shoot>();
        else
        {
            if (transform.position.x < other.transform.position.x)
                weapons = other.GetComponents<Shoot>().Where(w => w.barrelPosition.x < 0).ToArray();
            else
                weapons = other.GetComponents<Shoot>().Where(w => w.barrelPosition.x >= 0).ToArray();
        }

        foreach (var weapon in weapons)
            weapon.Projectile = Projectile;

        Destroy(gameObject);
    }
}
