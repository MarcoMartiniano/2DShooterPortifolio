using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTiros : MonoBehaviour
{
    [SerializeField] private GameObject prefabObject;
    [SerializeField] private int poolSize;
    public GameObject objPoolingTirosPlayer;
    private Boolean canGrown = true;

    private readonly List<GameObject> pool = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject pooledObject = Instantiate(prefabObject);
            pooledObject.transform.SetParent(objPoolingTirosPlayer.transform, false);
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
                Debug.Log("GetAvailableObject TIROOOOO" + pool[i].name);
                return pool[i];
            }    
        }
        if (canGrown == true)
        {
            GameObject pooledObject = Instantiate(prefabObject);
            pooledObject.transform.SetParent(objPoolingTirosPlayer.transform, false);
            pooledObject.SetActive(false);
            pool.Add(pooledObject);
            return pooledObject;
        }
        return null;
    }
}
