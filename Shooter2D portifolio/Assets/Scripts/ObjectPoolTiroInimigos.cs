using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTiroInimigos : MonoBehaviour
{
    [SerializeField] private GameObject prefabObjectTirosInimigos;
    [SerializeField] private int poolSizeTirosInimigos;
    public GameObject objPoolingTirosInimigos;
    private bool canGrown = true;

    private readonly List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSizeTirosInimigos; i++)
        {
            GameObject pooledObject = Instantiate(prefabObjectTirosInimigos);
            pooledObject.transform.SetParent(objPoolingTirosInimigos.transform, false);
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
                return pool[i];
            }
        }

        if (canGrown == true)
        {
            GameObject pooledObject = Instantiate(prefabObjectTirosInimigos);
            pooledObject.transform.SetParent(objPoolingTirosInimigos.transform, false);
            pooledObject.SetActive(false);
            pool.Add(pooledObject);
            return pooledObject;
        }
        return null;
    }
}
