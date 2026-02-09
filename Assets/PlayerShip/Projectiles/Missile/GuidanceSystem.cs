using System.Linq;
using UnityEngine;

public class GuidanceSystem : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        FindTarget();
    }

    void FixedUpdate()
    {
        if (target)
        {
            var direction = target.transform.position - transform.position;

            rb.AddForce(direction.normalized * (50 / direction.magnitude));
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, 7);
        }
        else
        {
            FindTarget();
        }

        animator.SetInteger("Direction", (int)(Vector2.SignedAngle(Quaternion.AngleAxis(-22.5f, Vector3.forward) * Vector2.down, rb.linearVelocity) / 45 + 4));
    }

    void FindTarget()
    {
        float distance = float.MaxValue;
        target = FindObjectsByType<Scorer>(FindObjectsSortMode.None).Aggregate(null, (Scorer closest, Scorer next) =>
        {
            float d = Vector3.Distance(next.gameObject.transform.position, transform.position);
            if (d < distance)
            {
                distance = d;
                return next;
            }
            return closest;

        }
        ).gameObject;
    }
}
