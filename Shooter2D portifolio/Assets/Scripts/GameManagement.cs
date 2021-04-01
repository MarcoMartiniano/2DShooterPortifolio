using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public static int vidas;
    public static int pontuacao;
    public static int tipoEndGame;
    public TextMeshProUGUI txtScore;
    public GameObject coracaoPrefab;
    public static List<GameObject> ListaCoracao;
    public GameObject coracaoGrupo;
    public GameObject panelEndGame;
    public GameObject panelStartGame;
    public GameObject panelFundo;
    public GameObject objectPool;

    public GameObject gameObjectFundo;
    public GameObject gameObjectNuvens;
    public GameObject gameObjectPlayer;
    public GameObject gameObjectInimigo;
    public GameObject gameObjectMeteoroPequeno;
    public GameObject gameObjectMeteoroGrande;
    public GameObject gameObjectTiroPlayer;
    public GameObject gameObjectTiroinimigo;
    public GameObject gameObjectGameManager;
    public GameObject gameObjectSpawnManager;

    public GameObject botaoPausar;
    public List<Sprite> listaBotaoPausar;

    List<int> indexInimigos;
    List<int> indexNuvens;
    List<int> indexMeteoroPequeno;
    List<int> indexMeteoroGrande;
    List<int> indexTiroPlayer;
    List<int> indexTiroinimigo;

    public static Boolean isPause;

    public GameObject txtPontuacaoFinal;

    public AudioClip audioExplosao;
    private AudioSource audioSource;

    private bool controladorBotaoPausarContinuar;
    private bool controladorBotaoPausarAuxiliar;

    string score;
    void Start()
    {
        //iniciando variaveis
        InicializacaoVariaveis();
    }

   
    void Update()
    {
        //Atualizar score
        score = "Score: " + pontuacao;
        txtScore.text = score;

    }


    //Gerar os coracoes
    public void gerarCoracao()
    {
        Vector3 vetor1 = new Vector3(-320, -240, 0);
        Vector3 vetor2 = new Vector3(-260, -240, 0);
        Vector3 vetor3 = new Vector3(-200, -240, 0);
        GameObject coracaoobj1 = Instantiate(coracaoPrefab, vetor1, coracaoPrefab.transform.rotation);
        coracaoobj1.transform.SetParent(coracaoGrupo.transform, false);
        GameObject coracaoobj2 = Instantiate(coracaoPrefab, vetor2, coracaoPrefab.transform.rotation);
        coracaoobj2.transform.SetParent(coracaoGrupo.transform, false);
        GameObject coracaoobj3 = Instantiate(coracaoPrefab, vetor3, coracaoPrefab.transform.rotation);
        coracaoobj3.transform.SetParent(coracaoGrupo.transform, false);
        ListaCoracao.Add(coracaoobj1);
        ListaCoracao.Add(coracaoobj2);
        ListaCoracao.Add(coracaoobj3);
    }


    
  public void abriPanelStartGame()
    {
        panelStartGame.SetActive(true);
    }

    public void fecharPanelStartGame()
    {
        panelStartGame.SetActive(false);
    }

    public void abriPanelEndGame()
    {
        panelEndGame.SetActive(true);
    }

    public void fecharPanelEndGame()
    {
        panelEndGame.SetActive(false);
    }

    public void InicializacaoVariaveis()
    {
        score = "Score: " + pontuacao;
        txtScore.text = score;
        vidas = 3;
        pontuacao = 0;
        tipoEndGame = 0;
        ListaCoracao = new List<GameObject>();
        abriPanelStartGame();
        indexInimigos = new List<int>();
        indexNuvens = new List<int>();
        indexMeteoroPequeno = new List<int>();
        indexMeteoroGrande = new List<int>();
        indexTiroPlayer = new List<int>();
        indexTiroinimigo = new List<int>();
        isPause = true;
        fecharPanelEndGame();
        audioSource = GetComponent<AudioSource>();
        controladorBotaoPausarContinuar = true;
        controladorBotaoPausarAuxiliar = true;

    }


    public static void DestruirTodosObjetosLista(List<GameObject> lista)
    {
        int tamanho = lista.Count;
        for(int i=0; i <tamanho; i++)
        {
            DestroyObject(lista[0]);
            lista.RemoveAt(0);
        }


    }

    //Voltar Menu
    public void VoltarMenuInicial()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }


    public void BotaoPausarContinuar()
    {

        if (controladorBotaoPausarContinuar == true)
        {
            PausarJogo();
            botaoPausar.GetComponent<Image>().sprite = listaBotaoPausar[1];
            controladorBotaoPausarAuxiliar = true;
        }
        else
        {
            botaoPausar.GetComponent<Image>().sprite = listaBotaoPausar[0];
            DespausarJogo();
            controladorBotaoPausarAuxiliar = false;

        }

        //Pausar
        if (controladorBotaoPausarAuxiliar == true)
        {
            controladorBotaoPausarContinuar = false;

        }else if (controladorBotaoPausarAuxiliar == false)
        {
            controladorBotaoPausarContinuar = true;

        }
        
    }


    public void PausarJogo()
    {
        //Metodos Spawn Nuvens, Spawn Inimigos
        gameObjectSpawnManager.GetComponent<SpawnObjects>().StopAllCoroutines();
        isPause = true;
        //Pausar fundo
        gameObjectFundo.GetComponent<MoveLeft>().speed = 0;

        //player
        gameObjectPlayer.GetComponent<PlayerController>().speedVertical = 0;
        gameObjectPlayer.GetComponent<PlayerController>().speedHorizontal = 0;

        //Nuvens
        PausarTodosObjetosAtivos(gameObjectNuvens, 0);

        //Inimigos
        PausarTodosObjetosAtivos(gameObjectInimigo, 1);

        //Meteoros
        PausarTodosObjetosAtivos(gameObjectMeteoroPequeno, 2);
        PausarTodosObjetosAtivos(gameObjectMeteoroGrande, 3);

        //TirosPlayer
        PausarTodosObjetosAtivos(gameObjectTiroPlayer, 4);

        //TirosInimigos
        PausarTodosObjetosAtivos(gameObjectTiroinimigo, 5);

    }
    public void DespausarJogo()
    {
        //Metodos Spawn Nuvens, Spawn Inimigos
        gameObjectSpawnManager.GetComponent<SpawnObjects>().StartCoroutine("SearchForTargetRepeat",1);
        gameObjectSpawnManager.GetComponent<SpawnObjects>().StartCoroutine("SpawnNuvensCouroutine");
        isPause = false;
        //DesPausar fundo
        gameObjectFundo.GetComponent<MoveLeft>().speed = 3;
        
        //Nuvens
        DespausarTodosObjetosAtivos(gameObjectNuvens, 0);
        //Inimigos
        DespausarTodosObjetosAtivos(gameObjectInimigo, 1);

        //player
        gameObjectPlayer.GetComponent<PlayerController>().speedVertical = 6;
        gameObjectPlayer.GetComponent<PlayerController>().speedHorizontal = 4;

        //Meteoros
        DespausarTodosObjetosAtivos(gameObjectMeteoroPequeno, 2);
        DespausarTodosObjetosAtivos(gameObjectMeteoroGrande, 3);

        //TirosPlayer
        DespausarTodosObjetosAtivos(gameObjectTiroPlayer, 4);

        //TirosInimigos
        DespausarTodosObjetosAtivos(gameObjectTiroinimigo, 5);

    }

    public void PausarTodosObjetosAtivos(GameObject objPool, int tipo)
    {
        int tamanho = objPool.transform.childCount;
        Debug.Log("Tamanho objPool  " + tamanho + "  " + objPool.name);

        if(tamanho > 0)
        {

  
        switch (tipo)
                {
                 //Nuvens
                 case 0:
                for (int i = 0; i < tamanho; i++)
                {
                    if (objPool.transform.GetChild(i).gameObject.activeInHierarchy == true)
                    {
                        objPool.transform.GetChild(i).GetComponent<MoveLeft>().speed = 0;
                        indexNuvens.Add(i);                          
                        }

                    }
                break;


                    //Inimigos
                 case 1:
                for (int i = 0; i < tamanho; i++)
                {
                    if (objPool.transform.GetChild(i).gameObject.activeInHierarchy == true)
                    {
                        objPool.transform.GetChild(i).GetComponent<MoveLeft>().speed = 0;
                  indexInimigos.Add(i);
                          
                        }
                }
                break;

                    //MeteoroPequeno
                    case 2:
                for (int i = 0; i < tamanho; i++)
                {
                    if (objPool.transform.GetChild(i).gameObject.activeInHierarchy == true)
                    {
                        objPool.transform.GetChild(i).GetComponent<MoveLeft>().speed = 0;
                        indexMeteoroPequeno.Add(i);
                    }
                }
                break;

                    //MeteoroGrande
                    case 3:
                for (int i = 0; i < tamanho; i++)
                {
                    if (objPool.transform.GetChild(i).gameObject.activeInHierarchy == true)
                    {
                        objPool.transform.GetChild(i).GetComponent<MoveLeft>().speed = 0;
                         objPool.transform.GetChild(i).GetComponent<MoveToPlayer>().speed = 0;
                          objPool.transform.GetChild(i).GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                          objPool.transform.GetChild(i).GetComponent<Rigidbody2D>().angularVelocity = 0;
                            
                            indexMeteoroGrande.Add(i);
                            Debug.Log("Adicionado ao indexMeteoroGrande  " + indexMeteoroGrande + "  Tamanho indexMeteoroGrande: " + indexMeteoroGrande.Count);
                        }
                }
                break;

                    //TirosPlayer
                    case 4:
                for (int i = 0; i < tamanho; i++)
                {
                    if (objPool.transform.GetChild(i).gameObject.activeInHierarchy == true)
                    {
                        objPool.transform.GetChild(i).GetComponent<MoveRight>().speed = 0;
                        indexTiroPlayer.Add(i);
                    }
                }
                break;

                    //TirosInimigos
                    case 5:
                    for (int i = 0; i < tamanho; i++)
                    {
                    if (objPool.transform.GetChild(i).gameObject.activeInHierarchy == true)
                    {
                        objPool.transform.GetChild(i).GetComponent<MoveLeft>().speed = 0;
                            objPool.transform.GetChild(i).GetComponent<MoveToPlayer>().speed = 0;
                            indexTiroinimigo.Add(i);
                    }
                    }
                        break;
                default:
                 break;
             }

        }
    }

    public void DespausarTodosObjetosAtivos(GameObject objPool, int tipo)
    {
        int tamanho = objPool.transform.childCount;

        if(tamanho > 0)
        {
               switch (tipo)
                {
                    //Nuvens
                    case 0:
                        for(int i2=0; i2 < indexNuvens.Count; i2++)
                        {
                         
                            int index = indexNuvens[i2];
                            objPool.transform.GetChild(index).GetComponent<MoveLeft>().speed = 3;
                        }
                        indexNuvens.Clear();
                      
                        break;

                    //Inimigos
                    case 1:
                        for (int i2 = 0; i2 < indexInimigos.Count; i2++)
                        {
                            int index = indexInimigos[i2];
                            objPool.transform.GetChild(index).GetComponent<MoveLeft>().speed = 5;

                        }
                        indexInimigos.Clear();
                   
        
                        break;

                    //MeteoroPequeno
                    case 2:
                        for (int i2 = 0; i2 < indexMeteoroPequeno.Count; i2++)
                        {
                            int index = indexMeteoroPequeno[i2];
                            objPool.transform.GetChild(index).GetComponent<MoveLeft>().speed = 10;
                        }
              
                        indexMeteoroPequeno.Clear();
                        break;

                    //MeteoroGrande
                    case 3:
                        for (int i2 = 0; i2 < indexMeteoroGrande.Count; i2++)
                        {
                        int index = indexMeteoroGrande[i2];
                        float randomForca = float.Parse(objPool.transform.GetChild(index).name.ToString()); 
                        objPool.transform.GetChild(index).GetComponent<Rigidbody2D>().AddForce(Vector3.left * randomForca);
                        objPool.transform.GetChild(index).GetComponent<Rigidbody2D>().AddTorque(100f);                                         
                        }
                        indexMeteoroGrande.Clear();
                        break;

                    //TirosPlayer
                    case 4:
                        for (int i2 = 0; i2 < indexTiroPlayer.Count; i2++)
                        {
                            int index = indexTiroPlayer[i2];
                            objPool.transform.GetChild(index).GetComponent<MoveRight>().speed = 5;
                        }
                        indexTiroPlayer.Clear();
                        break;

                    //TirosInimigos
                    case 5:
                        for (int i2 = 0; i2 < indexTiroinimigo.Count; i2++)
                        {
                            int index = indexTiroinimigo[i2];
                            objPool.transform.GetChild(index).GetComponent<MoveLeft>().speed = 8;
                            objPool.transform.GetChild(index).GetComponent<MoveToPlayer>().speed = 1;
                        }
                        indexTiroinimigo.Clear();
                        break;

                    default:
                        break;
                }

            }
                  
                
    }

    public void DificuldadeFacil()
    {
        InicializacaoVariaveis();    
        VariaveisMaximoDificuldade(3, 6, 3);
        //despausando
        DespausarJogo();
        //fechando panel
        fecharPanelStartGame();
        gerarCoracao();
        //Respawn Inicial
        gameObjectSpawnManager.GetComponent<SpawnObjects>().IniciarSpawn();

    }

    public void DificuldadeMedio()
    {
        InicializacaoVariaveis();
        VariaveisMaximoDificuldade(6, 10, 6);
        //despausando
        DespausarJogo();
        //fechando panel
        fecharPanelStartGame();
        gerarCoracao();
        //Respawn Inicial
        gameObjectSpawnManager.GetComponent<SpawnObjects>().IniciarSpawn();

    }
    public void DificuldadeDificil()
    {
        InicializacaoVariaveis();
        VariaveisMaximoDificuldade(8,15,9);
        //despausando
        DespausarJogo();
        //fechando panel
        fecharPanelStartGame();
        gerarCoracao();
        //Respawn Inicial
        gameObjectSpawnManager.GetComponent<SpawnObjects>().IniciarSpawn();

    }


    private void VariaveisMaximoDificuldade(int naves, int metpeq, int metgrande)
    {
        SpawnObjects.numeroMaximoInimigos = naves;
        SpawnObjects.numeroMaximoMeteoroPequeno = metpeq;
        SpawnObjects.numeroMaximoMeteoroGrande = metgrande;

        SpawnObjects.numeroAtualInimigos = 0;
        SpawnObjects.numeroAtualMeteoroPequeno = 0;
        SpawnObjects.numeroAtualMeteoroGrande = 0;
    }

    public void MetodoSetarScoreFinal()
    {
        String score = txtScore.GetComponent<TextMeshProUGUI>().text;
        txtPontuacaoFinal.GetComponent<TextMeshProUGUI>().text = pontuacao+"";
    }



    public void ReiniciarJogo()
    {
        SceneManager.LoadScene("SceneJogo", LoadSceneMode.Single);
    }


    //Audio Tiro
    public void AudioExplosao()
    {                 
        audioSource.PlayOneShot(audioExplosao);
    }

}
