using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
  
    private GameObject objetoGameManager;
    private GameManagement gameManagement;

    void Start()
    {
        objetoGameManager = GameObject.Find("EventSystemGameManager");
        gameManagement = objetoGameManager.GetComponent<GameManagement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        string colTag = collision.tag;
        int playerLife = GameManagement.tipoEndGame;
        

        switch (colTag)
        {
           
            case "Player":

                switch (gameObject.tag)
                {
                    case "NaveInimiga1":
                        int tamanho = GameManagement.ListaCoracao.Count;
                        if (tamanho > 0)
                        {
                            gameManagement.AudioExplosao();
                            gameObject.SetActive(false);
                            TirarVida();
                           
                        }
                        else if (tamanho == 0)
                        {
                            gameManagement.AudioExplosao();
                            gameObject.SetActive(false);
                            gameManagement.abriPanelEndGame();
                            gameManagement.PausarJogo();
                            gameManagement.MetodoSetarScoreFinal();
                            collision.gameObject.SetActive(false);
                         
                        }

                        break;

                    case "MeteoroPequeno":
                        int tamanho2 = GameManagement.ListaCoracao.Count;
                        if (tamanho2 > 0)
                        {
                            TirarVida();
                            gameObject.SetActive(false);
                            gameManagement.AudioExplosao();

                        }
                        else if (tamanho2 == 0)
                        {
                            gameManagement.AudioExplosao();
                            gameObject.SetActive(false);
                            collision.gameObject.SetActive(false);
                            gameManagement.abriPanelEndGame();
                            gameManagement.PausarJogo();
                            gameManagement.MetodoSetarScoreFinal();
                        }



                        break;

                    case "MeteoroGrande":
                        gameManagement.AudioExplosao();
                        TirarVida();
                        //PanelEndGame.SetActive(true);
                        gameManagement.abriPanelEndGame();
                        gameManagement.PausarJogo();
                        gameManagement.MetodoSetarScoreFinal();
                        gameObject.SetActive(false);
                        collision.gameObject.SetActive(false);                   
                        //Destruindo coracoes
                        GameManagement.DestruirTodosObjetosLista(GameManagement.ListaCoracao);
                        break;

                    case "TiroInimigo":
                        gameManagement.AudioExplosao();
                        int tamanho3 = GameManagement.ListaCoracao.Count;
                        if (tamanho3 > 0)
                        {
                            TirarVida();
                            gameObject.SetActive(false);
                        }
                        else if (tamanho3 == 0)
                        {
                          
                            gameObject.SetActive(false);
                            collision.gameObject.SetActive(false);
                            gameManagement.abriPanelEndGame();
                            gameManagement.PausarJogo();
                            gameManagement.MetodoSetarScoreFinal();

                        }
                        break;

                    default:
                        break;
                }
            
                break;


            case "NaveInimiga1":
                
                if (gameObject.tag.Equals("Player"))
                {                  
                }
                else if (gameObject.tag.Equals("NaveInimiga1"))
                {
                }
                else if (gameObject.tag.Equals("TiroPlayer")) 
                {
                    Debug.Log("gameObject: " + gameObject.tag); //Player
                    Debug.Log("collision.gameObject: " + collision.gameObject.tag); // naveinimigo
                    GameManagement.pontuacao += 10;
                    collision.gameObject.GetComponent<Atirar>().CancelInvoke();
                    gameObject.SetActive(false);
                    collision.gameObject.SetActive(false);
                    gameManagement.AudioExplosao();
                }
                else
                {
                }                            
                break;

            case "MeteoroPequeno":
                if (gameObject.tag.Equals("Player"))
                {
                    SpawnObjects.numeroAtualMeteoroPequeno = -1;
                }
                else if (gameObject.tag.Equals("NaveInimiga1"))
                {                              

                }
                else if(gameObject.tag.Equals("MeteoroGrande"))

                {
                }
                else if (gameObject.tag.Equals("TiroPlayer"))
                {
                    SpawnObjects.numeroAtualMeteoroPequeno = -1;
                    GameManagement.pontuacao += 3;
                    gameObject.SetActive(false);
                    collision.gameObject.SetActive(false);
                    gameManagement.AudioExplosao();

                }
                break;

            case "MeteoroGrande":
                if (gameObject.tag.Equals("Player"))
                {
                    SpawnObjects.numeroAtualMeteoroGrande = -1;
                }
                else if (gameObject.tag.Equals("NaveInimiga1"))
                {
                }
                else if (gameObject.tag.Equals("TiroPlayer"))
                {
                    SpawnObjects.numeroAtualMeteoroGrande = -1;
                    GameManagement.pontuacao += 6;
                    gameObject.SetActive(false);
                    collision.gameObject.SetActive(false);
                    gameManagement.AudioExplosao();
                }
      
                break;

            default:
                break;
        }
    }


 

    public void TirarVida()
    {
        int tamanho = GameManagement.ListaCoracao.Count;
        if (tamanho >= 1)
        {
            DestroyObject(GameManagement.ListaCoracao[tamanho - 1]);
            GameManagement.ListaCoracao.RemoveAt(tamanho - 1);         
        }
        else if (tamanho <= 0)
        {
            
        }
    }
}
