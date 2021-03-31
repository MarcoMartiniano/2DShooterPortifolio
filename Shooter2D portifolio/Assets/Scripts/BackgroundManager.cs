using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatPosition;
    private float tamanhoObjetoPlayer;
   
    // Start is called before the first frame update
    void Start()
    {
       // tamanhoObjetoPlayer = GameObject.Find("Player").GetComponent<BoxCollider2D>().size.x;
         startPosition = transform.position;
        repeatPosition = GetComponent<BoxCollider2D>().size.x/2 ;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.position.x < startPosition.x - repeatPosition)
        {
            transform.position = startPosition;
        }
    }



}
