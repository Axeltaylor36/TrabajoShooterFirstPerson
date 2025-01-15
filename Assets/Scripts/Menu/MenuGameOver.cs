using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Xml.Serialization;


public class MenuGameOver : MonoBehaviour
{

    [SerializeField] private GameObject menuFinPartida;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.MuerteJugador += ActivarMenu;

    }

    private void ActivarMenu(object sender, EventArgs e) 
    { 
    
        menuFinPartida.SetActive(true);
    
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(string nombre) 
    {
    SceneManager.LoadScene(nombre);
    
    }

    public void Salir()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
