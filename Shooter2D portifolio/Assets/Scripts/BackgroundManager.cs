using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatPosition;
   
    void Start()
    {
        startPosition = transform.position;
        repeatPosition = GetComponent<BoxCollider2D>().size.x/2 ;
    }
    void Update()
    {
        if (transform.position.x < startPosition.x - repeatPosition)
        {
            transform.position = startPosition;
        }
    }
}
