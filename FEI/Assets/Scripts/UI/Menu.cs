using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void jogar()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;//caso o jogo esteja pausado
    }

    public void sair()
    {
        Application.Quit();
    }
}