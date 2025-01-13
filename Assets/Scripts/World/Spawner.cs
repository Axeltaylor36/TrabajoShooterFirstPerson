using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] enemiesToSpawn;

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
            float probability = Random.value; //un float de 0 a 1.
            if(probability > 0.75f) //25%
            {
                Instantiate(enemiesToSpawn[1], puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemiesToSpawn[0], puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
            }
            yield return new WaitForSeconds(5);

        }
    }
}
