using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public List<GameObject> Items;


    void OnDestroy()
    {
        if (Random.Range(0, 10) < 1)
            Instantiate(Items[Random.Range(0, Items.Count)]).transform.position = transform.position;
    }
}
