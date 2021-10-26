using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 7)
        {
            objectPooling.instance.ReturnObject(this.gameObject);
            timer = 0;
        }
    }
   
    public void fire()
    {
        rb.velocity = transform.forward * speed;
    }
}