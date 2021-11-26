using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public static UnityEvent scoreEvent = new UnityEvent();
    GameObject playerref;
    public float speed = 5;
    public float timer = 0;
    public float minDistance = 10f;
    public int health = 2;
    public Transform Eshootpoint;

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
        float distance = Vector3.Distance(transform.position, playerref.transform.position);
        timer += Time.deltaTime;
        if (timer > 3f)
        {
            GameObject temp1 = NewPooler.Instance.GetPooledObject("EBullet", Eshootpoint.position, Quaternion.identity);
            if (temp1)
            {
                var direction = playerref.transform.position - transform.position;
                temp1.GetComponent<EBullet>().fire(direction);
            }
            timer = 0;
        }

        Vector3 dir = playerref.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (distance >= minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerref.transform.position, speed * Time.deltaTime);
        }
        if (health <= 0)
        {
            //gameObject.SetActive(false);////old spawner
            var temp = NewPooler.Instance.ReturnToPool(this.gameObject, "Enemy");
            //if (scoreEvent != null)
            //{
            //    scoreEvent.Invoke();
            //}
            scoreEvent?.Invoke();
            EnemySpawner.instance.count -= 1;
        }
    }
}
