using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float timer = 0;

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 6f)
        {
            var temp = NewPooler.Instance.ReturnToPool(this.gameObject, "EBullet");
            timer = 0;
        }
    }
    public void fire(Vector3 direction)
    {
        Vector2 dir = new Vector2(direction.x, direction.y);
        //rb.velocity += dir * speed * Time.deltaTime;
        rb.AddForce(direction * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Playermotion>())
        {
            collision.gameObject.GetComponent<Playermotion>().takedamage();
            var temp = NewPooler.Instance.ReturnToPool(this.gameObject, "EBullet");
        }
    }
}
