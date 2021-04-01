using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    private GameObject Player;
    public float speed = 1.0f;
    Vector3 vetorDirecaoPlayer;

    //CLASSE PARA O OBJETO IR EM DIREÇÃO AO PLAYER
   
    void Start()
    {
        Player = GameObject.Find("Player");
        //Pegando a direcao do Player na criacao do objeto
       vetorDirecaoPlayer = (Player.transform.position - transform.position).normalized;
        
    }

    // Update is called once per frame
    void Update()
    {     
        transform.Translate(vetorDirecaoPlayer * Time.deltaTime * speed);
    }




}
