using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{



    public void NovoJogo()
    {
        SceneManager.LoadScene("SceneJogo", LoadSceneMode.Single);
    }


    public void SairJogo()
    {

        Application.Quit();

    }




}
