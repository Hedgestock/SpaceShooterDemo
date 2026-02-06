using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public int DropPercentage = 10;

    public List<GameObject> Items;

    void OnDestroy()
    {
        if (Random.Range(0, 100) < DropPercentage)
            Instantiate(Items[Random.Range(0, Items.Count)]).transform.position = transform.position;
    }
}
