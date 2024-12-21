using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextAmmo;

    public static GameManager Instance {  get; private set; }

    public int gunAmmo = 10;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        TextAmmo.text = gunAmmo.ToString();
    }

}
