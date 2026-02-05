using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject explosion;

    public bool IsInvul = false;
    [field: SerializeField]
    private int _invul = 5;
    [field: SerializeField]
    private int _life = 20;
    public int LifePoints
    {
        get
        {
            return _life;
        }
        set
        {   
            if (value < _life)
            {
                if (IsInvul) return;
                if (_invul > 0)
                    StartCoroutine(nameof(InvulRoutine));
            }

            if (value <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
                return;
            }

            _life = value;
        }
    }

    SpriteRenderer sprite;
    Collider2D hurtBox;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        hurtBox = GetComponent<Collider2D>();
        if (IsInvul)
            StartCoroutine(nameof(InvulRoutine));
    }

    private void FixedUpdate()
    {
        if (transform.position.y > Camera.main.orthographicSize * 2 || transform.position.y < -Camera.main.orthographicSize * 2) 
            Destroy(gameObject);
    }

    private IEnumerator InvulRoutine()
    {
        IsInvul = true;
        for (int i = 0; i < _invul * 2; i++)
        {
            sprite.enabled = !sprite.enabled;

            yield return new WaitForSeconds(.05f);
        }

        hurtBox.enabled = false;
        sprite.enabled = true;
        IsInvul = false;
        hurtBox.enabled = true;
    }
}
