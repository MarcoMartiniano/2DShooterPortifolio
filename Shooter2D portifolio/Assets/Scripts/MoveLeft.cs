using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 5.0f;


    //   // Mover pra esquerda
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
