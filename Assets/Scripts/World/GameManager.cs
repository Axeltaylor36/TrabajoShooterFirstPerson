using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    [SerializeField] private TextMeshProUGUI TextAmmo;

    public int gunAmmo = 10;

    public int health = 100;

    public TextMeshProUGUI healthText;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        TextAmmo.text = gunAmmo.ToString();
        healthText.text = health.ToString();
    }

}
