
using System.Collections;

using UnityEngine;


public class SpawnObjects : MonoBehaviour

{

    public GameObject ObjPoolingInimigos;
    public GameObject ObjPoolingAsteroidePequeno;
    public GameObject ObjPoolingAsteroideGrande;
    public GameObject ObjPoolingNuvem;

    public ObjectPoolInimigos objPoolingInimigos;
    public ObjectPoolAsteroidePequeno objPoolingAsteroidePequeno;
    public ObjectPoolAsteroideGrande objPoolingAsteroideGrande;
    public ObjectPoolNuvem objPoolNuvem;

    public static int numeroMaximoInimigos;
    public static int numeroMaximoMeteoroPequeno;
    public static int numeroMaximoMeteoroGrande;

    public static int numeroAtualInimigos;
    public static int numeroAtualMeteoroPequeno;
    public static int numeroAtualMeteoroGrande;

    int tamanho = 0;

    void Start()
    {
        VariaveisInicial();
    }

    public  void IniciarSpawn()
    {
        VariaveisInicial();
        PaisagemInicialSpawn();
        InimigosSpawnInicial();       
        StartCoroutine(SearchForTargetRepeat(1));
        StartCoroutine(SpawnNuvensCouroutine());            
    }

    IEnumerator SpawnNuvensCouroutine()
    {
        while (GameManagement.tipoEndGame == 0)
        {
            yield return new WaitForSeconds(2f);
            NuvensSpawn();
        }
    }

    IEnumerator SearchForTargetRepeat(int level)
    {

        switch (level)
        {
            case 1:            
                while (GameManagement.tipoEndGame == 0)
                {
                    tamanho += 1;

                    if (numeroAtualInimigos < numeroMaximoInimigos)
                    {
                       Spawn(0, 1, 0, 0);
                       Spawn(0, 1,  0, 0);
                    }

                    if (numeroAtualMeteoroPequeno < numeroMaximoMeteoroPequeno)
                    {  
                        Spawn(1, 0, 0, 0);
                        Spawn(1, 0, 0, 0);                   
                        Spawn(1, 0, 0, 0);
                        Spawn(1, 0, 0, 0);
                    }

                    if (numeroAtualMeteoroGrande < numeroMaximoMeteoroGrande)
                    {           
                        Spawn(2, 0, 0, 0);
                        Spawn(2, 0, 0, 0);
                        Spawn(2, 0, 0, 0);
                    }
                    yield return new WaitForSeconds(2);               
                }

                break;

            default:
                break;
        }
        SearchForTargetRepeat(1);
    }


    public void Spawn (int tipo, int inicial, float x , float y)
    {
        Vector3 vetorRandom = new Vector3(Random.Range(20, 23), Random.Range(-7, 7), 0);
        Vector3 vetorRandom2 = new Vector3(Random.Range(6, 9), Random.Range(-7, 7), 0);

        switch (tipo)
        {
            case 0:
                if(inicial == 0)
                {
                    GameObject inimigo = objPoolingInimigos.GetAvailableObject();
                    inimigo.transform.localPosition = vetorRandom2;
                    inimigo.GetComponent<MoveLeft>().speed = 5;
                    numeroAtualInimigos = numeroAtualInimigos + 1;
                }
                else
                {
                    GameObject inimigo = objPoolingInimigos.GetAvailableObject();
                    inimigo.transform.localPosition = vetorRandom;
                    inimigo.GetComponent<MoveLeft>().speed = 5;
                    numeroAtualInimigos = numeroAtualInimigos + 1;
                }

                break;
            case 1:
                GameObject meteoroPequeno = objPoolingAsteroidePequeno.GetAvailableObject(); 
                meteoroPequeno.transform.localPosition = vetorRandom;
                meteoroPequeno.GetComponent<MoveLeft>().speed = 10;
                numeroAtualMeteoroPequeno = numeroAtualMeteoroPequeno + 1;

                break;

            case 2:
               GameObject meteoroGrande =  objPoolingAsteroideGrande.GetAvailableObject();
                meteoroGrande.transform.localPosition = vetorRandom;
                meteoroGrande.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                meteoroGrande.GetComponent<Rigidbody2D>().angularVelocity = 0;
                float randomForca = Random.Range(350, 700);
                meteoroGrande.GetComponent<Rigidbody2D>().AddForce(Vector3.left * randomForca);
                meteoroGrande.GetComponent<Rigidbody2D>().AddTorque(100f);
                meteoroGrande.name = randomForca + "";
                numeroAtualMeteoroGrande = numeroAtualMeteoroGrande + 1;
                //Tirar ou nao tirar o MoveToPlayer
                int sorteio = Random.Range(0, 2);
                //se for 0 tira
                if(sorteio == 0)
                {
                    meteoroGrande.GetComponent<MoveToPlayer>().enabled = false;
                }
                break;

            case 3:
                if(inicial == 0)
                {
                    GameObject objetoNuvem =  objPoolNuvem.GetAvailableObject(inicial,x,y);
                    objetoNuvem.GetComponent<MoveLeft>().speed = 3;
                }
                else{
                    GameObject objetoNuvem = objPoolNuvem.GetAvailableObject(inicial,0,0);
                    objetoNuvem.GetComponent<MoveLeft>().speed = 3;
                }              
                break;

            default:
                break;
        }
    }


    public void PaisagemInicialSpawn()
    {
        //Nuvens
        Spawn(3, 0, -6,4);
        Spawn(3, 0, -5, -3.5f);
        Spawn(3, 0, -2, 8);
        Spawn(3, 0, 0, -8);
        Spawn(3, 0, 2, -4);
        Spawn(3, 0, 3.5f, 6);
        Spawn(3, 0, 1.5f, 3f);
        Spawn(3, 0, 7f, -3f);
        Spawn(3, 0, 9f, -7f);
        Spawn(3, 0, 9f, 4f);
        Spawn(3, 0, 12f, 7f);
        Spawn(3, 0, 12f, 0f);
        Spawn(3, 0, 11f, -6f);
        Spawn(3, 0, 15f, 5f);
        Spawn(3, 0, 14f, 3f);
        Spawn(3, 0, 16f, -6f);
        Spawn(3, 0, 18f, 6f);
        Spawn(3, 0, 19f, 0f);
        Spawn(3, 0, 20f, -4f);
   
    }

    public void NuvensSpawn()
    {
        float deslocamento = 25;
        //9 setores
        //setor1
        float x1 = Random.Range(-8, -3);
        float y1 = Random.Range(6, 10);
        //setor2
        float x2 = Random.Range(-8, -3);
        float y2 = Random.Range(-2, 2);
        //setor3
        float x3 = Random.Range(-8, -3);
        float y3 = Random.Range(-4, -8);
        //setor4
        float x4 = Random.Range(0, 1);
        float y4 = Random.Range(6, 10);
        //setor5
        float x5 = Random.Range(0, 1);
        float y5 = Random.Range(-1, 1);
        //setor6
        float x6 = Random.Range(0, 1);
        float y6 = Random.Range(-4, -8);
        //setor7
        float x7 = Random.Range(4, 8);
        float y7 = Random.Range(6, 10);
        //setor8
        float x8 = Random.Range(4, 8);
        float y8 = Random.Range(-1, 1);
        //setor9
        float x9 = Random.Range(4, 8);
        float y9 = Random.Range(-4, -8);


        Spawn(3, 0, x1 +deslocamento, y1);
        Spawn(3, 0, x2 + deslocamento, y2);
        Spawn(3, 0, x3 + deslocamento, y3);
        Spawn(3, 0, x4 + deslocamento, y4);
        Spawn(3, 0, x5 + deslocamento, y5);
        Spawn(3, 0, x6 + deslocamento, y6);
        Spawn(3, 0, x7 + deslocamento, y7);
        Spawn(3, 0, x8 + deslocamento, y8);
        Spawn(3, 0, x9 + deslocamento, y9);

    }

    public void VariaveisInicial()
    {
        ObjPoolingInimigos = GameObject.Find("ObjectPoolInimigos");
        objPoolingInimigos = ObjPoolingInimigos.GetComponent<ObjectPoolInimigos>();

        ObjPoolingAsteroidePequeno = GameObject.Find("ObjectPoolAsteroidePequeno");
        objPoolingAsteroidePequeno = ObjPoolingAsteroidePequeno.GetComponent<ObjectPoolAsteroidePequeno>();

        ObjPoolingAsteroideGrande = GameObject.Find("ObjectPoolAsteroideGrande");
        objPoolingAsteroideGrande = ObjPoolingAsteroideGrande.GetComponent<ObjectPoolAsteroideGrande>();

        ObjPoolingNuvem = GameObject.Find("ObjectPoolNuvem");
        objPoolNuvem = ObjPoolingNuvem.GetComponent<ObjectPoolNuvem>();
    }

    public void InimigosSpawnInicial()
    {
        Spawn(2, 0, 10, 0);
      //  Spawn(2, 0, 10, 5);
       // Spawn(1, 0, 6, 0);
        Spawn(1, 0, 7, 3);
       // Spawn(1, 0, 9, -6);
        Spawn(0, 0, 0, 0);
       // Spawn(0, 0, 0, 0);
        Spawn(0, 0, 0, 0);

    }

}
