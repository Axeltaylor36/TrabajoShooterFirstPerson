using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    [SerializeField] private TextMeshProUGUI TextAmmo;

    public int gunAmmo = 10;

    [SerializeField] private float health = 100;

    public TextMeshProUGUI healthText;

    public event EventHandler MuerteJugador;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        TextAmmo.text = gunAmmo.ToString();
        healthText.text = health.ToString();
    }
    public void LoseHealth(float healthToReduce) //Cuando llamemos a este método al script PlayerInteracions
    {
        health -= healthToReduce; //que es los mismo que health = health - healthToReduce
        CheckHealth();
    }

    public void CheckHealth()
    {

        if (health <= 0)
        {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Debug.Log("Has muerto");

            //Cuando muramos reiniciamos el nivel. Entonces accedemos de neuvo a la escena que tenemos acticamente.
            //¿Que es el buildIndex? Cuando le damos al build settigs aparece un numero en el numero de escenas que tengamos activas, y nos señala que escena tenemos activa
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
