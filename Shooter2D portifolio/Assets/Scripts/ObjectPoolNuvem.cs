using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolNuvem : MonoBehaviour
{
    [SerializeField] private GameObject prefabObjectNuvem;
    [SerializeField] private int poolSizeNuvem;

    public GameObject objPoolingNuvem;
    private bool canGrown = true;


    private readonly List<GameObject> pool = new List<GameObject>();


    void Start()
    {
        for (int i = 0; i < poolSizeNuvem; i++)
        {
            GameObject pooledObject = Instantiate(prefabObjectNuvem);
            pooledObject.transform.SetParent(objPoolingNuvem.transform, false);
            pooledObject.SetActive(false);
            pool.Add(pooledObject);
        }
    }


    public GameObject GetAvailableObject(int inicial, float valorx,float valory)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                if(inicial == 0)
                {
                    pool[i].SetActive(true);
                    pool[i].transform.localPosition = new Vector3(valorx, valory, 0f);
                    return pool[i];

                }
                else
                {
                    float y = Random.Range(-8.0f, 8.0f);
                    Vector3 vetor = new Vector3(8f, y, 0f);
                    Debug.Log("GetAvailableObject:" + pool[i].name);
                    pool[i].SetActive(true);
                    pool[i].transform.localPosition = new Vector3(-6.0f, y, 0f);
                    return pool[i];

                }
               
            }
        }

        if (canGrown == true)
        {
            GameObject pooledObject = Instantiate(prefabObjectNuvem);
            pooledObject.transform.SetParent(objPoolingNuvem.transform, false);
            pooledObject.SetActive(false);
            pool.Add(pooledObject);
            return pooledObject;
        }
        return null;
    }
}
