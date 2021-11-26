using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject indicator;
    public GameObject Target;
    private SpriteRenderer rb;
    void Start()
    {
        Target = FindObjectOfType<Playermotion>().gameObject;
        rb = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.isVisible == false)
        {
            if (!indicator.activeSelf)
            {
                Debug.Log("1");
                indicator.SetActive(true);
            }

            Vector2 direction = Target.transform.position - transform.position;
            RaycastHit2D ray = Physics2D.Raycast(transform.position, direction);
            if (ray.collider !=null)
            {
                Debug.Log(ray.collider.name);
                indicator.SetActive(true);
                indicator.transform.position = ray.point;
            }
        }
        else
        {
            if (indicator.activeSelf)
            {
                Debug.Log("2");
                indicator.SetActive(false);
            }
        }
    }
}
