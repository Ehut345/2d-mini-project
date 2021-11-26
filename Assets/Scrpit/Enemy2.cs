using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy2 : MonoBehaviour
{
    public static UnityEvent scoreEvent = new UnityEvent();
    GameObject playerref;
    public float speed = 5;
    public int health = 2;

    private void OnEnable()
    {
        health = 2;
    }
    void Start()
    {
        playerref = FindObjectOfType<Playermotion>().gameObject;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerref.transform.position, speed * Time.deltaTime);
        if (health <= 0)
        {
            var temp = NewPooler.Instance.ReturnToPool(this.gameObject, "Enemy2");
            if (scoreEvent != null)
            {
                scoreEvent.Invoke();
            }
            EnemySpawner.instance.count -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Playermotion>().currenthealth = 0;
            var temp1 = NewPooler.Instance.ReturnToPool(this.gameObject, "Enemy2");
        }
        if (collision.CompareTag("Enemy1"))
        {
            collision.gameObject.GetComponent<Enemy>().health = 0;
            var temp = NewPooler.Instance.ReturnToPool(this.gameObject, "Enemy");
            var temp2 = NewPooler.Instance.ReturnToPool(this.gameObject, "Enemy2");
            EnemySpawner.instance.count -= 1;
        }
        if (collision.CompareTag("Enemy3"))
        {
            collision.gameObject.GetComponent<Enemy3>().health = 0;
            var temp = NewPooler.Instance.ReturnToPool(this.gameObject, "Enemy3");
            var temp2 = NewPooler.Instance.ReturnToPool(this.gameObject, "Enemy2");
            EnemySpawner.instance.count -= 1;
        }
    }
}
