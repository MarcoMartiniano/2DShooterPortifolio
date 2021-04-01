using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{

    public float speed = 5.0f;

    
    // Mover pra direita
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
