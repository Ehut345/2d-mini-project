using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPos;
    float timer;
    public int count = 0;
    public int currentCount = 0;
    //public int spawncounter;
    string[] names = { "Enemy", "Enemy2", "Enemy3" };

    public static EnemySpawner instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentCount = count;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count < currentCount)
            timer += Time.deltaTime;
        else
            timer = 0;
        /*if (timer > spawntime && count < 4)////old spawner
        {
            count++;
            GameObject temp = objectPooling.instance.SpwanFrompool("Enemy", spawnPos[Random.Range(0, 4)].position, Quaternion.identity);
            timer = 0;
          }*/
        if (timer > 2 && count < currentCount)
        {
            count++;
            GameObject temp = NewPooler.Instance.GetPooledObject(names[Random.Range(0, 3)], spawnPos[Random.Range(0, 4)].position, Quaternion.identity);
            timer = 0;
        }
    }
}
