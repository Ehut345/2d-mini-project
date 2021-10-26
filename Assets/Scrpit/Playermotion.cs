using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermotion : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;
    public float speed;

    public float mouseSen;
    float rotz;

    public Transform shootpoint;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
        shoot();
    }
    void MovePlayer()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
    void RotatePlayer()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject temp = objectPooling.instance.GetObject();
            temp.transform.position = shootpoint.position;
            Bullet direction = temp.GetComponent<Bullet>();
            temp.SetActive(true);
            direction.fire();
        }
    }
}
