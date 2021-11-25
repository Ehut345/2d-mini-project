using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusIndicator : MonoBehaviour
{
    public Transform target;
    private Vector3 Offset;

    void Awake()
    {
        Offset = transform.position - target.position;
    }

    void Update()
    {
        Vector3 finalpos = target.position + Offset;
        transform.position = finalpos;
    }
}