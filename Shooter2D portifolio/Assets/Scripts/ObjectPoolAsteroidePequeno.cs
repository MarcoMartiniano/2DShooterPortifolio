using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolAsteroidePequeno : MonoBehaviour
{

    [SerializeField] private GameObject prefabObjectAsteroidePequeno;
    [SerializeField] private int poolSizeTirosAsteroidePequeno;
    public GameObject objPoolingAsteroidePequens;
    private bool canGrown = true;

    private readonly List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSizeTirosAsteroidePequeno; i++)
        {
            GameObject pooledObject = Instantiate(prefabObjectAsteroidePequeno);
            pooledObject.transform.SetParent(objPoolingAsteroidePequens.transform, false);
            pooledObject.SetActive(false);
            pool.Add(pooledObject);
        }
    }



    public GameObject GetAvailableObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        if (canGrown == true)
        {
            GameObject pooledObject = Instantiate(prefabObjectAsteroidePequeno);
            pooledObject.transform.SetParent(objPoolingAsteroidePequens.transform, false);
            pooledObject.SetActive(true);
            pool.Add(pooledObject);
            return pooledObject;
        }
        return null;
    }
}
