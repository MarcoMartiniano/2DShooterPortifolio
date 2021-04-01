using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //Chamar Cena do jogo
    public void NovoJogo()
    {
        SceneManager.LoadScene("SceneJogo", LoadSceneMode.Single);
    }

    //Fechar o Jogo
    public void SairJogo()
    {
        Application.Quit();
    }

}
