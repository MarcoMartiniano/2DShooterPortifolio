
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolInimigos : MonoBehaviour
{
    [SerializeField] private GameObject prefabObjectInimigos;
    [SerializeField] private int poolSizeInimigos;

    public GameObject objPoolingInimigos;
    private bool canGrown = true;


    private readonly List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSizeInimigos; i++)
        {
            GameObject pooledObject = Instantiate(prefabObjectInimigos);
            pooledObject.transform.SetParent(objPoolingInimigos.transform, false);
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
            GameObject pooledObject = Instantiate(prefabObjectInimigos);
            pooledObject.transform.SetParent(objPoolingInimigos.transform, false);
            pooledObject.SetActive(true);
            pool.Add(pooledObject);
            return pooledObject;
        }
        return null;
    }
}
