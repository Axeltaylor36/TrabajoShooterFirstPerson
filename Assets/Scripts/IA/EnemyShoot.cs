using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject enemyBullet;

    public Transform spawnBulletPoint;

    private Transform playerPosition;

    public float bulletVelocity = 1000f;


    void Start()
    {
        playerPosition = FindObjectOfType<PlayerMovement>().transform;

        Invoke("ShootPlayer", 2); //Invoca al metodo seleccionado en x tiempo
    }

    void Update()
    {
        
    }

    void ShootPlayer()
    {

       Vector3 playerDirection = playerPosition.position - transform.position;

        GameObject newBullet;

        newBullet = Instantiate(enemyBullet,spawnBulletPoint.position,spawnBulletPoint.rotation);

        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity,ForceMode.Force);

        Invoke("ShootPlayer", 2); //Invocamos de nuevo al metodo asi creando un bucle
    }


}
