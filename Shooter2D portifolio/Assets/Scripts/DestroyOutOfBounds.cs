using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 0f;
    private float lowerBound = 0f;
    private float leftBound = 0f;
    private float rightBound = 0f;

    public int metodotipo;
    // Start is called before the first frame update
    void Start()
    {

        switch (gameObject.tag)
        {
            case "Player":
                topBound = 7.1f;
                lowerBound = -7.1f;
                rightBound = 9.3f;
                leftBound = -9.3f;
                break;

            case "MeteoroPequeno":              
                topBound = 10.5f;
                lowerBound = -10.5f;
                rightBound = 27.0f;
                leftBound = -12.3f;

                break;
            case "MeteoroGrande":
                topBound = 10.5f;
                lowerBound = -10.5f;
                rightBound = 27.0f;
                leftBound = -12.3f;
                break;
            case "NaveInimiga1":
                topBound = 10.5f;
                lowerBound = -10.5f;
                leftBound = -12.3f;
                rightBound = 25.0f;
                break;
            case "TiroInimigo":
                topBound = 10.5f;
                lowerBound = -10.5f;
                rightBound = 27.0f;
                leftBound = -12.3f;
                break;


            case "TiroPlayer":
                topBound = 10.5f;
                lowerBound = -10.5f;
                rightBound = 12.3f;
                leftBound = -12.3f;
                break;


            default:
                break;
        }


    }

    // Update is called once per frame
    void Update()
    {
        MetodoOutOfBounds();

    }


    public void MetodoOutOfBounds ()
    {
        if (transform.position.y > topBound)
        {
      
            switch (gameObject.tag)
            {
                case "Player":
                    break;
                case "MeteoroPequeno":
                    SpawnObjects.numeroAtualMeteoroPequeno =- 1;
                    gameObject.SetActive(false);

                    break;
                case "MeteoroGrande":
                    SpawnObjects.numeroAtualMeteoroGrande =- 1;
                    gameObject.SetActive(false);

                    break;
                case "NaveInimiga1":
                    SpawnObjects.numeroAtualInimigos =- 1;
                    gameObject.SetActive(false);

                    break;

                case "TiroInimigo":
                    gameObject.SetActive(false);
                    break;

                case "TiroPlayer":
                    gameObject.SetActive(false);
                    break;


                default:
                    break;
            }
         
            
                
        }
        else if (transform.position.y < lowerBound)
        {
            switch (gameObject.tag)
            {
                case "Player":
                    break;
                case "MeteoroPequeno":
                    SpawnObjects.numeroAtualMeteoroPequeno = -1;
                    gameObject.SetActive(false);

                    break;
                case "MeteoroGrande":
                    SpawnObjects.numeroAtualMeteoroGrande = -1;
                    gameObject.SetActive(false);

                    break;
                case "NaveInimiga1":
                    SpawnObjects.numeroAtualInimigos = -1;
                    gameObject.SetActive(false);

                    break;

                case "TiroInimigo":
                    gameObject.SetActive(false);
                    break;

                case "TiroPlayer":
                    gameObject.SetActive(false);
                    break;


                default:
                    break;
            }



        }
        else if (transform.position.x < leftBound)
        {
  
            switch (gameObject.tag)
            {
                case "Player":
                    break;
                case "MeteoroPequeno":
                    SpawnObjects.numeroAtualMeteoroPequeno = -1;
                    gameObject.SetActive(false);
                    break;
                case "MeteoroGrande":
                    SpawnObjects.numeroAtualMeteoroGrande = -1;
                    gameObject.SetActive(false);
                    break;
                case "NaveInimiga1":
                    SpawnObjects.numeroAtualInimigos = -1;
                    gameObject.SetActive(false);
                    break;
                case "TiroInimigo":
                    gameObject.SetActive(false);
                    break;

                case "TiroPlayer":
                    gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }
        else if (transform.position.x > rightBound)
        {
            switch (gameObject.tag)
            {
                case "Player":
                    break;
                case "MeteoroPequeno":
                    SpawnObjects.numeroAtualMeteoroPequeno = -1;
                    gameObject.SetActive(false);
                    break;
                case "MeteoroGrande":
                    SpawnObjects.numeroAtualMeteoroGrande = -1;
                    gameObject.SetActive(false);
                    break;
                case "NaveInimiga1":
                    SpawnObjects.numeroAtualInimigos = -1;
                    gameObject.SetActive(false);
                    break;
                case "TiroInimigo":
                    gameObject.SetActive(false);
                    break;

                case "TiroPlayer":
                    gameObject.SetActive(false);
                    break;
                default:
                    break;
            }



        }

    }


}
