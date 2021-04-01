using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float speed = 5.0f;
    public int lado = 1;
    private ObjectPoolTiroInimigos objectPoolTirosInimigos;
   


    // Start is called before the first frame update
    void Start()
    {  
            InvokeRepeating("Criartiro", 0, 2);
            objectPoolTirosInimigos = GameObject.Find("ObjectPoolTiroInimigos").GetComponent<ObjectPoolTiroInimigos>();
    }

    // Update is called once per frame
    void Update()
    {
     
     
    }


    private void Criartiro()
    {
        //não deixa criar tiro se tiver Pausado
        if (!GameManagement.isPause)
        {   
        Vector3 vetor = new Vector3(transform.position.x -1 , transform.position.y, transform.position.z);
        GameObject bullet = objectPoolTirosInimigos.GetAvailableObject();
        bullet.GetComponent<MoveLeft>().speed = 8;
        bullet.transform.position = vetor;
        bullet.SetActive(true);
        }

    }
}
