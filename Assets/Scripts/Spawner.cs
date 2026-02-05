using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Enemies;

    Vector2 range = new(1, 3);

    bool spawning = false;

    public bool Spawning
    {
        set
        {
            if (value == spawning) return;
            if (value)
                Invoke(nameof(Spawn), Random.Range(range.x, range.y));
            else
            {
                foreach (var gameObject in GameObject.FindGameObjectsWithTag("Cleanable"))
                {
                    Scorer s = gameObject.GetComponent<Scorer>();
                    if (s) //C# 10 would have let me use a null conditional assignment but Unity only support 9
                        s.Score = 0;
                    Destroy(gameObject);
                }
            }

            spawning = value;
        }
    }

    void Spawn()
    {
        if (!spawning) return;
        float height = Camera.main.orthographicSize - 1;
        float width = height * Camera.main.aspect;

        GameObject enemy = Instantiate(Enemies[Random.Range(0, Enemies.Count)]);

        Debug.Log(enemy.name);

        enemy.transform.position = new(Random.Range(-width, width), height + 2);
        enemy.GetComponent<Rigidbody2D>().linearVelocity += GameObject.Find("Grid").GetComponent<Rigidbody2D>().linearVelocity;

        Invoke(nameof(Spawn), Random.Range(range.x, range.y));
    }
}
