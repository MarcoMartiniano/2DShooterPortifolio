using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speedHorizontal = 4.0f;
    public float speedVertical = 6.0f;
    private float leftboundary = -9.3f;
    private float rightboundary = 9.3f;
    private float upboundary = 7.1f;
    private float downboundary = -7.1f;
    private AudioSource audioSource;
    public AudioClip audioTiro;

    private Boolean cooldownTiro = false;

    private ObjectPoolTiros objectPoolTiros;


    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        objectPoolTiros = GetComponent<ObjectPoolTiros>();
        Debug.Log("Posicao inicial player  "+ gameObject.transform.position);
        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftboundary)
        {
            transform.position = new Vector3(leftboundary, transform.position.y, transform.position.z);

        }
        if (transform.position.x > rightboundary)
        {
            transform.position = new Vector3(rightboundary, transform.position.y, transform.position.z);

        }

        if (transform.position.y < downboundary)
        {
            transform.position = new Vector3(transform.position.x, downboundary, transform.position.z);

        }

        if (transform.position.y > upboundary)
        {
            transform.position = new Vector3(transform.position.x, upboundary, transform.position.z);

        }



        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speedHorizontal);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speedVertical);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Espaco");
            if (!cooldownTiro && !GameManagement.isPause)
            {
                Debug.Log("Espaco  Cooldonw");
                Vector3 vetor = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                GameObject bullet = objectPoolTiros.GetAvailableObject();
                bullet.GetComponent<MoveRight>().speed = 5;
                bullet.transform.position = vetor;
                bullet.SetActive(true);      
                cooldownTiro = true;
                StartCoroutine(CooldownTiroJogador());

                //Audio tiro
                audioSource.PlayOneShot(audioTiro);
            }
            
          
        }


    }

    IEnumerator CooldownTiroJogador()
    {
        yield return new WaitForSeconds(0.4f);
        cooldownTiro = false;
    }

}
