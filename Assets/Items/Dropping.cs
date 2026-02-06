using UnityEngine;

public class Dropping : MonoBehaviour
{
    public float DroppingDiff = 1;
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity += GameObject.Find("Grid").GetComponent<Rigidbody2D>().linearVelocity + Vector2.down * DroppingDiff;
    }

    void OnBecameInvisible()
    {
         Destroy(gameObject);
    }
}
