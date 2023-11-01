using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    private string gameLevel;
    [SerializeField]
    private GameObject pMenu;
    [SerializeField]
    private GameObject pCreditos;
    public void Jogar()
    {
        SceneManager.LoadScene(gameLevel);  
    }

    public void Creditos()
    {
        pMenu.SetActive(false);
        pCreditos.SetActive(true);
    }
    public void FecharCreditos()
    {
        pCreditos.SetActive(false);
        pMenu.SetActive(true);
    } 

    public void Sair()
    {
        Debug.Log("Você saiu do jogo");
        Application.Quit();
    }

}
