using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolAsteroideGrande : MonoBehaviour
{
    [SerializeField] private GameObject prefabObjectAsteroideGrande;
    [SerializeField] private int poolSizeTirosAsteroideGrande;
    public GameObject objPoolingAsteroideGrande;
    private bool canGrown = true;
   


    private readonly List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSizeTirosAsteroideGrande; i++)
        {
            GameObject pooledObject = Instantiate(prefabObjectAsteroideGrande);
            pooledObject.transform.SetParent(objPoolingAsteroideGrande.transform, false);
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
            GameObject pooledObject = Instantiate(prefabObjectAsteroideGrande);
            pooledObject.transform.SetParent(objPoolingAsteroideGrande.transform, false);
            pooledObject.SetActive(true);
            pool.Add(pooledObject);
            return pooledObject;
        }
        return null;
    }
}
