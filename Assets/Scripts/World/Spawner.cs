using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject enemigoCaminantePrefab;

    //[SerializeField] private GameObject enemigoVoladorPrefab;

    [SerializeField] private Transform[] puntosSpawn;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Spawnear());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawnear()
    {
        while (true) 
        {
        
        Instantiate(enemigoCaminantePrefab, puntosSpawn[Random.Range(0,puntosSpawn.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(5);

        }
    }
}
