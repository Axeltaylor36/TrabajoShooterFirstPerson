using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WeaponLogic : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject bullet;

    public float shootForce = 1500f;
    public float shootRate = 0.5f;

    private float shootRateTime = 0;

    private AudioSource audioSource;

    public AudioClip shotSound;

    [SerializeField] private float destruccionBala = 3;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {


        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > shootRateTime && GameManager.Instance.gunAmmo > 0)
            {
                audioSource.PlayOneShot(shotSound);

                GameManager.Instance.gunAmmo --;


                GameObject newBullet;

                newBullet =Instantiate(bullet,spawnPoint.position,spawnPoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);

                shootRateTime = Time.time + shootRate;

                Destroy(newBullet, destruccionBala);
            }
        }


    }
}
