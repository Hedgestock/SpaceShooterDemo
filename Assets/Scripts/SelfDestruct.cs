using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    void Destroy()
    {
        Destroy(gameObject);
    }
}
