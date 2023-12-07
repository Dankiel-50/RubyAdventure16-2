using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float angularVelocity = 10f;
    float upwardForce = 0f;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch2(Vector2 direction, float initialForce)
    {
        rigidbody2d.velocity = direction * initialForce;
        rigidbody2d.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);

        rigidbody2d.angularVelocity = angularVelocity;
    }

    void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix2();
        }

        Destroy(gameObject);
    }
}
