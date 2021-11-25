using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class pool
{
    public string poolName;
    public int poolSize;
    public GameObject poolPrefab;
}

public class objectPooling : MonoBehaviour
{
    public List<pool> poolObjects = new List<pool>();
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public static objectPooling instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (pool item in poolObjects)
        {
            Queue<GameObject> objectinQPool = new Queue<GameObject>();
            for (int i = 0; i < item.poolSize; i++)
            {
                GameObject temp = Instantiate(item.poolPrefab);
                temp.SetActive(false);
                temp.transform.parent = this.transform;
                objectinQPool.Enqueue(temp);
            }
            poolDictionary.Add(item.poolName, objectinQPool);
        }
    }

    public GameObject SpwanFrompool(string poolName, Vector3 position, Quaternion rotation)
    {
        GameObject temp = poolDictionary[poolName].Dequeue();
        temp.SetActive(true);
        temp.transform.position = position;
        temp.transform.rotation = rotation;
        poolDictionary[poolName].Enqueue(temp);
        return temp;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
