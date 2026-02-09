using DG.Tweening;
using System.Linq;
using UnityEngine;

public class WeaponAugmentation : MonoBehaviour
{
    [SerializeField]
    private bool both = false;

    public GameObject Projectile;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (both)
        {
            other.GetComponent<WeaponSlots>().LeftAugment = gameObject;
            other.GetComponent<WeaponSlots>().RightAugment = gameObject;
            Destroy(gameObject);
        }
        else
        {
            if (transform.position.x < other.transform.position.x)
                other.GetComponent<WeaponSlots>().LeftAugment = gameObject;
            else
                other.GetComponent<WeaponSlots>().RightAugment = gameObject;
        }
    }
}
