using UnityEngine;

public class ShootOnCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SendMessage("OnFire");
    }
}
