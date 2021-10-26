using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPooling : MonoBehaviour
{
    #region Variables
    public static objectPooling instance;

    [Header("object Pooling Properties")]
    [Tooltip("Prefab that you want to pool")]
    public GameObject poolObject;

    public int totalObjects = 10;

    public bool canGrow = false;
    public int counter = 0;

    private List<GameObject> freeList = new List<GameObject>();
    private List<GameObject> usedList = new List<GameObject>();
    #endregion
    #region BuiltIn Methods
    private void Awake()
    {
        instance = this;


        for (int i = 0; i < totalObjects; i++)
        {
            GenerateObjects();
        }
    }
    #endregion
    #region Custom Methods
    void GenerateObjects()
    {
        GameObject obj = Instantiate(poolObject, transform);
        obj.SetActive(false);
        freeList.Add(obj);
    }
    public GameObject GetObject()
    {
        GameObject obj = null;
        counter = freeList.Count;
        if (counter > 0)
        {
            obj = freeList[counter - 1];
            freeList.Remove(obj);
            usedList.Add(obj);
        }
        return obj;
    }
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        usedList.Remove(obj);
        freeList.Add(obj);
    }
    #endregion
}