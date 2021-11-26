using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float timer = 0;

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            //this.gameObject.SetActive(false);////old spawner
            var temp = NewPooler.Instance.ReturnToPool(this.gameObject, "Bullet");
            timer = 0;
        }
    }
    public void fire(Vector3 direction)
    {
        Vector2 dir = new Vector2(direction.x, direction.y);
        rb.velocity += dir * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().health -= 1;
            var temp = NewPooler.Instance.ReturnToPool(this.gameObject, "Bullet");
        }
        if (collision.gameObject.GetComponent<Enemy2>())
        {
            collision.gameObject.GetComponent<Enemy2>().health -= 1;
            var temp = NewPooler.Instance.ReturnToPool(this.gameObject, "Bullet");
        }
        if (collision.gameObject.GetComponent<Enemy3>())
        {
            collision.gameObject.GetComponent<Enemy3>().health -= 1;
            var temp = NewPooler.Instance.ReturnToPool(this.gameObject, "Bullet");
        }
    }
}