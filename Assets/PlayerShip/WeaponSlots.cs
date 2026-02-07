using DG.Tweening;
using System.Linq;
using UnityEngine;

public class WeaponSlots : MonoBehaviour
{
    private GameObject _la = null;
    public GameObject LeftAugment
    {
        set
        {
            Destroy(_la);
            _la = value;
            MoveToSlot("LeftGun", value);
        }
    }

    private GameObject _ra = null;
    public GameObject RightAugment
    {
        set
        {
            Destroy(_ra);
            _ra = value;
            MoveToSlot("RightGun", value);
        }
    }

    void MoveToSlot(string slot, GameObject augment)
    {
        augment.GetComponent<Collider2D>().enabled = false;
        augment.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        augment.transform.DOMove(GameObject.Find(slot).GetComponent<RectTransform>().position, .5f).SetEase(Ease.InBack);

        GetComponents<Shoot>().First(w => slot == "LeftGun" ? w.barrelPosition.x < 0 : w.barrelPosition.x >= 0).Projectile = augment.GetComponent<WeaponAugmentation>().Projectile;
    }
}
